# CloselinkAPI.Api.StockApi

All URIs are relative to *https://public-api.closelink.net*

Method | HTTP request | Description
------------- | ------------- | -------------
[**PostStocks**](StockApi.md#poststocks) | **POST** /v1/stock | Creates new Stock data


<a name="poststocks"></a>
# **PostStocks**
> List<Stock> PostStocks (List<Stock> body = null)

Creates new Stock data

### Example
```csharp
using System;
using System.Diagnostics;
using CloselinkAPI.Api;
using CloselinkAPI.Client;
using CloselinkAPI.Model;

namespace Example
{
    public class PostStocksExample
    {
        public void main()
        {
            // Configure API key authorization: apikey
            Configuration.Default.AddApiKey("apikey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("apikey", "Bearer");

            var apiInstance = new StockApi();
            var body = new List<Stock>(); // List<Stock> |  (optional) 

            try
            {
                // Creates new Stock data
                List&lt;Stock&gt; result = apiInstance.PostStocks(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling StockApi.PostStocks: " + e.Message );
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

