#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["02 - APIs/EmailMarketing.API/EmailMarketing.API.csproj", "02 - APIs/EmailMarketing.API/"]
COPY ["01 - Architecture/EmailMarketing.Architecture.MessageBus/EmailMarketing.Architecture.MessageBus.csproj", "01 - Architecture/EmailMarketing.Architecture.MessageBus/"]
COPY ["01 - Architecture/EmailMarketing.Architecture.Core/EmailMarketing.Architecture.Core.csproj", "01 - Architecture/EmailMarketing.Architecture.Core/"]
COPY ["01 - Architecture/EmailMarketing.Architecture.WebApi.Core/EmailMarketing.Architecture.WebApi.Core.csproj", "01 - Architecture/EmailMarketing.Architecture.WebApi.Core/"]
COPY ["02 - APIs/EmailMarketing.Application/EmailMarketing.Application.csproj", "02 - APIs/EmailMarketing.Application/"]
COPY ["01 - Architecture/EmailMarketing.Architecture.Helpers/EmailMarketing.Architecture.Helpers.csproj", "01 - Architecture/EmailMarketing.Architecture.Helpers/"]
COPY ["02 - APIs/EmailMarketing.Domain/EmailMarketing.Domain.csproj", "02 - APIs/EmailMarketing.Domain/"]
COPY ["02 - APIs/EmailMarketing.Infra/EmailMarketing.Infra.csproj", "02 - APIs/EmailMarketing.Infra/"]
RUN dotnet restore "02 - APIs/EmailMarketing.API/EmailMarketing.API.csproj"
COPY . .
WORKDIR "/src/02 - APIs/EmailMarketing.API"
RUN dotnet build "EmailMarketing.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmailMarketing.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmailMarketing.API.dll"]