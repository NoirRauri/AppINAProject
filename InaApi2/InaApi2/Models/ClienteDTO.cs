using Entities;

namespace InaApi2.Models
{
    public class ClienteDTO
    {
        public string? Cedula { get; set; }

        public int TipoCliente { get; set; }

        public int DescMax { get; set; }

        public byte[]? Foto { get; set; }

        public bool Estado { get; set; }

        public string? Nombre { get; set; } 

        public string? Apellido1 { get; set; }

        public string? Apellido2 { get; set; }

        public int Genero { get; set; }

        public DateTime FechaNac { get; set; }

    }
}
