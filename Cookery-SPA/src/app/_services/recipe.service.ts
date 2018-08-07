import { Injectable } from '@angular/core';
import {
  HttpHeaders,
  HttpClient
} from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';
import { Recipe } from '../_models/recipe';

@Injectable({
  providedIn: 'root'
})
export class RecipeService {
  baseUrl = environment.apiUrl;
  constructor(private httpClient: HttpClient) {}
  getRecipes(): Observable<Recipe[]> {
    return this.httpClient.get<Recipe[]>(this.baseUrl + 'recipes/');
  }

  getRecipe(id: number): Observable<Recipe> {
    return this.httpClient.get<Recipe>(this.baseUrl + 'recipes/' + id);
  }
}
