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
    /// Maps a string key to a path within a volume.
    /// </summary>
    public partial class V1KeyToPath
    {
        /// <summary>
        /// Initializes a new instance of the V1KeyToPath class.
        /// </summary>
        public V1KeyToPath()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the V1KeyToPath class.
        /// </summary>
        /// <param name="key">The key to project.</param>
        /// <param name="path">The relative path of the file to map the key to.
        /// May not be an absolute path. May not contain the path element '..'.
        /// May not start with the string '..'.</param>
        /// <param name="mode">Optional: mode bits to use on this file, must be
        /// a value between 0 and 0777. If not specified, the volume
        /// defaultMode will be used. This might be in conflict with other
        /// options that affect the file mode, like fsGroup, and the result can
        /// be other mode bits set.</param>
        public V1KeyToPath(string key, string path, int? mode = default(int?))
        {
            Key = key;
            Mode = mode;
            Path = path;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the key to project.
        /// </summary>
        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets optional: mode bits to use on this file, must be a
        /// value between 0 and 0777. If not specified, the volume defaultMode
        /// will be used. This might be in conflict with other options that
        /// affect the file mode, like fsGroup, and the result can be other
        /// mode bits set.
        /// </summary>
        [JsonProperty(PropertyName = "mode")]
        public int? Mode { get; set; }

        /// <summary>
        /// Gets or sets the relative path of the file to map the key to. May
        /// not be an absolute path. May not contain the path element '..'. May
        /// not start with the string '..'.
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Key == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Key");
            }
            if (Path == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Path");
            }
        }
    }
}
