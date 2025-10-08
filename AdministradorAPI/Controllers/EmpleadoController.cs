using AdministradorAPI.Services;
using AdministradorAPI.Utilidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AdministradorAPI.Controllers
{
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoService _empleadoService;
        private readonly ILogger<EmpleadoController> _logger;
    
        private bool rpta = false;

        public EmpleadoController(ILogger<EmpleadoController> logger, IEmpleadoService empleadoService)
        {
            _logger = logger;
            _empleadoService = empleadoService;
   
        }

        [HttpGet]
        public async Task<Tuple<List<ONDEmpleado>,bool>> ObtenerTodos()
        {
            try
            {
                var rptaService =  await _empleadoService.ObtenerTodos();
                if (rptaService != null)
                {
                    rpta = true;
                }
                return  new Tuple<List<ONDEmpleado>,bool>(rptaService, rpta);
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<Tuple<ONDEmpleado, bool>> Obtener(int Id)
        {
            try
            {
                var rptaService = await _empleadoService.Obtener(Id);
                if (rptaService != null)
                {
                    rpta = true;
                }
                return new Tuple<ONDEmpleado, bool>(rptaService, rpta);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        [HttpPost]
        public async Task<Tuple<bool, bool>> Insertar([FromBody] ONDEmpleado empleado)
        {
            try
            {
                var rptaService = await _empleadoService.Insertar(empleado);
                if (rptaService != null)
                {
                    rpta = true;
                }
                return new Tuple<bool, bool>(rptaService, rpta);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        [HttpPut]
        public async Task<Tuple<bool, bool>> Actualizar([FromBody] ONDEmpleado empleado)
        {
            try
            {
                var rptaService = await _empleadoService.Actualizar(empleado);
                if (rptaService != null)
                {
                    rpta = true;
                }
                return new Tuple<bool, bool>(rptaService, rpta);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        [HttpDelete]
        public async Task<Tuple<bool, bool>> Eliminar(int Id)
        {
            try
            {
                var rptaService = await _empleadoService.Eliminar(Id);
                if (rptaService != null)
                {
                    rpta = true;
                }
                return new Tuple<bool, bool>(rptaService, rpta);
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}
