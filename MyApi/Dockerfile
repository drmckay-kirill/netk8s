FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
COPY . /app
WORKDIR /app
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
ENV ASPNETCORE_URLS="http://0.0.0.0:5000"
ENV ASPNETCORE_ENVIRONMENT="Development"
COPY --from=build-env /app/out .
ENTRYPOINT dotnet MyApi.dll

