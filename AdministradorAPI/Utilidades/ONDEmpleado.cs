namespace AdministradorAPI.Utilidades
{
    public class ONDEmpleado
    {

        public int Id { get; set; }

        public string? Nombres { get; set; } = null!;

        public string? Apellidos { get; set; } = null!;

        public string? Cargo { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public decimal? Salario { get; set; }
    }

}
