// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.Blueprint.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Azure resource created from deployment job.
    /// </summary>
    public partial class AssignmentJobCreatedResource : AzureResourceBase
    {
        /// <summary>
        /// Initializes a new instance of the AssignmentJobCreatedResource
        /// class.
        /// </summary>
        public AssignmentJobCreatedResource()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AssignmentJobCreatedResource
        /// class.
        /// </summary>
        /// <param name="id">String Id used to locate any resource on
        /// Azure.</param>
        /// <param name="type">Type of this resource.</param>
        /// <param name="name">Name of this resource.</param>
        /// <param name="properties">Additional properties in a
        /// dictionary.</param>
        public AssignmentJobCreatedResource(string id = default(string), string type = default(string), string name = default(string), IDictionary<string, string> properties = default(IDictionary<string, string>))
            : base(id, type, name)
        {
            Properties = properties;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets additional properties in a dictionary.
        /// </summary>
        [JsonProperty(PropertyName = "properties")]
        public IDictionary<string, string> Properties { get; set; }

    }
}
