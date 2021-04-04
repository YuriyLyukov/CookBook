import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class UpdateService {
  baseUrl = 'https://localhost:5001/api/v1/';
  constructor(private http: HttpClient, private router: Router) { }
  update(values: any): any{
    return this.http.patch(this.baseUrl + 'recipe', values);
  }
}
