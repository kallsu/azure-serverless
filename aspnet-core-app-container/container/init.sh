#!/bin/bash
set -e

echo "Starting SSH ..."
service ssh start

echo "Starting Application ..."
dotnet AzureServerless.AspNetCore.Api.dll