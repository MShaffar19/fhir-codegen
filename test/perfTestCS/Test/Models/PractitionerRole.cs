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
  /// More detailed availability information may be provided in associated Schedule/Slot resources.
  /// </summary>
  [JsonConverter(typeof(Fhir.R4.Serialization.JsonComponentConverter<PractitionerRoleAvailableTime>))]
  public class PractitionerRoleAvailableTime : BackboneElement,  IFhirJsonSerializable {
    /// <summary>
    /// Is this always available? (hence times are irrelevant) e.g. 24 hour service.
    /// </summary>
    public bool? AllDay { get; set; }
    /// <summary>
    /// The timezone is expected to be for where this HealthcareService is provided at.
    /// </summary>
    public string AvailableEndTime { get; set; }
    /// <summary>
    /// Extension container element for AvailableEndTime
    /// </summary>
    public Element _AvailableEndTime { get; set; }
    /// <summary>
    /// The timezone is expected to be for where this HealthcareService is provided at.
    /// </summary>
    public string AvailableStartTime { get; set; }
    /// <summary>
    /// Extension container element for AvailableStartTime
    /// </summary>
    public Element _AvailableStartTime { get; set; }
    /// <summary>
    /// Indicates which days of the week are available between the start and end Times.
    /// </summary>
    public List<string> DaysOfWeek { get; set; }
    /// <summary>
    /// Extension container element for DaysOfWeek
    /// </summary>
    public List<Element> _DaysOfWeek { get; set; }
    /// <summary>
    /// Serialize to a JSON object
    /// </summary>
    public new void SerializeJson(ref Utf8JsonWriter writer, JsonSerializerOptions options, bool includeStartObject = true)
    {
      if (includeStartObject)
      {
        writer.WriteStartObject();
      }

      ((Fhir.R4.Models.BackboneElement)this).SerializeJson(ref writer, options, false);

      if ((DaysOfWeek != null) && (DaysOfWeek.Count != 0))
      {
        writer.WritePropertyName("daysOfWeek");
        writer.WriteStartArray();

        foreach (string valDaysOfWeek in DaysOfWeek)
        {
          writer.WriteStringValue(valDaysOfWeek);
        }

        writer.WriteEndArray();
      }

      if ((_DaysOfWeek != null) && (_DaysOfWeek.Count != 0))
      {
        writer.WritePropertyName("_daysOfWeek");
        writer.WriteStartArray();

        foreach (Element val_DaysOfWeek in _DaysOfWeek)
        {
          val_DaysOfWeek.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if (AllDay != null)
      {
        writer.WriteBoolean("allDay", (bool)AllDay!);
      }

      if (!string.IsNullOrEmpty(AvailableStartTime))
      {
        writer.WriteString("availableStartTime", (string)AvailableStartTime!);
      }

      if (_AvailableStartTime != null)
      {
        writer.WritePropertyName("_availableStartTime");
        _AvailableStartTime.SerializeJson(ref writer, options);
      }

      if (!string.IsNullOrEmpty(AvailableEndTime))
      {
        writer.WriteString("availableEndTime", (string)AvailableEndTime!);
      }

      if (_AvailableEndTime != null)
      {
        writer.WritePropertyName("_availableEndTime");
        _AvailableEndTime.SerializeJson(ref writer, options);
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
        case "allDay":
          AllDay = reader.GetBoolean();
          break;

        case "availableEndTime":
          AvailableEndTime = reader.GetString();
          break;

        case "_availableEndTime":
          _AvailableEndTime = new Fhir.R4.Models.Element();
          _AvailableEndTime.DeserializeJson(ref reader, options);
          break;

        case "availableStartTime":
          AvailableStartTime = reader.GetString();
          break;

        case "_availableStartTime":
          _AvailableStartTime = new Fhir.R4.Models.Element();
          _AvailableStartTime.DeserializeJson(ref reader, options);
          break;

        case "daysOfWeek":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          DaysOfWeek = new List<string>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            DaysOfWeek.Add(reader.GetString());

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (DaysOfWeek.Count == 0)
          {
            DaysOfWeek = null;
          }

          break;

        case "_daysOfWeek":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          _DaysOfWeek = new List<Element>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.Element obj_DaysOfWeek = new Fhir.R4.Models.Element();
            obj_DaysOfWeek.DeserializeJson(ref reader, options);
            _DaysOfWeek.Add(obj_DaysOfWeek);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (_DaysOfWeek.Count == 0)
          {
            _DaysOfWeek = null;
          }

          break;

        default:
          ((Fhir.R4.Models.BackboneElement)this).DeserializeJsonProperty(ref reader, options, propertyName);
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
  /// <summary>
  /// The practitioner is not available or performing this role during this period of time due to the provided reason.
  /// </summary>
  [JsonConverter(typeof(Fhir.R4.Serialization.JsonComponentConverter<PractitionerRoleNotAvailable>))]
  public class PractitionerRoleNotAvailable : BackboneElement,  IFhirJsonSerializable {
    /// <summary>
    /// The reason that can be presented to the user as to why this time is not available.
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Extension container element for Description
    /// </summary>
    public Element _Description { get; set; }
    /// <summary>
    /// Service is not available (seasonally or for a public holiday) from this date.
    /// </summary>
    public Period During { get; set; }
    /// <summary>
    /// Serialize to a JSON object
    /// </summary>
    public new void SerializeJson(ref Utf8JsonWriter writer, JsonSerializerOptions options, bool includeStartObject = true)
    {
      if (includeStartObject)
      {
        writer.WriteStartObject();
      }

      ((Fhir.R4.Models.BackboneElement)this).SerializeJson(ref writer, options, false);

      if (!string.IsNullOrEmpty(Description))
      {
        writer.WriteString("description", (string)Description!);
      }

      if (_Description != null)
      {
        writer.WritePropertyName("_description");
        _Description.SerializeJson(ref writer, options);
      }

      if (During != null)
      {
        writer.WritePropertyName("during");
        During.SerializeJson(ref writer, options);
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
        case "description":
          Description = reader.GetString();
          break;

        case "_description":
          _Description = new Fhir.R4.Models.Element();
          _Description.DeserializeJson(ref reader, options);
          break;

        case "during":
          During = new Fhir.R4.Models.Period();
          During.DeserializeJson(ref reader, options);
          break;

        default:
          ((Fhir.R4.Models.BackboneElement)this).DeserializeJsonProperty(ref reader, options, propertyName);
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
  /// <summary>
  /// A specific set of Roles/Locations/specialties/services that a practitioner may perform at an organization for a period of time.
  /// </summary>
  [JsonConverter(typeof(Fhir.R4.Serialization.JsonComponentConverter<PractitionerRole>))]
  public class PractitionerRole : DomainResource,  IFhirJsonSerializable {
    /// <summary>
    /// Resource Type Name
    /// </summary>
    public string ResourceType => "PractitionerRole";
    /// <summary>
    /// If this value is false, you may refer to the period to see when the role was in active use. If there is no period specified, no inference can be made about when it was active.
    /// </summary>
    public bool? Active { get; set; }
    /// <summary>
    /// A description of site availability exceptions, e.g. public holiday availability. Succinctly describing all possible exceptions to normal site availability as details in the available Times and not available Times.
    /// </summary>
    public string AvailabilityExceptions { get; set; }
    /// <summary>
    /// Extension container element for AvailabilityExceptions
    /// </summary>
    public Element _AvailabilityExceptions { get; set; }
    /// <summary>
    /// More detailed availability information may be provided in associated Schedule/Slot resources.
    /// </summary>
    public List<PractitionerRoleAvailableTime> AvailableTime { get; set; }
    /// <summary>
    /// A person may have more than one role.
    /// </summary>
    public List<CodeableConcept> Code { get; set; }
    /// <summary>
    /// Technical endpoints providing access to services operated for the practitioner with this role.
    /// </summary>
    public List<Reference> Endpoint { get; set; }
    /// <summary>
    /// The list of healthcare services that this worker provides for this role's Organization/Location(s).
    /// </summary>
    public List<Reference> HealthcareService { get; set; }
    /// <summary>
    /// Business Identifiers that are specific to a role/location.
    /// </summary>
    public List<Identifier> Identifier { get; set; }
    /// <summary>
    /// The location(s) at which this practitioner provides care.
    /// </summary>
    public List<Reference> Location { get; set; }
    /// <summary>
    /// The practitioner is not available or performing this role during this period of time due to the provided reason.
    /// </summary>
    public List<PractitionerRoleNotAvailable> NotAvailable { get; set; }
    /// <summary>
    /// The organization where the Practitioner performs the roles associated.
    /// </summary>
    public Reference Organization { get; set; }
    /// <summary>
    /// The period during which the person is authorized to act as a practitioner in these role(s) for the organization.
    /// </summary>
    public Period Period { get; set; }
    /// <summary>
    /// Practitioner that is able to provide the defined services for the organization.
    /// </summary>
    public Reference Practitioner { get; set; }
    /// <summary>
    /// Specific specialty of the practitioner.
    /// </summary>
    public List<CodeableConcept> Specialty { get; set; }
    /// <summary>
    /// Contact details that are specific to the role/location/service.
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

      if (Practitioner != null)
      {
        writer.WritePropertyName("practitioner");
        Practitioner.SerializeJson(ref writer, options);
      }

      if (Organization != null)
      {
        writer.WritePropertyName("organization");
        Organization.SerializeJson(ref writer, options);
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

      if ((AvailableTime != null) && (AvailableTime.Count != 0))
      {
        writer.WritePropertyName("availableTime");
        writer.WriteStartArray();

        foreach (PractitionerRoleAvailableTime valAvailableTime in AvailableTime)
        {
          valAvailableTime.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if ((NotAvailable != null) && (NotAvailable.Count != 0))
      {
        writer.WritePropertyName("notAvailable");
        writer.WriteStartArray();

        foreach (PractitionerRoleNotAvailable valNotAvailable in NotAvailable)
        {
          valNotAvailable.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if (!string.IsNullOrEmpty(AvailabilityExceptions))
      {
        writer.WriteString("availabilityExceptions", (string)AvailabilityExceptions!);
      }

      if (_AvailabilityExceptions != null)
      {
        writer.WritePropertyName("_availabilityExceptions");
        _AvailabilityExceptions.SerializeJson(ref writer, options);
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

        case "availabilityExceptions":
          AvailabilityExceptions = reader.GetString();
          break;

        case "_availabilityExceptions":
          _AvailabilityExceptions = new Fhir.R4.Models.Element();
          _AvailabilityExceptions.DeserializeJson(ref reader, options);
          break;

        case "availableTime":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          AvailableTime = new List<PractitionerRoleAvailableTime>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.PractitionerRoleAvailableTime objAvailableTime = new Fhir.R4.Models.PractitionerRoleAvailableTime();
            objAvailableTime.DeserializeJson(ref reader, options);
            AvailableTime.Add(objAvailableTime);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (AvailableTime.Count == 0)
          {
            AvailableTime = null;
          }

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

        case "notAvailable":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          NotAvailable = new List<PractitionerRoleNotAvailable>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.PractitionerRoleNotAvailable objNotAvailable = new Fhir.R4.Models.PractitionerRoleNotAvailable();
            objNotAvailable.DeserializeJson(ref reader, options);
            NotAvailable.Add(objNotAvailable);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (NotAvailable.Count == 0)
          {
            NotAvailable = null;
          }

          break;

        case "organization":
          Organization = new Fhir.R4.Models.Reference();
          Organization.DeserializeJson(ref reader, options);
          break;

        case "period":
          Period = new Fhir.R4.Models.Period();
          Period.DeserializeJson(ref reader, options);
          break;

        case "practitioner":
          Practitioner = new Fhir.R4.Models.Reference();
          Practitioner.DeserializeJson(ref reader, options);
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
