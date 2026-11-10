using System.ComponentModel.DataAnnotations;

namespace MOERSitioWeb.DTOs
{
    public class TurnoEstadoUpdateDTO
    {
        [Required(ErrorMessage = "El estado del turno es obligatorio.")]
        public int IdEstadoTurno { get; set; }
    }
}