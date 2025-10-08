using AdministradorAPI.Utilidades;

namespace AdministradorAPI.Repository
{
    public interface IEmpleadoRepository
    {
        Task<List<ONDEmpleado>> ObtenerTodos();
        Task<ONDEmpleado> Obtener(int IdEmpleado);
        Task<bool> Insertar(ONDEmpleado empleado);
        Task<bool> Actualizar(ONDEmpleado empleado);
        Task<bool> Eliminar(int IdEmpleado);

    }
    
}
