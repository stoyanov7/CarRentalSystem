#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CarRentalSystem.Statistics.API/CarRentalSystem.Statistics.API.csproj", "CarRentalSystem.Statistics.API/"]
COPY ["CarRentalSystem.Statistics.Service/CarRentalSystem.Statistics.Service.csproj", "CarRentalSystem.Statistics.Service/"]
COPY ["CarRentalSystem.Common/CarRentalSystem.Common.csproj", "CarRentalSystem.Common/"]
COPY ["CarRentalSystem.Statistics.Data/CarRentalSystem.Statistics.Data.csproj", "CarRentalSystem.Statistics.Data/"]
RUN dotnet restore "CarRentalSystem.Statistics.API/CarRentalSystem.Statistics.API.csproj"
COPY . .
WORKDIR "/src/CarRentalSystem.Statistics.API"
ARG Mode=Debug
RUN dotnet build "CarRentalSystem.Statistics.API.csproj" -c $Mode -o /app/build

FROM build AS publish
RUN dotnet publish "CarRentalSystem.Statistics.API.csproj" -c $Mode -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarRentalSystem.Statistics.API.dll"]