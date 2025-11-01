using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeAroma_v2.Clases.Command;
using CafeAroma_v2.Clases.Entidades;
using CafeAroma_v2.Clases.Singleton;
using System;

namespace CafeAroma_v2.Tests.PatronesDeDiseno.Command
{
    [TestClass]
    public class AgregarProductoCommandTests
    {
        private GestorDelInventario gestor;

        [TestInitialize]
        public void Setup()
        {
            gestor = GestorDelInventario.Instancia;
            gestor.LimpiarInventario();
        }

        [TestCleanup]
        public void Cleanup()
        {
            gestor.LimpiarInventario();
        }

        [TestMethod]
        public void Constructor_ConProductoValido_DeberiaInicializarComando()
        {
            // Arrange
            var producto = new Producto("Café Premium", 1, 25, 15.99m);

            // Act
            var comando = new AgregarProductoCommand(producto);

            // Assert
            Assert.IsNotNull(comando);
            Assert.IsInstanceOfType(comando, typeof(ICommand));
        }

        [TestMethod]
        public void Ejecutar_ConProductoValido_DeberiaAgregarProductoAlInventario()
        {
            // Arrange
            var producto = new Producto("Café Premium", 1, 25, 15.99m);
            var comando = new AgregarProductoCommand(producto);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(25, gestor.ObtenerStockProducto("Café Premium"));
        }

        [TestMethod]
        public void Ejecutar_ConProductoExistenteEnInventario_DeberiaAcumularCantidad()
        {
            // Arrange
            var productoExistente = new Producto("Café Deluxe", 2, 20, 22.50m);
            var productoNuevo = new Producto("Café Deluxe", 2, 15, 22.50m);
            
            gestor.AgregarProducto(productoExistente); // Stock inicial
            var comando = new AgregarProductoCommand(productoNuevo);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(35, gestor.ObtenerStockProducto("Café Deluxe"));
        }

        [TestMethod]
        public void Deshacer_DespuesDeEjecutar_DeberiaQuitarProductoDelInventario()
        {
            // Arrange
            var producto = new Producto("Café Especial", 3, 18, 18.75m);
            var comando = new AgregarProductoCommand(producto);
            comando.Ejecutar();

            // Verificar que se agregó
            Assert.AreEqual(18, gestor.ObtenerStockProducto("Café Especial"));

            // Act
            comando.Deshacer();

            // Assert
            Assert.AreEqual(0, gestor.ObtenerStockProducto("Café Especial"));
        }

        [TestMethod]
        public void Deshacer_ConStockMayorAlComandoOriginal_DeberiaQuitarSoloLaCantidadCorrecta()
        {
            // Arrange
            var productoBase = new Producto("Café Gourmet", 4, 30, 25.00m);
            var productoComando = new Producto("Café Gourmet", 4, 20, 25.00m);
            
            gestor.AgregarProducto(productoBase); // Stock base: 30
            var comando = new AgregarProductoCommand(productoComando);
            comando.Ejecutar(); // Stock total: 50

            // Act
            comando.Deshacer(); // Debería quitar solo 20

            // Assert
            Assert.AreEqual(30, gestor.ObtenerStockProducto("Café Gourmet"));
        }

        [TestMethod]
        public void Deshacer_ConCantidadExactaEnInventario_DeberiaEliminarProductoCompletamente()
        {
            // Arrange
            var producto = new Producto("Café Único", 5, 12, 30.00m);
            var comando = new AgregarProductoCommand(producto);
            comando.Ejecutar();

            // Act
            comando.Deshacer();

            // Assert
            Assert.AreEqual(0, gestor.ObtenerStockProducto("Café Único"));
            var todosLosProductos = gestor.ObtenerTodosLosProductos();
            Assert.IsFalse(todosLosProductos.ContainsKey("Café Único"));
        }

