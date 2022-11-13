import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                data: { breadcrumb: 'Detail' },
                loadChildren: () =>
                    import('./table/tabledemo.module').then(
                        m => m.TableDemoModule
                    )
            },

            {
                path: 'add',
                data: { breadcrumb: 'Add Employee' },
                loadChildren: () =>
                    import('./formlayout/formlayoutdemo.module').then(
                        m => m.FormLayoutDemoModule
                    )
            },

            { path: '**', redirectTo: '/notfound' }
        ])
    ],
    exports: [RouterModule]
})
export class UIkitRoutingModule {}
