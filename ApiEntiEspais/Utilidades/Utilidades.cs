using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiEntiEspais.Utilidades
{
    public static class Utilidades
    {
        public static string MensajeError(SqlException sqlException)
        {
            String mensaje = "";

            switch (sqlException.Number)
            {
                case -1:
                    mensaje = "Error de conexión con el servidor";
                    break;
                case 547:
                    mensaje = "Tiene datos relacionados";
                    break;
                case 2601:
                    mensaje = "Datos duplicados";
                    break;
                case 2627:
                    mensaje = "Datos duplicados";
                    break;
                case 4060:
                    mensaje = "No se encuentra la base de datos";
                    break;
                case 18456:
                    mensaje = "Usuario o contraseña incorrectos";
                    break;
                default:
                    mensaje = sqlException.Number + " - " + sqlException.Message;
                    break;
            }
            return mensaje;
        }
    }
}