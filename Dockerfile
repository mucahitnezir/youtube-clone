FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
#
# copy csproj and restore as distinct layers
COPY *.sln .
COPY VideoApp.Business/*.csproj ./VideoApp.Business/
COPY VideoApp.Core/*.csproj ./VideoApp.Core/
COPY VideoApp.DataAccess/*.csproj ./VideoApp.DataAccess/
COPY VideoApp.Entities/*.csproj ./VideoApp.Entities/
COPY VideoApp.WebAPI/*.csproj ./VideoApp.WebAPI/
#
RUN dotnet restore
#
# copy everything else and build app
COPY VideoApp.Business/. ./VideoApp.Business/
COPY VideoApp.Core/. ./VideoApp.Core/
COPY VideoApp.DataAccess/. ./VideoApp.DataAccess/
COPY VideoApp.Entities/. ./VideoApp.Entities/
COPY VideoApp.WebAPI/. ./VideoApp.WebAPI/
#
WORKDIR /app/VideoApp.WebAPI
RUN dotnet publish -c Release -o out
#
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
WORKDIR /app

#
COPY --from=build /app/VideoApp.WebAPI/out ./
ENTRYPOINT ["dotnet", "VideoApp.WebAPI.dll"]
