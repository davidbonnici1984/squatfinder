
FROM microsoft/aspnetcore:1.1
LABEL Name=squatfinder Version=0.0.1 
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-bin/Debug/netcoreapp1.1/publish} .
ENTRYPOINT ["dotnet","squatfinder.dll"]
