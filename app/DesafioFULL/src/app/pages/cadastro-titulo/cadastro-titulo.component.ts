import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Titulo } from '../../interface/titulo';
import { validateCpf } from '../../validators/CpfValidator';

@Component({
  selector: 'cadastro-titulo',
  templateUrl: './cadastro-titulo.component.html',
  styleUrls: ['./cadastro-titulo.component.css']
})
export class CadastroTituloComponent {

  dataSource: Titulo[] = [];

  tituloForm = new FormGroup({
    numero: new FormControl('', [Validators.required, Validators.maxLength(10)]),
    devedorNome: new FormControl('', [Validators.required, Validators.maxLength(200)]),
    devedorCpf: new FormControl('', [Validators.required, Validators.minLength(14), Validators.maxLength(14), validateCpf()]),
    porcentagemJuros: new FormControl('0,00', [Validators.required, Validators.min(0.01), Validators.maxLength(6)]),
    porcentagemMulta: new FormControl('0,00', [Validators.required, Validators.min(0.01), Validators.maxLength(6)]),
  });

  cpfMask = [/\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/, /\d/];

  colunaDetalheParcela = [
    {
      dataField: 'Numero',
      caption: 'Número',
      width: 150,
      dataType: 'number',
    },
    {
      dataField: 'DataVencimento',
      caption: 'Data Vencimento',
      width: 150,
      dataType: 'string',
      align: 'left'
    },
    {
      dataField: 'Valor',
      caption: 'Valor',
      width: 200,
      dataType: 'string',
      align: 'left'
    }
  ];

  constructor(titleService: Title) {
    titleService.setTitle('Cadastro de Título');
    
    this.dataSource.push({
      Devedor: 'Thais Tozatto',
      DevedorCPF: '555.555.555-55',
      Numero: 123456,
      PorcentagemJuros: '10,00',
      PorcentagemMulta: '10,00',
      Parcela: [{
        DataVencimento: '15/12/2020',
        Numero: 1,
        Valor: '100,98'
      },
      {
        DataVencimento: '28/07/2021',
        Numero: 2,
        Valor: '200,89'
      }]
    },
      {
        Devedor: 'Elton Tozatto',
        DevedorCPF: '111.111.111-44',
        Numero: 923456,
        PorcentagemJuros: '10,66',
        PorcentagemMulta: '9,89',
        Parcela: [{
          DataVencimento: '04/01/1999',
          Numero: 1,
          Valor: '256.99'
        },
        {
          DataVencimento: '25/03/1991',
          Numero: 2,
          Valor: '245.87'
        }]
      });
  }

  gravar(){
    console.log(this.tituloForm.controls.devedorCpf);
  }

  limpar(){
    this.tituloForm.reset();
    this.tituloForm.controls.porcentagemJuros.setValue('0,00');
    this.tituloForm.controls.porcentagemMulta.setValue('0,00');
  }
}
