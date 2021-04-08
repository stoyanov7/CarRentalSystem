FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CarRentalSystem.Identity.API/CarRentalSystem.Identity.API.csproj", "CarRentalSystem.Identity.API/"]
COPY ["CarRentalSystem.Identity.Services/CarRentalSystem.Identity.Services.csproj", "CarRentalSystem.Identity.Services/"]
COPY ["CarRentalSystem.Identity.Data/CarRentalSystem.Identity.Data.csproj", "CarRentalSystem.Identity.Data/"]
COPY ["CarRentalSystem.Common/CarRentalSystem.Common.csproj", "CarRentalSystem.Common/"]
RUN dotnet restore "CarRentalSystem.Identity.API/CarRentalSystem.Identity.API.csproj"
COPY . .
WORKDIR "/src/CarRentalSystem.Identity.API"
RUN dotnet build "CarRentalSystem.Identity.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarRentalSystem.Identity.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarRentalSystem.Identity.API.dll"]