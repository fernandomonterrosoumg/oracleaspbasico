using ASPORACLE2.Controllers.oracle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPORACLE2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Definir la consulta SQL de actualización
                string query = @"select * from tb_sexoss where CODIGO=:codigo";

                // Crear un diccionario de parámetros con los nuevos valores y condiciones
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(":codigo", 1);

                // Ejecutar la actualización
                DataTable rowsAffected = oracleMaster.ExecuteQuery(query, parameters);

                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error " + ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Definir la consulta SQL de actualización
                string query = @"UPDATE tb_sexo SET ABREVIATURA = :ABREVIATURA
                        WHERE codigo = :codigo";

                // Crear un diccionario de parámetros con los nuevos valores y condiciones
                Dictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add(":ABREVIATURA", "X");
                parameters.Add(":codigo", 1);

                // Ejecutar la actualización
                int rowsAffected = oracleMaster.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Actualización exitosa.");
                }
                else
                {
                    Console.WriteLine("La actualización no tuvo éxito.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error durante la actualización: " + ex.Message);
            }
        }

    }
}