import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RecipeListComponent } from './recipe/recipe-list/recipe-list.component';

import { MessagesComponent } from './messages/messages.component';
import { FavoritesComponent } from './favorites/favorites.component';
import { AuthGuard } from './_guards/auth.guard';
import { RecipeDetailComponent } from './recipe/recipe-detail/recipe-detail.component';
import { RecipeDetailResolver } from './_resolvers/recipe-detail.resolver';
import { RecipeListResolver } from './_resolvers/recipe-list.resolver';

// ordering is important, first come first served
export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'recipes', component: RecipeListComponent, resolve: {recipes: RecipeListResolver} },
      { path: 'recipes/:id', component: RecipeDetailComponent, resolve: {recipe: RecipeDetailResolver}},
      { path: 'messages', component: MessagesComponent },
      { path: 'favorites', component: FavoritesComponent }
    ]
  },

  { path: '**', redirectTo: '', pathMatch: 'full' }
];
