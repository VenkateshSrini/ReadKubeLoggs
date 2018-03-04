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
    /// ID Range provides a min/max of an allowed range of IDs.
    /// </summary>
    public partial class V1beta1IDRange
    {
        /// <summary>
        /// Initializes a new instance of the V1beta1IDRange class.
        /// </summary>
        public V1beta1IDRange()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the V1beta1IDRange class.
        /// </summary>
        /// <param name="max">Max is the end of the range, inclusive.</param>
        /// <param name="min">Min is the start of the range, inclusive.</param>
        public V1beta1IDRange(long max, long min)
        {
            Max = max;
            Min = min;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets max is the end of the range, inclusive.
        /// </summary>
        [JsonProperty(PropertyName = "max")]
        public long Max { get; set; }

        /// <summary>
        /// Gets or sets min is the start of the range, inclusive.
        /// </summary>
        [JsonProperty(PropertyName = "min")]
        public long Min { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
