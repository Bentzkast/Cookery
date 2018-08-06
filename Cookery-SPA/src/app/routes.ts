import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RecipesComponent } from './recipes/recipes.component';
import { MessagesComponent } from './messages/messages.component';
import { FavoritesComponent } from './favorites/favorites.component';
import { AuthGuard } from './_guards/auth.guard';

// ordering is important, first come first served
export const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'recipes', component: RecipesComponent },
      { path: 'messages', component: MessagesComponent },
      { path: 'favorites', component: FavoritesComponent }
    ]
  },

  { path: '**', redirectTo: '', pathMatch: 'full' }
];
