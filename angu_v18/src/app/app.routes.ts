import { Routes } from '@angular/router';
import { ContactComponent } from './contact/contact.component';
import { HomeComponent } from './home/home.component';

export const routes: Routes = [
    {path : "contact" , component : ContactComponent},
    {path: "", component: HomeComponent}
];
