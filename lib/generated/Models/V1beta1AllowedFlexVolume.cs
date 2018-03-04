// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace k8s.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// AllowedFlexVolume represents a single Flexvolume that is allowed to be
    /// used.
    /// </summary>
    public partial class V1beta1AllowedFlexVolume
    {
        /// <summary>
        /// Initializes a new instance of the V1beta1AllowedFlexVolume class.
        /// </summary>
        public V1beta1AllowedFlexVolume()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the V1beta1AllowedFlexVolume class.
        /// </summary>
        /// <param name="driver">Driver is the name of the Flexvolume
        /// driver.</param>
        public V1beta1AllowedFlexVolume(string driver)
        {
            Driver = driver;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets driver is the name of the Flexvolume driver.
        /// </summary>
        [JsonProperty(PropertyName = "driver")]
        public string Driver { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Driver == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Driver");
            }
        }
    }
}
