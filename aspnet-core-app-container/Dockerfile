FROM mcr.microsoft.com/dotnet/core/sdk:3.1

ARG Environment

# prepare the environment
RUN mkdir -p /home/example/web-api && mkdir -p /var/wwwroot/web-api

# setting up the working directory
WORKDIR /home/example/web-api

# copy source code
COPY . .

# build and release
RUN dotnet publish src/AzureServerless.AspNetCore.Api -c Release -f netcoreapp3.1 -o /var/wwwroot/web-api
 
# Run
WORKDIR /var/wwwroot/web-api

# Clean home folder
RUN rm -rf /home/example

# Setup environment
ENV ASPNETCORE_ENVIRONMENT=$Environment
ENV ASPNETCORE_URLS="https://+:80"

# Expose the port
EXPOSE 80

# Run container
CMD ["dotnet", "AzureServerless.AspNetCore.Api.dll"]