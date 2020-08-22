# ASPNET Core Web Api - Container Deployment #

This example contains a simple ASPNET Core Web Api deployed into the Azure Cloud as container.

## 1. Azure Setup ##

It is required create first all the components for the environmnet into Azure.

* Login into Azure environment

  `az login`

* Select the required subscription, if it is required

  `az account set -s <SUBSCRIPTION_NAME/ID>`

* Create the resource group

  `az group create --location southeastasia --name MyContainerApp`

* Execute the template into the resource group

  `az deployment group create --resource-group MyContainerApp --template-file deployment/template.json --parameters @deployment/parameters.json`

* Enable the admin credentials for the ACR created.

  `az acr update --name myWebApiContainerRegistry --admin-enabled true`

  For a better configuration into an enterprise or production environment is reccomended to use another configuration for login into the ACR.

* To show the passwords generated for the Admin account for the ACR

  `az acr credential show  --name myWebApiContainerRegistry`

* Configure the Application with the right environment to run

  `az webapp config set --resource-group MyContainerApp --name MyContainerWebApiAppName --generic-configurations "{"ASPNETCORE_ENVIRONMENT": "Development"}"`

* Configure Application to pull from Container Regtry. Use the Continuous Deployment to automatically sync the container every time it is pushed

 ```az webapp config container set --docker-custom-image-name aspnetcore-webapi
        --docker-registry-server-password <ADMIN_PASSWORD> //<---- See steps before
        --docker-registry-server-url mywebapicontainerregistry.azurecr.io/aspnetcore-webapi:latest
        --docker-registry-server-user mywebapicontainerregistry
 ```

## 2. Container Setup ##

Build the container of the application as this command reports:

```
docker build -f .\Dockerfile -t aspnetcore-webapi --build-arg Environment=Development .

docker login mywebapicontainerregistry.azurecr.io

docker tag aspnetcore-webapi mywebapicontainerregistry.azurecr.io/aspnetcore-webapi 

docker push mywebapicontainerregistry.azurecr.io/aspnetcore-webapi 
```

## 3. Conclusion ##

Application will run here : [https://mycontainerwebapiappname.azurewebsites.net/weatherforecast](https://mycontainerwebapiappname.azurewebsites.net/weatherforecast)

For future improvement:

* Logging and Monitoring
  * Add an Azure AppInsight to the WebApplication
    * To allow the monitoring also to application level, enable the [application instrumentation with AppInsight](https://docs.microsoft.com/en-us/azure/azure-monitor/app/asp-net-core)


  * Enable on the WebApp Service Diagnostic settings to store the logs about:
    * App Settings
    * Configuration
    * All Metrics

* Authentication.
  * For container there is a different pattern to follow instead of the normal integration. [Official documentation is here](https://docs.microsoft.com/en-us/azure/app-service/overview-authentication-authorization#how-it-works)

## 4. Contribution ##

Please use the Issue tracker of this repository specifing the project where you refer.

Thanks