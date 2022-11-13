import { Component } from '@angular/core';
import { Employee } from 'src/app/demo/api/user';
import { EmployeeService } from 'src/app/demo/service/employee.service';
import { MessageService } from 'primeng/api';

@Component({
    templateUrl: './formlayoutdemo.component.html',
    providers: [MessageService]
})
export class FormLayoutDemoComponent {
    obj: Employee;

    constructor(
        public _empService: EmployeeService,
        private messageService: MessageService
    ) {
        this.obj = new Employee();
    }

    addNewEmployee() {
        if (this.checkObj()) {
            this._empService.AddNewEmployee(this.obj).subscribe(res => {
                debugger;
                if (res.body) {
                    this.messageService.add({
                        severity: 'success',
                        summary: 'Record Added',
                        detail: 'Via Axian'
                    });
                    this.obj = new Employee();
                } else {
                    this.messageService.add({
                        severity: 'error',
                        summary: 'Record Not Added',
                        detail: 'Via Axian'
                    });
                }
            });
        }
    }

    checkObj(): Boolean {
        if (
            this.obj != null &&
            this.obj.Name != '' &&
            this.obj.Name &&
            this.obj.Age &&
            this.obj.Age > 0 &&
            this.obj.DOB &&
            this.obj.Address != ''
        ) {
            return true;
        } else {
            return false;
        }
    }
}
