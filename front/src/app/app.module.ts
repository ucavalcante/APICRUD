import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SegurosComponent } from './component/seguros/seguros.component';
import { HttpClientModule } from '@angular/common/http';
import { DateToLocalDateStringPipe } from './pipe/date-to-local-date-string.pipe';

@NgModule({
  declarations: [
    AppComponent,
    SegurosComponent,
    DateToLocalDateStringPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
