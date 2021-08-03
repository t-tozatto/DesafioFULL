import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { Parcela } from 'src/app/interface/parcela';
import { TituloService } from 'src/app/services/titulo/titulo.service';
import { Titulo } from '../../interface/titulo';
import { validateCpf } from '../../validators/CpfValidator';
import { DatePipe } from '@angular/common'
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'cadastro-titulo',
  templateUrl: './cadastro-titulo.component.html',
  styleUrls: ['./cadastro-titulo.component.css']
})
export class CadastroTituloComponent {

  titulosGravados: Titulo[] = [];
  parcela: Parcela[] = [];
  parcelaApi: Parcela[] = [];
  minDate: Date = new Date();

  tituloForm = new FormGroup({
    numero: new FormControl('', [Validators.required, Validators.maxLength(10)]),
    devedorNome: new FormControl('', [Validators.required, Validators.maxLength(200)]),
    devedorCpf: new FormControl('', [Validators.required, Validators.minLength(14), Validators.maxLength(14), validateCpf()]),
    porcentagemJuros: new FormControl('0,00', [Validators.required, Validators.min(0.01), Validators.maxLength(6)]),
    porcentagemMulta: new FormControl('0,00', [Validators.required, Validators.min(0.01), Validators.maxLength(6)]),
  });

  parcelaForm = new FormGroup({
    numero: new FormControl('', [Validators.required, Validators.maxLength(10)]),
    dataVencimento: new FormControl(new Date(), [Validators.required]),
    valor: new FormControl('0,00', [Validators.required, Validators.min(0.01), Validators.maxLength(6)]),
  });

  cpfMask = [/\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '.', /\d/, /\d/, /\d/, '-', /\d/, /\d/];

  colunaDetalheParcela = [
    {
      dataField: 'numero',
      caption: 'Número',
      width: 150,
      dataType: 'number',
    },
    {
      dataField: 'dataVencimento',
      caption: 'Data Vencimento',
      width: 150,
      dataType: 'string',
      align: 'left'
    },
    {
      dataField: 'valor',
      caption: 'Valor',
      width: 200,
      dataType: 'string',
      align: 'left'
    }
  ];

  constructor(titleService: Title, private tituloService: TituloService,
    public datepipe: DatePipe,
    private _snackBar: MatSnackBar) {
    titleService.setTitle('Cadastro de Título');
    this.obterTitulos();
  }

  async obterTitulos() {
    this.titulosGravados = await this.tituloService.get().toPromise();
  }

  gravar() {
    this.tituloService.post({
      nomeDevedor: this.tituloForm.controls.devedorNome.value,
      cpfDevedor: this.tituloForm.controls.devedorCpf.value,
      numero: this.tituloForm.controls.numero.value,
      parcela: this.parcelaApi,
      porcentagemJuros: this.tituloForm.controls.porcentagemJuros.value,
      porcentagemMulta: this.tituloForm.controls.porcentagemMulta.value,
    }).toPromise();

    this.obterTitulos();

    this.limpar();
    this.limparParcela();

    this.openSnackBar('Título gravado com sucesso!');
  }

  limpar() {
    this.tituloForm.reset();
    this.tituloForm.controls.numero.setValue(0);
    this.tituloForm.controls.porcentagemJuros.setValue('0,00');
    this.tituloForm.controls.porcentagemMulta.setValue('0,00');
    this.tituloForm.markAsPristine();
  }

  adicionarParcela() {
    if (!this.parcela){
      this.parcela = [];
      this.parcelaApi = [];
    }

    let data;
    
    try{
      data = this.parcelaForm.controls.dataVencimento.value.toDate();
    }
    catch{
      data = this.parcelaForm.controls.dataVencimento.value;
    }

    const date = this.datepipe.transform(data, 'dd/MM/yyyy');

    this.parcela.push({
      dataVencimento: date ? date : '',
      numero: this.parcelaForm.controls.numero.value,
      valor: this.getFormattedPrice(this.parcelaForm.controls.valor.value)
    });

    this.parcelaApi.push({
      dataVencimento: data,
      numero: this.parcelaForm.controls.numero.value,
      valor: this.parcelaForm.controls.valor.value
    });

    this.limparParcela();
  }

  getFormattedPrice(price: number) {
    return new Intl.NumberFormat('pt-BR', { style: 'currency', currency: 'BRL' }).format(price);
}

  limparParcela() {
    this.parcelaForm.reset();
    this.parcelaForm.controls.valor.setValue('0,00');
    this.parcelaForm.controls.dataVencimento.setValue(new Date());
    this.parcelaForm.markAsPristine();
  }

  openSnackBar(message: string) {
    this._snackBar.open(message, '', {
      horizontalPosition: 'center',
      verticalPosition: 'top',
      panelClass: ['snackbar-sucesso'],
      duration: 3000
    });
  }
}
