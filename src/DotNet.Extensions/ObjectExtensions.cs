﻿using NuGet.Versioning;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Text.Json.JsonSerializer;

namespace DotNet.Extensions
{
    public static class ObjectExtensions
    {
        static readonly Lazy<JsonSerializerOptions> _lazyOptions = new(() => new()
        {
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = new HyphenatedJsonNamingPolicy()
        });

        static readonly SemanticVersion _versionZero = new(0, 0, 0);

        public static string? ToJson(this object value, JsonSerializerOptions? options = default) =>
            value is null ? null : Serialize(value, options ?? _lazyOptions.Value);

        public static T? FromJson<T>(this string? json, JsonSerializerOptions? options = default) =>
            string.IsNullOrWhiteSpace(json) ? default : Deserialize<T>(json, options ?? _lazyOptions.Value);

        public static SemanticVersion AsSemanticVersion(this string value) =>
            Version.TryParse(value, out var version)
                ? new SemanticVersion(version.Major, version.Minor, Math.Max(version.Build, 0))
                : SemanticVersion.TryParse(value, out var result) ? result : _versionZero;

        public static DateTime? ToDateTime(this string? value) =>
            DateTime.TryParse(value, out var dateTime) ? dateTime : null;

        public static void Deconstruct<T>(
            this T? nullable, out bool hasValue, out T value) where T : struct =>
            (hasValue, value) = (nullable.HasValue, nullable.GetValueOrDefault());
    }
}
