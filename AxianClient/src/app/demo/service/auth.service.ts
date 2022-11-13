import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { UserInfo } from '../api/user';
import { environment } from 'src/environments/environment';
import { map, catchError } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthService {
    constructor(private _http: HttpClient) {}

    verifyUserCredential(data: UserInfo) {
        let authorizationData =
            'Basic ' + btoa(data.Username + ':' + data.Password);
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                Authorization: authorizationData
            }),
            observe: 'response' as 'response'
        };
        let body = new HttpParams();
        return this._http
            .post(environment.api + 'api/auth', body, httpOptions)
            .pipe(map(res => res));
    }

    userSignUp(data: UserInfo) {
        let authorizationData =
            'Basic ' + btoa(data.Username + ':' + data.Password);
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                Authorization: authorizationData
            }),
            observe: 'response' as 'response'
        };
        let body = new HttpParams();
        return this._http
            .post(environment.api + 'api/auth/signup', body, httpOptions)
            .pipe(map(res => res));
    }

    logout() {
        localStorage.clear();
    }
}
