import { FormControl, ValidatorFn } from '@angular/forms';

export function validateCpf(c: FormControl): ValidatorFn {
    let valido: boolean = true;
    var soma = 0;
    var resto;
    var inputCPF = c.value?.replaceAll('.', '').replaceAll('-', '').replaceAll('_', '').trim();

    if (inputCPF?.length == 11) {

        if (inputCPF == '00000000000')
            valido = false;

        if (valido) {
            for (let i = 1; i <= 9; i++) soma = soma + parseInt(inputCPF.substring(i - 1, i)) * (11 - i);
            resto = (soma * 10) % 11;

            if ((resto == 10) || (resto == 11))
                resto = 0;

            if (resto != parseInt(inputCPF.substring(9, 10)))
                valido = false;
        }

        if (valido) {
            soma = 0;
            for (let i = 1; i <= 10; i++) soma = soma + parseInt(inputCPF.substring(i - 1, i)) * (12 - i);
            resto = (soma * 10) % 11;

            if ((resto == 10) || (resto == 11)) resto = 0;
            if (resto != parseInt(inputCPF.substring(10, 11)))
                valido = false;
        }

        console.log(valido);
    }

    return (): { [key: string]: any } | null =>
            valido
                ? null : { invalid: true };
}