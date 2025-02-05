using Entity;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Data
{
    public class ClienteData
    {
        public List<ClienteEntity> getClientes()
        {
            List<ClienteEntity> result = null;
            var lst = new List<ClienteEntity>();
            SqlConnection con = new SqlConnection("server = .\\SQLEXPRESS; Initial Catalog = CursoASP; Integrated Security = true; TrustServerCertificate =true");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Clientes]",con);

            con.Open();
            da.Fill(dt);
            con.Close();

            if(dt.Rows.Count > 0)
            {
                result = new List<ClienteEntity>();
            }
            foreach(DataRow item in dt.Rows )
            {
                var cliente = new ClienteEntity();
                cliente.IdCliente =Convert.ToInt32(item["IdCliente"].ToString());
                cliente.Nombre = item["Nombre"].ToString();
                cliente.Edad = Convert.ToInt32(item["Edad"].ToString());
                cliente.FechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"]);
                cliente.MayorEdad = Convert.ToBoolean(item["IsMayorEdad"].ToString());
                lst.Add(cliente);
            }
            return lst;
        }
        public bool DeleteCliente(int IdCliente)
        {
            bool result = false;
            SqlConnection con = new SqlConnection("server = .\\SQLEXPRESS; Initial Catalog = CursoASP; Integrated Security = true; TrustServerCertificate =true");
            SqlCommand cmd = new SqlCommand("Delete Clientes Where IdCliente = @IdCliente",con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("@IdCliente", IdCliente);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            result = true;
            return result;
        }
        public ClienteEntity getClienteById(int IdCliente)
        {
            ClienteEntity result = null;
            SqlConnection con = new SqlConnection("server = .\\SQLEXPRESS; Initial Catalog = CursoASP; Integrated Security = true; TrustServerCertificate =true");
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [Clientes] WHERE IdCliente = @IdCliente", con);
            da.SelectCommand.Parameters.AddWithValue("@IdCliente", IdCliente);

            con.Open();
            da.Fill(dt);
            con.Close();

            if(dt.Rows.Count > 0)
            {
                result = new ClienteEntity();
                foreach(DataRow item in dt.Rows)
                {
                    result.IdCliente =Convert.ToInt32(item["IdCliente"].ToString());
                    result.Nombre = item["Nombre"].ToString();
                    result.Edad = Convert.ToInt32(item["Edad"].ToString());
                    result.FechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"]);
                    result.MayorEdad = Convert.ToBoolean(item["Edad"]);
                    break;
                }
            }
            return result;
        }
        public bool UpdateCliente(ClienteEntity cliente)
        {
            bool result = false;
            SqlConnection con = new SqlConnection("server = .\\SQLEXPRESS; Initial Catalog = CursoASP; Integrated Security = true; TrustServerCertificate =true");
            SqlCommand cmd = new SqlCommand("sp_actualizar_cliente", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
            cmd.Parameters.AddWithValue("@nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@edad", cliente.Edad);
            cmd.Parameters.AddWithValue("@fecha", cliente.FechaNacimiento);
            cmd.Parameters.AddWithValue("@isMayor", cliente.MayorEdad);
            
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            result = true;
            return result;
        }
        public bool InsertCliente(ClienteEntity cliente)
        {
            bool result = false;
            SqlConnection con = new SqlConnection("server = .\\SQLEXPRESS; Initial Catalog = CursoASP; Integrated Security = true; TrustServerCertificate =true");
            SqlCommand cmd = new SqlCommand("sp_insert_cliente", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            cmd.Parameters.AddWithValue("@Edad", cliente.Edad);
            cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
            cmd.Parameters.AddWithValue("@MayorEdad", cliente.MayorEdad);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            result = true;
            return result;
        }
    }
}
