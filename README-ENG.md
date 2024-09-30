# Kafka Order Management System

This project demonstrates how to use **Kafka** for real-time event-driven architecture in an order management system. The system handles order creation and stock management through Kafka's distributed messaging capabilities.

## Quick Start

### Prerequisites

- **Docker** & **Docker Compose**
- **.NET 7.0 SDK**

### Installation

1. Clone the repository:
    ```
    git clone <repository-url>
    cd <repository-folder>
    ```

2. Start Kafka with Docker:
    ```
    docker-compose up -d
    ```

3. Run the APIs:
    ```
    dotnet run --project Order.API
    dotnet run --project Stock.API
    ```

4. Manage Kafka topics with Kafka UI:
    Access Kafka UI via your browser at:
    ```
    http://localhost:8080
    ```

For more detailed information, check the [documentation-eng.md](./documentation-eng.md) file.
