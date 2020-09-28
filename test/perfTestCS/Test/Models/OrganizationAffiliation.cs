// <auto-generated />
// Built from: hl7.fhir.r4.core version: 4.0.1

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Fhir.R4.ValueSets;
using Fhir.R4.Serialization;

namespace Fhir.R4.Models
{
  /// <summary>
  /// Defines an affiliation/assotiation/relationship between 2 distinct oganizations, that is not a part-of relationship/sub-division relationship.
  /// </summary>
  [JsonConverter(typeof(Fhir.R4.Serialization.JsonComponentConverter<OrganizationAffiliation>))]
  public class OrganizationAffiliation : DomainResource,  IFhirJsonSerializable {
    /// <summary>
    /// Resource Type Name
    /// </summary>
    public string ResourceType => "OrganizationAffiliation";
    /// <summary>
    /// If this value is false, you may refer to the period to see when the role was in active use. If there is no period specified, no inference can be made about when it was active.
    /// </summary>
    public bool? Active { get; set; }
    /// <summary>
    /// Definition of the role the participatingOrganization plays in the association.
    /// </summary>
    public List<CodeableConcept> Code { get; set; }
    /// <summary>
    /// Technical endpoints providing access to services operated for this role.
    /// </summary>
    public List<Reference> Endpoint { get; set; }
    /// <summary>
    /// Healthcare services provided through the role.
    /// </summary>
    public List<Reference> HealthcareService { get; set; }
    /// <summary>
    /// Business identifiers that are specific to this role.
    /// </summary>
    public List<Identifier> Identifier { get; set; }
    /// <summary>
    /// The location(s) at which the role occurs.
    /// </summary>
    public List<Reference> Location { get; set; }
    /// <summary>
    /// Health insurance provider network in which the participatingOrganization provides the role's services (if defined) at the indicated locations (if defined).
    /// </summary>
    public List<Reference> Network { get; set; }
    /// <summary>
    /// Organization where the role is available (primary organization/has members).
    /// </summary>
    public Reference Organization { get; set; }
    /// <summary>
    /// The Participating Organization provides/performs the role(s) defined by the code to the Primary Organization (e.g. providing services or is a member of).
    /// </summary>
    public Reference ParticipatingOrganization { get; set; }
    /// <summary>
    /// The period during which the participatingOrganization is affiliated with the primary organization.
    /// </summary>
    public Period Period { get; set; }
    /// <summary>
    /// Specific specialty of the participatingOrganization in the context of the role.
    /// </summary>
    public List<CodeableConcept> Specialty { get; set; }
    /// <summary>
    /// Contact details at the participatingOrganization relevant to this Affiliation.
    /// </summary>
    public List<ContactPoint> Telecom { get; set; }
    /// <summary>
    /// Serialize to a JSON object
    /// </summary>
    public new void SerializeJson(ref Utf8JsonWriter writer, JsonSerializerOptions options, bool includeStartObject = true)
    {
      if (includeStartObject)
      {
        writer.WriteStartObject();
      }

      if (!string.IsNullOrEmpty(ResourceType))
      {
        writer.WriteString("resourceType", (string)ResourceType!);
      }


      ((Fhir.R4.Models.DomainResource)this).SerializeJson(ref writer, options, false);

      if ((Identifier != null) && (Identifier.Count != 0))
      {
        writer.WritePropertyName("identifier");
        writer.WriteStartArray();

        foreach (Identifier valIdentifier in Identifier)
        {
          valIdentifier.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if (Active != null)
      {
        writer.WriteBoolean("active", (bool)Active!);
      }

      if (Period != null)
      {
        writer.WritePropertyName("period");
        Period.SerializeJson(ref writer, options);
      }

      if (Organization != null)
      {
        writer.WritePropertyName("organization");
        Organization.SerializeJson(ref writer, options);
      }

      if (ParticipatingOrganization != null)
      {
        writer.WritePropertyName("participatingOrganization");
        ParticipatingOrganization.SerializeJson(ref writer, options);
      }

      if ((Network != null) && (Network.Count != 0))
      {
        writer.WritePropertyName("network");
        writer.WriteStartArray();

        foreach (Reference valNetwork in Network)
        {
          valNetwork.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if ((Code != null) && (Code.Count != 0))
      {
        writer.WritePropertyName("code");
        writer.WriteStartArray();

        foreach (CodeableConcept valCode in Code)
        {
          valCode.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if ((Specialty != null) && (Specialty.Count != 0))
      {
        writer.WritePropertyName("specialty");
        writer.WriteStartArray();

        foreach (CodeableConcept valSpecialty in Specialty)
        {
          valSpecialty.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if ((Location != null) && (Location.Count != 0))
      {
        writer.WritePropertyName("location");
        writer.WriteStartArray();

        foreach (Reference valLocation in Location)
        {
          valLocation.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if ((HealthcareService != null) && (HealthcareService.Count != 0))
      {
        writer.WritePropertyName("healthcareService");
        writer.WriteStartArray();

        foreach (Reference valHealthcareService in HealthcareService)
        {
          valHealthcareService.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if ((Telecom != null) && (Telecom.Count != 0))
      {
        writer.WritePropertyName("telecom");
        writer.WriteStartArray();

        foreach (ContactPoint valTelecom in Telecom)
        {
          valTelecom.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if ((Endpoint != null) && (Endpoint.Count != 0))
      {
        writer.WritePropertyName("endpoint");
        writer.WriteStartArray();

        foreach (Reference valEndpoint in Endpoint)
        {
          valEndpoint.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if (includeStartObject)
      {
        writer.WriteEndObject();
      }
    }
    /// <summary>
    /// Deserialize a JSON property
    /// </summary>
    public new void DeserializeJsonProperty(ref Utf8JsonReader reader, JsonSerializerOptions options, string propertyName)
    {
      switch (propertyName)
      {
        case "active":
          Active = reader.GetBoolean();
          break;

        case "code":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          Code = new List<CodeableConcept>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.CodeableConcept objCode = new Fhir.R4.Models.CodeableConcept();
            objCode.DeserializeJson(ref reader, options);
            Code.Add(objCode);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (Code.Count == 0)
          {
            Code = null;
          }

          break;

        case "endpoint":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          Endpoint = new List<Reference>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.Reference objEndpoint = new Fhir.R4.Models.Reference();
            objEndpoint.DeserializeJson(ref reader, options);
            Endpoint.Add(objEndpoint);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (Endpoint.Count == 0)
          {
            Endpoint = null;
          }

          break;

        case "healthcareService":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          HealthcareService = new List<Reference>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.Reference objHealthcareService = new Fhir.R4.Models.Reference();
            objHealthcareService.DeserializeJson(ref reader, options);
            HealthcareService.Add(objHealthcareService);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (HealthcareService.Count == 0)
          {
            HealthcareService = null;
          }

          break;

        case "identifier":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          Identifier = new List<Identifier>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.Identifier objIdentifier = new Fhir.R4.Models.Identifier();
            objIdentifier.DeserializeJson(ref reader, options);
            Identifier.Add(objIdentifier);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (Identifier.Count == 0)
          {
            Identifier = null;
          }

          break;

        case "location":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          Location = new List<Reference>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.Reference objLocation = new Fhir.R4.Models.Reference();
            objLocation.DeserializeJson(ref reader, options);
            Location.Add(objLocation);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (Location.Count == 0)
          {
            Location = null;
          }

          break;

        case "network":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          Network = new List<Reference>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.Reference objNetwork = new Fhir.R4.Models.Reference();
            objNetwork.DeserializeJson(ref reader, options);
            Network.Add(objNetwork);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (Network.Count == 0)
          {
            Network = null;
          }

          break;

        case "organization":
          Organization = new Fhir.R4.Models.Reference();
          Organization.DeserializeJson(ref reader, options);
          break;

        case "participatingOrganization":
          ParticipatingOrganization = new Fhir.R4.Models.Reference();
          ParticipatingOrganization.DeserializeJson(ref reader, options);
          break;

        case "period":
          Period = new Fhir.R4.Models.Period();
          Period.DeserializeJson(ref reader, options);
          break;

        case "specialty":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          Specialty = new List<CodeableConcept>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.CodeableConcept objSpecialty = new Fhir.R4.Models.CodeableConcept();
            objSpecialty.DeserializeJson(ref reader, options);
            Specialty.Add(objSpecialty);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (Specialty.Count == 0)
          {
            Specialty = null;
          }

          break;

        case "telecom":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          Telecom = new List<ContactPoint>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.ContactPoint objTelecom = new Fhir.R4.Models.ContactPoint();
            objTelecom.DeserializeJson(ref reader, options);
            Telecom.Add(objTelecom);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (Telecom.Count == 0)
          {
            Telecom = null;
          }

          break;

        default:
          ((Fhir.R4.Models.DomainResource)this).DeserializeJsonProperty(ref reader, options, propertyName);
          break;
      }
    }

    /// <summary>
    /// Deserialize a JSON object
    /// </summary>
    public new void DeserializeJson(ref Utf8JsonReader reader, JsonSerializerOptions options)
    {
      string propertyName;

      while (reader.Read())
      {
        if (reader.TokenType == JsonTokenType.EndObject)
        {
          return;
        }

        if (reader.TokenType == JsonTokenType.PropertyName)
        {
          propertyName = reader.GetString();
          reader.Read();
          this.DeserializeJsonProperty(ref reader, options, propertyName);
        }
      }

      throw new JsonException();
    }
  }
}
