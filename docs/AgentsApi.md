# IO.Swagger.Api.AgentsApi

All URIs are relative to *https://public-api.closelink.net*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CreateAgent**](AgentsApi.md#createagent) | **POST** /v1/agents | Create agent
[**CreateAgentBulk**](AgentsApi.md#createagentbulk) | **POST** /v1/agents/bulk | Create multiple agents
[**FindAgentByExternalId**](AgentsApi.md#findagentbyexternalid) | **GET** /v1/agents/external/{externalId} | Find agent by external ID
[**FindAgentById**](AgentsApi.md#findagentbyid) | **GET** /v1/agents/{id} | Find agent by ID
[**FindAgents**](AgentsApi.md#findagents) | **GET** /v1/agents | Find agents
[**UpdateAgent**](AgentsApi.md#updateagent) | **PUT** /v1/agents/{id} | Update agent
[**UpdateAgentBulk**](AgentsApi.md#updateagentbulk) | **PUT** /v1/agents/bulk | Update multiple agents
[**UpdateAgentByExternalId**](AgentsApi.md#updateagentbyexternalid) | **PUT** /v1/agents/external/{externalId} | Update agent by external ID


<a name="createagent"></a>
# **CreateAgent**
> AgentMessage CreateAgent (AgentMessage body)

Create agent

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

            var apiInstance = new AgentsApi();
            var body = new AgentMessage(
                        "Agent 1",
                        new AddressMessage(
                            "Street",
                            "1",
                            "12344",
                            "Hamburg",
                            "Germany"
                        ),
                        new ContactMessage(
                            "Joe Doe",
                            "+49 5454 45 45 4",
                            "joe@doe.com",
                            "+49 45 5454 554 5"
                        ),
                        new List<string> { "loCode1", "loCode2" },
                        "Note 1",
                        "customerId1"
                    ); 

            try
            {
                // Create agent
                ApiResponse<AgentMessage> response = apiInstance.CreateAgent(body);
                Console.WriteLine("StatusCode: " + response.StatusCode);
                Console.WriteLine(response.Data); 
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling AgentsApi.CreateAgent: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**AgentMessage**](AgentMessage.md)|  | 

### Return type

[**AgentMessage**](AgentMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createagentbulk"></a>
# **CreateAgentBulk**
> AgentsMessage CreateAgentBulk (AgentsMessage body)

Create multiple agents

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

            var apiInstance = new AgentsApi();
            var body = new AgentsMessage(
                new List<AgentMessage>{
                    new AgentMessage(
                        "Agent 1",
                        new AddressMessage(
                            "Street",
                            "1",
                            "12344",
                            "Hamburg",
                            "Germany"
                        ),
                        new ContactMessage(
                            "Joe Doe",
                            "+49 5454 45 45 4",
                            "joe@doe.com",
                            "+49 45 5454 554 5"
                        ),
                        new List<string> { "loCode1", "loCode2" },
                        "Note 1",
                        "customerId1"
                    ),
                    new AgentMessage(
                        "Agent 2",
                        new AddressMessage(
                            "Street",
                            "2",
                            "25654",
                            "Hamburg",
                            "Germany"
                        ),
                        new ContactMessage(
                            "Joe Doe",
                            "+49 5454 45 45 4",
                            "joe@doe.com",
                            "+49 45 5454 554 5"
                        ),
                        new List<string> { "loCode1", "loCode2" },
                        "Note 2",
                        "customerId2"
                    )
                });

            try
            {
                // Create multiple agents
                ApiResponse<AgentsMessage> response = apiInstance.CreateAgentBulk(body);
                Console.WriteLine("StatusCode: " + response.StatusCode);
                response.Data.Agents.ForEach(Console.WriteLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling AgentsApi.CreateAgentBulk: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**AgentsMessage**](AgentsMessage.md)|  | 

### Return type

[**AgentsMessage**](AgentsMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findagentbyexternalid"></a>
# **FindAgentByExternalId**
> AgentMessage FindAgentByExternalId (string externalId)

Find agent by external ID

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

            var apiInstance = new AgentsApi();
            var externalId = "externalId1"; 

            try
            {
                // Find agent by external ID
                ApiResponse<AgentMessage> response = apiInstance.FindAgentByExternalId(externalId);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Data); 
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling AgentsApi.FindAgentByExternalId: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **externalId** | **string**|  | 

### Return type

[**AgentMessage**](AgentMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findagentbyid"></a>
# **FindAgentById**
> AgentMessage FindAgentById (string id)

Find agent by ID

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

            var apiInstance = new AgentsApi();
            var id = id_example;  // string | 

            try
            {
                // Find agent by ID
                ApiResponse<AgentMessage> response = apiInstance.FindAgentById(id);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Data); 
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling AgentsApi.FindAgentById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**|  | 

### Return type

[**AgentMessage**](AgentMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findagents"></a>
# **FindAgents**
> AgentsMessage FindAgents (List<string> customerIds, string searchQuery, List<string> loCodes)

Find agents

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

            var apiInstance = new AgentsApi();

            try
            {
                // Find agents
                ApiResponse<AgentsMessage> response = apiInstance.FindAgents();
                Console.WriteLine("StatusCode: " + response.StatusCode);
                response.Data.Agents.ForEach(Console.WriteLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling AgentsApi.FindAgents: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **customerIds** | [**List&lt;string&gt;**](string.md)| List of customer IDs | [optional]
 **searchQuery** | **string**| Search query | [optional]
 **loCodes** | [**List&lt;string&gt;**](string.md)| List of port IDs | [optional]

### Return type

[**AgentsMessage**](AgentsMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateagent"></a>
# **UpdateAgent**
> AgentMessage UpdateAgent (string id, AgentMessage body)

Update agent

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

            var apiInstance = new AgentsApi();
            var id = "id1";
            var body = new AgentMessage(
                "Agent 1",
                new AddressMessage(
                    "Street",
                    "1",
                    "12344",
                    "Hamburg",
                    "Germany"
                ),
                new ContactMessage(
                    "Joe Doe",
                    "+49 5454 45 45 4",
                    "joe@doe.com",
                    "+49 45 5454 554 5"
                ),
                new List<string> { "loCode1", "loCode2" },
                "Note 1",
                "customerId1"
            );

            try
            {
                // Update agent
                ApiResponse<AgentMessage> response = apiInstance.UpdateAgent(id, body);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Data); 
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling AgentsApi.UpdateAgent: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **id** | **string**| Agent ID | 
 **body** | [**AgentMessage**](AgentMessage.md)|  | 

### Return type

[**AgentMessage**](AgentMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateagentbulk"></a>
# **UpdateAgentBulk**
> AgentsMessage UpdateAgentBulk (AgentsMessage body)

Update multiple agents

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

            var apiInstance = new AgentsApi();
            var body = return new AgentsMessage(
                new List<AgentMessage>{
                    new AgentMessage(
                        "Agent 1",
                        new AddressMessage(
                            "Street",
                            "1",
                            "12344",
                            "Hamburg",
                            "Germany"
                        ),
                        new ContactMessage(
                            "Joe Doe",
                            "+49 5454 45 45 4",
                            "joe@doe.com",
                            "+49 45 5454 554 5"
                        ),
                        new List<string> { "loCode1", "loCode2" },
                        "Note 1",
                        "customerId1",
                        "externalId1"
                    ),
                    new AgentMessage(
                        "Agent 2",
                        new AddressMessage(
                            "Street",
                            "2",
                            "25654",
                            "Hamburg",
                            "Germany"
                        ),
                        new ContactMessage(
                            "Joe Doe",
                            "+49 5454 45 45 4",
                            "joe@doe.com",
                            "+49 45 5454 554 5"
                        ),
                        new List<string> { "loCode1", "loCode2" },
                        "Note 2",
                        "customerId2",
                        "externalId1"
                    )
                });

            try
            {
                // Update multiple agents
                ApiResponse<AgentsMessage> response = apiInstance.UpdateAgentBulk(body);
                Console.WriteLine("StatusCode: " + response.StatusCode);
                response.Data.Agents.ForEach(Console.WriteLine);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling AgentsApi.UpdateAgentBulk: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**AgentsMessage**](AgentsMessage.md)|  | 

### Return type

[**AgentsMessage**](AgentsMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateagentbyexternalid"></a>
# **UpdateAgentByExternalId**
> AgentMessage UpdateAgentByExternalId (string externalId, AgentMessage body)

Update agent by external ID

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

            var apiInstance = new AgentsApi();
            var externalId = "externalId1";
            var body = new AgentMessage(
                    "Agent 1",
                    new AddressMessage(
                        "Street",
                        "1",
                        "12344",
                        "Hamburg",
                        "Germany"
                    ),
                    new ContactMessage(
                        "Joe Doe",
                        "+49 5454 45 45 4",
                        "joe@doe.com",
                        "+49 45 5454 554 5"
                    ),
                    new List<string> { "loCode1", "loCode2" },
                    "Note 1",
                    "customerId1"
                );

            try
            {
                // Update agent by external ID
                ApiResponse<AgentMessage> response = apiInstance.UpdateAgentByExternalId(externalId, body);
                Console.WriteLine(response.StatusCode);
                Console.WriteLine(response.Data); 
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception when calling AgentsApi.UpdateAgentByExternalId: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **externalId** | **string**|  | 
 **body** | [**AgentMessage**](AgentMessage.md)|  | 

### Return type

[**AgentMessage**](AgentMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

