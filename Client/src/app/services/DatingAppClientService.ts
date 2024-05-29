import { HttpClient } from "@angular/common/http";
import { Inject, Injectable, inject } from "@angular/core";
import { Observable } from "rxjs";
import { AppUser } from "../models/appUser";


@Injectable({
    providedIn: 'root'
})


export class DatingAppClientService {

    private apiUsersUrl: string = "https://localhost:5001/api/users";
    private readonly http: HttpClient = inject(HttpClient);
    

    public getUsers(): Observable<any> {
        return this.http.get(this.apiUsersUrl);
    }
}