#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Neoris.Account/Neoris.Account.csproj", "Neoris.Account/"]
RUN dotnet restore "Neoris.Account/Neoris.Account.csproj"
COPY . .
WORKDIR "/src/Neoris.Account"
RUN dotnet build "Neoris.Account.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Neoris.Account.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Neoris.Account.dll"]