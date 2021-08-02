import { Parcela } from "./parcela";

export interface Titulo {
    Numero: number,
    Devedor: string,
    DevedorCPF: string,
    PorcentagemJuros: string,
    PorcentagemMulta: string,
    Parcela: Parcela[],
};