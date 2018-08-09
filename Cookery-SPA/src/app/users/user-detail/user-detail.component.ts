import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user';
import { UserService } from '../../_services/user.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import {
  NgxGalleryOptions,
  NgxGalleryImage,
  NgxGalleryAnimation
} from '../../../../node_modules/ngx-gallery';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  user: User;
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(
    private userService: UserService,
    private alertify: AlertifyService,
    private route: ActivatedRoute
  ) {}

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.user = data['user'];
      console.log(this.user);
    });

    this.galleryOptions = [
      {
        width: '320px',
        height: '320px',
        imagePercent: 100,
        thumbnailsColumns: 3,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false // prevent full screen
      }
    ];
    this.galleryImages = this.getImages();
  }

  getImages() {
    const imageUrls = [];
    for (let i = 0; i < this.user.recipes.length; i++) {
      imageUrls.push({
        small: this.user.recipes[i].pictureUrl,
        medium: this.user.recipes[i].pictureUrl,
        big: this.user.recipes[i].pictureUrl,
        description: this.user.recipes[i].name
      });
    }
    return imageUrls;
  }
}
