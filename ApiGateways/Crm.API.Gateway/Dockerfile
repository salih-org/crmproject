FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

COPY ApiGateways/Crm.API.Gateway/Crm.API.Gateway.csproj ./

RUN dotnet restore

COPY ApiGateways/Crm.API.Gateway/* ./

RUN dotnet publish --no-restore -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Crm.API.Gateway.dll"]