FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5211

ENV ASPNETCORE_URLS=http://+:5211

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/API/Sample.API/Sample.API.csproj", "src/API/Sample.API/"]
RUN dotnet restore "src/API/Sample.API/Sample.API.csproj"
COPY . .
WORKDIR "/src/src/API/Sample.API"
RUN dotnet build "Sample.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Sample.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sample.API.dll"]
