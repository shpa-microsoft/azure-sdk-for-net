// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Common;
using Microsoft.WindowsAzure.Common.Internals;
using Microsoft.WindowsAzure.Management.ServiceBus;
using Microsoft.WindowsAzure.Management.ServiceBus.Models;

namespace Microsoft.WindowsAzure.Management.ServiceBus
{
    /// <summary>
    /// The Service Bus Management API is a REST API for managing Service Bus
    /// queues, topics, rules and subscriptions.  (see
    /// http://msdn.microsoft.com/en-us/library/windowsazure/hh780776.aspx for
    /// more information)
    /// </summary>
    public partial class ServiceBusManagementClient : ServiceClient<ServiceBusManagementClient>, IServiceBusManagementClient
    {
        private Uri _baseUri;
        
        /// <summary>
        /// The URI used as the base for all Service Bus requests.
        /// </summary>
        public Uri BaseUri
        {
            get { return this._baseUri; }
        }
        
        private SubscriptionCloudCredentials _credentials;
        
        /// <summary>
        /// When you create a Windows Azure subscription, it is uniquely
        /// identified by a subscription ID. The subscription ID forms part of
        /// the URI for every call that you make to the Service Management
        /// API.  The Windows Azure Service ManagementAPI use mutual
        /// authentication of management certificates over SSL to ensure that
        /// a request made to the service is secure.  No anonymous requests
        /// are allowed.
        /// </summary>
        public SubscriptionCloudCredentials Credentials
        {
            get { return this._credentials; }
        }
        
        private INamespaceOperations _namespaces;
        
        /// <summary>
        /// The Service Bus Management API includes operations for managing
        /// Service Bus namespaces.
        /// </summary>
        public virtual INamespaceOperations Namespaces
        {
            get { return this._namespaces; }
        }
        
        private INotificationHubOperations _notificationHubs;
        
        /// <summary>
        /// The Service Bus Management API includes operations for managing
        /// Service Bus notification hubs.
        /// </summary>
        public virtual INotificationHubOperations NotificationHubs
        {
            get { return this._notificationHubs; }
        }
        
        private IQueueOperations _queues;
        
        /// <summary>
        /// The Service Bus Management API includes operations for managing
        /// Service Bus queues.
        /// </summary>
        public virtual IQueueOperations Queues
        {
            get { return this._queues; }
        }
        
        private IRelayOperations _relays;
        
        /// <summary>
        /// The Service Bus Management API includes operations for managing
        /// Service Bus relays.
        /// </summary>
        public virtual IRelayOperations Relays
        {
            get { return this._relays; }
        }
        
        private ITopicOperations _topics;
        
        /// <summary>
        /// The Service Bus Management API includes operations for managing
        /// Service Bus topics for a namespace.
        /// </summary>
        public virtual ITopicOperations Topics
        {
            get { return this._topics; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ServiceBusManagementClient class.
        /// </summary>
        private ServiceBusManagementClient()
            : base()
        {
            this._namespaces = new NamespaceOperations(this);
            this._notificationHubs = new NotificationHubOperations(this);
            this._queues = new QueueOperations(this);
            this._relays = new RelayOperations(this);
            this._topics = new TopicOperations(this);
            this.HttpClient.Timeout = TimeSpan.FromSeconds(300);
        }
        
        /// <summary>
        /// Initializes a new instance of the ServiceBusManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// When you create a Windows Azure subscription, it is uniquely
        /// identified by a subscription ID. The subscription ID forms part of
        /// the URI for every call that you make to the Service Management
        /// API.  The Windows Azure Service ManagementAPI use mutual
        /// authentication of management certificates over SSL to ensure that
        /// a request made to the service is secure.  No anonymous requests
        /// are allowed.
        /// </param>
        /// <param name='baseUri'>
        /// The URI used as the base for all Service Bus requests.
        /// </param>
        public ServiceBusManagementClient(SubscriptionCloudCredentials credentials, Uri baseUri)
            : this()
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this._credentials = credentials;
            this._baseUri = baseUri;
            
            this.Credentials.InitializeServiceClient(this);
        }
        
        /// <summary>
        /// Initializes a new instance of the ServiceBusManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// When you create a Windows Azure subscription, it is uniquely
        /// identified by a subscription ID. The subscription ID forms part of
        /// the URI for every call that you make to the Service Management
        /// API.  The Windows Azure Service ManagementAPI use mutual
        /// authentication of management certificates over SSL to ensure that
        /// a request made to the service is secure.  No anonymous requests
        /// are allowed.
        /// </param>
        public ServiceBusManagementClient(SubscriptionCloudCredentials credentials)
            : this()
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;
            this._baseUri = new Uri("https://management.core.windows.net");
            
            this.Credentials.InitializeServiceClient(this);
        }
        
        /// <summary>
        /// The Get Operation Status operation returns the status of
        /// thespecified operation. After calling an asynchronous operation,
        /// you can call Get Operation Status to determine whether the
        /// operation has succeeded, failed, or is still in progress.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/ee460783.aspx
        /// for more information)
        /// </summary>
        /// <param name='requestId'>
        /// The request ID for the request you wish to track. The request ID is
        /// returned in the x-ms-request-id response header for every request.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response body contains the status of the specified asynchronous
        /// operation, indicating whether it has succeeded, is inprogress, or
        /// has failed. Note that this status is distinct from the HTTP status
        /// code returned for the Get Operation Status operation itself.  If
        /// the asynchronous operation succeeded, the response body includes
        /// the HTTP status code for the successful request.  If the
        /// asynchronous operation failed, the response body includes the HTTP
        /// status code for the failed request, and also includes error
        /// information regarding the failure.
        /// </returns>
        public async Task<ServiceBusOperationStatusResponse> GetOperationStatusAsync(string requestId, CancellationToken cancellationToken)
        {
            // Validate
            if (requestId == null)
            {
                throw new ArgumentNullException("requestId");
            }
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("requestId", requestId);
                Tracing.Enter(invocationId, this, "GetOperationStatusAsync", tracingParameters);
            }
            
