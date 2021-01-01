# Azure Function - Durable - HTTP Async Pattern

This is a simple example of the [Azure Durable Function](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-overview?tabs=csharp) for the [HTTP Async Pattern](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-overview?tabs=csharp).


## 1. Azure Setup ##

It is required create first all the components for the environmnet into Azure.

* Login into Azure environment

  `az login`

* Select the required subscription, if it is required

  `az account set -s <SUBSCRIPTION_NAME/ID>`

* Create the resource group

  `az group create --location southeastasia --name MyDurableFunction`

* Execute the template into the resource group

  `az deployment group create --resource-group MyDurableFunction --template-file deployment/template.json --parameters @deployment/parameters.json`

* Configure the Azure Function

* Configure the Managed Identity for the Azure Durable Function to access to the Blob Storage

https://docs.microsoft.com/en-us/samples/azure-samples/functions-storage-managed-identity/using-managed-identity-between-azure-functions-and-azure-storage/

## 2. Function Setup ##

TBD.

## 3. Conclusion ##

Durable Function will run here : [https://example.org]()

### 3.1 Logging ###

Log into the App Insight custom metrics

Monitoring by the performance diagrams

Alert System


### 3.2 Security ###

* Authentication

See the Azure Function Authorization Key

* Authorization

Can I see those file ?

* Audit

See the logging before.

## 4. Contribution ##

Please use the Issue tracker of this repository specifing the project where you refer.

Thanks