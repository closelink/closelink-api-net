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
> AgentResponseMessage CreateAgent (AgentRequestMessage body)

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
            var body = new AgentRequestMessage(
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
                        new List<string> { "portId1", "portId2" },
                        "Note 1",
                        "customerId1"
                    ); 

            try
            {
                // Create agent
                ApiResponse<AgentRequestMessage> response = apiInstance.CreateAgent(body);
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
 **body** | [**AgentRequestMessage**](AgentRequestMessage.md)|  | 

### Return type

[**AgentResponseMessage**](AgentResponseMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="createagentbulk"></a>
# **CreateAgentBulk**
> AgentsResponseMessage CreateAgentBulk (AgentsRequestMessage body)

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
            var body = new AgentsRequestMessage(
                new List<AgentRequestMessage>{
                    new AgentRequestMessage(
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
                        new List<string> { "portId1", "portId2" },
                        "Note 1",
                        "customerId1"
                    ),
                    new AgentRequestMessage(
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
                        new List<string> { "portId1", "portId2" },
                        "Note 2",
                        "customerId2"
                    )
                });

            try
            {
                // Create multiple agents
                ApiResponse<AgentsResponseMessage> response = apiInstance.CreateAgentBulk(body);
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
 **body** | [**AgentsRequestMessage**](AgentsRequestMessage.md)|  | 

### Return type

[**AgentsResponseMessage**](AgentsResponseMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findagentbyexternalid"></a>
# **FindAgentByExternalId**
> AgentResponseMessage FindAgentByExternalId (string externalId)

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
                ApiResponse<AgentResponseMessage> response = apiInstance.FindAgentByExternalId(externalId);
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

[**AgentResponseMessage**](AgentResponseMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findagentbyid"></a>
# **FindAgentById**
> AgentResponseMessage FindAgentById (string id)

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
                ApiResponse<AgentResponseMessage> response = apiInstance.FindAgentById(id);
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

[**AgentResponseMessage**](AgentResponseMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findagents"></a>
# **FindAgents**
> AgentsResponseMessage FindAgents (List<string> customerIds, string searchQuery, List<string> portIds)

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
                ApiResponse<AgentsResponseMessage> response = apiInstance.FindAgents();
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
 **portIds** | [**List&lt;string&gt;**](string.md)| List of port IDs | [optional]

### Return type

[**AgentsResponseMessage**](AgentsResponseMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateagent"></a>
# **UpdateAgent**
> AgentResponseMessage UpdateAgent (string id, AgentRequestMessage body)

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
            var body = new AgentResponseMessage(
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
                new List<string> { "portId1", "portId2" },
                "Note 1",
                "customerId1"
            );

            try
            {
                // Update agent
                ApiResponse<AgentResponseMessage> response = apiInstance.UpdateAgent(id, body);
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
 **body** | [**AgentRequestMessage**](AgentRequestMessage.md)|  | 

### Return type

[**AgentResponseMessage**](AgentResponseMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateagentbulk"></a>
# **UpdateAgentBulk**
> AgentsResponseMessage UpdateAgentBulk (AgentsRequestMessage body)

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
            var body = return new AgentsRequestMessage(
                new List<AgentRequestMessage>{
                    new AgentRequestMessage(
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
                        new List<string> { "portId1", "portId2" },
                        "Note 1",
                        "customerId1",
                        "externalId1"
                    ),
                    new AgentRequestMessage(
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
                        new List<string> { "portId1", "portId2" },
                        "Note 2",
                        "customerId2",
                        "externalId1"
                    )
                });

            try
            {
                // Update multiple agents
                ApiResponse<AgentsResponseMessage> response = apiInstance.UpdateAgentBulk(body);
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
 **body** | [**AgentsRequestMessage**](AgentsRequestMessage.md)|  | 

### Return type

[**AgentsResponseMessage**](AgentsResponseMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateagentbyexternalid"></a>
# **UpdateAgentByExternalId**
> AgentResponseMessage UpdateAgentByExternalId (string externalId, AgentRequestMessage body)

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
            var body = new AgentRequestMessage(
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
                    new List<string> { "portId1", "portId2" },
                    "Note 1",
                    "customerId1"
                );

            try
            {
                // Update agent by external ID
                ApiResponse<AgentResponseMessage> response = apiInstance.UpdateAgentByExternalId(externalId, body);
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
 **body** | [**AgentRequestMessage**](AgentRequestMessage.md)|  | 

### Return type

[**AgentResponseMessage**](AgentResponseMessage.md)

### Authorization

[apikey](../README.md#apikey)

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

