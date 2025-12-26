# Incident Risk Platform (ASP.NET Core Web API + PostgreSQL)

A small Web API that ingests traffic/incident events (seed + CSV import), stores them in PostgreSQL, and exposes query endpoints with filtering + paging.

This repo is designed to demonstrate:
- Clean API structure (Domain / Application / Infrastructure / API)
- EF Core + PostgreSQL (Npgsql)
- Docker Compose for local database
- Data ingestion (CSV import) + basic validation
- Query filters + pagination

---

## Tech Stack
- **.NET 8** / ASP.NET Core Web API
- **Entity Framework Core 8** + **Npgsql** (PostgreSQL provider)
- **PostgreSQL 16** (Docker)
- **Swagger / OpenAPI** (Swashbuckle)
- **CsvHelper** (CSV parsing)

---

## Project Structure
- `IncidentRiskPlatform.Domain` — core entities + business rules
- `IncidentRiskPlatform.Application` — services / use-cases
- `IncidentRiskPlatform.Infrastructure` — EF Core DbContext + repositories
- `IncidentRiskPlatform.Api` — controllers + HTTP endpoints
- `data/` — sample CSV files for import (safe to commit)

---

## Prerequisites
Install these before running:
- **.NET SDK 8.x**
- **Docker Desktop** (must be running)

Verify:
```bash
dotnet --version
docker --version
