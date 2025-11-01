using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CafeAroma_v2.Tests.Configuracion
{
    /// <summary>
    /// Configuración global para las pruebas unitarias del proyecto CafeAroma_v2
    /// </summary>
    [TestClass]
    public class TestConfig
    {
        /// <summary>
        /// Se ejecuta una vez antes de todas las pruebas de la solución
        /// </summary>
        [AssemblyInitialize]
        public static void InicializarPruebas(TestContext context)
        {
            // Configuración global para todas las pruebas
            Console.WriteLine("=== INICIANDO SUITE DE PRUEBAS CAFEAROMA_V2 ===");
            Console.WriteLine($"Fecha: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Contexto: {context.TestName}");
            
            // Inicializar configuraciones globales si es necesario
            InicializarConfiguracionesGlobales();
        }

        /// <summary>
        /// Se ejecuta una vez después de todas las pruebas de la solución
        /// </summary>
        [AssemblyCleanup]
        public static void LimpiarPruebas()
        {
            Console.WriteLine("=== FINALIZANDO SUITE DE PRUEBAS CAFEAROMA_V2 ===");
            Console.WriteLine($"Pruebas completadas: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            
            // Limpieza global después de todas las pruebas
            LimpiarConfiguracionesGlobales();
        }

        /// <summary>
        /// Inicializa configuraciones que se necesitan para todas las pruebas
        /// </summary>
        private static void InicializarConfiguracionesGlobales()
        {
            // Configurar logging para pruebas
            Console.WriteLine("- Configurando ambiente de pruebas");
            
            // Configurar timeouts
            Console.WriteLine("- Configurando timeouts de pruebas");
            
            // Configurar cultura para pruebas consistentes
            System.Threading.Thread.CurrentThread.CurrentCulture = 
                new System.Globalization.CultureInfo("es-ES");
                
            Console.WriteLine("- Configuraciones globales aplicadas");
        }

        /// <summary>
        /// Limpia recursos globales después de las pruebas
        /// </summary>
        private static void LimpiarConfiguracionesGlobales()
        {
            Console.WriteLine("- Liberando recursos globales");
            
            // Forzar garbage collection
            GC.Collect();
            GC.WaitForPendingFinalizers();
            
            Console.WriteLine("- Limpieza completada");
        }

        /// <summary>
        /// Método de utilidad para crear datos de prueba consistentes
        /// </summary>
        public static class DatosDePrueba
        {
            public static readonly string[] TiposGranoValidos = { "Arábica", "Robusta", "Liberica", "Excelsa" };
            public static readonly string[] OrigenesValidos = { "Colombia", "Brasil", "Vietnam", "Etiopía", "Jamaica" };
            public static readonly decimal[] PreciosEjemplo = { 15.99m, 22.50m, 18.75m, 25.00m, 12.99m };
            
            /// <summary>
            /// Genera un ID único para pruebas
            /// </summary>
            public static int GenerarIdUnico()
            {
                return Math.Abs(DateTime.Now.GetHashCode());
            }
            
            /// <summary>
            /// Genera un nombre único basado en timestamp
            /// </summary>
            public static string GenerarNombreUnico(string prefijo = "Test")
            {
                return $"{prefijo}_{DateTime.Now:yyyyMMdd_HHmmss}_{GenerarIdUnico() % 1000}";
            }
        }

        /// <summary>
        /// Constantes para las pruebas
        /// </summary>
        public static class ConstantesPruebas
        {
            public const int TIMEOUT_CORTO_MS = 1000;
            public const int TIMEOUT_MEDIO_MS = 5000;
            public const int TIMEOUT_LARGO_MS = 10000;
            
            public const string MENSAJE_EXCEPCION_ESPERADA = "Se esperaba una excepción";
            public const string MENSAJE_NO_NULO = "El resultado no debería ser nulo";
            public const string MENSAJE_INSTANCIA_CORRECTA = "Debería ser una instancia del tipo correcto";
        }
    }
}
