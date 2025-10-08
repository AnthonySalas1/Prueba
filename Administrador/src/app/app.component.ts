import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { EmpleadoService } from './service/empleado.service';
import { DTOEmpleado } from './dtos/general';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Administrador';

  empleados?: DTOEmpleado[]

  constructor(public router: Router, private EmpleadoService: EmpleadoService) { }

  ngOnInit() {
    this.get()
  }

  get() {
    try {
      this.EmpleadoService.obtenerTodos().subscribe(data => {
        this.empleados = data
      }, e => {
        alert(e.error)
      })
    }
    catch (ex) {
      console.log(ex);
    }
  }
}
