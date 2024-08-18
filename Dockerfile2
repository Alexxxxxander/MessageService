FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MessageWebService.API/MessageWebService.API.csproj", "MessageWebService.API/"]
RUN dotnet restore "/MessageWebService.API/MessageWebService.API.csproj"
COPY . .
WORKDIR "/src/MessageWebService.API"
RUN dotnet build "MessageWebService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MessageWebService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MessageWebService.API.dll"]
