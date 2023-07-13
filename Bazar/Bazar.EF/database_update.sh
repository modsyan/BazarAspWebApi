#!/bin/sh

dotnet ef --startup-project "../Bazar.Api/Bazar.Api.csproj" database drop --force &&
dotnet ef --startup-project "../Bazar.Api/Bazar.Api.csproj" migrations remove --force &&
dotnet ef --startup-project "../Bazar.Api/Bazar.Api.csproj" migrations add init &&
dotnet ef --startup-project "../Bazar.Api/Bazar.Api.csproj" database update
