import { Component, OnInit } from '@angular/core';
import { Recipe } from '../../_models/recipe';
import { RecipeService } from '../../_services/recipe.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'app-recipe-list',
  templateUrl: './recipe-list.component.html',
  styleUrls: ['./recipe-list.component.css']
})
export class RecipeListComponent implements OnInit {
  recipes: Recipe[];

  constructor(
    private recipeService: RecipeService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.recipes = data['recipes'];
    });
  }

  // loadRecipes() {
  //   this.recipeService.getRecipes().subscribe(
  //     (recipes: Recipe[]) => {
  //       this.recipes = recipes;
  //     },
  //     error => {
  //       this.alertify.error(error);
  //     }
  //   );
  // }
}
