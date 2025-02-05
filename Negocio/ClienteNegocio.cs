using Data;
using Entity;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<ClienteEntity> getClientes()
        {
            var objClienteData = new ClienteData();
            return objClienteData.getClientes();
        }
        public bool DeleteCliente(int IdCliente)
        {
            var objClienteData = new ClienteData();
            return objClienteData.DeleteCliente(IdCliente);
        }
        public ClienteEntity getClienteById(int IdCliente)
        {
            var objClienteData = new ClienteData();
            return objClienteData.getClienteById(IdCliente);
        }
        public bool UpdateCliente(ClienteEntity cliente)
        {
            var objClienteData = new ClienteData();
            return objClienteData.UpdateCliente(cliente);
        }
        public bool InsertCliente(ClienteEntity cliente)
        {
            var objClienteData = new ClienteData();
            return objClienteData.InsertCliente(cliente);
        }
    }
}
