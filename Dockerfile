# Estágio 1: Build do projeto Angular
FROM node:14.17.1-alpine as build-angular
WORKDIR /app/AngularApp
COPY ./AngularApp/package.json .
RUN npm install
COPY ./AngularApp .
RUN npm run build -- --prod

# Estágio 2: Build e publicação da aplicação .NET Core
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-dotnet
WORKDIR /src/WebAPI
COPY ["WebAPI.csproj", "."]
RUN dotnet restore
COPY . .
RUN dotnet build -c Release -o /app/build

# Estágio 3: Criação da imagem final do Docker
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS publish
WORKDIR /app
COPY --from=build-dotnet /app/build .
COPY --from=build-angular /app/AngularApp/dist ./wwwroot
ENTRYPOINT ["dotnet", "WebAPI.dll"]
