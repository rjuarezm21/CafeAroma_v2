using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeAroma_v2.Clases.Factory;
using CafeAroma_v2.Clases.Entidades;

namespace CafeAroma_v2.Tests.PatronesDeDiseno.Factory
{
    [TestClass]
    public class FabricaDeGranoTests
    {
        [TestMethod]
        public void Crear_ConTipoArabica_DeberiaRetornarGranoArabicaConOrigenAlta()
        {
            // Arrange
            string tipoEsperado = "Arábica";
            int cantidadEsperada = 100;
            string origenEsperado = "Alta";

            // Act
            var grano = FabricaDeGrano.Crear(tipoEsperado, cantidadEsperada);

            // Assert
            Assert.IsNotNull(grano);
            Assert.AreEqual(tipoEsperado, grano.Tipo);
            Assert.AreEqual(cantidadEsperada, grano.Cantidad);
            Assert.AreEqual(origenEsperado, grano.Origen);
        }

        [TestMethod]
        public void Crear_ConTipoRobusta_DeberiaRetornarGranoRobustaConOrigenEstandar()
        {
            // Arrange
            string tipoEsperado = "Robusta";
            int cantidadEsperada = 50;
            string origenEsperado = "Estándar";

            // Act
            var grano = FabricaDeGrano.Crear(tipoEsperado, cantidadEsperada);

            // Assert
            Assert.IsNotNull(grano);
            Assert.AreEqual(tipoEsperado, grano.Tipo);
            Assert.AreEqual(cantidadEsperada, grano.Cantidad);
            Assert.AreEqual(origenEsperado, grano.Origen);
        }

        [TestMethod]
        public void Crear_ConTipoDesconocido_DeberiaRetornarGranoConOrigenBasica()
        {
            // Arrange
            string tipoDesconocido = "Liberica";
            int cantidadEsperada = 25;
            string origenEsperado = "Básica";

            // Act
            var grano = FabricaDeGrano.Crear(tipoDesconocido, cantidadEsperada);

            // Assert
            Assert.IsNotNull(grano);
            Assert.AreEqual(tipoDesconocido, grano.Tipo);
            Assert.AreEqual(cantidadEsperada, grano.Cantidad);
            Assert.AreEqual(origenEsperado, grano.Origen);
        }

        [TestMethod]
        public void Crear_SinEspecificarCantidad_DeberiaUsarCantidadPorDefectoCero()
        {
            // Arrange
            string tipo = "Arábica";
            int cantidadEsperada = 0;

            // Act
            var grano = FabricaDeGrano.Crear(tipo);

            // Assert
            Assert.IsNotNull(grano);
            Assert.AreEqual(tipo, grano.Tipo);
            Assert.AreEqual(cantidadEsperada, grano.Cantidad);
            Assert.AreEqual("Alta", grano.Origen);
        }

        [TestMethod]
        public void Crear_ConCantidadNegativa_DeberiaPermitirCantidadNegativa()
        {
            // Arrange
            string tipo = "Arábica";
            int cantidadNegativa = -10;

            // Act
            var grano = FabricaDeGrano.Crear(tipo, cantidadNegativa);

            // Assert
            Assert.IsNotNull(grano);
            Assert.AreEqual(cantidadNegativa, grano.Cantidad);
        }

        [TestMethod]
        public void Crear_ConTipoNulo_DeberiaRetornarGranoConTipoNuloYOrigenBasica()
        {
            // Arrange
            string tipoNulo = null;
            int cantidad = 10;

            // Act
            var grano = FabricaDeGrano.Crear(tipoNulo, cantidad);

            // Assert
            Assert.IsNotNull(grano);
            Assert.AreEqual(tipoNulo, grano.Tipo);
            Assert.AreEqual(cantidad, grano.Cantidad);
            Assert.AreEqual("Básica", grano.Origen);
        }

        [TestMethod]
        public void Crear_ConTipoVacio_DeberiaRetornarGranoConTipoVacioYOrigenBasica()
        {
            // Arrange
            string tipoVacio = "";
            int cantidad = 15;

            // Act
            var grano = FabricaDeGrano.Crear(tipoVacio, cantidad);

            // Assert
            Assert.IsNotNull(grano);
            Assert.AreEqual(tipoVacio, grano.Tipo);
            Assert.AreEqual(cantidad, grano.Cantidad);
            Assert.AreEqual("Básica", grano.Origen);
        }

        [TestMethod]
        public void Crear_ConTipoEnMinusculas_DeberiaTratatComoTipoDesconocido()
        {
            // Arrange - Factory es case-sensitive
            string tipoMinusculas = "arabica";
            int cantidad = 20;

            // Act
            var grano = FabricaDeGrano.Crear(tipoMinusculas, cantidad);

            // Assert
            Assert.IsNotNull(grano);
            Assert.AreEqual(tipoMinusculas, grano.Tipo);
            Assert.AreEqual(cantidad, grano.Cantidad);
            Assert.AreEqual("Básica", grano.Origen); // No reconoce "arabica" minúsculas
        }

        [TestMethod]
        public void Crear_ConTipoConEspacios_DeberiaTratatComoTipoDesconocido()
        {
            // Arrange
            string tipoConEspacios = " Arábica ";
            int cantidad = 30;

            // Act
            var grano = FabricaDeGrano.Crear(tipoConEspacios, cantidad);

            // Assert
            Assert.IsNotNull(grano);
            Assert.AreEqual(tipoConEspacios, grano.Tipo);
            Assert.AreEqual(cantidad, grano.Cantidad);
            Assert.AreEqual("Básica", grano.Origen); // No reconoce por los espacios
        }
    }
}
