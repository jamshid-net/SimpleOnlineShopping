import { Component ,Inject} from '@angular/core';
import {MatButtonModule} from '@angular/material/button';

import { MatDialogRef,MAT_DIALOG_DATA } from '@angular/material/dialog';
@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.css']
})
export class DeleteDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteDialogComponent>, 
     @Inject(MAT_DIALOG_DATA) public data: any) {}
  OnDelete(){

  }
}
