# IO.Swagger.Api.ScheduleApi

All URIs are relative to *https://public-api.closelink.net*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Create**](ScheduleApi.md#create) | **POST** /v1/schedule | Creates new Schedules
[**Get**](ScheduleApi.md#get) | **GET** /v1/schedule/{scheduleId} | Finds a Schedule by id
[**GetList**](ScheduleApi.md#getlist) | **GET** /v1/schedule/list | Finds a List of Schedules
[**Update**](ScheduleApi.md#update) | **PUT** /v1/schedule | Updates future Schedules (Overrides all future Schedules)


<a name="create"></a>
# **Create**
> List<Schedule> Create (List<Schedule> body = null)

Creates new Schedules

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class CreateExample
    {
        public void main()
        {
            // Configure API key authorization: apikey
            Configuration.Default.AddApiKey("apikey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("apikey", "Bearer");

            var apiInstance = new ScheduleApi();
            var body = new List<Schedule>(); // List<Schedule> |  (optional) 

            try
            {
                // Creates new Schedules
                List&lt;Schedule&gt; result = apiInstance.Create(body);
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

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;Schedule&gt;**](Schedule.md)|  | [optional] 

### Return type

[**List<Schedule>**](Schedule.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json, application/xml
 - **Accept**: application/json, application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="get"></a>
# **Get**
> Schedule Get (string scheduleId)

Finds a Schedule by id

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetExample
    {
        public void main()
        {
            // Configure API key authorization: apikey
            Configuration.Default.AddApiKey("apikey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("apikey", "Bearer");

            var apiInstance = new ScheduleApi();
            var scheduleId = scheduleId_example;  // string | 

            try
            {
                // Finds a Schedule by id
                Schedule result = apiInstance.Get(scheduleId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScheduleApi.Get: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **scheduleId** | **string**|  | 

### Return type

[**Schedule**](Schedule.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json, application/xml
 - **Accept**: application/json, application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getlist"></a>
# **GetList**
> List<Schedule> GetList (string imo = null, DateTime? etaFrom = null, DateTime? etaTo = null)

Finds a List of Schedules

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class GetListExample
    {
        public void main()
        {
            // Configure API key authorization: apikey
            Configuration.Default.AddApiKey("apikey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("apikey", "Bearer");

            var apiInstance = new ScheduleApi();
            var imo = imo_example;  // string | Optional imo filter (optional) 
            var etaFrom = 2013-10-20T19:20:30+01:00;  // DateTime? | Optional eta from date filter (optional) 
            var etaTo = 2013-10-20T19:20:30+01:00;  // DateTime? | Optional eta to date filter (optional) 

            try
            {
                // Finds a List of Schedules
                List&lt;Schedule&gt; result = apiInstance.GetList(imo, etaFrom, etaTo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScheduleApi.GetList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **imo** | **string**| Optional imo filter | [optional] 
 **etaFrom** | **DateTime?**| Optional eta from date filter | [optional] 
 **etaTo** | **DateTime?**| Optional eta to date filter | [optional] 

### Return type

[**List<Schedule>**](Schedule.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json, application/xml
 - **Accept**: application/json, application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="update"></a>
# **Update**
> List<Schedule> Update (List<Schedule> body = null)

Updates future Schedules (Overrides all future Schedules)

### Example
```csharp
using System;
using System.Diagnostics;
using IO.Swagger.Api;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace Example
{
    public class UpdateExample
    {
        public void main()
        {
            // Configure API key authorization: apikey
            Configuration.Default.AddApiKey("apikey", "YOUR_API_KEY");
            // Uncomment below to setup prefix (e.g. Bearer) for API key, if needed
            // Configuration.Default.AddApiKeyPrefix("apikey", "Bearer");

            var apiInstance = new ScheduleApi();
            var body = new List<Schedule>(); // List<Schedule> |  (optional) 

            try
            {
                // Updates future Schedules (Overrides all future Schedules)
                List&lt;Schedule&gt; result = apiInstance.Update(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ScheduleApi.Update: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**List&lt;Schedule&gt;**](Schedule.md)|  | [optional] 

### Return type

[**List<Schedule>**](Schedule.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json, application/xml
 - **Accept**: application/json, application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

