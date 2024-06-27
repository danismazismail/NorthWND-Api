# NorthWND-Api

![C#](https://upload.wikimedia.org/wikipedia/commons/4/4f/Csharp_Logo.png) ![ASP.NET](https://upload.wikimedia.org/wikipedia/commons/e/ee/.NET_Core_Logo.svg) ![Entity Framework Core](https://upload.wikimedia.org/wikipedia/commons/6/68/Entity_Framework.png) ![MSSQL](https://upload.wikimedia.org/wikipedia/commons/8/87/Microsoft_SQL_Server_Logo.png) ![PostgreSQL](https://upload.wikimedia.org/wikipedia/commons/2/29/Postgresql_elephant.svg) ![Visual Studio](https://upload.wikimedia.org/wikipedia/commons/5/59/Visual_Studio_Icon_2019.svg) ![Git](https://upload.wikimedia.org/wikipedia/commons/e/e0/Git-logo.svg) ![GitHub](https://upload.wikimedia.org/wikipedia/commons/9/91/Octicons-mark-github.svg)

## Proje Tanımı

NorthWND-Api, Entity Framework Core kullanılarak veri erişimi sağlayan ve MSSQL ve PostgreSQL gibi çeşitli veritabanlarını destekleyen bir ASP.NET Core Web API projesidir.

## Kullanılan Teknolojiler

### Backend
- ![C#](https://upload.wikimedia.org/wikipedia/commons/4/4f/Csharp_Logo.png) C#
- ![ASP.NET](https://upload.wikimedia.org/wikipedia/commons/e/ee/.NET_Core_Logo.svg) ASP.NET Core
- ![Entity Framework Core](https://upload.wikimedia.org/wikipedia/commons/6/68/Entity_Framework.png) Entity Framework Core

### Veritabanları
- ![MSSQL](https://upload.wikimedia.org/wikipedia/commons/8/87/Microsoft_SQL_Server_Logo.png) MSSQL
- ![PostgreSQL](https://upload.wikimedia.org/wikipedia/commons/2/29/Postgresql_elephant.svg) PostgreSQL

### Araçlar
- ![Visual Studio](https://upload.wikimedia.org/wikipedia/commons/5/59/Visual_Studio_Icon_2019.svg) Visual Studio
- ![Git](https://upload.wikimedia.org/wikipedia/commons/e/e0/Git-logo.svg) Git
- ![GitHub](https://upload.wikimedia.org/wikipedia/commons/9/91/Octicons-mark-github.svg) GitHub

## API Belgeleri

### Temel URL
`https://api.projeniz.com`

### Uç Noktalar

#### Tüm Öğeleri Getir

- **URL**: `/api/items`
- **Metod**: `GET`
- **Açıklama**: Tüm öğelerin listesini getirir.
- **Yanıt**:
    ```json
    [
        {
            "id": 1,
            "name": "Öğe 1",
            "description": "Öğe 1'in açıklaması"
        },
        {
            "id": 2,
            "name": "Öğe 2",
            "description": "Öğe 2'nin açıklaması"
        }
    ]
    ```

#### ID'ye Göre Öğe Getir

- **URL**: `/api/items/{id}`
- **Metod**: `GET`
- **Açıklama**: Belirtilen ID'ye sahip bir öğeyi getirir.
- **Parametreler**:
    - `id` (integer, zorunlu): Getirilecek öğenin ID'si.
- **Yanıt**:
    ```json
    {
        "id": 1,
        "name": "Öğe 1",
        "description": "Öğe 1'in açıklaması"
    }
    ```

#### Yeni Öğe Oluştur

- **URL**: `/api/items`
- **Metod**: `POST`
- **Açıklama**: Yeni bir öğe oluşturur.
- **İstek Gövdesi**:
    ```json
    {
        "name": "Yeni Öğe",
        "description": "Yeni öğe için açıklama"
    }
    ```
- **Yanıt**:
    ```json
    {
        "id": 3,
        "name": "Yeni Öğe",
        "description": "Yeni öğe için açıklama"
    }
    ```

#### Öğe Güncelle

- **URL**: `/api/items/{id}`
- **Metod**: `PUT`
- **Açıklama**: Mevcut bir öğeyi günceller.
- **Parametreler**:
    - `id` (integer, zorunlu): Güncellenecek öğenin ID'si.
- **İstek Gövdesi**:
    ```json
    {
        "name": "Güncellenmiş Öğe",
        "description": "Öğenin güncellenmiş açıklaması"
    }
    ```
- **Yanıt**:
    ```json
    {
        "id": 1,
        "name": "Güncellenmiş Öğe",
        "description": "Öğenin güncellenmiş açıklaması"
    }
    ```

#### Öğe Sil

- **URL**: `/api/items/{id}`
- **Metod**: `DELETE`
- **Açıklama**: Belirtilen ID'ye sahip bir öğeyi siler.
- **Parametreler**:
    - `id` (integer, zorunlu): Silinecek öğenin ID'si.
- **Yanıt**:
    ```json
    {
        "message": "Öğe başarıyla silindi"
    }
    ```

## Başlangıç

Bu projeyi kullanmaya başlamak için, depoyu klonlayın ve aşağıdaki adımları izleyin.

```bash
git clone https://github.com/danismazismail/NorthWND-Api.git
cd NorthWND-Api
