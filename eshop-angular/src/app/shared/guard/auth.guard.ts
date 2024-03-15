import { Injectable } from '@angular/core';
import {Router } from '@angular/router';

// ref: https://stackoverflow.com/questions/75602900/angular-how-to-resolve-canactivate-deprecated-in-angular-15-auth-guard

@Injectable({
    providedIn: 'root'
  })
export class AuthGuard {
    constructor(private router: Router) {}

    canActivate() {
        if (localStorage.getItem('isLoggedin')) {
            return true;
        }

        this.router.navigate(['/login']);
        return false;
    }
}
