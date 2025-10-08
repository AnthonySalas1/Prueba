using AdministradorAPI.Utilidades;

namespace AdministradorAPI.Services
{
    public interface IEmpleadoService
    {

        Task<List<ONDEmpleado>> ObtenerTodos();
        Task<ONDEmpleado> Obtener(int IdEmpleado);
        Task<bool> Insertar(ONDEmpleado usuario);
        Task<bool> Actualizar(ONDEmpleado usuario);
        Task<bool> Eliminar(int IdEmpleado);
    }
}