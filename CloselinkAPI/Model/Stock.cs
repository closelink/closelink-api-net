using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace CloselinkAPI.Model
{
    [DataContract]
    public partial class Stock : IEquatable<Stock>, IValidatableObject
    {

        [JsonConstructorAttribute]
        protected Stock() { }

        public Stock(
            string imo,
            DateTime dateMeasured,
            long quantity,
            OilTypeEnum oilType)
        {
            if (imo == null)
            {
                throw new InvalidDataException("imo is a required property for Stock and cannot be null");
            }
            else
            {
                this.Imo = imo;
            }
            if (dateMeasured == null)
            {
                throw new InvalidDataException("dateMeasured is a required property for Stock and cannot be null");
            }
            else
            {
                this.DateMeasured = dateMeasured;
            }
            this.Quantity = quantity;
            this.OilType = oilType;
        }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "dateCreated", EmitDefaultValue = false)]
        public DateTime? DateCreated { get; set; }

        [DataMember(Name = "dateUpdated", EmitDefaultValue = false)]
        public DateTime? DateUpdated { get; set; }

        [DataMember(Name = "customerId", EmitDefaultValue = false)]
        public string CustomerId { get; set; }

        [DataMember(Name = "imo", EmitDefaultValue = false)]
        public string Imo { get; set; }

        [DataMember(Name = "dateMeasured", EmitDefaultValue = false)]
        public DateTime DateMeasured { get; set; }

        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public long Quantity { get; set; }

        [DataMember(Name = "oilType", EmitDefaultValue = false)]
        public OilTypeEnum OilType { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Stock {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  DateCreated: ").Append(DateCreated).Append("\n");
            sb.Append("  DateUpdated: ").Append(DateUpdated).Append("\n");
            sb.Append("  CustomerId: ").Append(CustomerId).Append("\n");
            sb.Append("  Imo: ").Append(Imo).Append("\n");
            sb.Append("  DateMeasured: ").Append(DateMeasured).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  OilType: ").Append(OilType).Append("\n");
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
            return this.Equals(input as Stock);
        }

        /// <summary>
        /// Returns true if Stock instances are equal
        /// </summary>
        /// <param name="input">Instance of Stock to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Stock input)
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
                    this.CustomerId == input.CustomerId ||
                    (this.CustomerId != null &&
                    this.CustomerId.Equals(input.CustomerId))
                ) &&
                (
                    this.Imo == input.Imo ||
                    (this.Imo != null &&
                    this.Imo.Equals(input.Imo))
                ) &&
                (
                    this.DateMeasured == input.DateMeasured ||
                    (this.DateMeasured != null &&
                    this.DateMeasured.Equals(input.DateMeasured))
                ) &&
                (
                    this.Quantity == input.Quantity ||
                    this.Quantity.Equals(input.Quantity)
                ) &&
                (
                    this.OilType == input.OilType ||
                    this.OilType.Equals(input.OilType)
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
                if (this.CustomerId != null)
                    hashCode = hashCode * 59 + this.CustomerId.GetHashCode();
                if (this.Imo != null)
                    hashCode = hashCode * 59 + this.Imo.GetHashCode();
                if (this.DateMeasured != null)
                    hashCode = hashCode * 59 + this.DateMeasured.GetHashCode();
                    hashCode = hashCode * 59 + this.Quantity.GetHashCode();
                    hashCode = hashCode * 59 + this.OilType.GetHashCode();
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

        [JsonConverter(typeof(StringEnumConverter))]
        public enum OilTypeEnum
        {

            [EnumMember(Value = "ME_CIRC")]
            MECIRC = 1,

            [EnumMember(Value = "AE_CIRC")]
            AECIRC = 2,

            [EnumMember(Value = "ME_CYL_HS")]
            MECYLHS = 3,
            [EnumMember(Value = "ME_CYL_LS")]
            MECYLLS = 4
        }

    }

}
