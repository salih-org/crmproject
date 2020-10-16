FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src

COPY Services/ReservationService/ ./
COPY Services/Common/ ./

RUN dotnet publish Crm.API.Service.Reservation/Crm.API.Service.Reservation.csproj -c Release -o out


WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Crm.API.Service.Reservation.dll"]