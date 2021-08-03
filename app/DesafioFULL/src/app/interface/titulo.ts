import { Parcela } from "./parcela";

export interface Titulo {
    numero: number,
    nomeDevedor: string,
    cpfDevedor: string,
    porcentagemJuros: string,
    porcentagemMulta: string,
    parcela: Parcela[],
};