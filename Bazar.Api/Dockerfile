FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["BazarASPWebAPI/BazarASPWebAPI.csproj", "BazarASPWebAPI/"]
RUN dotnet restore "BazarASPWebAPI/BazarASPWebAPI.csproj"
COPY . .
WORKDIR "/src/BazarASPWebAPI"
RUN dotnet build "BazarASPWebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BazarASPWebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BazarASPWebAPI.dll"]
