#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CashRegisterApplication/CashRegisterApplication.csproj", "CashRegisterApplication/"]
RUN dotnet restore "CashRegisterApplication/CashRegisterApplication.csproj"
COPY . .
WORKDIR "/src/CashRegisterApplication"
RUN dotnet build "CashRegisterApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CashRegisterApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CashRegisterApplication.dll"]