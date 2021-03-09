import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthManager } from 'src/app/core/helpers/auth/auth-manager';
import { Person } from 'src/app/core/model/contacts/person';
import { Result } from 'src/app/core/model/messages/result';
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

  public filterForm: FormGroup;
  public showRemoved: boolean;

  constructor(
    private authManager: AuthManager,
    private router: Router,
    private contactService: ContactService,
    private formBuilder: FormBuilder,
  ) { 
    this.filterForm = this.formBuilder.group({
      showRemoved:  ['', Validators.required]
    });
  }

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
  }

  delete(id: number) {
    let msg = 'Do you really want to remove the person?';
    if (confirm(msg)) {
      this.contactService.remove(id).subscribe((result: Result) => {
        if (result.success) {
          setTimeout(() => {
            alert('Person remove success!');
            window.location.reload();
          }, 1000);
        } else {
          alert(result.messages);
        }
      });
    }
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

  public filter() {
    this.contactService.filterList(this.showRemoved).subscribe(data => {
      this.contacts = data;
    });
  }

  public edit(id: number) {
    this.router.navigate(['person/edit/' + id]);
  }

}
