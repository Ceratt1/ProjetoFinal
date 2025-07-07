#!/bin/bash
dotnet build
dotnet run --no-build --project ProjetoFinal.csproj ef migrations add $1
dotnet run --no-build --project ProjetoFinal.csproj ef database update