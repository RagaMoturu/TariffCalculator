import { Component } from '@angular/core';
import { TariffService } from './tariff-calculator.service';
import { Tariff } from '../models/tariff';

@Component({
  selector: 'app-tariff-calculator',
  templateUrl: './tariff-calculator.component.html',
  styleUrls: ['./tariff-calculator.component.css']
})

export class TariffCalculatorComponent {
  
  tariffs: Tariff[];
  consumption: number;

  constructor(private tariffService: TariffService) { }

  getTariffs() {
    this.tariffs = null;
    this.tariffService.getTariffs(this.consumption)
      .subscribe(
          result => {
            this.tariffs = result;
          },
          error => console.error(error)
      );
  }

}
