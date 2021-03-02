using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CloselinkAPI.Model
{
    /// <summary>
    /// Agent request model
    /// </summary>
    [DataContract]
    public partial class AgentMessage :  IEquatable<AgentMessage>, IValidatableObject
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AgentMessage" /> class.
        /// </summary>
        public AgentMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgentMessage" /> class.
        /// </summary>
        /// <param name="name">The name of the agency.</param>
        /// <param name="address">Information about the address of an agency.</param>
        /// <param name="contact">Information about the contact details of an agency.</param>
        /// <param name="LoCodes">List of loCodes of an agency.</param>
        /// <param name="note">Additional notes for an agent.</param>
        /// <param name="customerId">The customer ID of an agent.</param>
        public AgentMessage(string name = default(string), AddressMessage address = default(AddressMessage), ContactMessage contact = default(ContactMessage), List<string> LoCodes = default(List<string>), string note = default(string), string customerId = default(string))
        {
            this.Name = name;
            this.Address = address;
            this.Contact = contact;
            this.LoCodes = LoCodes;
            this.Note = note;
            this.CustomerId = customerId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AgentMessage" /> class.
        /// </summary>
        /// <param name="name">The name of the agency.</param>
        /// <param name="address">Information about the address of an agency.</param>
        /// <param name="contact">Information about the contact details of an agency.</param>
        /// <param name="LoCodes">List of loCodes of an agency.</param>
        /// <param name="note">Additional notes for an agent.</param>
        /// <param name="customerId">The customer ID of an agent.</param>
        /// <param name="externalId">The external ID of an agent.</param>
        public AgentMessage(string name = default(string), AddressMessage address = default(AddressMessage), ContactMessage contact = default(ContactMessage), List<string> LoCodes = default(List<string>), string note = default(string), string customerId = default(string), string externalId = default(string))
        {
            this.Name = name;
            this.Address = address;
            this.Contact = contact;
            this.LoCodes = LoCodes;
            this.Note = note;
            this.CustomerId = customerId;
            this.ExternalId = externalId;
        }

         /// <summary>
        /// Initializes a new instance of the <see cref="AgentMessage" /> class.
        /// </summary>
        /// <param name="name">The name of the agency.</param>
        /// <param name="address">Information about the address of an agency.</param>
        /// <param name="contact">Information about the contact details of an agency.</param>
        /// <param name="LoCodes">List of loCodes of an agency.</param>
        /// <param name="note">Additional notes for an agent.</param>
        /// <param name="customerId">The customer ID of an agent.</param>
        /// <param name="externalId">The external ID of an agent.</param>
        /// <param name="id">The ID of an agent.</param>
        public AgentMessage(string name = default(string), AddressMessage address = default(AddressMessage), ContactMessage contact = default(ContactMessage), List<string> LoCodes = default(List<string>), string note = default(string), string customerId = default(string), string externalId = default(string), string id = default(string))
        {
            this.Name = name;
            this.Address = address;
            this.Contact = contact;
            this.LoCodes = LoCodes;
            this.Note = note;
            this.CustomerId = customerId;
            this.ExternalId = externalId;
            this.Id = id;
        }
        
        /// <summary>
        /// The ID of the agent
        /// </summary>
        /// <value>The ID of the agent</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// The name of the agency
        /// </summary>
        /// <value>The name of the agency</value>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Information about the address of an agency
        /// </summary>
        /// <value>Information about the address of an agency</value>
        [DataMember(Name="address", EmitDefaultValue=false)]
        public AddressMessage Address { get; set; }

        /// <summary>
        /// Information about the contact details of an agency
        /// </summary>
        /// <value>Information about the contact details of an agency</value>
        [DataMember(Name="contact", EmitDefaultValue=false)]
        public ContactMessage Contact { get; set; }

        /// <summary>
        /// List of loCodes for an agency
        /// </summary>
        /// <value>List of loCodes for an agency</value>
        [DataMember(Name="loCodes", EmitDefaultValue=false)]
        public List<string> LoCodes { get; set; }

        /// <summary>
        /// Additional notes for an agent
        /// </summary>
        /// <value>Additional notes for an agent</value>
        [DataMember(Name="note", EmitDefaultValue=false)]
        public string Note { get; set; }

        /// <summary>
        /// The customer ID of an agent
        /// </summary>
        /// <value>The customer ID of an agent</value>
        [DataMember(Name="customerId", EmitDefaultValue=false)]
        public string CustomerId { get; set; }

        /// <summary>
        /// The external ID of an agent
        /// </summary>
        /// <value>The external ID of an agent</value>
        [DataMember(Name="externalId", EmitDefaultValue=false)]
        public string ExternalId { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AgentMessage {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Address: ").Append(Address).Append("\n");
            sb.Append("  Contact: ").Append(Contact).Append("\n");
            sb.Append("  LoCodes: ").Append(LoCodes).Append("\n");
            sb.Append("  Note: ").Append(Note).Append("\n");
            sb.Append("  CustomerId: ").Append(CustomerId).Append("\n");
            sb.Append("  ExternalId: ").Append(ExternalId).Append("\n");
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
            return this.Equals(input as AgentMessage);
        }

        /// <summary>
        /// Returns true if AgentMessage instances are equal
        /// </summary>
        /// <param name="input">Instance of AgentMessage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AgentMessage input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) && 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.Address == input.Address ||
                    (this.Address != null &&
                    this.Address.Equals(input.Address))
                ) && 
                (
                    this.Contact == input.Contact ||
                    (this.Contact != null &&
                    this.Contact.Equals(input.Contact))
                ) && 
                (
                    this.LoCodes == input.LoCodes ||
                    this.LoCodes != null &&
                    this.LoCodes.SequenceEqual(input.LoCodes)
                ) && 
                (
                    this.Note == input.Note ||
                    (this.Note != null &&
                    this.Note.Equals(input.Note))
                ) && 
                (
                    this.CustomerId == input.CustomerId ||
                    (this.CustomerId != null &&
                    this.CustomerId.Equals(input.CustomerId))
                ) && 
                (
                    this.ExternalId == input.ExternalId ||
                    (this.ExternalId != null &&
                    this.ExternalId.Equals(input.ExternalId))
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
                if (this.Id != null)
                    hashCode = hashCode * 59 + this.Id.GetHashCode();
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.Address != null)
                    hashCode = hashCode * 59 + this.Address.GetHashCode();
                if (this.Contact != null)
                    hashCode = hashCode * 59 + this.Contact.GetHashCode();
                if (this.LoCodes != null)
                    hashCode = hashCode * 59 + this.LoCodes.GetHashCode();
                if (this.Note != null)
                    hashCode = hashCode * 59 + this.Note.GetHashCode();
                if (this.CustomerId != null)
                    hashCode = hashCode * 59 + this.CustomerId.GetHashCode();
                if (this.ExternalId != null)
                    hashCode = hashCode * 59 + this.ExternalId.GetHashCode();
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
