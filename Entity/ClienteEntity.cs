namespace Entity
{
    public class ClienteEntity
    {
        public int IdCliente {  get; set; }
        public string Nombre { get; set; }
        public int Edad {  get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool MayorEdad { get; set; }
    }
}
