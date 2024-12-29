# Stage 1: Build the solution and restore dependencies
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

# Copy the .csproj files for each project to restore dependencies
COPY ["GarasAPP.API/GarasAPP.API.csproj", "GarasAPP.API/"]
COPY ["GarasAPP.Core/GarasAPP.Core.csproj", "GarasAPP.Core/"]
COPY ["GarasAPP.EntityFrameworkCore/GarasAPP.EntityFrameworkCore.csproj", "GarasAPP.EntityFrameworkCore/"]

# Restore dependencies for all projects
RUN dotnet restore "GarasAPP.API/GarasAPP.API.csproj"

# Copy the entire source code
COPY . .

# Stage 2: Build the projects
RUN dotnet build "GarasAPP.API/GarasAPP.API.csproj" -c Release -o /app/build

# Stage 3: Publish the API project
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final

WORKDIR /app

# Copy the build output from the build stage
COPY --from=build /app/build .

# Expose port 80 for the API
EXPOSE 80

# Define the entrypoint for the container
ENTRYPOINT ["dotnet", "GarasAPP.API.dll"]
