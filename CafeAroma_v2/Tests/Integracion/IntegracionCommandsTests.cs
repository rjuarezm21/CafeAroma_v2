using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeAroma_v2.Clases.Command;
using CafeAroma_v2.Clases.Entidades;
using CafeAroma_v2.Clases.Singleton;
using CafeAroma_v2.Clases.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CafeAroma_v2.Tests.Integracion
{
    [TestClass]
    public class IntegracionCommandsTests
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
        public void IntegracionCompleta_AgregarGranosYProductos_DeberiaFuncionarCorrectamente()
        {
            // Arrange - Crear granos usando Factory
            var granoArabica = FabricaDeGrano.Crear("Arábica", 200);
            var granoRobusta = FabricaDeGrano.Crear("Robusta", 150);

            // Crear productos
            var producto1 = new Producto("Café Premium Arábica", 1, 50, 25.99m);
            var producto2 = new Producto("Café Robusta Fuerte", 2, 30, 18.50m);

            // Crear comandos
            var comandoGrano1 = new AgregarGranoCommand(granoArabica);
            var comandoGrano2 = new AgregarGranoCommand(granoRobusta);
            var comandoProducto1 = new AgregarProductoCommand(producto1);
            var comandoProducto2 = new AgregarProductoCommand(producto2);

            // Act - Ejecutar comandos
            comandoGrano1.Ejecutar();
            comandoGrano2.Ejecutar();
            comandoProducto1.Ejecutar();
            comandoProducto2.Ejecutar();

            // Assert - Verificar estado final
            Assert.AreEqual(200, gestor.ObtenerStockGrano("Arábica"));
            Assert.AreEqual(150, gestor.ObtenerStockGrano("Robusta"));
            Assert.AreEqual(50, gestor.ObtenerStockProducto("Café Premium Arábica"));
            Assert.AreEqual(30, gestor.ObtenerStockProducto("Café Robusta Fuerte"));

            var todosLosGranos = gestor.ObtenerTodosLosGranos();
            var todosLosProductos = gestor.ObtenerTodosLosProductos();

            Assert.AreEqual(2, todosLosGranos.Count);
            Assert.AreEqual(2, todosLosProductos.Count);
        }

        [TestMethod]
        public void IntegracionComandos_EjecutarYDeshacerEnOrden_DeberiaMantenersConsistencia()
        {
            // Arrange
            var grano = FabricaDeGrano.Crear("Liberica", 100);
            var producto = new Producto("Café Liberica Especial", 3, 20, 35.00m);
            var comandoGrano = new AgregarGranoCommand(grano);
            var comandoProducto = new AgregarProductoCommand(producto);

            // Act - Ejecutar comandos
            comandoGrano.Ejecutar();
            comandoProducto.Ejecutar();

            // Verificar estado intermedio
            Assert.AreEqual(100, gestor.ObtenerStockGrano("Liberica"));
            Assert.AreEqual(20, gestor.ObtenerStockProducto("Café Liberica Especial"));

            // Deshacer en orden inverso
            comandoProducto.Deshacer();
            comandoGrano.Deshacer();

            // Assert - Verificar estado final
            Assert.AreEqual(0, gestor.ObtenerStockGrano("Liberica"));
            Assert.AreEqual(0, gestor.ObtenerStockProducto("Café Liberica Especial"));

            var todosLosGranos = gestor.ObtenerTodosLosGranos();
            var todosLosProductos = gestor.ObtenerTodosLosProductos();

            Assert.AreEqual(0, todosLosGranos.Count);
            Assert.AreEqual(0, todosLosProductos.Count);
        }

        [TestMethod]
        public void IntegracionFactory_CrearDiferentesTiposDeGrano_DeberiaAsignarOrigenesCorrectamente()
        {
            // Arrange & Act
            var granoArabica = FabricaDeGrano.Crear("Arábica", 100);
            var granoRobusta = FabricaDeGrano.Crear("Robusta", 150);
            var granoDesconocido = FabricaDeGrano.Crear("TipoRaro", 50);

            var comandoArabica = new AgregarGranoCommand(granoArabica);
            var comandoRobusta = new AgregarGranoCommand(granoRobusta);
            var comandoDesconocido = new AgregarGranoCommand(granoDesconocido);

            comandoArabica.Ejecutar();
            comandoRobusta.Ejecutar();
            comandoDesconocido.Ejecutar();

            // Assert
            Assert.AreEqual("Alta", granoArabica.Origen);
            Assert.AreEqual("Estándar", granoRobusta.Origen);
            Assert.AreEqual("Básica", granoDesconocido.Origen);

            Assert.AreEqual(100, gestor.ObtenerStockGrano("Arábica"));
            Assert.AreEqual(150, gestor.ObtenerStockGrano("Robusta"));
            Assert.AreEqual(50, gestor.ObtenerStockGrano("TipoRaro"));
        }

        [TestMethod]
        public void EscenarioRealista_GestionCompleta_DeberiaFuncionarComoSistemaCompleto()
        {
            // Escenario: Una cafetería recibe lotes de granos y produce diferentes productos

            // 1. Recepción de granos (usando Factory)
            var loteArabica1 = FabricaDeGrano.Crear("Arábica", 500);
            var loteArabica2 = FabricaDeGrano.Crear("Arábica", 300);
            var loteRobusta = FabricaDeGrano.Crear("Robusta", 400);

            var recepcionArabica1 = new AgregarGranoCommand(loteArabica1);
            var recepcionArabica2 = new AgregarGranoCommand(loteArabica2);
            var recepcionRobusta = new AgregarGranoCommand(loteRobusta);

            // 2. Ejecutar recepción
            recepcionArabica1.Ejecutar();
            recepcionArabica2.Ejecutar();
            recepcionRobusta.Ejecutar();

            // 3. Verificar inventario de granos
            Assert.AreEqual(800, gestor.ObtenerStockGrano("Arábica")); // 500 + 300
            Assert.AreEqual(400, gestor.ObtenerStockGrano("Robusta"));

            // 4. Producir productos terminados
            var producto1 = new Producto("Blend Premium", 1, 100, 22.99m);
            var producto2 = new Producto("Espresso Intenso", 2, 75, 19.99m);
            var producto3 = new Producto("Café Suave", 1, 50, 16.99m);

            var produccion1 = new AgregarProductoCommand(producto1);
            var produccion2 = new AgregarProductoCommand(producto2);
            var produccion3 = new AgregarProductoCommand(producto3);

            produccion1.Ejecutar();
            produccion2.Ejecutar();
            produccion3.Ejecutar();

            // 5. Verificar inventario de productos
            Assert.AreEqual(100, gestor.ObtenerStockProducto("Blend Premium"));
            Assert.AreEqual(75, gestor.ObtenerStockProducto("Espresso Intenso"));
            Assert.AreEqual(50, gestor.ObtenerStockProducto("Café Suave"));

            // 6. Simular venta (reducir stock)
            gestor.QuitarProducto("Blend Premium", 25);
            gestor.QuitarProducto("Espresso Intenso", 30);

            // 7. Verificar inventario después de ventas
            Assert.AreEqual(75, gestor.ObtenerStockProducto("Blend Premium"));
            Assert.AreEqual(45, gestor.ObtenerStockProducto("Espresso Intenso"));
            Assert.AreEqual(50, gestor.ObtenerStockProducto("Café Suave"));

            // 8. Verificar totales
            var totalGranos = gestor.ObtenerTodosLosGranos();
            var totalProductos = gestor.ObtenerTodosLosProductos();

            Assert.AreEqual(2, totalGranos.Count);
            Assert.AreEqual(3, totalProductos.Count);

            int stockTotalGranos = totalGranos.Values.Sum();
            int stockTotalProductos = totalProductos.Values.Sum();

            Assert.AreEqual(1200, stockTotalGranos); // 800 + 400
            Assert.AreEqual(170, stockTotalProductos); // 75 + 45 + 50
        }

        [TestMethod]
        public void EscenarioCorrecionErrores_DeshacerOperacionesIncorrectas()
        {
            // Escenario: Se agregaron productos incorrectamente y hay que corregir

            // 1. Agregar productos (algunos incorrectos)
            var producto1 = new Producto("Producto Correcto", 1, 50, 15.99m);
            var producto2 = new Producto("Producto Incorrecto", 2, 30, 25.99m);
            var producto3 = new Producto("Otro Correcto", 3, 20, 18.50m);

            var comando1 = new AgregarProductoCommand(producto1);
            var comando2 = new AgregarProductoCommand(producto2);
            var comando3 = new AgregarProductoCommand(producto3);

            comando1.Ejecutar();
            comando2.Ejecutar();
            comando3.Ejecutar();

            // 2. Verificar estado inicial
            Assert.AreEqual(3, gestor.ObtenerTodosLosProductos().Count);

            // 3. Corregir errores deshaciendo producto incorrecto
            comando2.Deshacer();

            // 4. Verificar corrección
            Assert.AreEqual(2, gestor.ObtenerTodosLosProductos().Count);
            Assert.AreEqual(50, gestor.ObtenerStockProducto("Producto Correcto"));
            Assert.AreEqual(0, gestor.ObtenerStockProducto("Producto Incorrecto"));
            Assert.AreEqual(20, gestor.ObtenerStockProducto("Otro Correcto"));

            // 5. Agregar producto corregido
            var productoCorregido = new Producto("Producto Corregido", 2, 35, 20.99m);
            var comandoCorregido = new AgregarProductoCommand(productoCorregido);
            comandoCorregido.Ejecutar();

            // 6. Verificar estado final
            Assert.AreEqual(3, gestor.ObtenerTodosLosProductos().Count);
            Assert.AreEqual(35, gestor.ObtenerStockProducto("Producto Corregido"));
        }

        [TestMethod]
        public void StresTest_MultiplesOperaciones_DeberiaMantenersConsistencia()
        {
            // Realizar múltiples operaciones y verificar consistencia

            var comandos = new List<ICommand>();

            // Crear múltiples granos
            for (int i = 1; i <= 10; i++)
            {
                var grano = FabricaDeGrano.Crear($"Grano_{i}", i * 10);
                comandos.Add(new AgregarGranoCommand(grano));
            }

            // Crear múltiples productos
            for (int i = 1; i <= 15; i++)
            {
                var producto = new Producto($"Producto_{i}", i, i * 5, i * 2.5m);
                comandos.Add(new AgregarProductoCommand(producto));
            }

            // Ejecutar todos los comandos
            foreach (var comando in comandos)
            {
                comando.Ejecutar();
            }

            // Verificar que todo se agregó correctamente
            var totalGranos = gestor.ObtenerTodosLosGranos();
            var totalProductos = gestor.ObtenerTodosLosProductos();

            Assert.AreEqual(10, totalGranos.Count);
            Assert.AreEqual(15, totalProductos.Count);

            // Deshacer algunos comandos aleatoriamente
            for (int i = 0; i < comandos.Count; i += 3)
            {
                comandos[i].Deshacer();
            }

            // Verificar consistencia después del deshecho parcial
            var granosFinales = gestor.ObtenerTodosLosGranos();
            var productosFinales = gestor.ObtenerTodosLosProductos();

            // Debe haber menos elementos que al inicio
            Assert.IsTrue(granosFinales.Count + productosFinales.Count < 25);

            // Todos los stocks deben ser no negativos
            foreach (var stock in granosFinales.Values)
            {
                Assert.IsTrue(stock >= 0);
            }

            foreach (var stock in productosFinales.Values)
            {
                Assert.IsTrue(stock >= 0);
            }
        }

        [TestMethod]
        public void IntegracionCommandsConSingleton_VariasOperaciones_DeberiaMantenserConsistenciaGlobal()
        {
            // Escenario: Verificar que el patrón Singleton mantiene la consistencia
            // entre múltiples comandos y accesos concurrentes al gestor

            // 1. Obtener referencias múltiples al singleton
            var gestor1 = GestorDelInventario.Instancia;
            var gestor2 = GestorDelInventario.Instancia;
            var gestor3 = GestorDelInventario.Instancia;

            // Verificar que todas son la misma instancia
            Assert.AreSame(gestor1, gestor2);
            Assert.AreSame(gestor2, gestor3);
            Assert.AreSame(gestor1, gestor);

            // 2. Ejecutar comandos usando diferentes referencias
            var grano1 = FabricaDeGrano.Crear("Test1", 100);
            var grano2 = FabricaDeGrano.Crear("Test2", 200);
            var producto1 = new Producto("ProductoTest1", 1, 50, 15.99m);

            var comandoGrano1 = new AgregarGranoCommand(grano1);
            var comandoGrano2 = new AgregarGranoCommand(grano2);
            var comandoProducto1 = new AgregarProductoCommand(producto1);

            comandoGrano1.Ejecutar();
            comandoGrano2.Ejecutar();
            comandoProducto1.Ejecutar();

            // 3. Verificar consistencia desde todas las referencias
            Assert.AreEqual(100, gestor1.ObtenerStockGrano("Test1"));
            Assert.AreEqual(200, gestor2.ObtenerStockGrano("Test2"));
            Assert.AreEqual(50, gestor3.ObtenerStockProducto("ProductoTest1"));
            Assert.AreEqual(50, gestor.ObtenerStockProducto("ProductoTest1"));

            // 4. Modificar desde una referencia y verificar desde otra
            gestor1.QuitarGrano("Test1", 30);
            Assert.AreEqual(70, gestor2.ObtenerStockGrano("Test1"));
            Assert.AreEqual(70, gestor3.ObtenerStockGrano("Test1"));

            // 5. Deshacer comandos y verificar consistencia
            comandoProducto1.Deshacer();
            Assert.AreEqual(0, gestor1.ObtenerStockProducto("ProductoTest1"));
            Assert.AreEqual(0, gestor2.ObtenerStockProducto("ProductoTest1"));
        }
    }
}
