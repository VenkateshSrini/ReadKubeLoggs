// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace k8s.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// NamespaceStatus is information about the current status of a Namespace.
    /// </summary>
    public partial class V1NamespaceStatus
    {
        /// <summary>
        /// Initializes a new instance of the V1NamespaceStatus class.
        /// </summary>
        public V1NamespaceStatus()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the V1NamespaceStatus class.
        /// </summary>
        /// <param name="phase">Phase is the current lifecycle phase of the
        /// namespace. More info:
        /// https://kubernetes.io/docs/tasks/administer-cluster/namespaces/</param>
        public V1NamespaceStatus(string phase = default(string))
        {
            Phase = phase;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets phase is the current lifecycle phase of the namespace.
        /// More info:
        /// https://kubernetes.io/docs/tasks/administer-cluster/namespaces/
        /// </summary>
        [JsonProperty(PropertyName = "phase")]
        public string Phase { get; set; }

    }
}
