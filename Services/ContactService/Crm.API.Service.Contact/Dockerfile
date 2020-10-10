FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

COPY Services/ContactService/Crm.API.Service.Contact.Data/*.csproj ./
COPY Services/ContactService/Crm.API.Service.Contact.Service/*.csproj ./
COPY Services/ContactService/Crm.API.Services.Contact/*.csproj ./

RUN dotnet restore

COPY Services/ContactService/Crm.API.Services.Contact/* ./

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Crm.API.Service.Contact.dll"]