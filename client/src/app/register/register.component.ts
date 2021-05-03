import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { error } from 'selenium-webdriver';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  @Output() cancelRegister =new  EventEmitter();
  model: any={};

  constructor(private accountService:AccountService, private toastr:ToastrService) { }

  ngOnInit(): void {
    

  }
  register(){
  
    this.accountService.regiser(this.model).subscribe(response=>{
      console.log(response);
      this.toastr.success("Now you can logg in","Account created")
    }, error=>
    {      
      this.toastr.error(error.error);      
    })
  }
     
        
  

  cancel(){
    this.cancelRegister.emit(false);
  }

}
