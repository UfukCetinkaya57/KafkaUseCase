# Kafka Sipariş Yönetim Sistemi - Detaylı Dokümantasyon

Bu doküman, projenin teknik detayları ve mimari yapısı hakkında daha fazla bilgi sağlar. **Kafka** entegrasyonu ve olay tabanlı mimari hakkında ayrıntılar içerir.

## Projenin Amacı

Projenin amacı, **Kafka** kullanarak sipariş yönetimi ve stok yönetimini gerçek zamanlı olarak yönetmektir. Kafka ile asenkron mesajlaşma sağlanarak, sistemler arasında olay temelli veri aktarımı yapılır.

### Kafka'nın Kullanım Alanları

1. **Sipariş Olaylarının Yayınlanması:**
   - Sipariş oluşturulduğunda bu olay Kafka'ya gönderilir.
   
2. **Stok Tüketimi:**
   - Sipariş olayları stok yönetim sistemi tarafından tüketilir ve stok güncellenir.

### Kullanılan Teknolojiler

- **Kafka:** Dağıtık mesajlaşma sistemi.
- **Docker & Docker Compose:** Kafka ve diğer hizmetlerin yönetimi.
- **Confluent Kafka Kütüphanesi:** .NET projelerinde Kafka ile iletişim sağlamak için kullanılan kütüphane.

### Mimariler

- **Event-Driven Architecture (EDA):** Olay tabanlı mimari kullanılarak sipariş oluşturma ve stok azaltma işlemleri gerçekleştirilir.
- **Microservice Mimarisi:** Sipariş ve stok yönetimi iki ayrı mikroservis olarak yapılandırılmıştır.
- **Asenkron İletişim:** Siparişler oluşturulduktan sonra asenkron olarak stok sistemine iletilir.

## Proje Akışı

### Sipariş Oluşturma

- **OrderService:** Sipariş oluşturulduğunda Kafka'ya `OrderCreatedEvent` gönderir.
- **Kafka Producer:** Sipariş olayı Kafka'ya yayımlanır.

### Stok Yönetimi

- **StockService:** `OrderCreatedEvent` olaylarını dinler ve stokları günceller.
- **Kafka Consumer:** Sipariş olayları tüketilir ve stok güncellenir.
