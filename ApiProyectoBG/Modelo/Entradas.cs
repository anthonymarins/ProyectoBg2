using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBalance.Modelo
{
    public class Entradas
    {
        [Key]
        public int IdCuenta { get; set; }
        [ForeignKey("IdCuenta")]
        public CuentasI cuentasI { get; set; }
        
        [Required]
        public int IdTransaccion { get; set; }
        public decimal entradas { get; set; }
    }
}
