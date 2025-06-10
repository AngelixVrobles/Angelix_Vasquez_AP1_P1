using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;



    namespace Angelix_Vasquez_AP1_P1.Models;
    public class Aportes
{

        [Key]

        public int AporteId { get; set; }

        [Required(ErrorMessage = "La fecha de ingreso es obligatoria")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[a-zA-ZÁÉÍÓÚÜÑáéíóúüñ'’\s]+$", ErrorMessage = "El nombre solo puede contener letras y caracteres válidos")]
        public string Nombres { get; set; } = string.Empty;

        [Required(ErrorMessage = "Introducir el monto del aporte.")]
        [Range(1, 2000000, ErrorMessage = "El monto debe ser mayor a 1 y menor a 2000000")]
        public float Monto { get; set; }
}

public class PaginacionAportes
{
    public List<Aportes> Aportes { get; set; } = new();
    public int TotalAportes { get; set; }
}









