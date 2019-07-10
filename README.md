# micro-ondas-web
Uma api simulando um micro-ondas

## Funcionamento
Utilizando as rotas abaixo você conseguirá iniciar uma simulação de micro ondas.
Quando mandada uma requisição para iniciar o aquecimento, é necessário consultar até que ele seja terminado para obter a mensagem de retorno.
Você pode pesquisar as programas ou criar seu próprio programa

# rotas

## get http://localhost:5000/api/turnOn
Retorna todas os programas existentes. Se nenhum programa for criado ele retorna os 3 programas padrão registrados.

### Parâmetros
N/A

## get http://localhost:5000/api/checkheat
Verifica se o aquecimento foi finalizado

### Parâmetros
N/A


## GET  http://localhost:5000/api/turnon/params
Começa o aquecimento pelo nome do programa informado

### Parâmetros
Querystring no formato:
`http://localhost:5000/api/turnon/params?time=10&power=1`



## GET  http://localhost:5000/api/turnon/turnonbyname
Começa o aquecimento pelo nome do programa informado

### Parâmetros
Querystring no formato:
`http://localhost:5000/api/turnon/turnonbyname?programname=chicken`


## GET  http://localhost:5000/api/turnon/programbyname
Retorna os dados de algum programa, buscado pelo seu nome

### Parâmetros
Querystring no formato:
`http://localhost:5000/api/turnon/programbyname?programname=chicken`



## POST  http://localhost:5000/api/turnOn
Adiciona um programa

### Parâmetros
Passar um json no body com o formato:

{  
   "charHeating":"-",
   "programName":"Presunto",
   "useInstructions":"mata o porco",
   "time":10,
   "power":1
}


# OBS:
Por motivos de facilidade as rotas ficaram todas "juntas", estando ciente que por boas práticas seria necessário dividi-las

