FROM microsoft/aspnetcore-build:2.0
WORKDIR /app

# Copy Domain Layer
WORKDIR /app/Domain
COPY . .
RUN dotnet restore
