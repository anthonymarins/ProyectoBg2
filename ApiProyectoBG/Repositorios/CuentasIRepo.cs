using ApiBalance.Data;
using ApiBalance.Modelo;
using ApiBalance.Repositorios.Irepositorio;

namespace ApiBalance.Repositorios
{
    public class CuentasIRepo : Repositorio<CuentasI> , IcuentasRepo
    {
        private readonly BGContext _db;

        public CuentasIRepo(BGContext db) : base(db)
        {
            _db = db;
        }

        public async Task<CuentasI> Ubdate(CuentasI entity)
        {
            _db.Cuentas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;  
        }
    }
}
