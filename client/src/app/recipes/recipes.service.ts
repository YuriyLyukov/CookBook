import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {IRecipe} from '../shared/models/recipe';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {
  baseUrl = 'https://localhost:5001/api/v1/';

  constructor(private http: HttpClient) { }
  getRecipes(): Observable<IRecipe[]> {
    return this.http.get<IRecipe[]>(this.baseUrl + 'recipe');
  }
  getRecipe(id: number): Observable<IRecipe>{
    return this.http.get<IRecipe>(this.baseUrl + 'recipe/' + id);
  }
  getParents(id: number): Observable<IRecipe[]>{
    return this.http.get<IRecipe[]>(this.baseUrl + 'recipe/parent/' + id);
  }
}
