import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AuthManager } from 'src/app/core/helpers/auth/auth-manager';
import { Person } from 'src/app/core/model/contacts/person';
import { ContactService } from 'src/app/core/services/contact.service';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.css']
})
export class ContactsComponent implements OnInit {

  public contacts: Person[] = [];
  public editing: boolean = false;
  public personType: number = 0;

  constructor(
    private authManager: AuthManager,
    private router: Router,
    private contactService: ContactService
  ) { }

  ngOnInit(): void {
    if (!this.authManager.isValid())
      this.router.navigate(['/']);

    this.contactService.listAll().subscribe(data => {
      this.contacts = data;
    });

    this.editing = false;
    this.personType = 0;
  }

  public new() {
    this.editing = true;
  }

  chooseType(choosed: number) {
    this.personType = choosed;
    console.log(this.personType);
  }

  public personTypeTranslate(type: Number) {
    let translated = "";

    switch (type) {
      case 1:
        translated = "Natural";
        break;

      case 2:
        translated = "Legal";
        break;
    }

    return translated;
  }

}
