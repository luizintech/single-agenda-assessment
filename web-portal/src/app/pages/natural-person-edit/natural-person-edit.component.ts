import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Gender } from 'src/app/core/model/contacts/gender';
import { Person } from 'src/app/core/model/contacts/person';
import { PersonType } from 'src/app/core/model/contacts/person-type';
import { Address } from 'src/app/core/model/location/address';
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

  public zipcode1: string = "";
  public description1: string = "";
  public city1: string = "";
  public state1: string = "";
  public country1: string = "";

  public zipcode2: string = "";
  public description2: string = "";
  public city2: string = "";
  public state2: string = "";
  public country2: string = "";

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
      birthday: ['', Validators.required],
      zipcode1: [''],
      description1: [''],
      city1: [''],
      state1: [''],
      country1: [''],
      zipcode2: [''],
      description2: [''],
      city2: [''],
      state2: [''],
      country2: ['']          
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

    if (this.description1 != "") {
      var address1 = new Address();
      address1.country = this.country1;
      address1.state = this.state1;
      address1.city = this.city1;
      address1.description = this.description1;
      address1.zipCode = this.zipcode1;
      naturalPerson.addresses.push(address1);
    }

    if (this.description2 != "") {
      var address2 = new Address();
      address2.country = this.country2;
      address2.state = this.state2;
      address2.city = this.city2;
      address2.description = this.description2;
      address2.zipCode = this.zipcode2;
      naturalPerson.addresses.push(address2);
    }

    return naturalPerson;
  }

  cancel() {
    window.location.reload();
  }

}
