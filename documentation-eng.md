# Kafka Order Management System

This document provides technical details and the architectural design of the project. It explains **Kafka** integration and event-driven architecture in depth.

## Project Purpose

The aim of the project is to manage order and stock processes in real-time using **Kafka**. By utilizing Kafka's asynchronous messaging, the system enables event-driven data transfer between services.

### Kafka Use Cases

1. **Order Event Publishing:**
   - When an order is created, an event is sent to Kafka.
   
2. **Stock Consumption:**
   - The stock management system consumes order events from Kafka and updates the stock.

### Technologies Used

- **Kafka:** Distributed messaging system.
- **.NET 7.0:** API development.
- **Docker & Docker Compose:** Managing Kafka and other services.

### Architectures

- **Event-Driven Architecture (EDA):** The system is built using event-driven architecture, where order creation and stock management are handled through events.
- **Microservice Architecture:** The project is divided into two microservices: Order management and Stock management.
- **Asynchronous Communication:** Orders are processed and sent to the stock system asynchronously.

## Project Flow

### Order Creation

- **OrderService:** When an order is created, it sends an `OrderCreatedEvent` to Kafka.
- **Kafka Producer:** The order event is published to Kafka.

### Stock Management

- **StockService:** Listens to `OrderCreatedEvent` events and updates the stock accordingly.
- **Kafka Consumer:** Consumes order events and updates the stock.

---

For more technical details or contributions, feel free to explore the project documentation.
