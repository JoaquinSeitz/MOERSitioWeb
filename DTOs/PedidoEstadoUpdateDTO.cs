using System.ComponentModel.DataAnnotations;

namespace MOERSitioWeb.DTOs
{
    public class PedidoEstadoUpdateDTO
    {
        [Required]
        public int IdEstadoPedido { get; set; }
    }
}