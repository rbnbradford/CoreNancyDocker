FROM domain:base as build-env
WORKDIR /app

# Copy Nancy Web Framework Layer
WORKDIR /app/NancyApplication
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o ../out

# Build runtime image
FROM microsoft/aspnetcore:2.0
WORKDIR /app
COPY --from=build-env /app/out ./app
EXPOSE 80
ENTRYPOINT ["dotnet", "./app/NancyApplication.dll"]
