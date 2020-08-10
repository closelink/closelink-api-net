# IO.Swagger.Api.StockApi

All URIs are relative to *https://public-api.closelink.net*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateStocks**](StockApi.md#createstocks) | **POST** /v1/stock | Creates new Stock data


<a name="createstocks"></a>
# **CreateStocks**
> List<Stock> CreateStocks (List<Stock> body = null)

Creates new Stock data

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateStocksExample
    {
        public void main()
        {
            // Configure API key authorization: apikey
            Configuration.Default.setApiKey("YOUR_API_KEY");

            var apiInstance = new StockApi();
            var body = new List<Stock>(); // List<Stock> |  (optional) 

            try
            {
                // Creates new Stock data
                List&lt;Stock&gt; result = apiInstance.CreateStocks(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StockApi.CreateStocks: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;Stock&gt;**](Stock.md)|  | [optional] 

### Return type

[**List<Stock>**](Stock.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json, application/xml
 - **Accept**: application/json, application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

