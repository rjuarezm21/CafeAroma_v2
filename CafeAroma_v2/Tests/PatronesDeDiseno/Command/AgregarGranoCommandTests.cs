using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeAroma_v2.Clases.Command;
using CafeAroma_v2.Clases.Entidades;
using CafeAroma_v2.Clases.Singleton;
using System;

namespace CafeAroma_v2.Tests.PatronesDeDiseno.Command
{
    [TestClass]
    public class AgregarGranoCommandTests
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
        public void Constructor_ConGranoValido_DeberiaInicializarComando()
        {
            // Arrange
            var grano = new Grano("Arábica", 100, "Colombia");

            // Act
            var comando = new AgregarGranoCommand(grano);

            // Assert
            Assert.IsNotNull(comando);
            Assert.IsInstanceOfType(comando, typeof(ICommand));
        }

        [TestMethod]
        public void Ejecutar_ConGranoValido_DeberiaAgregarGranoAlInventario()
        {
            // Arrange
            var grano = new Grano("Arábica", 100, "Colombia");
            var comando = new AgregarGranoCommand(grano);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(100, gestor.ObtenerStockGrano("Arábica"));
        }

        [TestMethod]
        public void Ejecutar_ConGranoExistenteEnInventario_DeberiaAcumularCantidad()
        {
            // Arrange
            var granoExistente = new Grano("Robusta", 50, "Vietnam");
            var granoNuevo = new Grano("Robusta", 75, "Brasil");
            
            gestor.AgregarGrano(granoExistente); // Stock inicial
            var comando = new AgregarGranoCommand(granoNuevo);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(125, gestor.ObtenerStockGrano("Robusta"));
        }

        [TestMethod]
        public void Deshacer_DespuesDeEjecutar_DeberiaQuitarGranoDelInventario()
        {
            // Arrange
            var grano = new Grano("Liberica", 80, "Filipinas");
            var comando = new AgregarGranoCommand(grano);
            comando.Ejecutar();

            // Verificar que se agregó
            Assert.AreEqual(80, gestor.ObtenerStockGrano("Liberica"));

            // Act
            comando.Deshacer();

            // Assert
            Assert.AreEqual(0, gestor.ObtenerStockGrano("Liberica"));
        }

        [TestMethod]
        public void Deshacer_ConStockMayorAlComandoOriginal_DeberiaQuitarSoloLaCantidadCorrecta()
        {
            // Arrange
            var granoBase = new Grano("Excelsa", 60, "Filipinas");
            var granoComando = new Grano("Excelsa", 40, "Filipinas");
            
            gestor.AgregarGrano(granoBase); // Stock base: 60
            var comando = new AgregarGranoCommand(granoComando);
            comando.Ejecutar(); // Stock total: 100

            // Act
            comando.Deshacer(); // Debería quitar solo 40

            // Assert
            Assert.AreEqual(60, gestor.ObtenerStockGrano("Excelsa"));
        }

        [TestMethod]
        public void Deshacer_ConCantidadExactaEnInventario_DeberiaEliminarGranoCompletamente()
        {
            // Arrange
            var grano = new Grano("Bourbon", 90, "Jamaica");
            var comando = new AgregarGranoCommand(grano);
            comando.Ejecutar();

            // Act
            comando.Deshacer();

            // Assert
            Assert.AreEqual(0, gestor.ObtenerStockGrano("Bourbon"));
            var todosLosGranos = gestor.ObtenerTodosLosGranos();
            Assert.IsFalse(todosLosGranos.ContainsKey("Bourbon"));
        }

        [TestMethod]
        public void Deshacer_ConCantidadMenorEnInventario_DeberiaEliminarTodoElStock()
        {
            // Arrange
            var grano = new Grano("Typica", 120, "Etiopía");
            var comando = new AgregarGranoCommand(grano);
            comando.Ejecutar();
            
            // Simular que se usó parte del stock
            gestor.QuitarGrano("Typica", 70); // Queda 50 en stock

            // Act
            comando.Deshacer(); // Intenta quitar 120, pero solo hay 50

            // Assert
            Assert.AreEqual(0, gestor.ObtenerStockGrano("Typica"));
        }

