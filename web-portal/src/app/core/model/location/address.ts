import { BaseModel } from "../base/base-model";

export class Address extends BaseModel {

    constructor() {
        super();
    }

    public zipCode: string = "";
    public country: string = "";
    public state: string = "";
    public city: string = "";
    public description: string = "";
    public personId: number = 0;

}