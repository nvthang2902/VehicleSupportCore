import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-pager',
  templateUrl: './pager.component.html',
  styleUrls: ['./pager.component.css']
})
export class PagerComponent implements OnInit {
  @Input() totalCount:number;
  @Input() pageSize:number;
  @Output() pageChanged =new EventEmitter<number>();
  constructor() { }

  ngOnInit(): void {
  }

  onPagerChange(event: any){
    this.pageChanged.emit(event.page);
  }
}
// pageChanged(event: any) {
//   this.page = event.page;
//   console.log('pageChanged to :', this.page);
//   // go through the service and subscribe in the end user
//   this.shopService.pageChanged.next(this.page);
// }


// // subscribe to pageChanged event and load the products on every change
//   this.shopService.pageChanged.subscribe(response => {
//     this.shopParams.pageIndex = response;
//     this.getProducts();
//   });