        [TestMethod]
        public void Ejecutar_ConGranoCantidadCero_DeberiaAgregarGranoConCantidadCero()
        {
            // Arrange
            var grano = new Grano("Geisha", 0, "Panamá");
            var comando = new AgregarGranoCommand(grano);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(0, gestor.ObtenerStockGrano("Geisha"));
            var todosLosGranos = gestor.ObtenerTodosLosGranos();
            Assert.IsTrue(todosLosGranos.ContainsKey("Geisha"));
        }

        [TestMethod]
        public void Ejecutar_ConGranoCantidadNegativa_DeberiaPermitirCantidadNegativa()
        {
            // Arrange
            var grano = new Grano("Catimor", -25, "Brasil");
            var comando = new AgregarGranoCommand(grano);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(-25, gestor.ObtenerStockGrano("Catimor"));
        }

        [TestMethod]
        public void Constructor_ConGranoNulo_DeberiaFuncionar()
        {
            // En la implementación actual, el constructor acepta null
            // Esta prueba verifica que no lance excepción
            
            // Act
            var comando = new AgregarGranoCommand(null);

            // Assert
            Assert.IsNotNull(comando);
        }

        [TestMethod]
        public void EjecutarYDeshacer_VariasVeces_DeberiaMantenersConsistente()
        {
            // Arrange
            var grano = new Grano("Maragogipe", 150, "Nicaragua");
            var comando = new AgregarGranoCommand(grano);

            // Act & Assert - Ciclo de ejecución y deshecho
            comando.Ejecutar();
            Assert.AreEqual(150, gestor.ObtenerStockGrano("Maragogipe"));

            comando.Deshacer();
            Assert.AreEqual(0, gestor.ObtenerStockGrano("Maragogipe"));

            comando.Ejecutar();
            Assert.AreEqual(150, gestor.ObtenerStockGrano("Maragogipe"));

            comando.Deshacer();
            Assert.AreEqual(0, gestor.ObtenerStockGrano("Maragogipe"));
        }

        [TestMethod]
        public void Ejecutar_ConDiferentesGranos_DeberiaAgregarPorSeparado()
        {
            // Arrange
            var grano1 = new Grano("Pacamara", 80, "El Salvador");
            var grano2 = new Grano("Catuai", 65, "Costa Rica");
            var comando1 = new AgregarGranoCommand(grano1);
            var comando2 = new AgregarGranoCommand(grano2);

            // Act
            comando1.Ejecutar();
            comando2.Ejecutar();

            // Assert
            Assert.AreEqual(80, gestor.ObtenerStockGrano("Pacamara"));
            Assert.AreEqual(65, gestor.ObtenerStockGrano("Catuai"));
            var todosLosGranos = gestor.ObtenerTodosLosGranos();
            Assert.AreEqual(2, todosLosGranos.Count);
        }

        [TestMethod]
        public void Ejecutar_ConGranoTipoVacio_DeberiaPermitirTipoVacio()
        {
            // Arrange
            var grano = new Grano("", 45, "Desconocido");
            var comando = new AgregarGranoCommand(grano);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(45, gestor.ObtenerStockGrano(""));
        }

        [TestMethod]
        public void Ejecutar_ConGranoOrigenNulo_DeberiaPermitirOrigenNulo()
        {
            // Arrange
            var grano = new Grano("Mundo Novo", 95, null);
            var comando = new AgregarGranoCommand(grano);

            // Act
            comando.Ejecutar();

            // Assert
            Assert.AreEqual(95, gestor.ObtenerStockGrano("Mundo Novo"));
        }
    }
}
