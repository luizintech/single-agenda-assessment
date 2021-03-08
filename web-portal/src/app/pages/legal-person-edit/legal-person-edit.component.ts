import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Person } from 'src/app/core/model/contacts/person';
import { PersonType } from 'src/app/core/model/contacts/person-type';
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

  constructor(
    private formBuilder: FormBuilder,
    private contactService: ContactService,
    private router: Router
  ) { 
    this.editForm = this.formBuilder.group({
      name:  ['', Validators.required], 
      email:  ['', Validators.required], 
      tradeName:  ['', Validators.required],
      document: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    
  }

  save() {
    if(this.editForm.valid){
      var person = this.populate();
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
    } else {
    }
  }

  private populate() : Person {
    let naturalPerson = new Person();
    naturalPerson.personType = PersonType.Legal;
    naturalPerson.name = this.name;
    naturalPerson.tradeName = this.tradeName;
    naturalPerson.email = this.email;
    naturalPerson.document = this.document;

    return naturalPerson;
  }

  cancel() {
    window.location.reload();
  }

}
