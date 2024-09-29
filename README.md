# Kafka ile Sipariş Yönetim Sistemi

Bu proje, **Kafka** kullanarak gerçek zamanlı olay tabanlı bir sipariş yönetim sisteminde kafkanın nasıl kullanıldığını göstermek amaçlı oluşturulan bir prototiptir. Sistem, sipariş oluşturma ve stok yönetimini Kafka'nın dağıtık mesajlaşma yetenekleri ile gerçekleştirmektedir.

## Hızlı Başlangıç

### Gereksinimler

- **Docker** & **Docker Compose**
- **.NET 7.0 SDK**

### Kurulum

1. Repository'yi klonlayın:
    ```
    git clone <repository-url>
    cd <repository-folder>
    ```

2. Docker ile Kafka'yı başlatın:
    ```
    docker-compose up -d
    ```

3. API'leri çalıştırın:
    ```
    dotnet run --project Order.API
    dotnet run --project Stock.API
    ```

4. Kafka UI ile konuları yönetin:
    Tarayıcı üzerinden Kafka UI'ye şu adresten ulaşabilirsiniz:
    ```
    http://localhost:8080
    ```

Daha fazla bilgi için [documentation.md](./documentation.md) dosyasına göz atabilirsiniz.
