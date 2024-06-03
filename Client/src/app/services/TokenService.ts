import { HttpClient } from "@angular/common/http";
import { Injectable, Signal, WritableSignal, computed, inject, signal } from "@angular/core";
import { LoginResponse, loginUser } from "../models/loginUser";
import { pipe, map, single } from "rxjs";


@Injectable({
    providedIn: "root"
})

export class TokenService {

    private readonly http: HttpClient = inject(HttpClient);
    private readonly loginUrl: string = "https://localhost:4200/api/account/login";

    private _currentUserSource: WritableSignal<LoginResponse> = signal({userName: '', token: ''});
 
    public LoggedIn: WritableSignal<boolean> = signal<boolean>(false);

    public login(user: loginUser){

        return this.http.post<LoginResponse>(this.loginUrl, user).pipe(map((res: LoginResponse) => {
            if(res.userName) {
                this._currentUserSource.set(res);
                localStorage.setItem('user', JSON.stringify(res.userName))
            }
        }))
    }

    public currentUser$(): Signal<LoginResponse> {
        return computed(this._currentUserSource);
    }

    public logout() {
        this._currentUserSource.set({userName: '', token: ''});
        localStorage.removeItem('user');
    }
}