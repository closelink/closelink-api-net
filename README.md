### Closelink.NET
API Wrapper for the Closelink API (http://developer.closelink.net)

<a name="installation"></a>
## Installation
```
Install-Package CloselinkAPI
```

```
dotnet add package CloselinkAPI
```

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using CloselinkAPI.Api;
using CloselinkAPI.Client;
using CloselinkAPI.Model;
```

<a name="getting-started"></a>
## Getting Started

```csharp
using System;
using System.Diagnostics;
using CloselinkAPI.Api;
using CloselinkAPI.Client;
using CloselinkAPI.Model;

namespace Example
{
    public class Example
    {
        public void main()
        {

            // Configure API key authorization: apikey
            Configuration.Default.ApiKey.Add("apikey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.ApiKeyPrefix.Add("apikey", "Bearer");

            var apiInstance = new ScheduleApi();
            var body = new List<Schedule>(); // List<Schedule> |  (optional) 

            try
            {
                // Creates new Schedules
                List<Schedule> result = apiInstance.Create(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScheduleApi.Create: " + e.Message );
            }

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to *https://public-api.closelink.net*

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*ScheduleApi* | [**Create**](docs/ScheduleApi.md#create) | **POST** /v1/schedule | Creates new Schedules
*ScheduleApi* | [**Get**](docs/ScheduleApi.md#get) | **GET** /v1/schedule/{scheduleId} | Finds a Schedule by id
*ScheduleApi* | [**GetList**](docs/ScheduleApi.md#getlist) | **GET** /v1/schedule/list | Finds a List of Schedules
*ScheduleApi* | [**GetPage**](docs/ScheduleApi.md#getpage) | **GET** /v1/schedule | Finds a Page of Schedules
*ScheduleApi* | [**Update**](docs/ScheduleApi.md#update) | **PUT** /v1/schedule | Updates future Schedules (Overrides all future Schedules)
*StockApi* | [**PostStocks**](docs/StockApi.md#poststocks) | **POST** /v1/stock | Creates new Stock data


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.Page](docs/Page.md)
 - [Model.Pageable](docs/Pageable.md)
 - [Model.Schedule](docs/Schedule.md)
 - [Model.Stock](docs/Stock.md)


<a name="documentation-for-authorization"></a>
## Documentation for Authorization

<a name="apikey"></a>
### apikey

- **Type**: API key
- **API key parameter name**: apikey
- **Location**: HTTP header
