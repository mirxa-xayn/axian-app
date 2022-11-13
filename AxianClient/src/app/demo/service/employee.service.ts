import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { UserInfo, Employee } from '../api/user';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class EmployeeService {
    constructor(private _http: HttpClient) {}

    private getHeaders() {
        let headers = new HttpHeaders();
        headers = headers.append('Access-Control-Allow-Origin', '*');
        headers = headers.append('Access-Control-Allow-Credentials', 'true');
        headers = headers.append('Access-Control-Allow-Headers', '*');
        headers = headers.append(
            'Authorization',
            'Bearer ' + localStorage.getItem('t_id')
        );
        headers = headers.append('Response-Type', 'text');

        headers = headers.append(
            'Content-Type',
            'application/json; charset=UTF-8'
        );
        headers = headers.append('Accept', 'application/json');
        return headers;
    }

    GetAllEmployees() {
        const httpOptions = {
            headers: this.getHeaders(),
            observe: 'response' as 'response'
        };
        let body = new HttpParams();
        return this._http
            .get<Employee>(
                environment.api + 'api/employee/GetAllEmployees',
                httpOptions
            )
            .pipe(map(res => res));
    }

    GetTotalEmployees() {
        const httpOptions = {
            headers: this.getHeaders(),
            observe: 'response' as 'response'
        };
        return this._http
            .get<Employee>(
                environment.api + 'api/employee/GetTotalEmployees',
                httpOptions
            )
            .pipe(map(res => res));
    }

    AddNewEmployee(data: Employee) {
        const httpOptions = {
            headers: this.getHeaders(),
            observe: 'response' as 'response'
        };
        return this._http
            .post<Employee>(
                environment.api + 'api/employee/AddNewEmployee',
                data,
                httpOptions
            )
            .pipe(map(res => res));
    }

    DeleteEmployee(data: Employee) {
        const httpOptions = {
            headers: this.getHeaders(),
            observe: 'response' as 'response'
        };

        return this._http
            .post<Employee>(
                environment.api + 'api/employee/DeleteEmployee',
                data,
                httpOptions
            )
            .pipe(map(res => res));
    }

    UpdateEmployee(data: Employee) {
        const httpOptions = {
            headers: this.getHeaders(),
            observe: 'response' as 'response'
        };
        return this._http
            .post<Employee>(
                environment.api + 'api/employee/UpdateEmployee',
                data,
                httpOptions
            )
            .pipe(map(res => res));
    }
}
