# Distributed Bank

This project is a sample of microservices architecture with .NET 8. You can see the overall picture below here;

![samplebank]()

## Whats Including

### User microservice
* **ASP.NET Core Web API** application
* **REST API** principles, **CRUD** operations
* Implementing **DDD, CQRS, and Clean Architecture** using best practices
* Developing **CQRS using MediatR, FluentValidation, and AutoMapper** libraries
* **PostgreSQL database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SQL Server when application run
* **Swagger Open API** implementation

### Order Microservice
* **ASP.NET Core Web API** application
* **REST API** principles, **CRUD** operations
* Implementing **DDD, CQRS, and Clean Architecture** using best practices
* Publish Account's transactions using **MassTransit and RabbitMQ**
* Developing **CQRS using MediatR, FluentValidation, and AutoMapper** libraries
* **PostgreSQL database** connection and containerization
* Using **Entity Framework Core ORM** and auto migrate to SQL Server when application run
* **Swagger Open API** implementation

### Notification Microservice
* **ASP.NET Core Web API** application
* **REST API** principles, **CRUD** operations
* **Repository Pattern** Implementation
* Consume Account's transactions using **MassTransit and RabbitMQ**
* **MongoDB database** connection and containerization
* **Swagger Open API** implementation

### API Gateway Ocelot Microservice
- Implement **API Gateways with Ocelot**
- Sample microservices/containers to reroute through the API Gateways
- Run multiple different **API Gateway/BFF** container types

### Microservices Cross-Cutting Implementations
- Implementing **Centralized Distributed Logging with Elastic Stack (ELK); Elasticsearch, Logstash, Kibana and SeriLog** for Microservices
- Use the **HealthChecks** feature in back-end ASP.NET microservices

### Microservices Resilience Implementations
- Making Microservices more **resilient Use IHttpClientFactory** to implement resilient HTTP requests
- Implement **Retry and Circuit Breaker patterns** with exponential backoff with IHttpClientFactory and **Polly policies**

### Helper Containers
- Use **Portainer** for Container lightweight management UI which allows you to easily manage your different Docker environments
- **pgAdmin PostgreSQL Tools** feature rich Open Source administration and development platform for PostgreSQL

### Docker Compose establishment with all microservices on docker;
- Containerization of microservices
- Containerization of databases
- Override Environment variables

### Project Startup
- Install Docker Desktop from UTL **https://www.docker.com/products/docker-desktop/**
- Go to src folder and run CMD command **docker compose up**
- To stop docker container run command **docker compose stop**
- Run API Projects from the Visual studio or use API Gateway URL

### Project URLs
- User API - https://localhost:58627/swagger/index.html
- Order API - https://localhost:58630/swagger/index.html
- Notification API - https://localhost:58630/swagger/index.html
- Kibana URL - http://localhost:5601/
- Elastic Search URL - http://localhost:9200/
- PgAdmin - http://localhost:5050/
- RAbbitMq - http://localhost:15672/
