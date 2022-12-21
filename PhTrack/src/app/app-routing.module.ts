import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent} from './dashboard/components/landing-page/landing-page.component'
import { DashboardComponent } from './dashboard/components/dashboard/dashboard.component';
import { InfoComponent } from './dashboard/components/info/info.component';
import { UserComponent } from './dashboard/components/user/user.component';
import { ProjectListComponent } from './dashboard/components/projects/project-list/project-list.component';

const routes: Routes = [
  // lazy loaded dashboard module
  {
    path: '',
    component:LandingPageComponent
  },
  
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
      path: 'projects',
      component: ProjectListComponent
    },
  {
    path: '**',
    redirectTo: '',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
