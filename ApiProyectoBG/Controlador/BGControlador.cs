using ApiBalance.Modelo;
using ApiBalance.Modelo.Dto;
using ApiBalance.Repositorios.Irepositorio;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBalance.Controlador
{
    [Route("api/[controller]")]
    [ApiController]
    public class BGControlador : ControllerBase
    {
        private readonly ILogger<BGControlador> _logger;
        private readonly IcuentasRepo _cuentasRepo;
        private readonly IMapper _mapper;

        public BGControlador(ILogger<BGControlador> logger, IcuentasRepo cuentasRepo, IMapper mapper)
        {
            _logger = logger;
            _cuentasRepo = cuentasRepo;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CuentasDto>>> GetCuentas()
        {
            _logger.LogInformation("Obtener las cuentas iniciales para realizar el Balance General");
            
            var CuentasList = await _cuentasRepo.GetAll();

            return Ok(_mapper.Map<IEnumerable<CuentasDto>>(CuentasList));
        }
        [HttpGet("{id:int}",Name = "GetCuenta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CuentasDto>>> GetCuenta(int id)
        {
            _logger.LogInformation("Obtener entradas de cuenta");

            if(id == 0)
            {
                _logger.LogError($"Error, no se encuentra nunguna entrada con este Id {id}");
                return BadRequest();
            }
            var cuenta = await _cuentasRepo.Get(e => e.IdCuenta == id);
            if(id == null)
            {
                _logger.LogError($"Error, no se encuentra nunguna entrada con este Id {id}");
                return NotFound();
            }

            return Ok(_mapper.Map<CuentasDto>(cuenta));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<CuentasI>> AddCuentas([FromBody] CuentasDtoCreateOrUpdate cuentas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(await _cuentasRepo.Get(c=> c.NombreCuenta.ToLower()==cuentas.NombreCuenta.ToLower() && c.tipoCuenta.ToLower() == cuentas.tipoCuenta.ToLower()) != null)
            {
                ModelState.AddModelError("Nombre Existe", "La cuenta que desea agregar ya existe");
                return BadRequest(ModelState);
            }

            if(cuentas == null)
            {
                return BadRequest(ModelState);
            }

            CuentasI modelo = _mapper.Map<CuentasI>(cuentas);
            await _cuentasRepo.Create(modelo);

            return CreatedAtRoute("GetCuenta", new { id = modelo.IdCuenta }, modelo);
        }
    }
}
