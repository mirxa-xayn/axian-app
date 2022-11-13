import { Injectable } from '@angular/core';
import {
    ActivatedRouteSnapshot,
    Route,
    Router,
    UrlSegment,
    RouterStateSnapshot,
    CanActivate,
    CanActivateChild,
    CanLoad
} from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate, CanActivateChild, CanLoad {
    constructor(private router: Router) {
        debugger;
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        let url: string = state.url;

        return this.checkLogin(url);
    }
    canActivateChild(
        childRoute: ActivatedRouteSnapshot,
        state: RouterStateSnapshot
    ) {
        return this.canActivate(childRoute, state);
    }
    canLoad(route: Route, segments: UrlSegment[]) {
        let url = `/${route.path}`;

        return this.checkLogin(url);
    }

    checkLogin(url: string): boolean {
        if (
            localStorage.getItem('t_id') != null &&
            localStorage.getItem('t_id') != ''
        ) {
            return true;
        } else {
            this.router.navigate(['auth/access']);
            return false;
        }
    }
}
