FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CarRentalSystem.Dealers.API/CarRentalSystem.Dealers.API.csproj", "CarRentalSystem.Dealers.API/"]
COPY ["CarRentalSystem.Dealers.Data/CarRentalSystem.Dealers.Data.csproj", "CarRentalSystem.Dealers.Data/"]
COPY ["CarRentalSystem.Common/CarRentalSystem.Common.csproj", "CarRentalSystem.Common/"]
COPY ["CarRentalSystem.Dealers.Service/CarRentalSystem.Dealers.Service.csproj", "CarRentalSystem.Dealers.Service/"]
RUN dotnet restore "CarRentalSystem.Dealers.API/CarRentalSystem.Dealers.API.csproj"
COPY . .
WORKDIR "/src/CarRentalSystem.Dealers.API"
ARG Mode=Debug
RUN dotnet build "CarRentalSystem.Dealers.API.csproj" -c $Mode -o /app/build

FROM build AS publish
RUN dotnet publish "CarRentalSystem.Dealers.API.csproj" -c $Mode -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarRentalSystem.Dealers.API.dll"]