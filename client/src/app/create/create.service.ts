import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Router} from '@angular/router';
import {map} from 'rxjs/operators';
import {ICreateRecipeRequest} from '../shared/models/createRecipeRequest';

@Injectable({
  providedIn: 'root'
})
export class CreateService {
  baseUrl = 'https://localhost:5001/api/v1/';
  constructor(private http: HttpClient, private router: Router) { }
  create(values: any): any{
    return this.http.post(this.baseUrl + 'recipe', values);
  }
}
