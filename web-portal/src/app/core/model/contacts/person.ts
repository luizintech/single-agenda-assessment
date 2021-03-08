import { BaseModel } from "../base/base-model";
import { Address } from "../location/address";
import { Gender } from "./gender";
import { PersonType } from "./person-type";

export class Person extends BaseModel {

    constructor(){
        super();
    }

    public name: string = "";
    public email: string = "";
    public personType: PersonType; 
    public document: string = "";
    public tradeName: string = "";
    public birthday: Date;
    public gender: Gender;
    public adresses: Address[] = [];

}