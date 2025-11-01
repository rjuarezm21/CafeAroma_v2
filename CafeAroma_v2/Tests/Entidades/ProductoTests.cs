using Microsoft.VisualStudio.TestTools.UnitTesting;
using CafeAroma_v2.Clases.Entidades;
using System;

namespace CafeAroma_v2.Tests.Entidades
{
    [TestClass]
    public class ProductoTests
    {
        [TestMethod]
        public void Constructor_Parametrizado_DeberiaInicializarPropiedadesCorrectamente()
        {
            // Arrange
            string nombreEsperado = "Café Premium";
            int idGranoEsperado = 1;
            int cantidadEsperada = 50;
            decimal precioEsperado = 15.99m;

            // Act
            var producto = new Producto(nombreEsperado, idGranoEsperado, cantidadEsperada, precioEsperado);

            // Assert
            Assert.AreEqual(nombreEsperado, producto.Nombre);
            Assert.AreEqual(idGranoEsperado, producto.IdGrano);
            Assert.AreEqual(cantidadEsperada, producto.Cantidad);
            Assert.AreEqual(precioEsperado, producto.Precio);
            Assert.AreEqual(0, producto.IdProducto); // Valor por defecto
        }

        [TestMethod]
        public void Constructor_SinParametros_DeberiaCrearInstanciaConValoresPorDefecto()
        {
            // Act
            var producto = new Producto();

            // Assert
            Assert.IsNotNull(producto);
            Assert.AreEqual(0, producto.IdProducto);
            Assert.IsNull(producto.Nombre);
            Assert.AreEqual(0, producto.IdGrano);
            Assert.AreEqual(0, producto.Cantidad);
            Assert.AreEqual(0m, producto.Precio);
        }

        [TestMethod]
        public void Propiedades_DeberianSerModificables()
        {
            // Arrange
            var producto = new Producto();
            int idProductoNuevo = 123;
            string nombreNuevo = "Café Deluxe";
            int idGranoNuevo = 2;
            int cantidadNueva = 25;
            decimal precioNuevo = 22.50m;

            // Act
            producto.IdProducto = idProductoNuevo;
            producto.Nombre = nombreNuevo;
            producto.IdGrano = idGranoNuevo;
            producto.Cantidad = cantidadNueva;
            producto.Precio = precioNuevo;

            // Assert
            Assert.AreEqual(idProductoNuevo, producto.IdProducto);
            Assert.AreEqual(nombreNuevo, producto.Nombre);
            Assert.AreEqual(idGranoNuevo, producto.IdGrano);
            Assert.AreEqual(cantidadNueva, producto.Cantidad);
            Assert.AreEqual(precioNuevo, producto.Precio);
        }

        [TestMethod]
        public void Producto_ConPrecioNegativo_DeberiaPermitirValorNegativo()
        {
            // Arrange & Act
            var producto = new Producto("Café Test", 1, 10, -5.00m);

            // Assert
            Assert.AreEqual(-5.00m, producto.Precio);
        }

        [TestMethod]
        public void Producto_ConCantidadCero_DeberiaPermitirCantidadCero()
        {
            // Arrange & Act
            var producto = new Producto("Café Agotado", 1, 0, 10.00m);

            // Assert
            Assert.AreEqual(0, producto.Cantidad);
        }

        [TestMethod]
        public void Producto_ConNombreVacio_DeberiaPermitirCadenaVacia()
        {
            // Arrange & Act
            var producto = new Producto("", 1, 10, 15.00m);

            // Assert
            Assert.AreEqual("", producto.Nombre);
        }

        [TestMethod]
        public void Producto_ConIdGranoNegativo_DeberiaPermitirValorNegativo()
        {
            // Arrange & Act
            var producto = new Producto("Café Test", -1, 10, 15.00m);

            // Assert
            Assert.AreEqual(-1, producto.IdGrano);
        }

        [TestMethod]
        public void Producto_PrecioConDecimales_DeberiaConservarPrecision()
        {
            // Arrange
            decimal precioConDecimales = 19.99m;

            // Act
            var producto = new Producto("Café Precision", 1, 10, precioConDecimales);

            // Assert
            Assert.AreEqual(precioConDecimales, producto.Precio);
        }
    }
}
