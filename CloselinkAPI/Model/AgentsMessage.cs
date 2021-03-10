using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CloselinkAPI.Model
{
    /// <summary>
    /// List request model of AgentMessage
    /// </summary>
    [DataContract]
    public partial class AgentsMessage :  IEquatable<AgentsMessage>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgentsMessage" /> class.
        /// </summary>
        /// <param name="agents">List of agents (required).</param>
        public AgentsMessage(List<AgentMessage> agents = default(List<AgentMessage>))
        {
            this.Agents = agents ?? throw new InvalidDataException("agents is a required property for AgentsMessage and cannot be null");
        }
        
        /// <summary>
        /// List of agents
        /// </summary>
        /// <value>List of agents</value>
        [DataMember(Name="agents", EmitDefaultValue=false)]
        public List<AgentMessage> Agents { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AgentsMessage {\n");
            sb.Append("  Agents: ").Append(Agents).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public virtual string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as AgentsMessage);
        }

        /// <summary>
        /// Returns true if AgentsMessage instances are equal
        /// </summary>
        /// <param name="input">Instance of AgentsMessage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AgentsMessage input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Agents == input.Agents ||
                    this.Agents != null &&
                    this.Agents.SequenceEqual(input.Agents)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Agents != null)
                    hashCode = hashCode * 59 + this.Agents.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}
