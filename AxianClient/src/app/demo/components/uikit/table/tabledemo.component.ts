import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Customer, Representative } from 'src/app/demo/api/customer';
import { CustomerService } from 'src/app/demo/service/customer.service';
import { Product } from 'src/app/demo/api/product';
import { ProductService } from 'src/app/demo/service/product.service';
import { Table } from 'primeng/table';
import { MessageService, ConfirmationService } from 'primeng/api';
import { EmployeeService } from 'src/app/demo/service/employee.service';
import { Employee } from 'src/app/demo/api/user';

interface expandedRows {
    [key: string]: boolean;
}

@Component({
    templateUrl: './tabledemo.component.html',
    providers: [MessageService, ConfirmationService]
})
export class TableDemoComponent implements OnInit {
    empList: Employee[];
    display: boolean = false;

    updateObj: Employee;

    constructor(
        private _employeeService: EmployeeService,
        private messageService: MessageService
    ) {
        this.empList = [];
        this.updateObj = new Employee();
    }

    ngOnInit() {
        this.getAllEmployees();
    }

    getAllEmployees() {
        this._employeeService.GetAllEmployees().subscribe(response => {
            if (response.body != undefined && response.body != null) {
                this.empList = response.body as any;
            }
        });
    }

    openUpdateModel(emp: any) {
        debugger;
        this.updateObj = {
            Address: emp.address,
            Age: emp.age,
            DOB: emp.dob,
            EmpId: emp.empId,
            Name: emp.name
        };
        this.display = true;
    }

    updateEmployee() {
        if (this.updateObj.EmpId && this.updateObj.EmpId > 0) {
            this.display = false;
            this._employeeService
                .UpdateEmployee(this.updateObj)
                .subscribe(res => {
                    if (res.body) {
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Record Updated',
                            detail: 'Via Axian'
                        });
                    } else {
                        this.messageService.add({
                            severity: 'error',
                            summary: 'Record Not Updated',
                            detail: 'Via Axian'
                        });
                    }
                    this.getAllEmployees();
                });
        }
    }

    deleteEmployee(emp: Employee) {
        this._employeeService.DeleteEmployee(emp).subscribe(res => {
            if (res.body) {
                this.messageService.add({
                    severity: 'success',
                    summary: 'Record Deleted',
                    detail: 'Via Axian'
                });
                this.getAllEmployees();
            } else {
                this.messageService.add({
                    severity: 'error',
                    summary: 'Record Not Deleted',
                    detail: 'Via Axian'
                });
            }
        });
    }
}
