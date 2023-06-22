import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private baseUrl = 'https://localhost:5001/api';

  constructor(private http: HttpClient) { }

  public getInvestimentos(): Observable<any> {
    return this.http.get<any>(`${this.baseUrl}/investimentos`);
  }

  public calcularInvestimento(valorInicial: number, prazoMeses: number): Observable<any> {
    const body = {
      valorInicial: valorInicial,
      prazoMeses: prazoMeses
    };
    return this.http.post<any>(`${this.baseUrl}/Investimento`, body);
  }
}
