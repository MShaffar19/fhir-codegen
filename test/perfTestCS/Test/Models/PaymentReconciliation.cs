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
  /// Distribution of the payment amount for a previously acknowledged payable.
  /// </summary>
  [JsonConverter(typeof(Fhir.R4.Serialization.JsonComponentConverter<PaymentReconciliationDetail>))]
  public class PaymentReconciliationDetail : BackboneElement,  IFhirJsonSerializable {
    /// <summary>
    /// The monetary amount allocated from the total payment to the payable.
    /// </summary>
    public Money Amount { get; set; }
    /// <summary>
    /// The date from the response resource containing a commitment to pay.
    /// </summary>
    public string Date { get; set; }
    /// <summary>
    /// Extension container element for Date
    /// </summary>
    public Element _Date { get; set; }
    /// <summary>
    /// Unique identifier for the current payment item for the referenced payable.
    /// </summary>
    public Identifier Identifier { get; set; }
    /// <summary>
    /// The party which is receiving the payment.
    /// </summary>
    public Reference Payee { get; set; }
    /// <summary>
    /// Unique identifier for the prior payment item for the referenced payable.
    /// </summary>
    public Identifier Predecessor { get; set; }
    /// <summary>
    /// A resource, such as a Claim, the evaluation of which could lead to payment.
    /// </summary>
    public Reference Request { get; set; }
    /// <summary>
    /// A resource, such as a ClaimResponse, which contains a commitment to payment.
    /// </summary>
    public Reference Response { get; set; }
    /// <summary>
    /// A reference to the individual who is responsible for inquiries regarding the response and its payment.
    /// </summary>
    public Reference Responsible { get; set; }
    /// <summary>
    /// The party which submitted the claim or financial transaction.
    /// </summary>
    public Reference Submitter { get; set; }
    /// <summary>
    /// For example: payment, adjustment, funds advance, etc.
    /// </summary>
    public CodeableConcept Type { get; set; }
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

      if (Identifier != null)
      {
        writer.WritePropertyName("identifier");
        Identifier.SerializeJson(ref writer, options);
      }

      if (Predecessor != null)
      {
        writer.WritePropertyName("predecessor");
        Predecessor.SerializeJson(ref writer, options);
      }

      writer.WritePropertyName("type");
      Type.SerializeJson(ref writer, options);

      if (Request != null)
      {
        writer.WritePropertyName("request");
        Request.SerializeJson(ref writer, options);
      }

      if (Submitter != null)
      {
        writer.WritePropertyName("submitter");
        Submitter.SerializeJson(ref writer, options);
      }

      if (Response != null)
      {
        writer.WritePropertyName("response");
        Response.SerializeJson(ref writer, options);
      }

      if (!string.IsNullOrEmpty(Date))
      {
        writer.WriteString("date", (string)Date!);
      }

      if (_Date != null)
      {
        writer.WritePropertyName("_date");
        _Date.SerializeJson(ref writer, options);
      }

      if (Responsible != null)
      {
        writer.WritePropertyName("responsible");
        Responsible.SerializeJson(ref writer, options);
      }

      if (Payee != null)
      {
        writer.WritePropertyName("payee");
        Payee.SerializeJson(ref writer, options);
      }

      if (Amount != null)
      {
        writer.WritePropertyName("amount");
        Amount.SerializeJson(ref writer, options);
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
        case "amount":
          Amount = new Fhir.R4.Models.Money();
          Amount.DeserializeJson(ref reader, options);
          break;

        case "date":
          Date = reader.GetString();
          break;

        case "_date":
          _Date = new Fhir.R4.Models.Element();
          _Date.DeserializeJson(ref reader, options);
          break;

        case "identifier":
          Identifier = new Fhir.R4.Models.Identifier();
          Identifier.DeserializeJson(ref reader, options);
          break;

        case "payee":
          Payee = new Fhir.R4.Models.Reference();
          Payee.DeserializeJson(ref reader, options);
          break;

        case "predecessor":
          Predecessor = new Fhir.R4.Models.Identifier();
          Predecessor.DeserializeJson(ref reader, options);
          break;

        case "request":
          Request = new Fhir.R4.Models.Reference();
          Request.DeserializeJson(ref reader, options);
          break;

        case "response":
          Response = new Fhir.R4.Models.Reference();
          Response.DeserializeJson(ref reader, options);
          break;

        case "responsible":
          Responsible = new Fhir.R4.Models.Reference();
          Responsible.DeserializeJson(ref reader, options);
          break;

        case "submitter":
          Submitter = new Fhir.R4.Models.Reference();
          Submitter.DeserializeJson(ref reader, options);
          break;

        case "type":
          Type = new Fhir.R4.Models.CodeableConcept();
          Type.DeserializeJson(ref reader, options);
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
  /// A note that describes or explains the processing in a human readable form.
  /// </summary>
  [JsonConverter(typeof(Fhir.R4.Serialization.JsonComponentConverter<PaymentReconciliationProcessNote>))]
  public class PaymentReconciliationProcessNote : BackboneElement,  IFhirJsonSerializable {
    /// <summary>
    /// The explanation or description associated with the processing.
    /// </summary>
    public string Text { get; set; }
    /// <summary>
    /// Extension container element for Text
    /// </summary>
    public Element _Text { get; set; }
    /// <summary>
    /// The business purpose of the note text.
    /// </summary>
    public string Type { get; set; }
    /// <summary>
    /// Extension container element for Type
    /// </summary>
    public Element _Type { get; set; }
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

      if (!string.IsNullOrEmpty(Type))
      {
        writer.WriteString("type", (string)Type!);
      }

      if (_Type != null)
      {
        writer.WritePropertyName("_type");
        _Type.SerializeJson(ref writer, options);
      }

      if (!string.IsNullOrEmpty(Text))
      {
        writer.WriteString("text", (string)Text!);
      }

      if (_Text != null)
      {
        writer.WritePropertyName("_text");
        _Text.SerializeJson(ref writer, options);
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
        case "text":
          Text = reader.GetString();
          break;

        case "_text":
          _Text = new Fhir.R4.Models.Element();
          _Text.DeserializeJson(ref reader, options);
          break;

        case "type":
          Type = reader.GetString();
          break;

        case "_type":
          _Type = new Fhir.R4.Models.Element();
          _Type.DeserializeJson(ref reader, options);
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
  /// This resource provides the details including amount of a payment and allocates the payment items being paid.
  /// </summary>
  [JsonConverter(typeof(Fhir.R4.Serialization.JsonComponentConverter<PaymentReconciliation>))]
  public class PaymentReconciliation : DomainResource,  IFhirJsonSerializable {
    /// <summary>
    /// Resource Type Name
    /// </summary>
    public string ResourceType => "PaymentReconciliation";
    /// <summary>
    /// The date when the resource was created.
    /// </summary>
    public string Created { get; set; }
    /// <summary>
    /// Extension container element for Created
    /// </summary>
    public Element _Created { get; set; }
    /// <summary>
    /// Distribution of the payment amount for a previously acknowledged payable.
    /// </summary>
    public List<PaymentReconciliationDetail> Detail { get; set; }
    /// <summary>
    /// A human readable description of the status of the request for the reconciliation.
    /// </summary>
    public string Disposition { get; set; }
    /// <summary>
    /// Extension container element for Disposition
    /// </summary>
    public Element _Disposition { get; set; }
    /// <summary>
    /// May be needed to identify specific jurisdictional forms.
    /// </summary>
    public CodeableConcept FormCode { get; set; }
    /// <summary>
    /// A unique identifier assigned to this payment reconciliation.
    /// </summary>
    public List<Identifier> Identifier { get; set; }
    /// <summary>
    /// The resource may be used to indicate that: the request has been held (queued) for processing; that it has been processed and errors found (error); that no errors were found and that some of the adjudication has been undertaken (partial) or that all of the adjudication has been undertaken (complete).
    /// </summary>
    public string Outcome { get; set; }
    /// <summary>
    /// Extension container element for Outcome
    /// </summary>
    public Element _Outcome { get; set; }
    /// <summary>
    /// Total payment amount as indicated on the financial instrument.
    /// </summary>
    public Money PaymentAmount { get; set; }
    /// <summary>
    /// The date of payment as indicated on the financial instrument.
    /// </summary>
    public string PaymentDate { get; set; }
    /// <summary>
    /// Extension container element for PaymentDate
    /// </summary>
    public Element _PaymentDate { get; set; }
    /// <summary>
    /// For example: EFT number or check number.
    /// </summary>
    public Identifier PaymentIdentifier { get; set; }
    /// <summary>
    /// This party is also responsible for the reconciliation.
    /// </summary>
    public Reference PaymentIssuer { get; set; }
    /// <summary>
    /// The period of time for which payments have been gathered into this bulk payment for settlement.
    /// </summary>
    public Period Period { get; set; }
    /// <summary>
    /// A note that describes or explains the processing in a human readable form.
    /// </summary>
    public List<PaymentReconciliationProcessNote> ProcessNote { get; set; }
    /// <summary>
    /// Original request resource reference.
    /// </summary>
    public Reference Request { get; set; }
    /// <summary>
    /// The practitioner who is responsible for the services rendered to the patient.
    /// </summary>
    public Reference Requestor { get; set; }
    /// <summary>
    /// This element is labeled as a modifier because the status contains codes that mark the resource as not currently valid.
    /// </summary>
    public string Status { get; set; }
    /// <summary>
    /// Extension container element for Status
    /// </summary>
    public Element _Status { get; set; }
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

      if (!string.IsNullOrEmpty(Status))
      {
        writer.WriteString("status", (string)Status!);
      }

      if (_Status != null)
      {
        writer.WritePropertyName("_status");
        _Status.SerializeJson(ref writer, options);
      }

      if (Period != null)
      {
        writer.WritePropertyName("period");
        Period.SerializeJson(ref writer, options);
      }

      if (!string.IsNullOrEmpty(Created))
      {
        writer.WriteString("created", (string)Created!);
      }

      if (_Created != null)
      {
        writer.WritePropertyName("_created");
        _Created.SerializeJson(ref writer, options);
      }

      if (PaymentIssuer != null)
      {
        writer.WritePropertyName("paymentIssuer");
        PaymentIssuer.SerializeJson(ref writer, options);
      }

      if (Request != null)
      {
        writer.WritePropertyName("request");
        Request.SerializeJson(ref writer, options);
      }

      if (Requestor != null)
      {
        writer.WritePropertyName("requestor");
        Requestor.SerializeJson(ref writer, options);
      }

      if (!string.IsNullOrEmpty(Outcome))
      {
        writer.WriteString("outcome", (string)Outcome!);
      }

      if (_Outcome != null)
      {
        writer.WritePropertyName("_outcome");
        _Outcome.SerializeJson(ref writer, options);
      }

      if (!string.IsNullOrEmpty(Disposition))
      {
        writer.WriteString("disposition", (string)Disposition!);
      }

      if (_Disposition != null)
      {
        writer.WritePropertyName("_disposition");
        _Disposition.SerializeJson(ref writer, options);
      }

      if (!string.IsNullOrEmpty(PaymentDate))
      {
        writer.WriteString("paymentDate", (string)PaymentDate!);
      }

      if (_PaymentDate != null)
      {
        writer.WritePropertyName("_paymentDate");
        _PaymentDate.SerializeJson(ref writer, options);
      }

      writer.WritePropertyName("paymentAmount");
      PaymentAmount.SerializeJson(ref writer, options);

      if (PaymentIdentifier != null)
      {
        writer.WritePropertyName("paymentIdentifier");
        PaymentIdentifier.SerializeJson(ref writer, options);
      }

      if ((Detail != null) && (Detail.Count != 0))
      {
        writer.WritePropertyName("detail");
        writer.WriteStartArray();

        foreach (PaymentReconciliationDetail valDetail in Detail)
        {
          valDetail.SerializeJson(ref writer, options, true);
        }

        writer.WriteEndArray();
      }

      if (FormCode != null)
      {
        writer.WritePropertyName("formCode");
        FormCode.SerializeJson(ref writer, options);
      }

      if ((ProcessNote != null) && (ProcessNote.Count != 0))
      {
        writer.WritePropertyName("processNote");
        writer.WriteStartArray();

        foreach (PaymentReconciliationProcessNote valProcessNote in ProcessNote)
        {
          valProcessNote.SerializeJson(ref writer, options, true);
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
        case "created":
          Created = reader.GetString();
          break;

        case "_created":
          _Created = new Fhir.R4.Models.Element();
          _Created.DeserializeJson(ref reader, options);
          break;

        case "detail":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          Detail = new List<PaymentReconciliationDetail>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.PaymentReconciliationDetail objDetail = new Fhir.R4.Models.PaymentReconciliationDetail();
            objDetail.DeserializeJson(ref reader, options);
            Detail.Add(objDetail);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (Detail.Count == 0)
          {
            Detail = null;
          }

          break;

        case "disposition":
          Disposition = reader.GetString();
          break;

        case "_disposition":
          _Disposition = new Fhir.R4.Models.Element();
          _Disposition.DeserializeJson(ref reader, options);
          break;

        case "formCode":
          FormCode = new Fhir.R4.Models.CodeableConcept();
          FormCode.DeserializeJson(ref reader, options);
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

        case "outcome":
          Outcome = reader.GetString();
          break;

        case "_outcome":
          _Outcome = new Fhir.R4.Models.Element();
          _Outcome.DeserializeJson(ref reader, options);
          break;

        case "paymentAmount":
          PaymentAmount = new Fhir.R4.Models.Money();
          PaymentAmount.DeserializeJson(ref reader, options);
          break;

        case "paymentDate":
          PaymentDate = reader.GetString();
          break;

        case "_paymentDate":
          _PaymentDate = new Fhir.R4.Models.Element();
          _PaymentDate.DeserializeJson(ref reader, options);
          break;

        case "paymentIdentifier":
          PaymentIdentifier = new Fhir.R4.Models.Identifier();
          PaymentIdentifier.DeserializeJson(ref reader, options);
          break;

        case "paymentIssuer":
          PaymentIssuer = new Fhir.R4.Models.Reference();
          PaymentIssuer.DeserializeJson(ref reader, options);
          break;

        case "period":
          Period = new Fhir.R4.Models.Period();
          Period.DeserializeJson(ref reader, options);
          break;

        case "processNote":
          if ((reader.TokenType != JsonTokenType.StartArray) || (!reader.Read()))
          {
            throw new JsonException();
          }

          ProcessNote = new List<PaymentReconciliationProcessNote>();

          while (reader.TokenType != JsonTokenType.EndArray)
          {
            Fhir.R4.Models.PaymentReconciliationProcessNote objProcessNote = new Fhir.R4.Models.PaymentReconciliationProcessNote();
            objProcessNote.DeserializeJson(ref reader, options);
            ProcessNote.Add(objProcessNote);

            if (!reader.Read())
            {
              throw new JsonException();
            }
          }

          if (ProcessNote.Count == 0)
          {
            ProcessNote = null;
          }

          break;

        case "request":
          Request = new Fhir.R4.Models.Reference();
          Request.DeserializeJson(ref reader, options);
          break;

        case "requestor":
          Requestor = new Fhir.R4.Models.Reference();
          Requestor.DeserializeJson(ref reader, options);
          break;

        case "status":
          Status = reader.GetString();
          break;

        case "_status":
          _Status = new Fhir.R4.Models.Element();
          _Status.DeserializeJson(ref reader, options);
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
