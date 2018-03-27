FROM domain:base as build-env
WORKDIR /app

# Copy Tests
WORKDIR /app/Tests
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o ../tests

# Build runtime image
FROM microsoft/dotnet:2.0-sdk
WORKDIR /app
COPY --from=build-env /app/tests ./tests
CMD ["bash"]
