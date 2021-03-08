import { User } from "../userAndRoles/user";
import { Result } from "./result";

export class AuthMessage extends Result {

    constructor() {
        super();
    }

    public token: string = "";
    public userInfo: User = new User();

}