FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine

RUN apk add --no-cache make

COPY .config .config
RUN dotnet tool restore


WORKDIR /code