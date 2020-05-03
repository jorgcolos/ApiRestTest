# NuGet restore
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY *.sln .
COPY ApiRestTest.Application/*.csproj ApiRestTest.Application/
COPY ApiRestTest.Domain/*.csproj ApiRestTest.Domain/
COPY ApiRestTest.Infrastructure/*.csproj ApiRestTest.Infrastructure/
COPY ApiRestTest.Persistence/*.csproj ApiRestTest.Persistence/
COPY ApiRestTest.API/*.csproj ApiRestTest.API/
RUN dotnet restore
COPY . .

# publish
FROM build AS publish
WORKDIR /src/ApiRestTest.api
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
# ENTRYPOINT ["dotnet", "Colors.API.dll"]
# heroku uses the following
CMD ASPNETCORE_URLS=http://*:$PORT dotnet ApiRestTest.API.dll