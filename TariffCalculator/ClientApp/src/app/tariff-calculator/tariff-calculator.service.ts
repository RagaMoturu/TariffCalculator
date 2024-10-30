import { Injectable } from '@angular/core';
import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Tariff } from '../models/tariff';

@Injectable()
export class TariffService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  getTariffs(consumption) {
     return this.http.get<Tariff[]>(this.baseUrl + 'api/TariffCalculation/GetTariffs?consumption=' + consumption);
  }
}
