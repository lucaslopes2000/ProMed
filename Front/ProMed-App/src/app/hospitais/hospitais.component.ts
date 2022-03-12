import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-hospitais',
  templateUrl: './hospitais.component.html',
  styleUrls: ['./hospitais.component.scss']
})
export class HospitaisComponent implements OnInit {

  public hospitais: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getHospitais();
  }

  public getHospitais(): void {
    this.http.get('https://localhost:5001/api/hospitais').subscribe(
      response => this.hospitais = response,
      error => console.log(error)
    );
  }

}
