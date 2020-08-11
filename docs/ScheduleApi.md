# CloselinkAPI.Api.ScheduleApi

All URIs are relative to *https://public-api.closelink.net*

Method | HTTP request | Description
------------- | ------------- | -------------
[**Create**](ScheduleApi.md#create) | **POST** /v1/schedule | Creates new Schedules
[**Get**](ScheduleApi.md#get) | **GET** /v1/schedule/{scheduleId} | Finds a Schedule by id
[**GetList**](ScheduleApi.md#getlist) | **GET** /v1/schedule/list | Finds a List of Schedules
[**Update**](ScheduleApi.md#update) | **PUT** /v1/schedule | Updates future Schedules (Overrides all future Schedules)


<a name="create"></a>
# **Create**
> List<Schedule> Create(List<Schedule> body)

Creates new Schedules

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

            var apiInstance = new ScheduleApi();
            var schedules = new List<Schedule>
            {
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-09-01T00:00:00.000Z"),
                    DateTime.Parse("2020-09-04T00:00:00.000Z"),
                    "DEHAM"
                ),
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-09-06T00:00:00.000Z"),
                    DateTime.Parse("2020-09-07T00:00:00.000Z"),
                    "AUSYD"
                )
            };

            try
            {
                // Creates new Schedule data
                ApiResponse<List<Schedule>> response = apiInstance.Create(schedules);
                Console.WriteLine("StatusCode: " + response.StatusCode);
                var scheduleResult = response.Data;
                scheduleResult.ForEach(Console.WriteLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling ScheduleApi.Create: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  
------------- | ------------- | ------------- 
 **body** | [**List&lt;Schedule&gt;**](Schedule.md)| List of Schedule data to create.

### Return type

[**List&lt;Schedule&gt;**](Schedule.md)

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

            var apiInstance = new ScheduleApi();
            var scheduleId = "exampleId";

            try
            {
                // Creates new Schedule data
                ApiResponse<Schedule> response = apiInstance.Get(scheduleId);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Data); 
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling ScheduleApi.Get: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description
------------- | ------------- | ------------- 
 **scheduleId** | **string** | scheduleId of searched Schedule

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

             var apiInstance = new ScheduleApi();
            var imo = "9703291";  // string | Optional imo filter (optional) 
            var etaFrom = DateTime.Parse("2020-08-31T00:00:00.000Z");  // DateTime? | Optional eta from date filter (optional) 
            var etaTo = DateTime.Parse("2020-09-10T00:00:00.000Z");  // DateTime? | Optional eta to date filter (optional)  

            try
            {
                // Creates new Schedule data
                ApiResponse<List<Schedule>> response = apiInstance.GetList(imo, etaFrom, etaTo);
                Console.WriteLine("StatusCode: " + response.StatusCode);
                var scheduleResult = response.Data;
                scheduleResult.ForEach(Console.WriteLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling ScheduleApi.GetList: " + e.Message );
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
> List<Schedule> Update (List<Schedule> body)

Updates future Schedules (Overrides all future Schedules)

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

            var apiInstance = new ScheduleApi();
            var schedules = new List<Schedule>
            {
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-09-01T00:00:00.000Z"),
                    DateTime.Parse("2020-09-04T00:00:00.000Z"),
                    "DEHAM"
                ),
                new Schedule(
                    "imo1",
                    DateTime.Parse("2020-09-06T00:00:00.000Z"),
                    DateTime.Parse("2020-09-07T00:00:00.000Z"),
                    "AUSYD"
                )
            };

            try
            {
                // Updates new Schedule data
                ApiResponse<List<Schedule>> response = apiInstance.Update(schedules);
                Console.WriteLine("StatusCode: " + response.StatusCode);
                var scheduleResult = response.Data;
                scheduleResult.ForEach(Console.WriteLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling ScheduleApi.Update: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description 
------------- | ------------- | ------------- 
 **body** | [**List&lt;Schedule&gt;**](Schedule.md) | List of Schedule data to create. 

### Return type

[**List<Schedule>**](Schedule.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json, application/xml
 - **Accept**: application/json, application/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

