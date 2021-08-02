import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function validateCpf(): ValidatorFn {
    return (control: AbstractControl): ValidationErrors | null => {
        let valido: boolean = true;
        var soma = 0;
        var resto;
        const value = control.value?.replaceAll('.', '').replaceAll('-', '').replaceAll('_', '').trim();

        if (!value) {
            return null;
        }

        if (value?.length == 11) {

            if (value == '00000000000')
                valido = false;

            if (valido) {
                for (let i = 1; i <= 9; i++) soma = soma + parseInt(value.substring(i - 1, i)) * (11 - i);
                resto = (soma * 10) % 11;

                if ((resto == 10) || (resto == 11))
                    resto = 0;

                if (resto != parseInt(value.substring(9, 10)))
                    valido = false;
            }

            if (valido) {
                soma = 0;
                for (let i = 1; i <= 10; i++) soma = soma + parseInt(value.substring(i - 1, i)) * (12 - i);
                resto = (soma * 10) % 11;

                if ((resto == 10) || (resto == 11)) resto = 0;
                if (resto != parseInt(value.substring(10, 11)))
                    valido = false;
            }
        }

        return !valido ? { cpfInvalido: true } : null;
    }
}