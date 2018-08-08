import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RecipeListComponent } from './recipe/recipe-list/recipe-list.component';

import { MessagesComponent } from './messages/messages.component';
import { FavoritesComponent } from './favorites/favorites.component';
import { AuthGuard } from './_guards/auth.guard';
import { RecipeDetailComponent } from './recipe/recipe-detail/recipe-detail.component';
import { RecipeDetailResolver } from './_resolvers/recipe-detail.resolver';
import { RecipeListResolver } from './_resolvers/recipe-list.resolver';
import { UserDetailComponent } from './users/user-detail/user-detail.component';
import { UserDetailResolver } from './_resolvers/user-detail.resolver';
import { UserListComponent } from './users/user-list/user-list.component';
import { UserListResolver } from './_resolvers/user-list.resolver';
import { UserEditComponent } from './users/user-edit/user-edit.component';
import { UserEditResolver } from './_resolvers/user-edit.resolver';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';

// ordering is important, first come first served
export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {
        path: 'recipes',
        component: RecipeListComponent,
        resolve: { recipes: RecipeListResolver }
      },
      {
        path: 'recipes/:id',
        component: RecipeDetailComponent,
        resolve: { recipe: RecipeDetailResolver }
      },
      {
        path: 'users/edit',
        component: UserEditComponent,
        resolve: { user: UserEditResolver },
        canDeactivate: [PreventUnsavedChanges]
      },
      {
        path: 'users/:id',
        component: UserDetailComponent,
        resolve: { user: UserDetailResolver }
      },
      {
        path: 'users',
        component: UserListComponent,
        resolve: { users: UserListResolver }
      },
      { path: 'messages', component: MessagesComponent },
      { path: 'favorites', component: FavoritesComponent }
    ]
  },

  { path: '**', redirectTo: '', pathMatch: 'full' }
];
