import { Injectable } from '../../../node_modules/@angular/core';
import { CanDeactivate } from '../../../node_modules/@angular/router';
import { UserEditComponent } from '../users/user-edit/user-edit.component';

@Injectable()
export class PreventUnsavedChanges implements CanDeactivate<UserEditComponent> {
  canDeactivate(component: UserEditComponent, e) {
    if (component.editForm.dirty) {
      return confirm(
        'Are you sure you want to continue? any unsaved changes will be lost'
      );
    }
    return true;
  }
}
