import { BaseModel } from "../base/base-model";

export class User extends BaseModel {

    constructor() {
        super();
    }

    public id: number = 0;
    public name: string = "";
    public email: string = "";
    public password: string = "";
}