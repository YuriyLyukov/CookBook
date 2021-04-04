import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AboutUsComponent } from './about-us.component';
import {RouterModule} from "@angular/router";



@NgModule({
  declarations: [AboutUsComponent],
    imports: [
        CommonModule,
        RouterModule
    ],
  exports: [AboutUsComponent]
})
export class AboutUsModule { }
