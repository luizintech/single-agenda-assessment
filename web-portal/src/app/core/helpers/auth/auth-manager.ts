import { AuthMessage } from "../../model/messages/authMessage";

export class AuthManager {

    private sessionInfo: string;
    private userName: string;
    private userEmail: string;

    constructor() {
        this.sessionInfo = localStorage.getItem("__sm_");
        this.userName = localStorage.getItem("__nmUser_");
        this.userEmail = localStorage.getItem("__mailUser_");
    }

    public getSessionInfo() {
        return this.sessionInfo;
    }

    public getUserName() {
        return this.userName;
    }

    public getUserEmail() {
        return this.userEmail;
    }

    public setSessionInfo(auth: AuthMessage) {
        localStorage.setItem("__sm_", auth.token);
        localStorage.setItem("__nmUser_", auth.userInfo.name);
        localStorage.setItem("__mailUser_", auth.userInfo.email);
    }

    public isValid() {
        return ((this.sessionInfo != '') && (this.sessionInfo != undefined) &&
            (this.userEmail != '') && (this.userEmail != undefined) &&
            (this.userName != '') && (this.userName != undefined));
    }

}