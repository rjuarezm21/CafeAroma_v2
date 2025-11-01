using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeAroma_v2.Clases.Entidades;
using System;

namespace CafeAroma_v2.Tests.Entidades
{
    [TestClass]
    public class GranoTests
    {
        [TestMethod]
        public void Constructor_Parametrizado_DeberiaInicializarPropiedadesCorrectamente()
        {
            // Arrange
            string tipoEsperado = "Arábica";
            int cantidadEsperada = 100;
            string origenEsperado = "Colombia";

            // Act
            var grano = new Grano(tipoEsperado, cantidadEsperada, origenEsperado);

            // Assert
            Assert.AreEqual(tipoEsperado, grano.Tipo);
            Assert.AreEqual(cantidadEsperada, grano.Cantidad);
            Assert.AreEqual(origenEsperado, grano.Origen);
        }

        [TestMethod]
        public void Constructor_SinParametros_DeberiaCrearInstanciaConValoresPorDefecto()
        {
            // Act
            var grano = new Grano();

            // Assert
            Assert.IsNotNull(grano);
            Assert.IsNull(grano.Tipo);
            Assert.AreEqual(0, grano.Cantidad);
            Assert.IsNull(grano.Origen);
        }

        [TestMethod]
        public void Propiedades_DeberianSerModificables()
        {
            // Arrange
            var grano = new Grano();
            string nuevoTipo = "Robusta";
            int nuevaCantidad = 50;
            string nuevoOrigen = "Brasil";

            // Act
            grano.Tipo = nuevoTipo;
            grano.Cantidad = nuevaCantidad;
            grano.Origen = nuevoOrigen;

            // Assert
            Assert.AreEqual(nuevoTipo, grano.Tipo);
            Assert.AreEqual(nuevaCantidad, grano.Cantidad);
            Assert.AreEqual(nuevoOrigen, grano.Origen);
        }

        [TestMethod]
        public void Grano_ConCantidadNegativa_DeberiaPermitirValorNegativo()
        {
            // Arrange & Act
            var grano = new Grano("Arábica", -10, "Colombia");

            // Assert
            Assert.AreEqual(-10, grano.Cantidad);
        }

        [TestMethod]
        public void Grano_ConTipoVacio_DeberiaPermitirCadenaVacia()
        {
            // Arrange & Act
            var grano = new Grano("", 100, "Colombia");

            // Assert
            Assert.AreEqual("", grano.Tipo);
        }

        [TestMethod]
        public void Grano_ConOrigenNulo_DeberiaPermitirValorNulo()
        {
            // Arrange & Act
            var grano = new Grano("Arábica", 100, null);

            // Assert
            Assert.IsNull(grano.Origen);
        }
    }
}
