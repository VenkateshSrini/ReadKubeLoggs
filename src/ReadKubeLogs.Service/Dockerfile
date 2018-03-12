FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY src/ReadKubeLogs.Service/ReadKubeLogs.Service.csproj src/ReadKubeLogs.Service/
COPY lib/KubernetesClient.csproj lib/
RUN dotnet restore
COPY . .
WORKDIR /src/src/ReadKubeLogs.Service
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ReadKubeLogs.Service.dll"]
