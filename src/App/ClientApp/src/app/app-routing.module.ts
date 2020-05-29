import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./home/home.module').then(m => m.HomeModule)
    },
    {
        path: 'medicos',
        loadChildren: () => import('./medicos/medicos.module').then(m => m.MedicoModule)
    },
    {
        path: 'pacientes',
        loadChildren: () => import('./pacientes/pacientes.module').then(m => m.PacientesModule)
    },

]

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule {}

