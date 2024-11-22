Adicione a seguinte documenta��o no README.md:

Rotas Implementadas:

-----GET /health

Descri��o: Verifica o status do servi�o.
Resposta: json
Copiar c�digo
{
  "status": "Service is running",
  "timestamp": "2024-11-21T12:00:00Z"
}
Status Codes:
200 OK: Servi�o est� ativo.

-----POST /consumo

Descri��o: Registra um consumo de energia.

Request Body: json
Copiar c�digo
{
  "consumption": 120.5
}

Resposta: json
Copiar c�digo
{
  "id": "unique-id",
  "consumption": 120.5,
  "timestamp": "2024-11-21T12:00:00Z"
}
Status Codes:
201 Created: Consumo registrado.
400 Bad Request: Dados inv�lidos.

-----GET /consumo

Descri��o: Retorna todos os consumos registrados.
Resposta:
json
Copiar c�digo
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