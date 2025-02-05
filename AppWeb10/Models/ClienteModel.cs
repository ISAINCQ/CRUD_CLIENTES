namespace AppWeb10.Models
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool MayorEdad { get; set; }
    }
}
