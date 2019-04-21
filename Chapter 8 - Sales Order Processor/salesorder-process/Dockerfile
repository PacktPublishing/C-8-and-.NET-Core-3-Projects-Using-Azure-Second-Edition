FROM mcr.microsoft.com/dotnet/core/runtime:3.0-stretch-slim AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY ["salesorder-process/salesorder-process.csproj", "salesorder-process/"]
RUN dotnet restore "salesorder-process/salesorder-process.csproj"
COPY . .
WORKDIR "/src/salesorder-process"
RUN dotnet build "salesorder-process.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "salesorder-process.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "salesorder-process.dll"]