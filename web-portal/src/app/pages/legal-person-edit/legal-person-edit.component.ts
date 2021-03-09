import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Person } from 'src/app/core/model/contacts/person';
import { PersonType } from 'src/app/core/model/contacts/person-type';
import { Address } from 'src/app/core/model/location/address';
import { Result } from 'src/app/core/model/messages/result';
import { ContactService } from 'src/app/core/services/contact.service';

@Component({
  selector: 'app-legal-person-edit',
  templateUrl: './legal-person-edit.component.html',
  styleUrls: ['./legal-person-edit.component.css']
})
export class LegalPersonEditComponent implements OnInit {

  public editForm: FormGroup;

  public name: string = "";
  public tradeName: string = "";
  public email: string = "";
  public document: string = "";

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

  public additionalAddress1 = false;
  public additionalAddress2 = false;

  constructor(
    private formBuilder: FormBuilder,
    private contactService: ContactService,
    private router: Router
  ) { 
    this.editForm = this.formBuilder.group({
      name:  ['', Validators.required], 
      email:  ['', Validators.required], 
      tradeName:  ['', Validators.required],
      document: ['', Validators.required],
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
    if(this.editForm.valid){
      var person = this.populate();
      if (this.additionalAddress1 && !this.validateAddress1()) {
        alert('Please fill all the fields of address 1 area!');
      } else if (this.additionalAddress2 && !this.validateAddress2()) {
        alert('Please fill all the fields of address 2 area!');
      } else {
        this.contactService.create(person).subscribe((result: Result) => {
          console.log(result);
          if (result.success) {
            alert('Legal Person edited with success!');
            this.router.navigate(['contacts']);
            window.location.reload();
          } else {
            alert(result.messages);
          }
        });
      }
    }
  }

  private populate() : Person {
    let naturalPerson = new Person();
    naturalPerson.personType = PersonType.Legal;
    naturalPerson.name = this.name;
    naturalPerson.tradeName = this.tradeName;
    naturalPerson.email = this.email;
    naturalPerson.document = this.document;

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

  showAddressArea(area: number) {
    if (area == 1) {
      this.additionalAddress1 = true;
    } else if (area == 2) {
      if (this.validateAddress1())
        this.additionalAddress2 = true;
      else
        alert('Please fill all the addresses fields before add another one!');
    }
  }

  private validateAddress1(): boolean {
    let valid = true;

    if (this.description1 == "")
      valid = false;

    if (this.zipcode1 == "")
      valid = false;

    if (this.state1 == "")
      valid = false;

    if (this.city1 == "")
      valid = false;

    if (this.country1 == "")
      valid = false;

    return valid;
  }

  private validateAddress2(): boolean {
    let valid = true;

    if (this.description2 == "")
      valid = false;

    if (this.zipcode2 == "")
      valid = false;

    if (this.state2 == "")
      valid = false;

    if (this.city2 == "")
      valid = false;

    if (this.country2 == "")
      valid = false;

    return valid;
  }

}
