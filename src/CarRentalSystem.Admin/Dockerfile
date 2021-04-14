FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
WORKDIR /src
COPY ["CarRentalSystem.Admin/CarRentalSystem.Admin.csproj", "CarRentalSystem.Admin/"]
RUN dotnet restore "CarRentalSystem.Admin/CarRentalSystem.Admin.csproj"
ENV PATH="$PATH:/root/.dotnet/tools"
COPY . .
WORKDIR "/src/CarRentalSystem.Admin"
RUN libman restore
RUN dotnet build "CarRentalSystem.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarRentalSystem.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CarRentalSystem.Admin.dll"]