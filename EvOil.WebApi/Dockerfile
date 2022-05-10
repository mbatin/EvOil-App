FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS dotnet-runtime

# .NET App
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS dotnet-builder

# Restore .NET App
COPY ["nuget.config", "nuget.config"]
COPY ["EvOil.Persistence/EvOil.Persistence.csproj", "EvOil.Persistence/"]
COPY ["EvOil.Domain/EvOil.Domain.csproj", "EvOil.Domain/"]
COPY ["EvOil.Business/EvOil.Business.csproj", "EvOil.Business/"]
COPY ["EvOil.WebApi/EvOil.WebApi.csproj", "EvOil.WebApi/"]
RUN dotnet restore "EvOil.Persistence/EvOil.Persistence.csproj" --configfile "nuget.config"

# Build .NET App
COPY . .
RUN dotnet build "EvOil.WebApi/EvOil.WebApi.csproj" -c Release -o /app/server/build --configfile "nuget.config"

# Publish .NET App
FROM dotnet-builder AS dotnet-publisher
RUN dotnet publish "EvOil.WebApi/EvOil.WebApi.csproj" -c Release -o /app/server/publish

# Client App
FROM node AS client-builder

# set working directory
RUN mkdir /usr/src/app
WORKDIR /usr/src/app

# add `/usr/src/app/node_modules/.bin` to $PATH
ENV PATH /usr/src/app/node_modules/.bin:$PATH

# install and cache app dependencies
COPY client/package.json /usr/src/app/package.json
RUN npm install

# Copy rest of Client Application files
COPY client/. /usr/src/app

# Build Client Application
RUN npm run build

FROM dotnet-runtime AS final

# Copy Client Application From client-builder Image Into final Image
RUN mkdir -p /app/client/build
COPY --from=client-builder /usr/src/app/build/. /app/client/build

# Sets working directory for dotnet entry point command
WORKDIR /app/server

# Copy .NET Application From dotnet-publisher Image Into final Image
COPY --from=dotnet-publisher /app/server/publish /app/server
ENTRYPOINT ["dotnet", "EvOil.WebApi.dll"]
