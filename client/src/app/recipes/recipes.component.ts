import { Component, OnInit } from '@angular/core';
import {RecipesService} from './recipes.service';
import {IRecipe} from '../shared/models/recipe';
import {NavigationEnd, Router} from "@angular/router";

@Component({
  selector: 'app-recipes',
  templateUrl: './recipes.component.html',
  styleUrls: ['./recipes.component.scss']
})
export class RecipesComponent implements OnInit {
  recipes: IRecipe[];
  constructor(private recipesService: RecipesService, private router: Router) {
    router.events.subscribe(e => {
      if (e instanceof NavigationEnd) {
        this.loadRecipes();
      }
    });
  }

  ngOnInit(): void {
   this.loadRecipes();
  }
  loadRecipes(): void{
    this.recipesService.getRecipes().subscribe(response => {
      this.recipes = response;
    }, error => {
      console.log(error);
    });
  }
}
