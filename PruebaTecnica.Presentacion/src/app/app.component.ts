import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Usuario } from './models/dtos/usuarios/usuario.model';
import { ResponseServerType } from './models/enums/response-type.model';
import { UsuariosService } from './services/usuarios.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public users?: Usuario[];

  constructor(private _usuariosService: UsuariosService) { }


  clickButton(){
    this._usuariosService.GetUsers().subscribe(result =>{
      if(result.code === ResponseServerType.Succes){
        this.users = result.result;
      }
    },error =>{
      console.log(error);  
    }    
    );
  }

  title = 'PruebaTecnica.Presentacion';
}
