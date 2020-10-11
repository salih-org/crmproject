FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR /app

COPY Services/ReservationService/ ./

RUN dotnet publish Crm.API.Service.Reservation/Crm.API.Service.Reservation.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Crm.API.Service.Reservation.dll"]