using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeAroma_v2.Clases.Entidades;
using System;

namespace CafeAroma_v2.Tests.Entidades
{
    [TestClass]
    public class LoteTests
    {
        [TestMethod]
        public void Constructor_ConParametrosValidos_DeberiaInicializarPropiedadesCorrectamente()
        {
            // Arrange
            int idLoteEsperado = 1;
            string numeroLoteEsperado = "LT-2024-001";
            string estadoEsperado = "Activo";
            DateTime fechaVencimientoEsperada = new DateTime(2024, 12, 31);

            // Act
            var lote = new Lote(idLoteEsperado, numeroLoteEsperado, estadoEsperado, fechaVencimientoEsperada);

            // Assert
            Assert.AreEqual(idLoteEsperado, lote.IdLote);
            Assert.AreEqual(numeroLoteEsperado, lote.NumeroLote);
            Assert.AreEqual(estadoEsperado, lote.Estado);
            Assert.AreEqual(fechaVencimientoEsperada, lote.FechaVencimiento);
        }

        [TestMethod]
        public void Constructor_ConFechaEnElPasado_DeberiaPermitirFechaPasada()
        {
            // Arrange
            DateTime fechaPasada = new DateTime(2020, 1, 1);

            // Act
            var lote = new Lote(1, "LT-2020-001", "Vencido", fechaPasada);

            // Assert
            Assert.AreEqual(fechaPasada, lote.FechaVencimiento);
        }

        [TestMethod]
        public void Constructor_ConIdNegativo_DeberiaPermitirIdNegativo()
        {
            // Arrange & Act
            var lote = new Lote(-1, "LT-TEST", "Test", DateTime.Now);

            // Assert
            Assert.AreEqual(-1, lote.IdLote);
        }

        [TestMethod]
        public void Constructor_ConNumeroLoteVacio_DeberiaPermitirCadenaVacia()
        {
            // Arrange & Act
            var lote = new Lote(1, "", "Activo", DateTime.Now);

            // Assert
            Assert.AreEqual("", lote.NumeroLote);
        }

        [TestMethod]
        public void Constructor_ConEstadoNulo_DeberiaPermitirEstadoNulo()
        {
            // Arrange & Act
            var lote = new Lote(1, "LT-001", null, DateTime.Now);

            // Assert
            Assert.IsNull(lote.Estado);
        }

        [TestMethod]
        public void Propiedades_DeberianSerModificables()
        {
            // Arrange
            var lote = new Lote(1, "LT-001", "Activo", DateTime.Now);
            int nuevoId = 999;
            string nuevoNumero = "LT-999";
            string nuevoEstado = "Inactivo";
            DateTime nuevaFecha = new DateTime(2025, 6, 15);

            // Act
            lote.IdLote = nuevoId;
            lote.NumeroLote = nuevoNumero;
            lote.Estado = nuevoEstado;
            lote.FechaVencimiento = nuevaFecha;

            // Assert
            Assert.AreEqual(nuevoId, lote.IdLote);
            Assert.AreEqual(nuevoNumero, lote.NumeroLote);
            Assert.AreEqual(nuevoEstado, lote.Estado);
            Assert.AreEqual(nuevaFecha, lote.FechaVencimiento);
        }

        [TestMethod]
        public void FechaVencimiento_ConFechaMaxValue_DeberiaPermitirFechaMaxima()
        {
            // Arrange & Act
            var lote = new Lote(1, "LT-MAX", "Test", DateTime.MaxValue);

            // Assert
            Assert.AreEqual(DateTime.MaxValue, lote.FechaVencimiento);
        }

        [TestMethod]
        public void FechaVencimiento_ConFechaMinValue_DeberiaPermitirFechaMinima()
        {
            // Arrange & Act
            var lote = new Lote(1, "LT-MIN", "Test", DateTime.MinValue);

            // Assert
            Assert.AreEqual(DateTime.MinValue, lote.FechaVencimiento);
        }
    }
}
