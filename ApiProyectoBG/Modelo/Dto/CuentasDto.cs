using System.ComponentModel.DataAnnotations;

namespace ApiBalance.Modelo.Dto
{
    public class CuentasDto
    {
        public int IdCuenta { get; set; }
        [Required]
        public string? tipoCuenta { get; set; }
        public string? NombreCuenta { get; set; }
        public decimal SaldoCuentas { get; set; }
    }
}
