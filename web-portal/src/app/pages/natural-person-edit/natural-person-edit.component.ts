import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Gender } from 'src/app/core/model/contacts/gender';
import { Person } from 'src/app/core/model/contacts/person';
import { PersonType } from 'src/app/core/model/contacts/person-type';
import { Result } from 'src/app/core/model/messages/result';
import { ContactService } from 'src/app/core/services/contact.service';

@Component({
  selector: 'app-natural-person-edit',
  templateUrl: './natural-person-edit.component.html',
  styleUrls: ['./natural-person-edit.component.css']
})
export class NaturalPersonEditComponent implements OnInit {

  public editForm: FormGroup;

  public name: string = "";
  public email: string = "";
  public gender: number = 0;
  public document: string = "";
  public birthday: Date;

  constructor(
    private formBuilder: FormBuilder,
    private contactService: ContactService,
    private router: Router
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
    console.log(this.editForm.valid);
    console.log(this.editForm);
    if(this.editForm.valid){
      var person = this.populate();
      console.log(person);
      this.contactService.create(person).subscribe((result: Result) => {
        console.log(result);
        if (result.success) {
          alert('Person edited with success!');
          this.router.navigate(['contacts']);
          window.location.reload();
        } else {
          alert(result.messages);
        }
      });
    } else {
    }
  }

  private populate() : Person {
    let naturalPerson = new Person();
    naturalPerson.personType = PersonType.Natural;
    naturalPerson.name = this.name;
    naturalPerson.email = this.email;
    naturalPerson.birthday = this.birthday;
    naturalPerson.document = this.document;

    switch (this.gender) {
      case 1:
        naturalPerson.gender = Gender.Male;
        break;

      case 2:
        naturalPerson.gender = Gender.Female;
        break;

      case 3:
        naturalPerson.gender = Gender.NonBinary;
        break;

      default:
        break;
    }

    return naturalPerson;
  }

  cancel() {
    window.location.reload();
  }

}
