import { Component, Input} from '@angular/core';

@Component({
  selector: 'app-master-detail',
  templateUrl: './master-detail.component.html',
  styleUrls: ['./master-detail.component.css']
})
export class MasterDetailComponent {

  @Input()
  dataSource: any[] = [];

  @Input()
  colunas: any[] = [];

  constructor() {}  
}

