import {Component, Input, OnInit} from '@angular/core';
import {IRecipe} from '../../shared/models/recipe';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.scss']
})
export class RecipeComponent implements OnInit {
  @Input() recipe: IRecipe;
  constructor() { }

  ngOnInit(): void {
  }

}
