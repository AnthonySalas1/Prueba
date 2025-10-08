import { Data } from "@angular/router";

export interface DTOEmpleado {
  id: number,
  nombres: string,
  apellidos: string,
  cargo: string,
  fechaIngreso: Date,
  salario: number
}
