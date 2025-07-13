# Event Feedback System - Setup Guide

## Prerequisites
- Docker Desktop (v20.10+) installed
- Git (optional)
- .NET 8 SDK (for local development)

## Quick Start

### 1. Clone the repository (if not already cloned)
```bash
git clone https://github.com/your-repo/event-feedback-system.git
cd event-feedback-system
```

### 2. Run the application
```bash
docker-compose up --build
```

The system will:
- Start a PostgreSQL container
- Build and launch the ASP.NET Core web app
- Automatically apply database migrations
- Seed initial test data

## Accessing the Application
- API: `http://localhost:8080`
- Swagger UI: `http://localhost:8080/swagger`
- PostgreSQL: `localhost:5432` (username: `sa`, password: `123qwe`)

## Common Issues & Solutions

### Database Connection Errors
If you encounter database-related errors:
1. First try restarting only the web app container:
```bash
docker-compose restart web
```

2. If the issue persists, rebuild the containers:
```bash
docker-compose down
docker-compose up --build
```

### Timezone Issues
The system uses UTC timestamps. If you see incorrect dates:
```bash
docker-compose exec db psql -U sa -c "SELECT now();"
```
Verify this matches your current UTC time.

### Seed Data Problems
To force re-seeding:
```bash
docker-compose exec web dotnet run --seed
```

## Development Notes

### Environment Variables
Create a `.env` file for local development:
```
POSTGRES_PASSWORD=your_secure_password
ASPNETCORE_ENVIRONMENT=Development
```

### Useful Commands
- View logs: `docker-compose logs -f`
- Run tests: `docker-compose run web dotnet test`
- Enter database: `docker-compose exec db psql -U sa event_feedback_system_db`

## Project Structure
```
/src
  /EventFeedbackSystem.Web       - Main web project
  /EventFeedbackSystem.Core      - Domain models
  /EventFeedbackSystem.EntityFrameworkCore - Database layer
/docker
  docker-compose.yml             - Container configuration
  Dockerfile                     - Web app image
```

## Troubleshooting
If containers fail to start:
1. Verify Docker is running
2. Check port conflicts (8080, 5432)
3. Clean previous containers:
```bash
docker-compose down -v
docker system prune
```

For persistent issues, please open a GitHub issue with:
1. Exact error message
2. Docker version (`docker --version`)
3. Steps to reproduce