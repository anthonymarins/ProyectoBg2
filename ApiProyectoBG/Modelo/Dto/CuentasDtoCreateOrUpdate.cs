using System.ComponentModel.DataAnnotations;

namespace ApiBalance.Modelo.Dto
{
    public class CuentasDtoCreateOrUpdate
    {
        [Required]
        public string? tipoCuenta { get; set; }
        public string? NombreCuenta { get; set; }
        public decimal SaldoCuentas { get; set; }
    }
}
