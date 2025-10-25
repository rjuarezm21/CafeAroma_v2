using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;

namespace CafeAroma_v2.Clases.Database
{
    public sealed class ConexionBD
    {
        //  Instancia única (Singleton)
        private static readonly ConexionBD instancia = new ConexionBD();

        //  Cadena de conexión ODBC con DSN de Windows
        private readonly string cadena = "DSN=CafeAromaDSN;";
        private OdbcConnection conexion;

        //  Constructor privado
        private ConexionBD() { }

        //  Acceso global a la instancia
        public static ConexionBD Instancia => instancia;

        // =========================================================
        //  Método para obtener conexión abierta
        // =========================================================
        private OdbcConnection ObtenerConexion()
        {
            conexion = null;
            if (conexion == null)
                conexion = new OdbcConnection(cadena);

            if (conexion.State != ConnectionState.Open)
                conexion.Open();

            return conexion;
        }

        // =========================================================
        //  Método genérico para ejecutar SP con parámetros
        // =========================================================
        public void EjecutarSP(string nombreSP, Dictionary<string, object> parametros)
        {
            try
            {
                using (OdbcConnection con = ObtenerConexion())
                {
                    using (OdbcCommand cmd = new OdbcCommand($"{{CALL {nombreSP}({ConstruirParametros(parametros.Count)})}}", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros dinámicamente
                        foreach (var p in parametros)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($" Error ejecutando SP '{nombreSP}': {ex.Message}");
            }
        }

        // =========================================================
        //  Método para ejecutar SP que devuelve DataTable
        // =========================================================
        public DataTable EjecutarSPConResultado(string nombreSP, Dictionary<string, object> parametros)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OdbcConnection con = ObtenerConexion())
                {
                    using (OdbcCommand cmd = new OdbcCommand($"{{CALL {nombreSP}({ConstruirParametros(parametros.Count)})}}", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (var p in parametros)
                        {
                            cmd.Parameters.AddWithValue(p.Key, p.Value);
                        }

                        using (OdbcDataAdapter da = new OdbcDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                conexion.Close();
            }
            catch (Exception ex)
            {
                throw new Exception($" Error ejecutando SP '{nombreSP}': {ex.Message}");
            }

            return dt;
        }

        // =========================================================
        // 🧮 Construye la cantidad de placeholders dinámicamente
        // =========================================================
        private string ConstruirParametros(int cantidad)
        {
            if (cantidad == 0) return "";
            return string.Join(", ", new string[cantidad].Select(_ => "?"));
        }
    }
}
