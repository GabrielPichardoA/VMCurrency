# VMCurrencyAPI

## Instalation steps

Open .sln file inside VMCurrencyApi\VMCurrencyApi folder.

## IMPORTANT:

* To run this project you need to have installed .Net 6 in order to work.
* At least SQLExpress and modify the ConnectionString on the appsettings.json for your sqlserver.
  "ConnectionStrings": {
    "VMCurrencyConnection": "Server=*YourServer*;Database=VMCurrency;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
  }
  
For more information: https://www.connectionstrings.com/sql-server/

## Development server

Application runs in `https://localhost:7250` if you change it then you will have to change on the UI project too.
