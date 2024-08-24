import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [],
  templateUrl: './contact.component.html',
  styleUrl: './contact.component.scss'
})
export class ContactComponent implements OnInit {
  constructor(private http : HttpClient){

  }
  ngOnInit() {
    this.http.get("https://localhost:7000/api/home/init").subscribe(r=>{
      console.log(r);
    },(e)=>{
      console.log(e);
    })
  }


}
