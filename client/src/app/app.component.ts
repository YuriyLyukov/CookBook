import {Component, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {IRecipe} from './models/recipe';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'CookBook';
  recipes: IRecipe[];
  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/v1/recipe').subscribe((response: IRecipe[]) => {
      this.recipes = response;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }
}
