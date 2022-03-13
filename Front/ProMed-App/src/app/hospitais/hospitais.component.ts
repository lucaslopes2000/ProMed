import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-hospitais',
  templateUrl: './hospitais.component.html',
  styleUrls: ['./hospitais.component.scss']
})
export class HospitaisComponent implements OnInit {

  public hospitais: any = [];
  public hospitaisFiltrados: any = [];

  widthImg: number = 100;
  marginImg: number = 2;
  exibirImg: boolean = true;
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.hospitaisFiltrados = this.filtroLista ? this.filtrarHospitais(this.filtroLista) : this.hospitais;
  }

  filtrarHospitais(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.hospitais.filter(
      (hospital: { nome: string; endereco: string; }) => hospital.nome.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      hospital.endereco.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getHospitais();
  }

  estadoImg() {
    this.exibirImg = !this.exibirImg;
  }

  public getHospitais(): void {
    this.http.get('https://localhost:5001/api/hospitais').subscribe(
    response => {
      this.hospitais = response;
      this.hospitaisFiltrados = this.hospitais;
    },
    error => console.log(error)
    );
  }

}
