#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/EventFeedbackSystem.Web/EventFeedbackSystem.Web.csproj", "src/EventFeedbackSystem.Web/"]
COPY ["src/EventFeedbackSystem.Application.Shared/EventFeedbackSystem.Application.Shared.csproj", "src/EventFeedbackSystem.Application.Shared/"]
COPY ["src/EventFeedbackSystem.Core/EventFeedbackSystem.Core.csproj", "src/EventFeedbackSystem.Core/"]
COPY ["src/EventFeedbackSystem.Application/EventFeedbackSystem.Application.csproj", "src/EventFeedbackSystem.Application/"]
COPY ["src/EventFeedbackSystem.EntityFrameworkCore/EventFeedbackSystem.EntityFrameworkCore.csproj", "src/EventFeedbackSystem.EntityFrameworkCore/"]
RUN dotnet restore "./src/EventFeedbackSystem.Web/EventFeedbackSystem.Web.csproj"
COPY . .
WORKDIR "/src/src/EventFeedbackSystem.Web"
RUN dotnet build "./EventFeedbackSystem.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EventFeedbackSystem.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EventFeedbackSystem.Web.dll"]