# ASPNET Core Web Api - Container Deployment #

This example contains a simple ASPNET Core Web Api deployed into the Azure Cloud as container.

## Container ##

Build the container of the application as this command reports:

```
docker build -f .\Dockerfile -t aspnetcore-webapi --build-arg Environment=Development .

dokcer login mywebapicontainerregistry.azurecr.io

docker tag aspnetcore-webapi mywebapicontainerregistry.azurecr.io/aspnetcore-webapi 

docker push mywebapicontainerregistry.azurecr.io/aspnetcore-webapi 
```


