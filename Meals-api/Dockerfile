#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Meals-api/Meals-api.csproj", "Meals-api/"]
RUN dotnet restore "Meals-api/Meals-api.csproj"
COPY . .
WORKDIR "/src/Meals-api"
RUN dotnet build "Meals-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Meals-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Meals-api.dll"]