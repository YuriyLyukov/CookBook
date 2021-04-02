import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecipesComponent } from './recipes.component';
import { RecipeComponent } from './recipe/recipe.component';



@NgModule({
  declarations: [RecipesComponent, RecipeComponent],
  imports: [
    CommonModule
  ]
})
export class RecipesModule { }
