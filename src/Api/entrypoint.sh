#!/bin/bash
set -e

# Aplicar migraciones
dotnet ef database update

# Arrancar la app
dotnet Api.dll
