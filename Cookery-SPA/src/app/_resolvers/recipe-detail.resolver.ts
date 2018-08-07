import { Injectable } from '@angular/core';
import { Recipe } from '../_models/recipe';
import { Resolve, ActivatedRouteSnapshot, Router } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { RecipeService } from '../_services/recipe.service';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';

@Injectable()
export class RecipeDetailResolver implements Resolve<Recipe> {
  constructor(
    private recipeService: RecipeService,
    private router: Router,
    private alertify: AlertifyService
  ) {}
  resolve(route: ActivatedRouteSnapshot): Observable<Recipe> {
    return this.recipeService.getRecipe(route.params['id']).pipe(
      catchError(error => {
        this.alertify.error('Problem retrieving data');
        this.router.navigate(['/recipes']);
        return of(null);
      })
    );
  }
}
