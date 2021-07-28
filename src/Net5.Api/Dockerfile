FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Net5.Api/Net5.Api.csproj", "src/Net5.Api/"]
RUN dotnet restore "src/Net5.Api/Net5.Api.csproj"
COPY . .
WORKDIR "/src/src/Net5.Api"
RUN dotnet build "Net5.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Net5.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Net5.Api.dll"]