# DesafioFULL

Configurações Necessárias:

Front-End
- No arquivo de environment configurar na JSON a urlAPI de acordo com a porta que o Back irá utilizar.

Back-End
- Necessário rodar o seguinte Script para realizar a gravação das tabelas:

```
CREATE TABLE Titulo(
Id INTEGER IDENTITY(1,1) PRIMARY KEY,
Numero BIGINT NOT NULL,
NomeDevedor VARCHAR(200) NOT NULL,
CpfDevedor CHAR(14) NOT NULL,
PorcentagemJuros DECIMAL(18,2) NOT NULL,
PorcentagemMulta DECIMAL(18,2) NOT NULL
)

CREATE TABLE Parcela(
	Id INTEGER IDENTITY(1,1) PRIMARY KEY,
	Titulo INTEGER NOT NULL,
	Numero INTEGER NOT NULL,
	DataVencimento Date2 NOT NULL,
	Valor DECIMAL(18,2),
	FOREIGN KEY (Titulo) REFERENCES Titulo(Id)
)
```

Após realizado necessário configurar a conexão com o banco no arquivo 'appsettings.json'
