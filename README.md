# Kafka ile Sipariş Yönetim Sistemi

Bu proje, bir sipariş yönetim sistemi geliştirmek amacıyla oluşturulmuştur. Projede **Kafka** kullanılarak sipariş olayları işlenmekte ve stok sistemine entegre edilmektedir. Projenin amacı, **Kafka**'nın gerçek zamanlı olay işleme yeteneklerini kullanarak dağıtık bir sistemde mesajlaşma mimarisini sergilemektir.

## Projenin Amacı

Projenin temel amacı, **Kafka** kullanarak sipariş ve stok yönetimini gerçek zamanlı olarak yönetmektir. Kafka'nın güçlü dağıtık mesajlaşma özellikleri sayesinde, sipariş oluşturulduğunda bu olay Kafka'ya gönderilir ve stok sistemine tüketici olarak gelen bu mesajlar işlenir. Bu sayede sistemler arasında asenkron veri aktarımı sağlanır.

Kafka, bu projede aşağıdaki amaçlarla kullanılmıştır:
- **Sipariş olaylarının yayımlanması:** Yeni bir sipariş oluşturulduğunda bu olay Kafka'ya yayımlanır.
- **Stok tüketimi:** Kafka'da yayımlanan sipariş olayları, stok yönetimi sistemi tarafından tüketilir ve stok azaltma işlemleri gerçekleştirilir.

## Kullanılan Teknolojiler ve Mimariler

### Teknolojiler
- **Kafka:** Mesaj tabanlı iletişim için kullanılan dağıtık sistem.
- **Docker & Docker Compose:** Kafka broker'larının ve Kafka UI'nin çalıştırılması için kullanılmıştır.
- **Confluent Kafka Kütüphanesi:** .NET projelerinde Kafka ile iletişim sağlamak için kullanılan kütüphane.

### Mimariler
- **Event-Driven Architecture (EDA):** Proje, olay tabanlı bir mimari üzerine inşa edilmiştir. Sipariş oluşturma ve stok azaltma işlemleri Kafka üzerinden olaylar aracılığıyla yürütülmektedir.
- **Microservice Mimarisi:** Proje, sipariş yönetimi ve stok yönetimi olmak üzere iki temel mikroservis üzerine kurulmuştur. Servisler Kafka üzerinden birbiriyle iletişim kurar.
- **Asenkron İletişim:** Siparişler oluşturulduktan sonra asenkron olarak stok yönetim sistemine iletilir. Bu sayede sistemde yüksek esneklik ve performans elde edilir.

## Projenin Çalıştırılması

### 1. Repozitory'yi Klonlayın

Proje dosyalarını yerel bilgisayarınıza klonlayın:

```bash
git clone <repository-url> cd <repository-folder>
```

### 2. Docker ile Kafka'yı Başlatma

Proje Docker ve Docker Compose kullanarak Kafka'yı çalıştırır. Aşağıdaki komutları kullanarak tek broker veya çoklu broker kurulumu yapabilirsiniz.

#### Tek Broker Kurulumu

Aşağıdaki komutla Kafka'yı tek bir broker ile başlatabilirsiniz:

```bash
docker-compose up -d
```


#### Çoklu Broker Kümesi Kurulumu

Üç broker ile Kafka kümesi kurmak için:

```bash
docker-compose -f docker-compose-cluster.yml up -d
```


### 3. API'yi Çalıştırma

API'yi çalıştırmak için aşağıdaki komutu kullanabilirsiniz:

```bash
dotnet run --project Order.API dotnet run --project Stock.API
```


### 4. Kafka UI ile Yönetim

Kafka UI, konuları ve mesajları izlemek için kullanılır. Tarayıcı üzerinden Kafka UI'ye şu adresten ulaşabilirsiniz: `http://localhost:8080`


### 5. Olay Tüketicilerini Çalıştırma

Stock API içerisindeki Kafka olay tüketicisi arka plan hizmeti olarak çalışır ve `OrderCreatedEvent` olaylarını dinler. Arka plan hizmeti başlatıldığında stok yönetimi için sipariş olayları işlenecektir.

## Proje İçerisindeki Önemli Kavramlar ve Olay Akışı

### Sipariş Oluşturma
- **OrderService** sınıfı, yeni bir sipariş oluşturulduğunda bir Kafka olayı olan `OrderCreatedEvent` oluşturur ve yayımlar.
- **Kafka Producer:** Sipariş oluşturma olayı Kafka'ya gönderilir. Bu olayın yayımı sırasında mesajın anahtarı ve içeriği de belirlenir.

### Stok Yönetimi
- **StockService** sınıfı, yayımlanan `OrderCreatedEvent` olaylarını Kafka'dan dinler ve stokları bu olaya göre azaltır.
- **Kafka Consumer:** Sipariş olayları tüketilirken olay içeriği çözümlenir ve stoklar güncellenir.
