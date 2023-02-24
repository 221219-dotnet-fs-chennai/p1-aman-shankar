import { Component } from '@angular/core';
import {NgForm} from '@angular/forms';
import { NgbAlert, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  // standalone:true,
  // imports:[NgbAlertModule],
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Demo';
  status = true;
  color = 'Blue';
  colors ='Yellow';
  userarray=['Arshad','Bunty','Rizwan'];
  userlist=[
    {name:'Arshad',salary:60000,location:'Chennai',skillset:['C','Java','Angular']},
    {name:'Bunty',salary:60000,location:'Hygerabad',skillset:['Python','sJava','Angular']},
    {name:'Rizwan',salary:60000,location:'Chennai',skillset:['Java','Angular','React']},
  ]
  ChangeColor(){
    this.color='Red';
    this.colors='Indigo';
  }


  dataObject: any;
  getData(data:NgForm){
    this.dataObject=data;
  } 
}
