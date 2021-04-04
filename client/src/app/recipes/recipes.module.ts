import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecipesComponent } from './recipes.component';
import { RecipeComponent } from './recipe/recipe.component';
import { RecipeDetailsComponent } from './recipe-details/recipe-details.component';
import {RouterModule} from '@angular/router';



@NgModule({
  declarations: [RecipesComponent, RecipeComponent, RecipeDetailsComponent],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [RecipesComponent]
})
export class RecipesModule { }
