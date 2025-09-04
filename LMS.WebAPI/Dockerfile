# Use the official .NET 9 runtime as the base image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Use the official .NET 9 SDK as the build image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy the solution file and restore dependencies
COPY ["LibraryManager.sln", "./"]
COPY ["LMS.BusinessLogic/LMS.BusinessLogic.csproj", "LMS.BusinessLogic/"]
COPY ["LMS.WebAPI/LMS.WebAPI.csproj", "LMS.WebAPI/"]

# Restore dependencies
RUN dotnet restore "LMS.WebAPI/LMS.WebAPI.csproj"

# Copy the rest of the source code
COPY . .

# Build the application
WORKDIR "/src/LMS.WebAPI"
RUN dotnet build "LMS.WebAPI.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "LMS.WebAPI.csproj" -c Release -o /app/publish

# Final stage/image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set environment variables
ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Production

ENTRYPOINT ["dotnet", "LMS.WebAPI.dll"]
