namespace CRUDClientes.Models
{
    public class Clientes
    {
        public string? Identificacion { get; set; } 

        public string? PrimerNombre { get; set; }

        public string? PrimerApellido { get; set; }

        public int? Edad { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public byte[]? Fotografia { get; set; }

        public List<Clientes>? ListaClientes { get; set; }
        public Clientes? ObjetoClientes { get; set; }
    }
}
