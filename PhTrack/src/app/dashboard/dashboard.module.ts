import { NgModule, CUSTOM_ELEMENTS_SCHEMA} from '@angular/core';
import { CommonModule } from '@angular/common';
import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { InfoComponent } from './components/info/info.component';
import { UserComponent } from './components/user/user.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { SidenavWrapperComponent } from './components/sidenav-wrapper/sidenav-wrapper.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component';
import { SidenavextComponent } from './components/sidenavext/sidenavext.component';
import { ProjectListComponent } from './components/projects/project-list/project-list.component';

@NgModule({
  declarations: [SidenavWrapperComponent, DashboardComponent, InfoComponent, UserComponent, LandingPageComponent, SidenavextComponent, ProjectListComponent],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    // NG Material Modules
    MatSidenavModule,
    MatIconModule,
    // MatTableModule,
    MatToolbarModule, 
  ],
  schemas:[CUSTOM_ELEMENTS_SCHEMA]
})
export class DashboardModule { }
