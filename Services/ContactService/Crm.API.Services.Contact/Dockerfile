#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS  build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "Crm.API.Service.Contact.dll"]



#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS  build-env
#
#WORKDIR /app
#
#COPY ./Crm.API/Crm.API.csproj ./
#
#RUN dotnet restore
#
#ENV ASPNETCORE_ENVIRONMENT=Production
#
#COPY . ./
#
#RUN dotnet publish ./Crm.API -c Release -o /out
#
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
#COPY --from=build-env /out .
#ENTRYPOINT ["dotnet", "Crm.API.dll"]