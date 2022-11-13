import { Component } from '@angular/core';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import { AuthService } from 'src/app/demo/service/auth.service';
import { UserInfo } from 'src/app/demo/api/user';
import { Router } from '@angular/router';
import { ReturnModel } from 'src/app/demo/api/returnModel';
import { MessageService } from 'primeng/api';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styles: [
        `
            :host ::ng-deep .pi-eye,
            :host ::ng-deep .pi-eye-slash {
                transform: scale(1.6);
                margin-right: 1rem;
                color: var(--primary-color) !important;
            }
        `,
    ],
    providers: [MessageService],
})
export class LoginComponent {
    valCheck: string[] = ['remember'];

    password!: string;
    email!: string;

    constructor(
        public _layoutService: LayoutService,
        public _authService: AuthService,
        private _router: Router,
        private _msgService: MessageService
    ) {}

    userLogin() {
        if (
            this.email &&
            this.email != '' &&
            this.password &&
            this.password != ''
        ) {
            let obj: UserInfo = {
                Username: this.email,
                Password: this.password,
            };

            this._authService
                .verifyUserCredential(obj)
                .subscribe((response) => {
                    if (response.body != undefined) {
                        let res = response.body as ReturnModel;
                        if (
                            res.data != '' &&
                            res.data != null &&
                            res.data != undefined
                        ) {
                            localStorage.setItem('t_id', res.data);
                            this._router.navigate(['/main']);
                            this._msgService.add({
                                severity: 'success',
                                summary: 'Logged In Successfully',
                                detail: 'Via Axian',
                            });
                        } else {
                            localStorage.clear();
                            this._router.navigate(['/auth/login']);
                            this._msgService.add({
                                severity: 'error',
                                summary: 'Invalid Credentials',
                                detail: 'Via Axian',
                            });
                        }
                    } else {
                        localStorage.clear();
                        this._router.navigate(['/auth/login']);
                        this._msgService.add({
                            severity: 'error',
                            summary: 'Invalid Credentials',
                            detail: 'Via Axian',
                        });
                    }
                });
        }
    }
}
