using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CloselinkAPI.Model
{
    /// <summary>
    /// Model for address details
    /// </summary>
    [DataContract]
    public partial class AddressMessage :  IEquatable<AddressMessage>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Schedule" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected AddressMessage()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressMessage" /> class.
        /// </summary>
        /// <param name="street">street.</param>
        /// <param name="streetNumber">streetNumber.</param>
        /// <param name="zipCode">zipCode.</param>
        /// <param name="city">city.</param>
        /// <param name="country">country.</param>
        public AddressMessage(string street = default(string), string streetNumber = default(string), string zipCode = default(string), string city = default(string), string country = default(string))
        {
            this.Street = street;
            this.StreetNumber = streetNumber;
            this.ZipCode = zipCode;
            this.City = city;
            this.Country = country;
        }
        
        /// <summary>
        /// Gets or Sets Street
        /// </summary>
        [DataMember(Name="street", EmitDefaultValue=false)]
        public string Street { get; set; }

        /// <summary>
        /// Gets or Sets StreetNumber
        /// </summary>
        [DataMember(Name="streetNumber", EmitDefaultValue=false)]
        public string StreetNumber { get; set; }

        /// <summary>
        /// Gets or Sets ZipCode
        /// </summary>
        [DataMember(Name="zipCode", EmitDefaultValue=false)]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or Sets City
        /// </summary>
        [DataMember(Name="city", EmitDefaultValue=false)]
        public string City { get; set; }

        /// <summary>
        /// Gets or Sets Country
        /// </summary>
        [DataMember(Name="country", EmitDefaultValue=false)]
        public string Country { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class AddressMessage {\n");
            sb.Append("  Street: ").Append(Street).Append("\n");
            sb.Append("  StreetNumber: ").Append(StreetNumber).Append("\n");
            sb.Append("  ZipCode: ").Append(ZipCode).Append("\n");
            sb.Append("  City: ").Append(City).Append("\n");
            sb.Append("  Country: ").Append(Country).Append("\n");
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
            return this.Equals(input as AddressMessage);
        }

        /// <summary>
        /// Returns true if AddressMessage instances are equal
        /// </summary>
        /// <param name="input">Instance of AddressMessage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(AddressMessage input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.Street == input.Street ||
                    (this.Street != null &&
                    this.Street.Equals(input.Street))
                ) && 
                (
                    this.StreetNumber == input.StreetNumber ||
                    (this.StreetNumber != null &&
                    this.StreetNumber.Equals(input.StreetNumber))
                ) && 
                (
                    this.ZipCode == input.ZipCode ||
                    (this.ZipCode != null &&
                    this.ZipCode.Equals(input.ZipCode))
                ) && 
                (
                    this.City == input.City ||
                    (this.City != null &&
                    this.City.Equals(input.City))
                ) && 
                (
                    this.Country == input.Country ||
                    (this.Country != null &&
                    this.Country.Equals(input.Country))
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
                if (this.Street != null)
                    hashCode = hashCode * 59 + this.Street.GetHashCode();
                if (this.StreetNumber != null)
                    hashCode = hashCode * 59 + this.StreetNumber.GetHashCode();
                if (this.ZipCode != null)
                    hashCode = hashCode * 59 + this.ZipCode.GetHashCode();
                if (this.City != null)
                    hashCode = hashCode * 59 + this.City.GetHashCode();
                if (this.Country != null)
                    hashCode = hashCode * 59 + this.Country.GetHashCode();
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
