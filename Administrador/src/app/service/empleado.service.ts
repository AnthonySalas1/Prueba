import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { DTOEmpleado } from '../dtos/general';

@Injectable({
  providedIn: 'root'
})

export class EmpleadoService {
    constructor(private https: HttpClient) { }

    private apiUrl = 'https://localhost:7153/api/empleados';
    


  public obtenerTodos(): Observable<any[]> {
    try {
      return this.https.get<any[]>(this.apiUrl);
    }
    catch (x) {
      console.log(x)
      return new Observable;
    }

  }
    public editar(empleado: DTOEmpleado): Observable<any[]> {
        try {
            return this.https.put<any[]>(this.apiUrl, empleado);
        }
        catch (x) {
            console.log(x)
            return new Observable;
        }

    }
    public eliminar(Id: number): Observable<any[]> {
        try {
            return this.https.delete<any[]>(this.apiUrl + "/" + Id );
        }
        catch (x) {
            console.log(x)
            return new Observable;
        }

    }
    public insertar(empleado: DTOEmpleado): Observable<any[]> {
        try {
            
            var datos = {
                Empleado: empleado
            };
           
            return this.https.post<any[]>(this.apiUrl, {json : empleado} );
        }
        catch (x) {
            console.log(x)
            return new Observable;
        }

    }

}
