// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace k8s.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// APIVersions lists the versions that are available, to allow clients to
    /// discover the API at /api, which is the root path of the legacy v1 API.
    /// </summary>
    public partial class V1APIVersions
    {
        /// <summary>
        /// Initializes a new instance of the V1APIVersions class.
        /// </summary>
        public V1APIVersions()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the V1APIVersions class.
        /// </summary>
        /// <param name="serverAddressByClientCIDRs">a map of client CIDR to
        /// server address that is serving this group. This is to help clients
        /// reach servers in the most network-efficient way possible. Clients
        /// can use the appropriate server address as per the CIDR that they
        /// match. In case of multiple matches, clients should use the longest
        /// matching CIDR. The server returns only those CIDRs that it thinks
        /// that the client can match. For example: the master will return an
        /// internal IP CIDR only, if the client reaches the server using an
        /// internal IP. Server looks at X-Forwarded-For header or X-Real-Ip
        /// header or request.RemoteAddr (in that order) to get the client
        /// IP.</param>
        /// <param name="versions">versions are the api versions that are
        /// available.</param>
        /// <param name="apiVersion">APIVersion defines the versioned schema of
        /// this representation of an object. Servers should convert recognized
        /// schemas to the latest internal value, and may reject unrecognized
        /// values. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#resources</param>
        /// <param name="kind">Kind is a string value representing the REST
        /// resource this object represents. Servers may infer this from the
        /// endpoint the client submits requests to. Cannot be updated. In
        /// CamelCase. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#types-kinds</param>
        public V1APIVersions(IList<V1ServerAddressByClientCIDR> serverAddressByClientCIDRs, IList<string> versions, string apiVersion = default(string), string kind = default(string))
        {
            ApiVersion = apiVersion;
            Kind = kind;
            ServerAddressByClientCIDRs = serverAddressByClientCIDRs;
            Versions = versions;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets aPIVersion defines the versioned schema of this
        /// representation of an object. Servers should convert recognized
        /// schemas to the latest internal value, and may reject unrecognized
        /// values. More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#resources
        /// </summary>
        [JsonProperty(PropertyName = "apiVersion")]
        public string ApiVersion { get; set; }

        /// <summary>
        /// Gets or sets kind is a string value representing the REST resource
        /// this object represents. Servers may infer this from the endpoint
        /// the client submits requests to. Cannot be updated. In CamelCase.
        /// More info:
        /// https://git.k8s.io/community/contributors/devel/api-conventions.md#types-kinds
        /// </summary>
        [JsonProperty(PropertyName = "kind")]
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets a map of client CIDR to server address that is serving
        /// this group. This is to help clients reach servers in the most
        /// network-efficient way possible. Clients can use the appropriate
        /// server address as per the CIDR that they match. In case of multiple
        /// matches, clients should use the longest matching CIDR. The server
        /// returns only those CIDRs that it thinks that the client can match.
        /// For example: the master will return an internal IP CIDR only, if
        /// the client reaches the server using an internal IP. Server looks at
        /// X-Forwarded-For header or X-Real-Ip header or request.RemoteAddr
        /// (in that order) to get the client IP.
        /// </summary>
        [JsonProperty(PropertyName = "serverAddressByClientCIDRs")]
        public IList<V1ServerAddressByClientCIDR> ServerAddressByClientCIDRs { get; set; }

        /// <summary>
        /// Gets or sets versions are the api versions that are available.
        /// </summary>
        [JsonProperty(PropertyName = "versions")]
        public IList<string> Versions { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (ServerAddressByClientCIDRs == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ServerAddressByClientCIDRs");
            }
            if (Versions == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Versions");
            }
            if (ServerAddressByClientCIDRs != null)
            {
                foreach (var element in ServerAddressByClientCIDRs)
                {
                    if (element != null)
                    {
                        element.Validate();
                    }
                }
            }
        }
    }
}
