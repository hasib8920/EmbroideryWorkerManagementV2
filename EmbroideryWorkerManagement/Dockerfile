# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore dependencies
COPY ["EmbroideryWorkerManagement.csproj", "./"]
RUN dotnet restore "EmbroideryWorkerManagement.csproj"

# Copy all source files and publish the project
COPY . .
RUN dotnet publish "EmbroideryWorkerManagement.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 2: Create runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copy published files from build stage
COPY --from=build /app/publish .

# Expose port 80
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "EmbroideryWorkerManagement.dll"]
