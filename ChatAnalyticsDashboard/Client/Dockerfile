FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /Client
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/Client
# VS Debug
#COPY ./Client .
# CMD
COPY . .
RUN dotnet restore "./Client.csproj"
RUN dotnet build "./Client.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Client.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:8080
#ENV ASPNETCORE_URLS=https://+:8081
ENTRYPOINT ["dotnet", "Client.dll"]