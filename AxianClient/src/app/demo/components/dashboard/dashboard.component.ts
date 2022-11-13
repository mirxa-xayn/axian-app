import { Component, OnInit, OnDestroy } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Product } from '../../api/product';
import { ProductService } from '../../service/product.service';
import { Subscription } from 'rxjs';
import { LayoutService } from 'src/app/layout/service/app.layout.service';
import { EmployeeService } from '../../service/employee.service';

@Component({
    templateUrl: './dashboard.component.html'
})
export class DashboardComponent implements OnInit {
    totalEmployees: number = 0;

    constructor(
        public layoutService: LayoutService,
        private _empService: EmployeeService
    ) {}

    ngOnInit() {
        this.getDashboardData();
    }

    getDashboardData() {
        this._empService.GetTotalEmployees().subscribe(res => {
            this.totalEmployees = res.body as any;
        });
    }
}
