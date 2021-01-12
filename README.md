# BancoBari
Um exemplo simples de comunicação entre Microserviços com Kafka

Requisito Dokcer instalado.
Na pasta raiz execute docker-compose up -d

Após a execução do docker-compose já podemos rodar as duas APIs ViniApi e MacApi no Visual Studio 2019.

ViniApi é producer de mensagens de MacApi e consumer da MacApi;
Para iniciar o envio das mensagens a cada 5 segundos, basta executar o endpoint disponibilizado pelo Swagger e será inciado o envio das mensagens, no console é possível ver os logs de envio e recebimento das mensagens.

MacApi é producer de mensagens de ViniApi e consumer da ViniApi;
Para enviar uma mensagens de Customer, basta executar o endpoint disponibilizado pelo swagger e será enviada uma mensagem, no console é possível ver os logs de envio e recebimento das mensagens.

