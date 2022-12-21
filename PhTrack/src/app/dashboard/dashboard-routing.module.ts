import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { InfoComponent } from './components/info/info.component';
import { LandingPageComponent } from './components/landing-page/landing-page.component'
import { UserComponent } from './components/user/user.component';
import { ProjectListComponent } from './components/projects/project-list/project-list.component';
import { SidenavWrapperComponent } from './components/sidenav-wrapper/sidenav-wrapper.component';

const routes: Routes = [

  {
    path: '',
    component: SidenavWrapperComponent,
    children: [
      {
        path: 'dashboard',
        component: DashboardComponent
      },
      {
        path: 'info',
        component: InfoComponent
      },
      {
        path: 'user',
        component: UserComponent
      },
      {
        path: 'landing-page',
        component: LandingPageComponent
      },
      {
        path:'projects',
        component:ProjectListComponent
      }
    ]
  },
  {
    path: '**',
    redirectTo: '/landing-page',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardRoutingModule { }
