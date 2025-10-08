using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;


namespace AdministradorAPI.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Data;

public class SigsContext : DbContext
{
    private SqlConnection connection = null;
    public SqlCommand command = null;
    private SqlTransaction transaction = null;
    private SqlParameter parameter = null;
    private readonly IConfiguration _configuration;
    private string ChainConnection;

    public SigsContext(DbContextOptions<SigsContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
        Configuration();
        
    }
    private void Configuration()
    {
        try
        {
            this.ChainConnection = _configuration.GetConnectionString("DefaultConnection");
        }
        catch (ConfigurationException ex)
        {
            throw ex;
        }
    }
    private void Configuration(string cadena)
    {
        try
        {
            //this.ChainConnection = ConfigurationManager.ConnectionStrings[cadena].ConnectionString;
        }
        catch (ConfigurationException ex)
        {
            throw ex;
        }
    }
    public void Disconnect()
    {
        if (this.connection.State.Equals(ConnectionState.Open))
        {
            this.connection.Close();
            Console.WriteLine("Desconectar 0");
        }
    }
    public void Connect()
    {

        if (this.connection != null && !this.connection.State.Equals(ConnectionState.Closed))
        {
            throw new Exception("La conexión ya se encuentra abierta.");
        }
        if (this.connection == null)
        {
            this.connection = new SqlConnection();
            this.connection.ConnectionString = ChainConnection;
        }
        this.connection.Open();
        Console.WriteLine("Conectar 1");
    }
    public void CreateCommand(string storeSQL)
    {
        this.command = new SqlCommand();
        this.command.Connection = this.connection;
        this.command.CommandType = CommandType.StoredProcedure;
        this.command.CommandText = storeSQL;
        if (this.transaction != null)
        {
            this.command.Transaction = this.transaction;
        }
    }
    public void AssignParameter(SqlParameter param)
    {
        this.command.Parameters.Add(param);
    }

    public void AssignParameter(string name, object value)
    {
        this.parameter = new SqlParameter();
        this.parameter.ParameterName = name;
        this.parameter.Value = value;
        this.parameter.Direction = ParameterDirection.Input;
        this.parameter.IsNullable = true;
        this.command.Parameters.Add(this.parameter);
    }
    public void AssignParameter(string name, object value, SqlDbType type)
    {
        this.parameter = new SqlParameter();
        this.parameter.ParameterName = name;
        this.parameter.Value = value;
        this.parameter.Direction = ParameterDirection.Input;
        this.parameter.IsNullable = true;
        this.command.Parameters.Add(this.parameter);
    }
    public void AssignParameter(string name, object value, SqlDbType type, int size)
    {
        this.parameter = new SqlParameter();
        this.parameter.ParameterName = name;
        this.parameter.Value = value;
        this.parameter.Direction = ParameterDirection.Input;
        this.parameter.IsNullable = true;
        this.command.Parameters.Add(this.parameter);
    }
    public void AssignParameter(string name, object value, SqlDbType type, int size, ParameterDirection direction)
    {
        this.parameter = new SqlParameter();
        this.parameter.ParameterName = name;
        this.parameter.Value = value;
        this.parameter.SqlDbType = type;
        this.parameter.Size = size;
        this.parameter.Direction = direction;
        this.command.Parameters.Add(this.parameter);
    }
    public void AssignParameter(string name, object value, SqlDbType type, ParameterDirection direction)
    {
        this.parameter = new SqlParameter();
        this.parameter.ParameterName = name;
        this.parameter.Value = value;
        this.parameter.SqlDbType = type;
        this.parameter.Direction = direction;
        this.command.Parameters.Add(this.parameter);
    }
    public void AssignParameter(string name, object value, byte precision, byte scale, ParameterDirection direction)
    {
        try
        {
            this.parameter = new SqlParameter
            {
                ParameterName = name,
                Value = value,
                SqlDbType = SqlDbType.Decimal,
                Precision = precision,
                Scale = scale,
                Direction = direction,
                IsNullable = true
            };
            this.command.Parameters.Add(this.parameter);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public SqlDataReader ExecuteReader()
    {
        return this.command.ExecuteReader();
    }
    public async Task<SqlDataReader> ExecuteReaderAsync()
    {
        return await this.command.ExecuteReaderAsync();
    }
    public int ExecuteScalar()
    {
        int scalar = 0;

        scalar = int.Parse(this.command.ExecuteScalar().ToString());

        return scalar;
    }
    public void ExecuteCommand()
    {
        this.command.ExecuteNonQuery();
    }
    public bool ExecuteCommandWithResponse()
    {
        return this.command.ExecuteNonQuery() > 0 ? true : false;
    }
    public async Task<bool> ExecuteCommandAsync()
    {
        return await this.command.ExecuteNonQueryAsync() > 0 ? true : false;
    }

    public int ExecuteCommandInt()
    {
        return this.command.ExecuteNonQuery();
    }
    public void BeginTransaction()
    {
        if (this.transaction == null)
        {
            this.transaction = this.connection.BeginTransaction();
        }
    }
    public void CancelTransaction()
    {
        if (this.transaction != null)
        {
            this.transaction.Rollback();
        }
    }
    public void ConfirmTransaction()
    {
        if (this.transaction != null)
        {
            this.transaction.Commit();
        }
    }

}
