Adicione a seguinte documentação no README.md:

Rotas Implementadas:

-----GET /health

Descrição: Verifica o status do serviço.
Resposta: json
Copiar código
{
  "status": "Service is running",
  "timestamp": "2024-11-21T12:00:00Z"
}
Status Codes:
200 OK: Serviço está ativo.

-----POST /consumo

Descrição: Registra um consumo de energia.

Request Body: json
Copiar código
{
  "consumption": 120.5
}

Resposta: json
Copiar código
{
  "id": "unique-id",
  "consumption": 120.5,
  "timestamp": "2024-11-21T12:00:00Z"
}
Status Codes:
201 Created: Consumo registrado.
400 Bad Request: Dados inválidos.

-----GET /consumo

Descrição: Retorna todos os consumos registrados.
Resposta:
json
Copiar código
[
  {
    "id": "unique-id",
    "consumption": 100,
    "timestamp": "2024-11-21T12:00:00Z"
  }
]
Status Codes:
200 OK: Dados retornados.
404 Not Found: Nenhum dado encontrado.