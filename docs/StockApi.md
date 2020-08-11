# CloselinkAPI.Api.StockApi

All URIs are relative to *https://public-api.closelink.net*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Create**](StockApi.md#create) | **POST** /v1/stock | Creates new Stock data


<a name="create"></a>
# **Create**
> List<Stock> Create (List<Stock> body)

Creates new Stock data

### Example
```csharp
using System;
using System.Collections.Generic;
using CloselinkAPI.Api;
using CloselinkAPI.Client;
using CloselinkAPI.Model;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure API key authorization
            Configuration.Default.ApiKey = "YOUR_API_KEY";

            var apiInstance = new StockApi();
            var stocks = new List<Stock>(){
                new Stock(
                    "imo1",
                    DateTime.Parse("2020-08-01T00:00:00.000Z"),
                    5000,
                    Stock.OilTypeEnum.AECIRC
                ),
                new Stock(
                    "imo1",
                    DateTime.Parse("2020-08-01T00:00:00.000Z"),
                    7000,
                    Stock.OilTypeEnum.MECYLHS
                )
            };

            try
            {
                // Creates new Stock data
                ApiResponse<List<Stock>> response = apiInstance.Create(stocks);
                Console.WriteLine("StatusCode: " + response.StatusCode);
                var stockResult = response.Data;
                stockResult.ForEach(delegate (Stock stock){
                        Console.WriteLine(stock);
                    }
                );

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling StockApi.Create: " + e.Message);
            }
        }
    }
}
```

### Parameters

Name | Type | Description  
------------- | ------------- | ------------- 
 **body** | [**List&lt;Stock&gt;**](Stock.md)| List of Stock data to create. 

### Return type

[**List&lt;Stock&gt;**](Stock.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json, application/xml
 - **Accept**: application/json, application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

