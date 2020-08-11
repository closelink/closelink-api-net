using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace CloselinkAPI.Model
{
    [DataContract]
    public partial class Schedule : IEquatable<Schedule>, IValidatableObject
    {
        [JsonConstructorAttribute]
        protected Schedule() { }

        public Schedule(
            string imo,
            DateTime eta,
            DateTime etd,
            string locode)
        {
            // to ensure "imo" is required (not null)
            if (imo == null)
            {
                throw new InvalidDataException("imo is a required property for Schedule and cannot be null");
            }
            else
            {
                this.Imo = imo;
            }

            // to ensure "locode" is required (not null)
            if (locode == null)
            {
                throw new InvalidDataException("locode is a required property for Schedule and cannot be null");
            }
            else
            {
                this.Locode = locode;
            }
            this.Eta = eta;
            this.Etd = etd;
        }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "dateCreated", EmitDefaultValue = false)]
        public DateTime? DateCreated { get; set; }

        [DataMember(Name = "dateUpdated", EmitDefaultValue = false)]
        public DateTime? DateUpdated { get; set; }

        [DataMember(Name = "CustomerGroupId", EmitDefaultValue = false)]
        public string CustomerGroupId { get; set; }

        [DataMember(Name = "imo", EmitDefaultValue = false)]
        public string Imo { get; set; }

        [DataMember(Name = "eta", EmitDefaultValue = false)]
        public DateTime? Eta { get; set; }

        [DataMember(Name = "etd", EmitDefaultValue = false)]
        public DateTime? Etd { get; set; }

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
            return this.Equals(input as Schedule);
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
                    this.Id == input.Id ||
                    (this.Id != null &&
                    this.Id.Equals(input.Id))
                ) &&
                (
                    this.DateCreated == input.DateCreated ||
                    (this.DateCreated != null &&
                    this.DateCreated.Equals(input.DateCreated))
                ) &&
                (
                    this.DateUpdated == input.DateUpdated ||
                    (this.DateUpdated != null &&
                    this.DateUpdated.Equals(input.DateUpdated))
                ) &&
                (
                    this.CustomerGroupId == input.CustomerGroupId ||
                    (this.CustomerGroupId != null &&
                    this.CustomerGroupId.Equals(input.CustomerGroupId))
                ) &&
                (
                    this.Imo == input.Imo ||
                    (this.Imo != null &&
                    this.Imo.Equals(input.Imo))
                ) &&
                (
                    this.Eta == input.Eta ||
                    (this.Eta != null &&
                    this.Eta.Equals(input.Eta))
                ) &&
                (
                    this.Etd == input.Etd ||
                    (this.Etd != null &&
                    this.Etd.Equals(input.Etd))
                ) &&
                (
                    this.Locode == input.Locode ||
                    (this.Locode != null &&
                    this.Locode.Equals(input.Locode))
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
                if (this.DateCreated != null)
                    hashCode = hashCode * 59 + this.DateCreated.GetHashCode();
                if (this.DateUpdated != null)
                    hashCode = hashCode * 59 + this.DateUpdated.GetHashCode();
                if (this.CustomerGroupId != null)
                    hashCode = hashCode * 59 + this.CustomerGroupId.GetHashCode();
                if (this.Imo != null)
                    hashCode = hashCode * 59 + this.Imo.GetHashCode();
                if (this.Eta != null)
                    hashCode = hashCode * 59 + this.Eta.GetHashCode();
                if (this.Etd != null)
                    hashCode = hashCode * 59 + this.Etd.GetHashCode();
                if (this.Locode != null)
                    hashCode = hashCode * 59 + this.Locode.GetHashCode();
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
