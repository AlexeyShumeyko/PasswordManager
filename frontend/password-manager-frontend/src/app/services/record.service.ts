import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IRecords, Record } from '../model/records';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecordService {
  private apiUrl="https://localhost:7101";

  constructor(private http: HttpClient) { }

  getAllRecords(): Observable<IRecords[]> {
    return this.http.get<IRecords[]>(this.apiUrl+"/Record/GetAllRecords");
  }

  addRecord(record: Record): Observable<Record>{
    const headers = new HttpHeaders().set('Content-Type', 'application/json');
    return this.http.post<Record>(this.apiUrl+"/Record/AddRecord", record, { headers });
  }

  searchRecords(query: string): Observable<IRecords[]>{
    return this.http.get<IRecords[]>(`${this.apiUrl}/Record/SearchRecord?searchQuery=${query}`);
  }
}
