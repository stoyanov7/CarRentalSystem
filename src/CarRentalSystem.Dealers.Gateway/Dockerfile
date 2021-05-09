FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CarRentalSystem.Dealers.Gateway/CarRentalSystem.Dealers.Gateway.csproj", "CarRentalSystem.Dealers.Gateway/"]
COPY ["CarRentalSystem.Common/CarRentalSystem.Common.csproj", "CarRentalSystem.Common/"]
RUN dotnet restore "CarRentalSystem.Dealers.Gateway/CarRentalSystem.Dealers.Gateway.csproj"
COPY . .
WORKDIR "/src/CarRentalSystem.Dealers.Gateway"
ARG Mode=Debug
RUN dotnet build "CarRentalSystem.Dealers.Gateway.csproj" -c $Mode -o /app/build

FROM build AS publish
RUN dotnet publish "CarRentalSystem.Dealers.Gateway.csproj" -c $Mode -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarRentalSystem.Dealers.Gateway.dll"]