using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBalance.Modelo
{
    public class CuentasI
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCuenta { get; set; }
        [Required]
        public string? tipoCuenta { get; set; }
        public string? NombreCuenta { get; set; }
        public decimal SaldoCuentas { get; set; }  
    }
}
