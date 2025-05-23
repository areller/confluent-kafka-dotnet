// Copyright 2020 Confluent Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
// Refer to LICENSE for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using Confluent.Kafka;


namespace Confluent.SchemaRegistry.Serdes
{
    /// <summary>
    ///     <see cref="Confluent.SchemaRegistry.Serdes.ProtobufSerializer{T}" />
    ///     configuration properties.
    /// </summary>
    public class ProtobufSerializerConfig : SerdeConfig
    {
        /// <summary>
        ///     Configuration property names specific to 
        ///     <see cref="Confluent.SchemaRegistry.Serdes.ProtobufSerializer{T}" />.
        /// </summary>
        public static class PropertyNames
        {
            /// <summary>
            ///     Specifies the initial size (in bytes) of the buffer used for Protobuf message
            ///     serialization. Use a value high enough to avoid resizing the buffer, but
            ///     small enough to avoid excessive memory use. Inspect the size of the byte
            ///     array returned by the Serialize method to estimate an appropriate value.
            ///     Note: each call to serialize creates a new buffer.
            ///
            ///     default: 1024
            /// </summary>
            public const string BufferBytes = "protobuf.serializer.buffer.bytes";

            /// <summary>
            ///     Specifies whether or not the Protobuf serializer should attempt to auto-register
            ///     unrecognized schemas with Confluent Schema Registry.
            ///
            ///     default: true
            /// </summary>
            public const string AutoRegisterSchemas = "protobuf.serializer.auto.register.schemas";

            /// <summary>
            ///     Specifies whether to normalize schemas, which will transform schemas
            ///     to have a consistent format, including ordering properties and references.
            ///
            ///     default: false
            /// </summary>
            public const string NormalizeSchemas = "protobuf.serializer.normalize.schemas";

            /// <summary>
            ///     Specifies the schema ID to use for serialization.
            ///     WARNING: There is no check that the given schema is backwards compatible
            ///     with the schema of the object being serialized.
            /// </summary>
            public const string UseSchemaId = "protobuf.serializer.use.schema.id";

            /// <summary>
            ///     Specifies whether or not the Protobuf serializer should use the latest subject
            ///     version for serialization.
            ///     WARNING: There is no check that the latest schema is backwards compatible
            ///     with the schema of the object being serialized.
            ///
            ///     default: false
            /// </summary>
            public const string UseLatestVersion = "protobuf.serializer.use.latest.version";

            /// <summary>
            ///     Specifies whether or not the Protobuf serializer should use the latest subject
            ///     version for serialization.
            ///     WARNING: There is no check that the latest schema is backwards compatible
            ///     with the schema of the object being serialized.
            /// </summary>
            public const string UseLatestWithMetadata = "protobuf.serializer.use.latest.with.metadata";

            /// <summary>
            ///     Specifies whether or not the Protobuf serializer should skip known types
            ///     when resolving dependencies.
            ///
            ///     default: false
            /// </summary>
            public const string SkipKnownTypes = "protobuf.serializer.skip.known.types";

            /// <summary>
            ///     Specifies whether the Protobuf serializer should serialize message indexes
            ///     without zig-zag encoding.
            ///
            ///     default: false
            /// </summary>
            public const string UseDeprecatedFormat = "protobuf.serializer.use.deprecated.format";

            /// <summary>
            ///     The subject name strategy to use for schema registration / lookup.
            ///     Possible values: <see cref="Confluent.SchemaRegistry.SubjectNameStrategy" />
            /// </summary>
            public const string SubjectNameStrategy = "protobuf.serializer.subject.name.strategy";

            /// <summary>
            ///     The subject name strategy to use for registration / lookup of referenced schemas
            ///     Possible values: <see cref="Confluent.SchemaRegistry.ReferenceSubjectNameStrategy" />
            /// </summary>
            public const string ReferenceSubjectNameStrategy = "protobuf.serializer.reference.subject.name.strategy";

            /// <summary>
            ///     The schema id name strategy to use to serialize the ID/GUID.
            ///     Possible values: <see cref="Confluent.SchemaRegistry.SchemaIdSerializerStrategy" />
            /// </summary>
            public const string SchemaIdStrategy = "protobuf.serializer.schema.id.strategy";
        }

        /// <summary>
        ///     Initialize a new <see cref="ProtobufSerializerConfig" />.
        /// </summary>
        public ProtobufSerializerConfig() { }


        /// <summary>
        ///     Initialize a new <see cref="ProtobufSerializerConfig" /> from the provided
        ///     key/value pair collection.
        /// </summary>
        public ProtobufSerializerConfig(IEnumerable<KeyValuePair<string, string>> config) : base(config.ToDictionary(v => v.Key, v => v.Value)) { }


        /// <summary>
        ///     Specifies the initial size (in bytes) of the buffer used for Protobuf message
        ///     serialization. Use a value high enough to avoid resizing the buffer, but
        ///     small enough to avoid excessive memory use. Inspect the size of the byte
        ///     array returned by the Serialize method to estimate an appropriate value.
        ///     Note: each call to serialize creates a new buffer.
        /// 
        ///     default: 1024
        /// </summary>
        public int? BufferBytes
        {
            get { return GetInt(PropertyNames.BufferBytes); }
            set { SetObject(PropertyNames.BufferBytes, value); }
        }


