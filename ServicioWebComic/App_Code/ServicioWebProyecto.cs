using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Descripción breve de ServicioWebProyecto
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
// [System.Web.Script.Services.ScriptService]
public class ServicioWebProyecto : System.Web.Services.WebService
{

    public ServicioWebProyecto()
    {

        //Elimine la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public int UpdVendedores(string Estado)
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ConnectionString);
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }

        SqlCommand cmd = new SqlCommand("Direcciones_Insertar", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Estado", Estado);
        conn.Open();
        int IdOrigenDestino = int.Parse(cmd.ExecuteScalar().ToString());
        conn.Close();
        return IdOrigenDestino;
    }

}
