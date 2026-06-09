FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["PulseDesk.API.csproj", "./"]
RUN dotnet restore "PulseDesk.API.csproj"

COPY . .
RUN dotnet publish "PulseDesk.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "PulseDesk.API.dll"]