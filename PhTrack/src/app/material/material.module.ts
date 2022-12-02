import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatToolbarModule} from '@angular/material/toolbar'
import { MatIconModule} from '@angular/material/icon'
import { MatButtonModule} from '@angular/material/button'
import { MatSidenavModule} from '@angular/material/sidenav'
import { MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatListModule} from '@angular/material/list';

@NgModule({
  declarations: [],
  imports: [ 
    CommonModule
  ]
  , 
  exports:[
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatSidenavModule,
    MatButtonToggleModule,
    MatListModule
  ]
})
export class MaterialModule { }
