FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

#copy the csproj and restore any dependencies (via NUGET)
COPY *.csproj ./
RUN dotnet restore

# Copy the Project file and build our release
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image 
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet","MongoAPI.dll"]