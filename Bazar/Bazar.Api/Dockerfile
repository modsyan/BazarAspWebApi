FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Bazar.Api.csproj", "./"]
RUN dotnet restore "Bazar.Api.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "Bazar.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bazar.Api.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bazar.Api.dll"]
