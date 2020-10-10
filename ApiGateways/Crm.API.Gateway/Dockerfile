FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

COPY ApiGateways/Crm.API.Gateway/Crm.API.Gateway.csproj ./

RUN dotnet restore

COPY ApiGateways/Crm.API.Gateway/* ./

RUN dotnet publish ApiGateways/Crm.API.Gateway/Crm.API.Gateway.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build-env /out .
ENTRYPOINT ["dotnet", "Crm.API.Gateway.dll"]