            // Construct URL
            string url = new Uri(this.BaseUri, "/").ToString() + this.Credentials.SubscriptionId + "/operations/" + requestId;
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-version", "2013-08-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    ServiceBusOperationStatusResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new ServiceBusOperationStatusResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement operationElement = responseDoc.Element(XName.Get("Operation", "http://schemas.microsoft.com/windowsazure"));
                    if (operationElement != null)
                    {
                        XElement idElement = operationElement.Element(XName.Get("ID", "http://schemas.microsoft.com/windowsazure"));
                        if (idElement != null)
                        {
                            string idInstance = idElement.Value;
                            result.Id = idInstance;
                        }
                        
                        XElement statusElement = operationElement.Element(XName.Get("Status", "http://schemas.microsoft.com/windowsazure"));
                        if (statusElement != null)
                        {
                            OperationStatus statusInstance = (OperationStatus)Enum.Parse(typeof(OperationStatus), statusElement.Value, false);
                            result.Status = statusInstance;
                        }
                        
                        XElement httpStatusCodeElement = operationElement.Element(XName.Get("HttpStatusCode", "http://schemas.microsoft.com/windowsazure"));
                        if (httpStatusCodeElement != null)
                        {
                            HttpStatusCode httpStatusCodeInstance = (HttpStatusCode)Enum.Parse(typeof(HttpStatusCode), httpStatusCodeElement.Value, false);
                            result.HttpStatusCode = httpStatusCodeInstance;
                        }
                        
                        XElement errorElement = operationElement.Element(XName.Get("Error", "http://schemas.microsoft.com/windowsazure"));
                        if (errorElement != null)
                        {
                            ServiceBusOperationStatusResponse.ErrorDetails errorInstance = new ServiceBusOperationStatusResponse.ErrorDetails();
                            result.Error = errorInstance;
                            
                            XElement codeElement = errorElement.Element(XName.Get("Code", "http://schemas.microsoft.com/windowsazure"));
                            if (codeElement != null)
                            {
                                string codeInstance = codeElement.Value;
                                errorInstance.Code = codeInstance;
                            }
                            
                            XElement messageElement = errorElement.Element(XName.Get("Message", "http://schemas.microsoft.com/windowsazure"));
                            if (messageElement != null)
                            {
                                string messageInstance = messageElement.Value;
                                errorInstance.Message = messageInstance;
                            }
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Retrieves the list of regions that support the creation and
        /// management of Service Bus service namespaces.  (see
        /// http://msdn.microsoft.com/en-us/library/windowsazure/jj860465.aspx
        /// for more information)
        /// </summary>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// A response to a request for a list of regions.
        /// </returns>
        public async Task<ServiceBusRegionsResponse> GetServiceBusRegionsAsync(CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = CloudContext.Configuration.Tracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = Tracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                Tracing.Enter(invocationId, this, "GetServiceBusRegionsAsync", tracingParameters);
            }
            
            // Construct URL
            string url = new Uri(this.BaseUri, "/").ToString() + this.Credentials.SubscriptionId + "/services/servicebus/regions";
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("Accept", "application/atom+xml");
                httpRequest.Headers.Add("x-ms-version", "2013-08-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        Tracing.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        Tracing.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false), CloudExceptionType.Xml);
                        if (shouldTrace)
                        {
                            Tracing.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    ServiceBusRegionsResponse result = null;
                    // Deserialize Response
                    cancellationToken.ThrowIfCancellationRequested();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                    result = new ServiceBusRegionsResponse();
                    XDocument responseDoc = XDocument.Parse(responseContent);
                    
                    XElement feedElement = responseDoc.Element(XName.Get("feed", "http://www.w3.org/2005/Atom"));
                    if (feedElement != null)
                    {
                        if (feedElement != null)
                        {
                            foreach (XElement entriesElement in feedElement.Elements(XName.Get("entry", "http://www.w3.org/2005/Atom")))
                            {
                                ServiceBusLocation entryInstance = new ServiceBusLocation();
                                result.Regions.Add(entryInstance);
                                
                                XElement contentElement = entriesElement.Element(XName.Get("content", "http://www.w3.org/2005/Atom"));
                                if (contentElement != null)
                                {
                                    XElement regionCodeDescriptionElement = contentElement.Element(XName.Get("RegionCodeDescription", "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect"));
                                    if (regionCodeDescriptionElement != null)
                                    {
                                        XElement codeElement = regionCodeDescriptionElement.Element(XName.Get("Code", "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect"));
                                        if (codeElement != null)
                                        {
                                            string codeInstance = codeElement.Value;
                                            entryInstance.Code = codeInstance;
                                        }
                                        
                                        XElement fullNameElement = regionCodeDescriptionElement.Element(XName.Get("FullName", "http://schemas.microsoft.com/netservices/2010/10/servicebus/connect"));
                                        if (fullNameElement != null)
                                        {
                                            string fullNameInstance = fullNameElement.Value;
                                            entryInstance.FullName = fullNameInstance;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        Tracing.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
