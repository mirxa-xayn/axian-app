import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from './service/app.layout.service';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html',
})
export class AppMenuComponent implements OnInit {
    model: any[] = [];

    constructor(public layoutService: LayoutService) {}

    ngOnInit() {
        this.model = [
            {
                label: 'Home',
                items: [
                    {
                        label: 'Dashboard',
                        icon: 'pi pi-fw pi-home',
                        routerLink: ['/main'],
                    },
                ],
            },
            {
                label: 'Employees',
                items: [
                    {
                        label: 'All Employees',
                        icon: 'pi pi-fw pi-list',
                        routerLink: ['/main/emp'],
                    },
                    {
                        label: 'Add Employee',
                        icon: 'pi pi-fw pi-user-plus',
                        routerLink: ['/main/emp/add'],
                    },
                ],
            },
        ];
    }
}
