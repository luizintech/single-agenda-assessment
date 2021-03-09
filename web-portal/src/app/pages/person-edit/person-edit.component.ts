import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Gender } from 'src/app/core/model/contacts/gender';
import { Person } from 'src/app/core/model/contacts/person';
import { PersonType } from 'src/app/core/model/contacts/person-type';
import { Address } from 'src/app/core/model/location/address';
import { Result } from 'src/app/core/model/messages/result';
import { ContactService } from 'src/app/core/services/contact.service';

@Component({
  selector: 'app-person-edit',
  templateUrl: './person-edit.component.html',
  styleUrls: ['./person-edit.component.css']
})
export class PersonEditComponent implements OnInit {

  public editForm: FormGroup;
  public personRouteId: string;

  public isNaturalPerson: boolean = true;

  public name: string = "";
  public tradeName: string = "";
  public email: string = "";
  public gender: number = 0;
  public document: string = "";
  public documentCnpj: string = "";
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

  public additionalAddress1 = false;
  public additionalAddress2 = false;

  constructor(
    private formBuilder: FormBuilder,
    private contactService: ContactService,
    private router: Router,
    private route: ActivatedRoute
  ) { 
    this.editForm = this.formBuilder.group({
      name:  ['', Validators.required], 
      email:  ['', Validators.required], 
      gender:  [''],
      document: [''],
      birthday: [''],
      zipcode1: [''],
      description1: [''],
      city1: [''],
      state1: [''],
      country1: [''],
      zipcode2: [''],
      description2: [''],
      city2: [''],
      state2: [''],
      country2: [''],
      documentCnpj: [''],
      tradeName: ['']          
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe( paramMap => {
      this.personRouteId = paramMap.get('id');

      if (this.personRouteId != undefined && this.personRouteId != "") {
        this.contactService.getById(parseInt(this.personRouteId)).subscribe((data: Person) => {
          this.isNaturalPerson = (data.personType == PersonType.Natural);

          this.name = data.name;
          this.email = data.email;
          this.tradeName = data.tradeName;
          this.document = data.document;
          this.documentCnpj = data.document;
          this.gender = data.gender;
          this.birthday = data.birthday;

          if (data.addresses.length > 0) {
            let address1 = data.addresses[0];
            this.zipcode1 = address1.zipCode;
            this.state1 = address1.state;
            this.city1 = address1.city;
            this.description1 = address1.description;
            this.country1 = address1.country;
          }

          if (data.addresses.length > 1) {
            let address2 = data.addresses[1];
            this.zipcode2 = address2.zipCode;
            this.state2 = address2.state;
            this.city2 = address2.city;
            this.description2 = address2.description;
            this.country2 = address2.country;
          }

          this.additionalAddress1 = (data.addresses.length > 0);
          this.additionalAddress2 = (data.addresses.length > 1);

        });
      }
      else {
        setTimeout(() => {
          alert('Error loading person info.');
          this.router.navigate(['contacts']);
        }, 500);
      }
    })

  }

  save() {
    console.log(this.editForm);
    if(this.editForm.valid){
      if (this.additionalAddress1 && !this.validateAddress1()) {
        alert('Please fill all the fields of address 1 area!');
      } else if (this.additionalAddress2 && !this.validateAddress2()) {
        alert('Please fill all the fields of address 2 area!');
      } else {
        var person = this.populate();
        console.log(person);
        this.contactService.update(parseInt(this.personRouteId), person).subscribe((result: Result) => {
          if (result.success) {
            alert('Person edited with success!');
            this.router.navigate(['contacts']);
          } else {
            alert(result.messages);
          }
        });
      }
    } 
  }

  private populate() : Person {
    let naturalPerson = new Person();
    naturalPerson.id = parseInt(this.personRouteId);
    naturalPerson.name = this.name;
    naturalPerson.email = this.email;

    if (this.isNaturalPerson) {
      naturalPerson.personType = PersonType.Natural;
      naturalPerson.birthday = this.birthday;
      naturalPerson.document = this.document;
      console.log(this.gender);

      if (this.gender == 1) {
        naturalPerson.gender = Gender.Male;
      } else if (this.gender == 2) {
        naturalPerson.gender = Gender.Female;
      } else if (this.gender == 3) {
        naturalPerson.gender = Gender.NonBinary
      }

      console.log('debug');
      console.log(naturalPerson.gender);
    } else {
      naturalPerson.document = this.documentCnpj;
      naturalPerson.tradeName = this.tradeName;
      naturalPerson.personType = PersonType.Legal;
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
    this.router.navigate(['contacts']);
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
