FROM mcr.microsoft.com/dotnet/core/sdk:3.1

ARG Environment

# prepare the environment
RUN mkdir -p /home/example/web-api && mkdir -p /var/wwwroot/web-api

# setting up the working directory
WORKDIR /home/example/web-api

# copy source code
COPY . .

# build and release
RUN dotnet publish src/AzureServerless.AspNetCore.Api -c Release -f netcoreapp3.1 -o /var/wwwroot/web-api \
 && cp -v container/init.sh /var/wwwroot/web-api
 
# Run
WORKDIR /var/wwwroot/web-api

# Setup environment
ENV ASPNETCORE_ENVIRONMENT=$Environment
ENV ASPNETCORE_URLS="http://+:80"

# Azure Custom container customization
ENV SSH_PASSWD "root:Docker!"
RUN apt-get update \
        && apt-get install -y --no-install-recommends dialog \
        && apt-get update \
	&& apt-get install -y --no-install-recommends openssh-server \
	&& echo "$SSH_PASSWD" | chpasswd 

RUN mv -v /home/example/web-api/container/sshd_config /etc/ssh/
RUN mv -v /home/example/web-api/container/init.sh /usr/local/bin/

RUN chmod u+x /usr/local/bin/init.sh

# Clean home folder
RUN rm -rf /home/example

# Expose the ports
EXPOSE 80 2222

# Start SSH and run dotnet instruction
ENTRYPOINT ["init.sh"]