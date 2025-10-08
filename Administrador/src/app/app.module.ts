import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideRouter, Routes } from '@angular/router';
import { provideHttpClient } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

const routes: Routes = [];
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [provideRouter(routes),
    provideHttpClient()]
    ,
  bootstrap: [AppComponent]
})
export class AppModule { }
