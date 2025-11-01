using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeAroma_v2.Clases.Singleton;
using CafeAroma_v2.Clases.Entidades;
using System.Linq;

namespace CafeAroma_v2.Tests.PatronesDeDiseno.Singleton
{
    [TestClass]
    public class GestorDelInventarioTests
    {
        private GestorDelInventario gestor;

        [TestInitialize]
        public void Setup()
        {
            gestor = GestorDelInventario.Instancia;
            gestor.LimpiarInventario(); // Limpiar estado entre pruebas
        }

        [TestCleanup]
        public void Cleanup()
        {
            gestor.LimpiarInventario();
        }

        #region Pruebas del Patrón Singleton

        [TestMethod]
        public void Instancia_DeberiaRetornarSiempreLaMismaInstancia()
        {
            // Act
            var instancia1 = GestorDelInventario.Instancia;
            var instancia2 = GestorDelInventario.Instancia;

            // Assert
            Assert.AreSame(instancia1, instancia2);
            Assert.IsNotNull(instancia1);
        }

        [TestMethod]
        public void Instancia_DeberiaSerThreadSafe()
        {
            // Arrange
            GestorDelInventario instancia1 = null;
            GestorDelInventario instancia2 = null;
            var task1 = System.Threading.Tasks.Task.Run(() => instancia1 = GestorDelInventario.Instancia);
            var task2 = System.Threading.Tasks.Task.Run(() => instancia2 = GestorDelInventario.Instancia);

            // Act
            System.Threading.Tasks.Task.WaitAll(task1, task2);

            // Assert
            Assert.AreSame(instancia1, instancia2);
        }

        #endregion

        #region Pruebas de Gestión de Granos

        [TestMethod]
        public void AgregarGrano_ConGranoNuevo_DeberiaAgregarAlInventario()
        {
            // Arrange
            var grano = new Grano("Arábica", 100, "Colombia");

            // Act
            gestor.AgregarGrano(grano);

            // Assert
            Assert.AreEqual(100, gestor.ObtenerStockGrano("Arábica"));
        }

        [TestMethod]
        public void AgregarGrano_ConGranoExistente_DeberiaAcumularCantidad()
        {
            // Arrange
            var grano1 = new Grano("Arábica", 100, "Colombia");
            var grano2 = new Grano("Arábica", 50, "Brasil");

            // Act
            gestor.AgregarGrano(grano1);
            gestor.AgregarGrano(grano2);

            // Assert
            Assert.AreEqual(150, gestor.ObtenerStockGrano("Arábica"));
        }

        [TestMethod]
        public void AgregarGrano_CaseSensitive_DeberiaDistinguirMayusculasMinusculas()
        {
            // Arrange
            var grano1 = new Grano("Arábica", 100, "Colombia");
            var grano2 = new Grano("arábica", 50, "Brasil"); // Minúsculas

            // Act
            gestor.AgregarGrano(grano1);
            gestor.AgregarGrano(grano2);

            // Assert - Debería tratarlos como el mismo tipo (case insensitive)
            Assert.AreEqual(150, gestor.ObtenerStockGrano("Arábica"));
            Assert.AreEqual(150, gestor.ObtenerStockGrano("arábica"));
        }

        [TestMethod]
        public void QuitarGrano_ConStockSuficiente_DeberiaReducirCantidad()
        {
            // Arrange
            var grano = new Grano("Robusta", 100, "Vietnam");
            gestor.AgregarGrano(grano);

            // Act
            gestor.QuitarGrano("Robusta", 30);

            // Assert
            Assert.AreEqual(70, gestor.ObtenerStockGrano("Robusta"));
        }

        [TestMethod]
        public void QuitarGrano_ConCantidadIgualAlStock_DeberiaEliminarDelInventario()
        {
            // Arrange
            var grano = new Grano("Robusta", 100, "Vietnam");
            gestor.AgregarGrano(grano);

            // Act
            gestor.QuitarGrano("Robusta", 100);

            // Assert
            Assert.AreEqual(0, gestor.ObtenerStockGrano("Robusta"));
            var todosLosGranos = gestor.ObtenerTodosLosGranos();
            Assert.IsFalse(todosLosGranos.ContainsKey("Robusta"));
        }

        [TestMethod]
        public void QuitarGrano_ConCantidadMayorAlStock_DeberiaEliminarDelInventario()
        {
            // Arrange
            var grano = new Grano("Robusta", 50, "Vietnam");
            gestor.AgregarGrano(grano);

            // Act
            gestor.QuitarGrano("Robusta", 100);

            // Assert
            Assert.AreEqual(0, gestor.ObtenerStockGrano("Robusta"));
            var todosLosGranos = gestor.ObtenerTodosLosGranos();
            Assert.IsFalse(todosLosGranos.ContainsKey("Robusta"));
        }

        [TestMethod]
        public void QuitarGrano_ConTipoInexistente_NoDeberiaAfectarInventario()
        {
            // Arrange
            var grano = new Grano("Arábica", 100, "Colombia");
            gestor.AgregarGrano(grano);

            // Act
            gestor.QuitarGrano("Liberica", 50);

            // Assert
            Assert.AreEqual(100, gestor.ObtenerStockGrano("Arábica"));
            Assert.AreEqual(0, gestor.ObtenerStockGrano("Liberica"));
        }

