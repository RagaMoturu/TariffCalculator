import { BrowserModule } from '@angular/platform-browser';
import { NgModule, LOCALE_ID } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { registerLocaleData } from '@angular/common';
import localeDe from '@angular/common/locales/de';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { TariffCalculatorComponent } from './tariff-calculator/tariff-calculator.component';
import { TariffService } from './tariff-calculator/tariff-calculator.service';

registerLocaleData(localeDe);

@NgModule({
  declarations: [
    AppComponent,
    TariffCalculatorComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule
  ],
  providers: [
    TariffService,
    { provide: LOCALE_ID, useValue: 'de-DE'}
],
  bootstrap: [AppComponent]
})
export class AppModule { }
