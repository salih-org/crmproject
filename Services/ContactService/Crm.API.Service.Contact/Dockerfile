FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

COPY Services/ContactService/ ./
COPY Services/Common/ ./

RUN dotnet publish Crm.API.Service.Contact/Crm.API.Service.Contact.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Crm.API.Service.Contact.dll"]