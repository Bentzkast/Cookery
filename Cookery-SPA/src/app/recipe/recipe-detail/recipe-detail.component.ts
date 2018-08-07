import { Component, OnInit } from '@angular/core';
import { Recipe } from '../../_models/recipe';
import { RecipeService } from '../../_services/recipe.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css']
})
export class RecipeDetailComponent implements OnInit {
  recipe: Recipe;

  constructor(
    private recipeService: RecipeService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.recipe = data['recipe'];
    });
  }

  // loadRecipe() {
  //   this.recipeService.getRecipe(+this.route.snapshot.params['id']).subscribe(
  //     (recipe: Recipe) => {
  //       this.recipe = recipe;
  //     },
  //     err => this.alertify.error(err)
  //   );
  // }
}
