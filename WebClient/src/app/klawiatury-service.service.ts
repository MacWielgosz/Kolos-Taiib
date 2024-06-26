import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { KlawiaturaResponceDTO } from './Model/KlawiaturaResponce.interface';
import { KlawiaturyRequestDTO } from './Model/KlawiaturyRequestDTO.interface';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class KlawiaturyServiceService {

  constructor(private httpClient:HttpClient) { }
  
  public get(): Observable<KlawiaturaResponceDTO[]> {
    return this.httpClient.get<KlawiaturaResponceDTO[]>('https://localhost:7190/api/Klawiatury');
  }
  
    public post(body: KlawiaturyRequestDTO): Observable<void> {
      return this.httpClient.post<void>('https://localhost:7190/api/Klawiatury', body);
    }
  
    public delete(id: number): Observable<void> {
      return this.httpClient.delete<void>('https://localhost:7190/api/Klawiatury/'+ id);
    }

}
