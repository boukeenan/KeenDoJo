import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';

@Component({
  selector: 'app-find-data-by-name',
  templateUrl: './find-data-by-name.component.html',
  styleUrls: ['./find-data-by-name.component.css']
})
export class FindDataByNameComponent implements OnInit {
  public foundData: DataByName[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string)
  {
    http.get<DataByName[]>(baseUrl + 'finddatabyname').subscribe(result => {
      this.foundData = result;
    }, error => console.error(error));
  }

  ngOnInit(): void {
  }

}

interface DataByName
{
  tableName: string;
  columnName: string;
  Details: string;
}
