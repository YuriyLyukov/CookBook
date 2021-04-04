import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from './home/home.component';
import {RecipesComponent} from './recipes/recipes.component';
import {RecipeDetailsComponent} from './recipes/recipe-details/recipe-details.component';
import {AboutUsComponent} from './about-us/about-us.component';
import {ContactComponent} from './contact/contact.component';
import {CreateComponent} from './create/create.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'recipes', component: RecipesComponent},
  {path: 'recipes/:id', component: RecipeDetailsComponent},
  {path: 'about-us', component: AboutUsComponent},
  {path: 'contact', component: ContactComponent},
  {path: 'create', component: CreateComponent},
  {path: '**', redirectTo: '', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
