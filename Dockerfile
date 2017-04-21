
FROM microsoft/aspnetcore:1.1
LABEL Name=dnstwistermonitor Version=0.0.1 
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-bin/Debug/netcoreapp1.1/publish} .
ENTRYPOINT ["dotnet","DnsTwisterMonitor.dll"]
