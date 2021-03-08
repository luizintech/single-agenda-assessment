import { Result } from "./result";

export class AuthMessage extends Result {

    constructor() {
        super();
    }

    public token: string = "";

}