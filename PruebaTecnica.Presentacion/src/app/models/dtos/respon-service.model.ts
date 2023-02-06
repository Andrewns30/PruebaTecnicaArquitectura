import { ResponseServerType } from "../enums/response-type.model";

export interface RespuestaService<T>{
    code:ResponseServerType;
    message:string;    
    errors:string[]
    result:T;
}