import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {CoreModule} from './core/core.module';
import {RecipesModule} from './recipes/recipes.module';
import {HomeModule} from './home/home.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {CreateModule} from './create/create.module';


@NgModule({
  declarations: [
    AppComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CoreModule,
    RecipesModule,
    HomeModule,
    FormsModule,
    ReactiveFormsModule,
    CreateModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
