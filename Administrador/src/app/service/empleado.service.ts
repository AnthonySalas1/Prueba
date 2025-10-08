import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { DTOEmpleado } from '../dtos/general';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {
  private apiUrl = 'https://localhost:7153/api/empleados';
  constructor(private https: HttpClient) { }

  obtenerTodos(): Observable<DTOEmpleado[]> {
    console.log(this.https.get<DTOEmpleado[]>(this.apiUrl));
    return new Observable;
  }
}
