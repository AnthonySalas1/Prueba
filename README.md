# Prueba Técnica: CRUD de Empleados

...

## Frontend (Angular 18)
1. Navega a `/frontend`.
2. Instala dependencias: `npm install`.
3. Ajusta la URL de la API en `src/app/servicios/empleado.service.ts` si el puerto del backend cambia.
4. Ejecuta: `ng serve`.
   - Puerto: **http://localhost:60406** o configurado en program.cs.
   - Usa PrimeNG para UI: Tabla responsive, formularios, instalar bootstrap.

Detalles adicionales:
- Angular 18 con componentes standalone y sintaxis de control flow moderna.
- Pruebas: Crea/editar/eliminar empleados vía API; maneja errores con mensajes.
- Si hay issues de CORS, verifica el backend.


## .NET (8)

Instalar dependencias.
Cambiar las cadenas de conexion
adicionalmente se puede ejecutar las siguientes queries para efectos de la prueba:

CREATE DATABASE SIGS
GO

USE SIGS
GO 

--DROP TABLE GEN_Empleado
CREATE TABLE GEN_Empleado(
	EMP_Id INT PRIMARY KEY IDENTITY,
	EMP_Nombres VARCHAR(100) NULL,
	EMP_Apellidos VARCHAR(100) NULL,
	EMP_Cargo VARCHAR(100) NULL,
	EMP_FechaIngreso DATETIME NULL,
	EMP_Salario DECIMAL NULL
)
GO

INSERT INTO GEN_Empleado VALUES(
 'Anthony'
 ,'Salas'
 ,'Analista TI'
 ,GETDATE()
 ,'1200.00'
)

GO

-- =============================================
-- Author:      Anthony Salas
-- Create Date: 07/10/2025
-- Description: Obtiene todos los empleados
-- =============================================
alter PROCEDURE GEN_EMPS_ObtenerEmpleados
(@Id INT = NULL)
AS
BEGIN
SELECT * 
FROM GEN_Empleado

END
GO
-- =============================================
-- Author:      Anthony Salas
-- Create Date: 07/10/2025
-- Description: Obtiene un usuario
-- =============================================
CREATE PROCEDURE GEN_EMPS_Obtener
(@Id INT = NULL)
AS
BEGIN
SELECT * 
FROM GEN_Empleado
WHERE EMP_Id = @Id

END

GO

-- =============================================
-- Author:      Anthony Salas
-- Create Date: 07/10/2025
-- Description: Eliminar un usuario
-- =============================================
CREATE PROCEDURE GEN_EMPD_Eliminar
(@Id INT = NULL)
AS
BEGIN
DELETE 
FROM GEN_Empleado
WHERE EMP_Id = @Id

END

GO
-- =============================================
-- Author:      Anthony Salas
-- Create Date: 07/10/2025
-- Description: Insertar un usuario
-- =============================================
CREATE PROCEDURE GEN_EMPI_Insertar
(@Id INT = NULL
,@Nombres VARCHAR(100) = NULL
,@Apellidos VARCHAR(100) = NULL
,@Cargo VARCHAR(100) = null
,@FechaIngreso DATETIME = null
,@Salario DECIMAL = NULL
)
AS
BEGIN

INSERT INTO GEN_Empleado VALUES(
 @Nombres
 ,@Apellidos
 ,@Cargo
 ,@FechaIngreso
 ,@Salario
)

END

GO
-- =============================================
-- Author:      Anthony Salas
-- Create Date: 07/10/2025
-- Description: Actualizar un usuario
-- =============================================
ALTER PROCEDURE GEN_EMPU_Actualizar
(@Id INT = NULL
,@Nombres VARCHAR(100) = NULL
,@Apellidos VARCHAR(100) = NULL
,@Cargo VARCHAR(100) = null
,@FechaIngreso DATETIME = null
,@Salario DECIMAL = NULL
)
AS
BEGIN

UPDATE GEN_Empleado 
  SET EMP_Nombres = ISNULL(@Nombres, EMP_Nombres)
 ,EMP_Apellidos = ISNULL(@Apellidos, EMP_Apellidos)
 ,EMP_Cargo  = ISNULL(@Cargo, EMP_Cargo)
 ,EMP_FechaIngreso  = ISNULL(@FechaIngreso, EMP_FechaIngreso)
 ,EMP_Salario  = ISNULL(@Salario,EMP_Salario)
WHERE EMP_Id = @Id

END




verificar la ruta sea la misma utilizada para el frontend:
puerto https://localhost:7153

