import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroTituloComponent } from './pages/cadastro-titulo/cadastro-titulo.component';
import { PaginaInexistenteComponent } from './pages/pagina-inexistente/pagina-inexistente.component';

const routes: Routes = [
    {path: 'cadastro-titulo', component: CadastroTituloComponent},
    {path: '', redirectTo: '/cadastro-titulo', pathMatch: 'full'},                    
    {path: '**', component: PaginaInexistenteComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
