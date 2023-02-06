import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RespuestaService } from '../models/dtos/respon-service.model';
import { Usuario } from '../models/dtos/usuarios/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  constructor(private http: HttpClient) { }

  GetUsers(){
    
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json; charset=utf-8');
    headers = headers.set('Access-Control-Allow-Origin', 'http://localhost:4200');

    return this.http.get<RespuestaService<Usuario[]>>(`https://localhost:7121/api/Usuarios`, {headers});
  }
}
