import {Component, Input, OnInit} from '@angular/core';
import {FormControl, FormGroup, FormBuilder, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {CreateService} from './create.service';
import {ICreateRecipeRequest} from '../shared/models/createRecipeRequest';
import {HttpClient} from '@angular/common/http';
import {IUpdateRecipeRequest} from "../shared/models/updateRecipeRequest";
import {IRecipe} from "../shared/models/recipe";
import {UpdateService} from "./update.service";
import {RecipesService} from "../recipes/recipes.service";

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {
  recipeForm: FormGroup;
  returnUrl: string;
  parentId: string | null = null;
  id = null;
  recipe: IUpdateRecipeRequest = {id: null, name: '', description: '', };
  constructor(private fb: FormBuilder, private createService: CreateService, private router: Router,
              private activatedRoute: ActivatedRoute, private http: HttpClient,
              private updateService: UpdateService, private recipesService: RecipesService) { }

  ngOnInit(): void {
    this.createRecipeForm();
    if (this.activatedRoute.snapshot.queryParams.id)
    {
      this.id = this.activatedRoute.snapshot.queryParams.id;
      this.recipesService.getRecipe(this.id).subscribe(recipe => {
        this.recipe = recipe;
      }, error => {
        console.log(error);
      });
      this.recipeForm.setValue({
        name: this.recipe.name,
        description: this.recipe.description
      });
      console.log('value');
      console.log(this.recipeForm.get('description').value);
    }
    this.returnUrl = this.activatedRoute.snapshot.queryParams.returnUrl || '/recipes';
    if (this.activatedRoute.snapshot.queryParams.parentId)
    {
      this.parentId = this.activatedRoute.snapshot.queryParams.parentId;
    }
  }
  createRecipeForm(): any {
    this.recipeForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
    });
  }
  onSubmit(event): any{
    event.preventDefault();
    if (this.id == null)
    {
      const newRecipe: ICreateRecipeRequest = {
        parentId: parseInt(this.parentId, 10),
        name: this.recipeForm.get('name').value,
        description: this.recipeForm.get('description').value
      };
      this.createService.create(newRecipe).subscribe(() => {
        this.router.navigate(['/recipes']);
      });
    }
    else
    {
      const recipeUpdate: IUpdateRecipeRequest = {
        id: parseInt(this.id, 10),
        name: this.recipeForm.get('name').value,
        description: this.recipeForm.get('description').value
      };
      this.updateService.update(recipeUpdate).subscribe(() => {
        this.router.navigate(['/recipes/', this.id]);
      });
    }
  }
}
