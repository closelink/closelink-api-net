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
    /// List response model AgentResponseMessage
    /// </summary>
    [DataContract]
    public partial class AgentsResponseMessage :  IEquatable<AgentsResponseMessage>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AgentsResponseMessage" /> class.
        /// </summary>
        public AgentsResponseMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgentsResponseMessage" /> class.
        /// </summary>
        /// <param name="agents">List of agents (required).</param>
        public AgentsResponseMessage(List<AgentResponseMessage> agents = default(List<AgentResponseMessage>))
        {
            this.Agents = agents ?? throw new InvalidDataException("agents is a required property for AgentsResponseMessage and cannot be null");
        }
        
        /// <summary>
        /// List of agents
        /// </summary>
        /// <value>List of agents</value>
        [DataMember(Name="agents", EmitDefaultValue=false)]
        public List<AgentResponseMessage> Agents { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AgentsResponseMessage {\n");
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
            return this.Equals(input as AgentsResponseMessage);
        }

        /// <summary>
        /// Returns true if AgentsResponseMessage instances are equal
        /// </summary>
        /// <param name="input">Instance of AgentsResponseMessage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AgentsResponseMessage input)
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
