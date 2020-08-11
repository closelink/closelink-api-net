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
    /// <summary>
    /// Stock data containing quantity of a OilType on a specific date
    /// </summary>
    [DataContract]
    public partial class Stock : IEquatable<Stock>, IValidatableObject
    {

        /// <summary>
        /// The OilType for the quantity
        /// </summary>
        /// <value>The OilType for the quantity</value>
        [JsonConstructorAttribute]
        protected Stock() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Stock" /> class.
        /// </summary>
        /// <param name="imo">The imo of the vessel (required).</param>
        /// <param name="dateMeasured">Date Stock was measured (required).</param>
        /// <param name="quantity">Quantity in liters (required).</param>
        /// <param name="oilType">The OilType for the quantity (required).</param>
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
        /// Date Stock was measured
        /// </summary>
        /// <value>Date Stock was measured</value>
        [DataMember(Name = "dateMeasured", EmitDefaultValue = false)]
        public DateTime DateMeasured { get; set; }

        /// <summary>
        /// Quantity in liters
        /// </summary>
        /// <value>Quantity in liters</value>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        public long Quantity { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
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
            sb.Append("  CustomerGroupId: ").Append(CustomerGroupId).Append("\n");
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
                if (this.CustomerGroupId != null)
                    hashCode = hashCode * 59 + this.CustomerGroupId.GetHashCode();
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

        /// <summary>
        /// The OilType for the quantity
        /// </summary>
        /// <value>The OilType for the quantity</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OilTypeEnum
        {

            /// <summary>
            /// Enum ME_CIRC for value: ME_CIRC
            /// </summary>
            [EnumMember(Value = "ME_CIRC")]
            ME_CIRC = 1,

            /// <summary>
            /// Enum AE_CIRC for value: AE_CIRC
            /// </summary>
            [EnumMember(Value = "AE_CIRC")]
            AE_CIRC = 2,

            /// <summary>
            /// Enum ME_CYL_HS for value: ME_CYL_HS
            /// </summary>
            [EnumMember(Value = "ME_CYL_HS")]
            ME_CYL_HS = 3,

            /// <summary>
            /// Enum ME_CYL_LS for value: ME_CYL_LS
            /// </summary>
            [EnumMember(Value = "ME_CYL_LS")]
            ME_CYL_LS = 4
        }

    }

}
