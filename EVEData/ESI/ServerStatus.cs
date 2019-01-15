﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using ServerData;
//
//    var serverStatus = ServerStatus.FromJson(jsonString);

namespace ServerData
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class ServerStatus
    {
        [JsonProperty("players")]
        public long Players { get; set; }

        [JsonProperty("server_version")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ServerVersion { get; set; }

        [JsonProperty("start_time")]
        public DateTimeOffset StartTime { get; set; }
    }

    public partial class ServerStatus
    {
        public static ServerStatus FromJson(string json) => JsonConvert.DeserializeObject<ServerStatus>(json, ServerData.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ServerStatus self) => JsonConvert.SerializeObject(self, ServerData.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}