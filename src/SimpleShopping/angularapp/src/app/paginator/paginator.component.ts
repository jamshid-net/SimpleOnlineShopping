import { Component ,Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-paginator',
  templateUrl: './paginator.component.html',
  styleUrls: ['./paginator.component.css']
})
export class PaginatorComponent {
  @Input() totalPages!: number;
  @Input() currentPage!: number;
  @Input() totalPagesArray!:number[];
  @Output() pageChanged = new EventEmitter<number>();

 

  goToPage(page: number) {
    if (page >= 1 && page <= this.totalPages) {
      this.pageChanged.emit(page);
    }
  }
}
