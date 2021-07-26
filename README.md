## Integração Cielo API-3.0
Biblioteca de integração com Cielo Api 3.0. em .NET Core

## Desenvolvimento e melhorias
Esta biblioteca foi escrita em uma tarde seguindo a referência das bibliotecas oficiais da Cielo em JAVA e PHP. Fique a vontade para clonar, melhorar/corrigir ou ainda melhor contribuir para sua melhoria.

## Transações
Biblioteca atende as seguintes transações:
- Criação de venda (```CreateSaleAsync```)
- Captura (para cartões) (```CaptureSaleAsync```)
- Cancelamento (```CancelSaleAsync```)

Tipos de pagamento
- Cartão de crédito
- Cartão de débito
- Boleto
- Transferência eletrônica


## Exemplos de uso

### Configuração básica
```C#
var merchantID = "XXXXXX";
var key = "XXX";

var environment = Ecommerce.Environment.Sandbox();
var merchant = new Merchant(merchantID, key);
```

### Venda no boleto

```C#
// Nova Venda 123
var sale = new Sale("123"); 

// Novo cliente
var customer = new Customer("Fulano de tal")
{
    Identity = "12312312387",
    Address = new Address
    {
        City = "Araquari",
        Street = "Rod. Br 280",
        Complement = "KM 23,5 - Xamã Soluções e Sistemas",
        Country = "Brasil",
        Number = "8835",
        State = "SC",
        ZipCode = "89245000",
        District = "Volta Redonda"
    }
};

// Pagamento de R$ 157,00
var payment = new Payment(15700)
{
    Type = PaymentTypes.Boleto,
    SoftDescriptor = "XamaEcommerce"
};

sale.Payment = payment;
sale.Customer = customer;

 try
{
  // Nova transação
  var transaction = new CieloEcommerce(merchant, environment, _httpClient);
  
  sale = await transaction.CreateSaleAsync(sale);
  var boletoUrl = sale.Payment.Url; // Endereço do boleto
}
catch(Exception e)
{
 //
}
```
### Venda no Cartão de crédito

```C#
// Nova Venda 123
var sale = new Sale("123"); 

// Novo cliente
var customer = new Customer("Fulano de tal")
{
    Identity = "12312312387"
};

var creditCard = new CreditCard("123", "visa")
{
    CardNumber = "0000.0000.0000.0001",
    ExpirationDate = "12/2025",
    Holder = "Fulano de tal"
};

// Pagamento de R$ 157,00
var payment = new Payment(15700)
{
    Type = PaymentTypes.CreditCard,
    SoftDescriptor = "XamaEcommerce",
    CreditCard = creditCard
};

sale.Payment = payment;
sale.Customer = customer;

 try
{
  // Nova transação
  var transaction = new CieloEcommerce(merchant, environment, _httpClient);
  
  sale = await transaction.CreateSaleAsync(sale);
  var capture = await transaction.CaptureSaleAsync(paymentID); // autorização do cartão
  
}
catch(Exception e)
{
 //
}
```


## Performance
Como replicamos(tentamos) as bibliotecas oficiais em JAVA e PHP, vimos que não é performático o modo como ela trabalha. Em uma versão futura iremos melhorar isso.


## Licença
Este projeto é open source. Sem taxas ocultas, chaves de remoção de licença ou semelhantes. Você pode remover/alterar qualquer ponto removendo o nome dos criados. É distribuído sob a GNU General Public License v3.0, disponível [aqui](https://github.com/xamasistemas/Integra-o-Cielo-Api-3.0/blob/main/LICENSE)
