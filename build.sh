dotnet publish src/ReadApi/ --configuration=Release
dotnet publish src/WriteApi/ --configuration=Release

docker-compose build read-api
docker-compose build write-api
docker-compose build read-database
docker-compose build write-database
