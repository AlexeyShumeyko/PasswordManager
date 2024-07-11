import { Routes } from '@angular/router';
import { RecordsListComponent } from './components/records-list/records-list.component';
import { RecordFormComponent } from './components/record-form/record-form.component';

export const routes: Routes = [
    { path:"", redirectTo: "/records-list", pathMatch: "full" },
    { path:"records-list", component: RecordsListComponent },
    { path:"record-form", component: RecordFormComponent }
];
