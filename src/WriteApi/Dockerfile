FROM microsoft/dotnet:2.1-aspnetcore-runtime

ENV ASPNETCORE_ENVIRONMENT="Release"

WORKDIR /app
COPY ./bin/Release/netcoreapp2.1/publish .

ENTRYPOINT ["dotnet", "WriteApi.dll"]
