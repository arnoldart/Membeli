# Gunakan image base ASP.NET Core yang sesuai dengan versi Anda
FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

# Lakukan proses build dalam image berikut
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

# Salin file .csproj ke dalam kontainer
COPY ["/backend/..csproj", "backend/"]

# Lakukan proses restore
RUN dotnet restore "backend/backend.csproj"

# Salin seluruh proyek ke dalam kontainer
COPY . .

# Lakukan proses build proyek
WORKDIR "/src/backend"
RUN dotnet build "backend.csproj" -c Release -o /app/build

# Lakukan proses publish proyek
FROM build AS publish
RUN dotnet publish "backend.csproj" -c Release -o /app/publish

# Konfigurasi kontainer akhir
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend.dll"]
