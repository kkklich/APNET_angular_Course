import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-detail-user',
  templateUrl: './detail-user.component.html',
  styleUrls: ['./detail-user.component.css']
})
export class DetailUserComponent implements OnInit {
  users: any;
  constructor(private http: HttpClient ) { }
 
  ngOnInit(){
    this.getUser();    
  }

  getUser(){
    this.http.get('https://localhost:5001/api/users').subscribe(Response => {
      this.users=Response;
    }, error=>{ 
      console.log(error);   
    }
    );
  }


}