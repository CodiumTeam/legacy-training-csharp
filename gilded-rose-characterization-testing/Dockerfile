FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine

COPY .config .config
RUN dotnet tool restore

WORKDIR /code