        /// <summary>
        ///     Specifies whether or not the Protobuf serializer should attempt to auto-register
        ///     unrecognized schemas with Confluent Schema Registry.
        ///
        ///     default: true
        /// </summary>
        public bool? AutoRegisterSchemas
        {
            get { return GetBool(PropertyNames.AutoRegisterSchemas); }
            set { SetObject(PropertyNames.AutoRegisterSchemas, value); }
        }
        
        
        /// <summary>
        ///     Specifies whether to normalize schemas, which will transform schemas
        ///     to have a consistent format, including ordering properties and references.
        ///
        ///     default: false
        /// </summary>
        public bool? NormalizeSchemas
        {
            get { return GetBool(PropertyNames.NormalizeSchemas); }
            set { SetObject(PropertyNames.NormalizeSchemas, value); }
        }


        /// <summary>
        ///     Specifies the schema ID to be used for serialization.
        ///     WARNING: There is no check that the latest schema is backwards compatible
        ///     with the schema of the object being serialized.
        /// </summary>
        public int? UseSchemaId
        {
            get { return GetInt(PropertyNames.UseSchemaId); }
            set { SetObject(PropertyNames.UseSchemaId, value); }
        }


        /// <summary>
        ///     Specifies whether or not the Protobuf serializer should use the latest subject
        ///     version for serialization.
        ///     WARNING: There is no check that the latest schema is backwards compatible
        ///     with the schema of the object being serialized.
        ///
        ///     default: false
        /// </summary>
        public bool? UseLatestVersion
        {
            get { return GetBool(PropertyNames.UseLatestVersion); }
            set { SetObject(PropertyNames.UseLatestVersion, value); }
        }
        

        /// <summary>
        ///     Specifies whether or not the Protobuf serializer should use the latest subject
        ///     version with the given metadata for serialization.
        ///     WARNING: There is no check that the latest schema is backwards compatible
        ///     with the schema of the object being serialized.
        /// </summary>
        public IDictionary<string, string> UseLatestWithMetadata
        {
            get { return GetDictionaryProperty(PropertyNames.UseLatestWithMetadata); }
            set { SetDictionaryProperty(PropertyNames.UseLatestWithMetadata, value); }
        }
        

        /// <summary>
        ///     Specifies whether or not the Protobuf serializer should skip known types
        ///     when resolving dependencies.
        ///
        ///     default: true
        /// </summary>
        public bool? SkipKnownTypes
        {
            get { return GetBool(PropertyNames.SkipKnownTypes); }
            set { SetObject(PropertyNames.SkipKnownTypes, value); }
        }
        

        /// <summary>
        ///     Specifies whether the Protobuf serializer should serialize message indexes
        ///     without zig-zag encoding.
        ///
        ///     default: false
        /// </summary>
        public bool? UseDeprecatedFormat
        {
            get { return GetBool(PropertyNames.UseDeprecatedFormat); }
            set { SetObject(PropertyNames.UseDeprecatedFormat, value); }
        }
        

        /// <summary>
        ///     Subject name strategy.
        ///     
        ///     default: SubjectNameStrategy.Topic
        /// </summary>
        public SubjectNameStrategy? SubjectNameStrategy
        {
            get
            {
                var r = Get(PropertyNames.SubjectNameStrategy);
                if (r == null) { return null; }
                else
                {
                    SubjectNameStrategy result;
                    if (!Enum.TryParse<SubjectNameStrategy>(r, out result))
                        throw new ArgumentException(
                            $"Unknown ${PropertyNames.SubjectNameStrategy} value: {r}.");
                    else
                        return result;
                }
            }
            set
            {
                if (value == null) { this.properties.Remove(PropertyNames.SubjectNameStrategy); }
                else { this.properties[PropertyNames.SubjectNameStrategy] = value.ToString(); }
            }
        }


        /// <summary>
        ///     Reference subject name strategy.
        ///     
        ///     default: ReferenceSubjectNameStrategy.ReferenceName
        /// </summary>
        public ReferenceSubjectNameStrategy? ReferenceSubjectNameStrategy
        {
            get
            {
                var r = Get(PropertyNames.ReferenceSubjectNameStrategy);
                if (r == null) { return null; }
                else
                {
                    ReferenceSubjectNameStrategy result;
                    if (!Enum.TryParse<ReferenceSubjectNameStrategy>(r, out result))
                        throw new ArgumentException(
                            $"Unknown ${PropertyNames.ReferenceSubjectNameStrategy} value: {r}.");
                    else
                        return result;
                }
            }
            set
            {
                if (value == null) { this.properties.Remove(PropertyNames.ReferenceSubjectNameStrategy); }
                else { this.properties[PropertyNames.ReferenceSubjectNameStrategy] = value.ToString(); }
            }
        }

        /// <summary>
        ///     Schema id strategy.
        ///
        ///     default: SchemaIdSerializerStrategy.Prefix
        /// </summary>
        public SchemaIdSerializerStrategy? SchemaIdStrategy
        {
            get
            {
                var r = Get(PropertyNames.SchemaIdStrategy);
                if (r == null) { return null; }
                else
                {
                    SchemaIdSerializerStrategy result;
                    if (!Enum.TryParse<SchemaIdSerializerStrategy>(r, out result))
                        throw new ArgumentException(
                            $"Unknown ${PropertyNames.SchemaIdStrategy} value: {r}.");
                    else
                        return result;
                }
            }
            set
            {
                if (value == null) { this.properties.Remove(PropertyNames.SchemaIdStrategy); }
                else { this.properties[PropertyNames.SchemaIdStrategy] = value.ToString(); }
            }
        }


        /// <summary>
        /// Custom reference subject name strategy resolver.
        /// Ensure <seealso cref="ReferenceSubjectNameStrategy.Custom"/> is set for this to take effect.
        /// </summary>
        public ICustomReferenceSubjectNameStrategy CustomReferenceSubjectNameStrategy { get; set; } = null;
    }
}
