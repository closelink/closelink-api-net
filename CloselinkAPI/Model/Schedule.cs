using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CloselinkAPI.Model
{
    /// <summary>
    /// Schedule Entry for a vessel
    /// </summary>
    [DataContract]
    public partial class Schedule : IEquatable<Schedule>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Schedule" /> class.
        /// </summary>
        [JsonConstructorAttribute]
        protected Schedule()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Schedule" /> class.
        /// </summary>
        /// <param name="imo">The imo of the vessel (required).</param>
        /// <param name="eta">The estimated time of arrival (required).</param>
        /// <param name="etd">The estimated time of departure (required).</param>
        /// <param name="locode">The locode of the port (required).</param>
        public Schedule(
            string imo,
            DateTime eta,
            DateTime etd,
            string locode)
        {
            Imo = imo ?? throw new InvalidDataException("imo is a required property for Schedule and cannot be null");
            Locode = locode ?? throw new InvalidDataException(
                "locode is a required property for Schedule and cannot be null");
            Eta = eta;
            Etd = etd;
        }

        /// <summary>
        /// Internal id (read-only)
        /// </summary>
        /// <value>Internal id (read-only)</value>
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        /// <summary>
        /// The date-time the object was created (read-only)
        /// </summary>
        /// <value>The date-time the object was created (read-only)</value>
        [DataMember(Name = "dateCreated", EmitDefaultValue = false)]
        public DateTime? DateCreated { get; set; }

        /// <summary>
        /// The date-time the object was last updated (read-only)
        /// </summary>
        /// <value>The date-time the object was last updated (read-only)</value>
        [DataMember(Name = "dateUpdated", EmitDefaultValue = false)]
        public DateTime? DateUpdated { get; set; }

        /// <summary>
        /// Internal CustomerGroupId (read-only)
        /// </summary>
        /// <value>Internal CustomerGroupId (read-only)</value>
        [DataMember(Name = "CustomerGroupId", EmitDefaultValue = false)]
        public string CustomerGroupId { get; set; }

        /// <summary>
        /// The imo of the vessel
        /// </summary>
        /// <value>The imo of the vessel</value>
        [DataMember(Name = "imo", EmitDefaultValue = false)]
        public string Imo { get; set; }

        /// <summary>
        /// The estimated time of arrival
        /// </summary>
        /// <value>The estimated time of arrival</value>
        [DataMember(Name = "eta", EmitDefaultValue = false)]
        public DateTime? Eta { get; set; }

        /// <summary>
        /// The estimated time of departure
        /// </summary>
        /// <value>The estimated time of departure</value>
        [DataMember(Name = "etd", EmitDefaultValue = false)]
        public DateTime? Etd { get; set; }

        /// <summary>
        /// The locode of the port
        /// </summary>
        /// <value>The locode of the port</value>
        [DataMember(Name = "locode", EmitDefaultValue = false)]
        public string Locode { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Schedule {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DateCreated: ").Append(DateCreated).Append("\n");
            sb.Append("  DateUpdated: ").Append(DateUpdated).Append("\n");
            sb.Append("  CustomerGroupId: ").Append(CustomerGroupId).Append("\n");
            sb.Append("  Imo: ").Append(Imo).Append("\n");
            sb.Append("  Eta: ").Append(Eta).Append("\n");
            sb.Append("  Etd: ").Append(Etd).Append("\n");
            sb.Append("  Locode: ").Append(Locode).Append("\n");
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
            return Equals(input as Schedule);
        }

        /// <summary>
        /// Returns true if Schedule instances are equal
        /// </summary>
        /// <param name="input">Instance of Schedule to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Schedule input)
        {
            if (input == null)
                return false;

            return
                (
                    Id == input.Id ||
                    (Id != null &&
                     Id.Equals(input.Id))
                ) &&
                (
                    DateCreated == input.DateCreated ||
                    (DateCreated != null &&
                     DateCreated.Equals(input.DateCreated))
                ) &&
                (
                    DateUpdated == input.DateUpdated ||
                    (DateUpdated != null &&
                     DateUpdated.Equals(input.DateUpdated))
                ) &&
                (
                    CustomerGroupId == input.CustomerGroupId ||
                    (CustomerGroupId != null &&
                     CustomerGroupId.Equals(input.CustomerGroupId))
                ) &&
                (
                    Imo == input.Imo ||
                    (Imo != null &&
                     Imo.Equals(input.Imo))
                ) &&
                (
                    Eta == input.Eta ||
                    (Eta != null &&
                     Eta.Equals(input.Eta))
                ) &&
                (
                    Etd == input.Etd ||
                    (Etd != null &&
                     Etd.Equals(input.Etd))
                ) &&
                (
                    Locode == input.Locode ||
                    (Locode != null &&
                     Locode.Equals(input.Locode))
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
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (DateCreated != null)
                    hashCode = hashCode * 59 + DateCreated.GetHashCode();
                if (DateUpdated != null)
                    hashCode = hashCode * 59 + DateUpdated.GetHashCode();
                if (CustomerGroupId != null)
                    hashCode = hashCode * 59 + CustomerGroupId.GetHashCode();
                if (Imo != null)
                    hashCode = hashCode * 59 + Imo.GetHashCode();
                if (Eta != null)
                    hashCode = hashCode * 59 + Eta.GetHashCode();
                if (Etd != null)
                    hashCode = hashCode * 59 + Etd.GetHashCode();
                if (Locode != null)
                    hashCode = hashCode * 59 + Locode.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }
}