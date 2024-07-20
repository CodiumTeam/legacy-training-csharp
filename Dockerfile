FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine

RUN apk add --no-cache make

WORKDIR /code

COPY .config .config
RUN dotnet tool restore

VOLUME [ "/code" ]