import {Component, Input, OnInit, Output} from '@angular/core';
import {IRecipe} from '../../shared/models/recipe';
import {RecipesService} from '../recipes.service';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.scss']
})
export class RecipeDetailsComponent implements OnInit {
  @Input() recipe: IRecipe;
  parents: IRecipe[];
  constructor(private recipeService: RecipesService, private activateRoute: ActivatedRoute, private router: Router) { }

  ngOnInit(): void {
    this.router.routeReuseStrategy.shouldReuseRoute = () => false;
    this.loadRecipe();
    this.loadParentRecipes();
  }

  loadRecipe(): any{
    this.recipeService.getRecipe(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(recipe => {
      this.recipe = recipe;
    }, error => {
      console.log(error);
    });
  }
  loadParentRecipes(): any{
    this.recipeService.getParents(+this.activateRoute.snapshot.paramMap.get('id')).subscribe(parents => {
      this.parents = parents;
    }, error => {
      console.log(error);
    });
  }

}
