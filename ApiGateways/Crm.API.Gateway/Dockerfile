#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS  build-env
WORKDIR /app
#EXPOSE 443

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish "Crm.API.Gateway.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "Crm.API.Gateway.dll"]