        [TestMethod]
        public void Deshacer_ConCantidadMenorEnInventario_DeberiaEliminarTodoElStock()
        {
            // Arrange
            var producto = new Producto("Café Limitado", 6, 40, 35.00m);
            var comando = new AgregarProductoCommand(producto);
            comando.Ejecutar();
            
            // Simular que se vendió parte del stock
            gestor.QuitarProducto("Café Limitado", 25); // Queda 15 en stock

            // Act
            comando.Deshacer(); // Intenta quitar 40, pero solo hay 15

            // Assert
            Assert.AreEqual(0, gestor.ObtenerStockProducto("Café Limitado"));
        }

        [TestMethod]
        public void Ejecutar_ConProductoCantidadCero_DeberiaAgregarProductoConCantidadCero()
        {
            // Arrange
            var producto = new Producto("Café Muestra", 7, 0, 5.00m);
            var comando = new AgregarProductoCommand(producto);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(0, gestor.ObtenerStockProducto("Café Muestra"));
            var todosLosProductos = gestor.ObtenerTodosLosProductos();
            Assert.IsTrue(todosLosProductos.ContainsKey("Café Muestra"));
        }

        [TestMethod]
        public void Ejecutar_ConProductoPrecioNegativo_DeberiaPermitirPrecioNegativo()
        {
            // Arrange
            var producto = new Producto("Café Descuento", 8, 10, -5.00m);
            var comando = new AgregarProductoCommand(producto);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(10, gestor.ObtenerStockProducto("Café Descuento"));
        }

        [TestMethod]
        public void Constructor_ConProductoNulo_DeberiaFuncionar()
        {
            // En la implementación actual, el constructor acepta null
            // Esta prueba verifica que no lance excepción
            
            // Act
            var comando = new AgregarProductoCommand(null);

            // Assert
            Assert.IsNotNull(comando);
        }

        [TestMethod]
        public void EjecutarYDeshacer_VariasVeces_DeberiaMantenersConsistente()
        {
            // Arrange
            var producto = new Producto("Café Ciclo", 9, 50, 20.00m);
            var comando = new AgregarProductoCommand(producto);

            // Act & Assert - Ciclo de ejecución y deshecho
            comando.Ejecutar();
            Assert.AreEqual(50, gestor.ObtenerStockProducto("Café Ciclo"));

            comando.Deshacer();
            Assert.AreEqual(0, gestor.ObtenerStockProducto("Café Ciclo"));

            comando.Ejecutar();
            Assert.AreEqual(50, gestor.ObtenerStockProducto("Café Ciclo"));

            comando.Deshacer();
            Assert.AreEqual(0, gestor.ObtenerStockProducto("Café Ciclo"));
        }

        [TestMethod]
        public void Ejecutar_ConDiferentesProductos_DeberiaAgregarPorSeparado()
        {
            // Arrange
            var producto1 = new Producto("Café Mañana", 1, 30, 12.99m);
            var producto2 = new Producto("Café Tarde", 2, 25, 15.99m);
            var comando1 = new AgregarProductoCommand(producto1);
            var comando2 = new AgregarProductoCommand(producto2);

            // Act
            comando1.Ejecutar();
            comando2.Ejecutar();

            // Assert
            Assert.AreEqual(30, gestor.ObtenerStockProducto("Café Mañana"));
            Assert.AreEqual(25, gestor.ObtenerStockProducto("Café Tarde"));
            var todosLosProductos = gestor.ObtenerTodosLosProductos();
            Assert.AreEqual(2, todosLosProductos.Count);
        }

        [TestMethod]
        public void Ejecutar_ConProductoNombreVacio_DeberiaPermitirNombreVacio()
        {
            // Arrange
            var producto = new Producto("", 10, 15, 10.00m);
            var comando = new AgregarProductoCommand(producto);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(15, gestor.ObtenerStockProducto(""));
        }

        [TestMethod]
        public void Ejecutar_ConProductoIdGranoNegativo_DeberiaPermitirIdNegativo()
        {
            // Arrange
            var producto = new Producto("Café Test", -1, 20, 15.00m);
            var comando = new AgregarProductoCommand(producto);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(20, gestor.ObtenerStockProducto("Café Test"));
        }
    }
}
