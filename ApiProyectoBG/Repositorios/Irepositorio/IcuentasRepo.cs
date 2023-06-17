using ApiBalance.Modelo;

namespace ApiBalance.Repositorios.Irepositorio
{
    public interface IcuentasRepo : IRepositorio<CuentasI>
    {
        Task<CuentasI> Ubdate(CuentasI entity);
    }
}
