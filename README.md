Project: Ride Booking System

Functional Requirements:
- Book ride
- Accept ride
- Track ride

Non-Functional:
- Scalable
- Available
- Low latency

Entities:
- User
- Driver
- Ride

API DESIGN 

APIs:

POST /rides
GET /rides/{id}
POST /rides/{id}/cancel

POST /drivers/{id}/accept
PUT /drivers/{id}/availability

POST /users
GET /users/{id}

DATABASE DESIGN

Users
------
Id (PK)
Name
Phone
CreatedAt

Drivers
--------
Id (PK)
Name
IsAvailable
CreatedAt

Rides
------
Id (PK)
UserId (FK)
DriverId (FK)
Source
Destination
Status
CreatedAt

FINAL ARCHITECTURE DESIGN 

Client
  ↓
DNS
  ↓
Load Balancer
  ↓
API Gateway
  ↓
Cache (Redis)
  ↓
Microservices
  ↓
Database (Primary + Replica)

  ↓
Message Broker → Async Tasks

SCALING 

- Caching (Redis)
- Load Balancer
- Read Replicas
- Message Broker
- Horizontal Scaling
