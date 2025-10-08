using AdministradorAPI.Repository;
using AdministradorAPI.Utilidades;

namespace AdministradorAPI.Services
{
    public class EmpleadoService :IEmpleadoService
    {
        private IEmpleadoRepository UsuarioRepository;

        public EmpleadoService(IConfiguration configuration, IEmpleadoRepository empleadoRepository)
        {
            UsuarioRepository = empleadoRepository;
        }

        public async Task<List<ONDEmpleado>> ObtenerTodos()
        {
            try
            {
                
                var rpta = await UsuarioRepository.ObtenerTodos();


                return rpta;
            }
            catch(Exception ex)
            {
                throw ex;     
            }
        }
        public async Task<ONDEmpleado> Obtener(int IdEmpleado)
        {
            try
            {

                var rpta = await UsuarioRepository.Obtener(IdEmpleado);


                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Insertar(ONDEmpleado empleado)
        {
            try
            {

                var rpta = await UsuarioRepository.Insertar(empleado);


                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Actualizar(ONDEmpleado empleado)
        {
            try
            {

                var rpta = await UsuarioRepository.Actualizar(empleado);


                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> Eliminar(int IdEmpleado)
        {
            try
            {

                var rpta = await UsuarioRepository.Eliminar(IdEmpleado);


                return rpta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
