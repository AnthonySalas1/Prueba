using AdministradorAPI.DBContext;
using AdministradorAPI.Utilidades;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Data;
using System.Reflection.Metadata;

namespace AdministradorAPI.Repository
{


    public class EmpleadoRepository : IEmpleadoRepository
    {

        SigsContext _dbcontext { get; set; }
        public IConfiguration _configuration;

        public EmpleadoRepository( SigsContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<ONDEmpleado>> ObtenerTodos()
        {
            try
            {
                
                List<ONDEmpleado> empleados = new List<ONDEmpleado>();
                _dbcontext.Connect();
                _dbcontext.BeginTransaction();
                _dbcontext.CreateCommand("GEN_EMPS_ObtenerEmpleados");
                using (var reader = await _dbcontext.ExecuteReaderAsync())
                {

                    while (await reader.ReadAsync())
                    {
                        var empleado = new ONDEmpleado
                        {
                            Id = (int)reader["EMP_Id"],
                            Nombres = (string)reader["EMP_nombres"],
                            Apellidos = (string)reader["EMP_Apellidos"],
                            Cargo = (string)reader["EMP_Cargo"],
                            FechaIngreso = reader["EMP_FechaIngreso"] == DBNull.Value ? null : (DateTime)reader["EMP_FechaIngreso"],
                            Salario = reader["EMP_Salario"] == DBNull.Value ? 0.00m : (decimal)reader["EMP_Salario"],
                        };
                        empleados.Add(empleado);
                    }
               
                
                reader.Close();
                _dbcontext.ConfirmTransaction();
                return empleados;
            }
            }
            catch (Exception ex)
            {
                return new List<ONDEmpleado>();
            }
        }
        public async Task<ONDEmpleado> Obtener(int IdEmpleado)
        {
            try
            {

                ONDEmpleado empleado = new ONDEmpleado();
                _dbcontext.Connect();
                _dbcontext.BeginTransaction();
                _dbcontext.CreateCommand("GEN_EMPS_Obtener");
                _dbcontext.AssignParameter("@Id", IdEmpleado, SqlDbType.Int, ParameterDirection.Input);
                using (var reader = await _dbcontext.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        empleado.Id = (int)reader["EMP_Id"];
                        empleado.Nombres = (string)reader["EMP_nombres"];
                        empleado.Apellidos = (string)reader["EMP_Apellidos"];
                        empleado.Cargo = (string)reader["EMP_Cargo"];
                        empleado.FechaIngreso = (DateTime)reader["EMP_FechaIngreso"];
                        empleado.Salario = reader["EMP_Salario"] == DBNull.Value ? 0.00m : (decimal)reader["EMP_Salario"];
                    }
                    reader.Close();
                    _dbcontext.ConfirmTransaction();
                    return empleado;
                }
            }
            catch (Exception ex)
            {
                return new ONDEmpleado();
            }
        }
        public  Task<bool> Insertar(ONDEmpleado empleado)
        {
            try
            {

       
                _dbcontext.Connect();
                _dbcontext.BeginTransaction();
                _dbcontext.CreateCommand("GEN_EMPI_Insertar");
                _dbcontext.AssignParameter("@Nombres", empleado.Nombres, SqlDbType.VarChar, ParameterDirection.Input);
                _dbcontext.AssignParameter("@Apellidos", empleado.Apellidos, SqlDbType.VarChar, ParameterDirection.Input);
                _dbcontext.AssignParameter("@Cargo", empleado.Cargo, SqlDbType.VarChar, ParameterDirection.Input);
                _dbcontext.AssignParameter("@FechaIngreso", empleado.FechaIngreso, SqlDbType.DateTime, ParameterDirection.Input);
                _dbcontext.AssignParameter("@Salario", empleado.Salario, SqlDbType.Decimal, ParameterDirection.Input);
                var respuesta = _dbcontext.ExecuteCommandInt();
                _dbcontext.ConfirmTransaction();

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _dbcontext.CancelTransaction();
                //throw ex;
                return Task.FromResult(false);
            }
        }
        public Task<bool> Actualizar(ONDEmpleado empleado)
        {
            try
            {


                _dbcontext.Connect();
                _dbcontext.BeginTransaction();
                _dbcontext.CreateCommand("GEN_EMPU_Actualizar");
                _dbcontext.AssignParameter("@Id", empleado.Id, SqlDbType.Int, ParameterDirection.Input);
                _dbcontext.AssignParameter("@Nombres", empleado.Nombres, SqlDbType.VarChar, ParameterDirection.Input);
                _dbcontext.AssignParameter("@Apellidos", empleado.Apellidos, SqlDbType.VarChar, ParameterDirection.Input);
                _dbcontext.AssignParameter("@Cargo", empleado.Cargo, SqlDbType.VarChar, ParameterDirection.Input);
                _dbcontext.AssignParameter("@FechaIngreso", empleado.FechaIngreso, SqlDbType.DateTime, ParameterDirection.Input);
                _dbcontext.AssignParameter("@Salario", empleado.Salario, SqlDbType.Decimal, ParameterDirection.Input);
                var respuesta = _dbcontext.ExecuteCommandInt();
                _dbcontext.ConfirmTransaction();

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _dbcontext.CancelTransaction();
                //throw ex;
                return Task.FromResult(false);
            }
        }

        public Task<bool> Eliminar(int IdEmpleado)
        {
            try
            {


                _dbcontext.Connect();
                _dbcontext.BeginTransaction();
                _dbcontext.CreateCommand("GEN_EMPD_Eliminar");
                _dbcontext.AssignParameter("@Id", IdEmpleado, SqlDbType.Int, ParameterDirection.Input);
                var respuesta = _dbcontext.ExecuteCommandInt();
                _dbcontext.ConfirmTransaction();

                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                _dbcontext.CancelTransaction();
                //throw ex;
                return Task.FromResult(false);
            }
        }

    }
}
