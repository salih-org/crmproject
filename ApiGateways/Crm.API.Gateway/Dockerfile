FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

COPY ApiGateways/Crm.API.Gateway/*.csproj ./

RUN dotnet restore

ENV ASPNETCORE_ENVIRONMENT=Production

COPY ApiGateways/Crm.API.Gateway/* ./

RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build-env /out .
ENTRYPOINT ["dotnet", "Crm.API.Gateway.dll"]