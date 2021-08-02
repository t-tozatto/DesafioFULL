import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { DxDataGridModule } from 'devextreme-angular/ui/data-grid';
import { DxTemplateModule } from 'devextreme-angular';
import { DxBulletModule } from 'devextreme-angular/ui/bullet';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { DevExtremeModule } from 'devextreme-angular';
import { MasterDetailComponent } from './components/master-detail/master-detail.component';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { TextMaskModule } from 'angular2-text-mask';
import { MatButtonModule } from '@angular/material/button';
import { MatToolbarModule } from '@angular/material/toolbar';
import { CadastroTituloComponent } from './pages/cadastro-titulo/cadastro-titulo.component';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';
import { PaginaInexistenteComponent } from './pages/pagina-inexistente/pagina-inexistente.component';

@NgModule({
  declarations: [
    AppComponent,
    MasterDetailComponent,
    CadastroTituloComponent,
    PaginaInexistenteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    DxDataGridModule,
    DxTemplateModule,
    DxBulletModule,
    DevExtremeModule,
    MatExpansionModule,
    MatIconModule,
    MatInputModule,
    MatFormFieldModule,
    ReactiveFormsModule,
    TextMaskModule,
    MatButtonModule,
    MatToolbarModule,
    MatSidenavModule,
    MatListModule,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
platformBrowserDynamic().bootstrapModule(AppModule);