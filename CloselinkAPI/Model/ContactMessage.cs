using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CloselinkAPI.Model
{
    /// <summary>
    /// Model for contact details
    /// </summary>
    [DataContract]
    public partial class ContactMessage :  IEquatable<ContactMessage>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactMessage" /> class.
        /// </summary>
        public ContactMessage()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactMessage" /> class.
        /// </summary>
        /// <param name="name">name.</param>
        /// <param name="phoneNumber">phoneNumber.</param>
        /// <param name="emailAddress">emailAddress.</param>
        /// <param name="faxNumber">faxNumber.</param>
        public ContactMessage(string name = default(string), string phoneNumber = default(string), string emailAddress = default(string), string faxNumber = default(string))
        {
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.EmailAddress = emailAddress;
            this.FaxNumber = faxNumber;
        }
        
        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue=false)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets PhoneNumber
        /// </summary>
        [DataMember(Name="phoneNumber", EmitDefaultValue=false)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or Sets EmailAddress
        /// </summary>
        [DataMember(Name="emailAddress", EmitDefaultValue=false)]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Gets or Sets FaxNumber
        /// </summary>
        [DataMember(Name="faxNumber", EmitDefaultValue=false)]
        public string FaxNumber { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ContactMessage {\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  PhoneNumber: ").Append(PhoneNumber).Append("\n");
            sb.Append("  EmailAddress: ").Append(EmailAddress).Append("\n");
            sb.Append("  FaxNumber: ").Append(FaxNumber).Append("\n");
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
            return this.Equals(input as ContactMessage);
        }

        /// <summary>
        /// Returns true if ContactMessage instances are equal
        /// </summary>
        /// <param name="input">Instance of ContactMessage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ContactMessage input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Name == input.Name ||
                    (this.Name != null &&
                    this.Name.Equals(input.Name))
                ) && 
                (
                    this.PhoneNumber == input.PhoneNumber ||
                    (this.PhoneNumber != null &&
                    this.PhoneNumber.Equals(input.PhoneNumber))
                ) && 
                (
                    this.EmailAddress == input.EmailAddress ||
                    (this.EmailAddress != null &&
                    this.EmailAddress.Equals(input.EmailAddress))
                ) && 
                (
                    this.FaxNumber == input.FaxNumber ||
                    (this.FaxNumber != null &&
                    this.FaxNumber.Equals(input.FaxNumber))
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
                if (this.Name != null)
                    hashCode = hashCode * 59 + this.Name.GetHashCode();
                if (this.PhoneNumber != null)
                    hashCode = hashCode * 59 + this.PhoneNumber.GetHashCode();
                if (this.EmailAddress != null)
                    hashCode = hashCode * 59 + this.EmailAddress.GetHashCode();
                if (this.FaxNumber != null)
                    hashCode = hashCode * 59 + this.FaxNumber.GetHashCode();
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
