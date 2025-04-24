.

🛡️ Ocelot API Gateway
This project implements an API Gateway using Ocelot, a lightweight API Gateway built on the .NET platform. It routes traffic to internal microservices, handles load balancing, caching, and rate limiting, and supports aggregation of downstream services.

📌 Features
🔀 Routing & Load Balancing (Least Connection strategy)

⚡ Rate Limiting (2 requests per 60s window)

🗂 Caching (15-second TTL with custom header)

🔗 Service Aggregation

🛠️ Easy to extend and configure

🗺️ Route Configuration
1. /api/user
Downstream services: Ports 7001, 7004, 7005

Methods: GET, POST, PUT, DELETE

Load Balancer: LeastConnection

Rate Limiting: 2 requests per 60 seconds

2. /api/weather
Downstream service: Port 7002

Methods: Same as above

Rate Limiting: Enabled

Load Balancer: LeastConnection

3. /api/account/{email}/{password}
Downstream service: Port 7003

Methods: Same as above

Rate Limiting: Enabled

🔄 Aggregated Route
/api/aggregate
Combines: /api/user and /api/weather

Use Case: Returns a combined response from both services

🌐 Global Configuration
json
Copiar
Editar
{
  "BaseUrl": "https://localhost:7000"
}
All upstream requests should be made to this base URL.

