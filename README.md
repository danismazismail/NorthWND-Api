# NorthWND-Api

![C#](https://upload.wikimedia.org/wikipedia/commons/thumb/0/0d/C_Sharp_wordmark.svg/200px-C_Sharp_wordmark.svg.png)
![ASP.NET Core](https://upload.wikimedia.org/wikipedia/commons/thumb/e/ee/.NET_Core_Logo.svg/200px-.NET_Core_Logo.svg.png) 
![Entity Framework Core](https://upload.wikimedia.org/wikipedia/commons/thumb/8/8d/Entity_Framework_Logo.svg/200px-Entity_Framework_Logo.svg.png) 
![MSSQL]((https://user-images.githubusercontent.com/4249331/52232852-e2c4f780-28bd-11e9-835d-1e3cf3e43888.png))) 
![PostgreSQL](https://upload.wikimedia.org/wikipedia/commons/thumb/2/29/Postgresql_elephant.svg/200px-Postgresql_elephant.svg.png) 
![Visual Studio](https://upload.wikimedia.org/wikipedia/commons/thumb/5/59/Visual_Studio_Icon_2019.svg/200px-Visual_Studio_Icon_2019.svg.png) 
![Git](https://upload.wikimedia.org/wikipedia/commons/thumb/e/e0/Git-logo.svg/200px-Git-logo.svg.png) 
![GitHub](https://upload.wikimedia.org/wikipedia/commons/thumb/9/91/Octicons-mark-github.svg/200px-Octicons-mark-github.svg.png)

## Proje Tanımı

NorthWND-Api, Entity Framework Core kullanılarak veri erişimi sağlayan ve MSSQL ve PostgreSQL gibi çeşitli veritabanlarını destekleyen bir ASP.NET Core Web API projesidir.

## API Belgeleri

### URL
`[https://api.projeniz.com](https://github.com/danismazismail/NorthWND-Api)`

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
