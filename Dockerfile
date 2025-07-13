# BUILD Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["EventFeedbackSystem.sln", "./"]
COPY ["src/EventFeedbackSystem.Web/*.csproj", "src/EventFeedbackSystem.Web/"]
COPY ["src/EventFeedbackSystem.Application/*.csproj", "src/EventFeedbackSystem.Application/"]
COPY ["src/EventFeedbackSystem.Application.Shared/*.csproj", "src/EventFeedbackSystem.Application.Shared/"]
COPY ["src/EventFeedbackSystem.Core/*.csproj", "src/EventFeedbackSystem.Core/"]
COPY ["src/EventFeedbackSystem.EntityFrameworkCore/*.csproj", "src/EventFeedbackSystem.EntityFrameworkCore/"]
COPY ["src/EventFeedbackSystem.Web/*.csproj", "src/EventFeedbackSystem.Web/"]

RUN dotnet restore "EventFeedbackSystem.sln"

#Copy all
COPY . .

# Build and Publish
RUN dotnet publish "src/EventFeedbackSystem.Web/EventFeedbackSystem.Web.csproj" -c Release -o /app

# Run Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app .

# Ports
EXPOSE 80

# Run
ENTRYPOINT ["dotnet", "EventFeedbackSystem.Web.dll"]