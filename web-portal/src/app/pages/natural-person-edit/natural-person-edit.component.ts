import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Gender } from 'src/app/core/model/contacts/gender';

@Component({
  selector: 'app-natural-person-edit',
  templateUrl: './natural-person-edit.component.html',
  styleUrls: ['./natural-person-edit.component.css']
})
export class NaturalPersonEditComponent implements OnInit {

  public editForm: FormGroup;

  public name: string = "";
  public email: string = "";
  public gender: Gender;
  public document: string = "";
  public birthday: Date;

  constructor(
    private formBuilder: FormBuilder,
  ) { 
    this.editForm = this.formBuilder.group({
      name:  ['', Validators.required], 
      email:  ['', Validators.required], 
      gender:  ['', Validators.required],
      document: ['', Validators.required],
      birthday: ['', Validators.required]              
    });
  }

  ngOnInit(): void {
    
  }

  save() {

  }

}
