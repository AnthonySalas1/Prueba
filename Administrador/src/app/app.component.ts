import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { EmpleadoService } from './service/empleado.service';
import { DTOEmpleado } from './dtos/general';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  //Declaramos miembros
  title = 'Administrador';
  empleados?: DTOEmpleado[]
  empleadoForm: FormGroup;
  mostrarForm: boolean = false;
  accionCrear: boolean = false;
  accionActualizar: boolean = false;
  constructor(
    private fb: FormBuilder, public router: Router, private EmpleadoService: EmpleadoService) {
    this.empleadoForm = this.fb.group({
      Id: [''],
      Nombres: [''],
      Apellidos: [''],
      Cargo: [''],
      FechaIngreso: [''],
      Salario: ['']
    })
  }

  ngOnInit() {
    this.ObtenerTodos()
  }

  ObtenerTodos() {
    try {
      this.EmpleadoService.obtenerTodos().subscribe(data => {
        let response = Object.values(data);
        if (response[1]) {
          this.empleados = response[0] as DTOEmpleado[];
        } else {
          alert("No se cargaron datos del servidor");
        }
      }, x => {
        console.log("Error en el servicio TS")
      })
    }
    catch (ex) {
      console.log(ex);
    }
  }

  nuevo() {
    this.mostrarForm = true;
    this.empleadoForm.reset();
    this.accionCrear = true;
  }

  editar(id: number) {
    this.empleadoForm.reset();
    this.mostrarForm = true;
    let empleado = this.empleados?.find(x => x.id == id);
    this.empleadoForm.patchValue({
      Id: empleado?.id,
      Nombres: empleado?.nombres,
      Apellidos: empleado?.apellidos,
      Cargo: empleado?.cargo,
      FechaIngreso: empleado?.fechaIngreso,
      Salario: empleado?.salario
    });
    this.accionActualizar = true;
  }
  guardar() {
    try {

      this.mostrarForm = true;
      const formData = this.empleadoForm.value;
      let empleado: DTOEmpleado;

      let temp = this.empleadoForm.getRawValue()
      empleado = temp as DTOEmpleado;
      empleado.id = 0;
      console.log(empleado)
      if (this.accionCrear) {

        this.EmpleadoService.insertar(empleado).subscribe(data => {
          console.log(data)
          let response = Object.values(data);
          if (response[1]) {
            this.ObtenerTodos();
          } else {
            alert("No se actualizó el registro")
          }
        }, x => {
          console.log("Error en el servicio TS")

        });
        this.accionCrear = false;
      } else if (this.accionActualizar) {
        this.EmpleadoService.editar(empleado).subscribe(data => {
          let response = Object.values(data);
          if (response[1]) {
            this.ObtenerTodos();
          } else {
            alert("No se actualizó el registro")
          }
        }, x => {
          console.log("Error en el servicio TS")

        });
        this.accionActualizar = false;
      }
      this.empleadoForm.reset();
      this.mostrarForm = false;

    }
    catch (ex) {
      console.log(ex);
    }
  }
  eliminar(Id: any) {
    try {
      alert("se eliminara un registro")
      this.EmpleadoService.eliminar(Id).subscribe(data => {
        let response = Object.values(data);
        if (response[1]) {
          this.ObtenerTodos();
        } else {
          alert("No se eliminó el registro")
        }
      }, x => {
        console.log("Error en el servicio TS")

      })
    }
    catch (x) {
      console.log(x)
    }
  }
}
