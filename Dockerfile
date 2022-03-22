FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder

WORKDIR /src

COPY ./src/Common/. ./src/Common
COPY ./src/Domain/. ./src/Domain
COPY ./src/Features/. ./src/Features
COPY ./src/Infrastructure/. ./src/Infrastructure

COPY ./Assignment/Assignment.csproj ./Assignment/Assignment.csproj

WORKDIR /src/Assignment
RUN dotnet restore -v diag

COPY ./Assignment .

RUN dotnet publish -c Release -o /app 

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base

WORKDIR /app
COPY --from=builder /app . 
#ENTRYPOINT ["dotnet", "Assignment.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Assignment.dll