        [TestMethod]
        public void ObtenerStockGrano_ConTipoExistente_DeberiaRetornarCantidadCorrecta()
        {
            // Arrange
            var grano = new Grano("Arábica", 75, "Colombia");
            gestor.AgregarGrano(grano);

            // Act
            int stock = gestor.ObtenerStockGrano("Arábica");

            // Assert
            Assert.AreEqual(75, stock);
        }

        [TestMethod]
        public void ObtenerStockGrano_ConTipoInexistente_DeberiaRetornarCero()
        {
            // Act
            int stock = gestor.ObtenerStockGrano("TipoInexistente");

            // Assert
            Assert.AreEqual(0, stock);
        }

        [TestMethod]
        public void ObtenerTodosLosGranos_ConVariosGranos_DeberiaRetornarTodos()
        {
            // Arrange
            gestor.AgregarGrano(new Grano("Arábica", 100, "Colombia"));
            gestor.AgregarGrano(new Grano("Robusta", 150, "Vietnam"));
            gestor.AgregarGrano(new Grano("Liberica", 50, "Filipinas"));

            // Act
            var todosLosGranos = gestor.ObtenerTodosLosGranos();

            // Assert
            Assert.AreEqual(3, todosLosGranos.Count);
            Assert.AreEqual(100, todosLosGranos["Arábica"]);
            Assert.AreEqual(150, todosLosGranos["Robusta"]);
            Assert.AreEqual(50, todosLosGranos["Liberica"]);
        }

        [TestMethod]
        public void ObtenerTodosLosGranos_InventarioVacio_DeberiaRetornarDiccionarioVacio()
        {
            // Act
            var todosLosGranos = gestor.ObtenerTodosLosGranos();

            // Assert
            Assert.AreEqual(0, todosLosGranos.Count);
        }

        #endregion

        #region Pruebas de Gestión de Productos

        [TestMethod]
        public void AgregarProducto_ConProductoNuevo_DeberiaAgregarAlInventario()
        {
            // Arrange
            var producto = new Producto("Café Premium", 1, 25, 15.99m);

            // Act
            gestor.AgregarProducto(producto);

            // Assert
            Assert.AreEqual(25, gestor.ObtenerStockProducto("Café Premium"));
        }

        [TestMethod]
        public void AgregarProducto_ConProductoExistente_DeberiaAcumularCantidad()
        {
            // Arrange
            var producto1 = new Producto("Café Premium", 1, 25, 15.99m);
            var producto2 = new Producto("Café Premium", 1, 15, 15.99m);

            // Act
            gestor.AgregarProducto(producto1);
            gestor.AgregarProducto(producto2);

            // Assert
            Assert.AreEqual(40, gestor.ObtenerStockProducto("Café Premium"));
        }

        [TestMethod]
        public void QuitarProducto_ConStockSuficiente_DeberiaReducirCantidad()
        {
            // Arrange
            var producto = new Producto("Café Deluxe", 2, 50, 22.50m);
            gestor.AgregarProducto(producto);

            // Act
            gestor.QuitarProducto("Café Deluxe", 20);

            // Assert
            Assert.AreEqual(30, gestor.ObtenerStockProducto("Café Deluxe"));
        }

        [TestMethod]
        public void QuitarProducto_ConCantidadIgualAlStock_DeberiaEliminarDelInventario()
        {
            // Arrange
            var producto = new Producto("Café Especial", 3, 15, 18.75m);
            gestor.AgregarProducto(producto);

            // Act
            gestor.QuitarProducto("Café Especial", 15);

            // Assert
            Assert.AreEqual(0, gestor.ObtenerStockProducto("Café Especial"));
            var todosLosProductos = gestor.ObtenerTodosLosProductos();
            Assert.IsFalse(todosLosProductos.ContainsKey("Café Especial"));
        }

        [TestMethod]
        public void ObtenerTodosLosProductos_ConVariosProductos_DeberiaRetornarTodos()
        {
            // Arrange
            gestor.AgregarProducto(new Producto("Café Premium", 1, 25, 15.99m));
            gestor.AgregarProducto(new Producto("Café Deluxe", 2, 30, 22.50m));
            gestor.AgregarProducto(new Producto("Café Especial", 3, 15, 18.75m));

            // Act
            var todosLosProductos = gestor.ObtenerTodosLosProductos();

            // Assert
            Assert.AreEqual(3, todosLosProductos.Count);
            Assert.AreEqual(25, todosLosProductos["Café Premium"]);
            Assert.AreEqual(30, todosLosProductos["Café Deluxe"]);
            Assert.AreEqual(15, todosLosProductos["Café Especial"]);
        }

        #endregion

        #region Pruebas de Limpieza de Inventario

        [TestMethod]
        public void LimpiarInventario_ConInventarioCompleto_DeberiaEliminarTodo()
        {
            // Arrange
            gestor.AgregarGrano(new Grano("Arábica", 100, "Colombia"));
            gestor.AgregarGrano(new Grano("Robusta", 150, "Vietnam"));
            gestor.AgregarProducto(new Producto("Café Premium", 1, 25, 15.99m));
            gestor.AgregarProducto(new Producto("Café Deluxe", 2, 30, 22.50m));

            // Act
            gestor.LimpiarInventario();

            // Assert
            Assert.AreEqual(0, gestor.ObtenerTodosLosGranos().Count);
            Assert.AreEqual(0, gestor.ObtenerTodosLosProductos().Count);
            Assert.AreEqual(0, gestor.ObtenerStockGrano("Arábica"));
            Assert.AreEqual(0, gestor.ObtenerStockProducto("Café Premium"));
        }

        #endregion
    }
}
