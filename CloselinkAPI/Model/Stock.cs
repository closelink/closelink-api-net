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
        protected Stock()
        {
        }

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
            Imo = imo ?? throw new InvalidDataException("imo is a required property for Stock and cannot be null");
            DateMeasured = dateMeasured;
            Quantity = quantity;
            OilType = oilType;
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
            return Equals(input as Stock);
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
                    DateMeasured == input.DateMeasured ||
                    DateMeasured.Equals(input.DateMeasured)
                ) &&
                (
                    Quantity == input.Quantity ||
                    Quantity.Equals(input.Quantity)
                ) &&
                (
                    OilType == input.OilType ||
                    OilType.Equals(input.OilType)
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
                hashCode = hashCode * 59 + DateMeasured.GetHashCode();
                hashCode = hashCode * 59 + Quantity.GetHashCode();
                hashCode = hashCode * 59 + OilType.GetHashCode();
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

        /// <summary>
        /// The OilType for the quantity
        /// </summary>
        /// <value>The OilType for the quantity</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OilTypeEnum
        {
            /// <summary>
            /// Enum MeCirc for value: ME_CIRC
            /// </summary>
            [EnumMember(Value = "ME_CIRC")] MeCirc = 1,

            /// <summary>
            /// Enum AeCirc for value: AE_CIRC
            /// </summary>
            [EnumMember(Value = "AE_CIRC")] AeCirc = 2,

            /// <summary>
            /// Enum MeCylHs for value: ME_CYL_HS
            /// </summary>
            [EnumMember(Value = "ME_CYL_HS")] MeCylHs = 3,

            /// <summary>
            /// Enum MeCylLs for value: ME_CYL_LS
            /// </summary>
            [EnumMember(Value = "ME_CYL_LS")] MeCylLs = 4
        }
    }
}