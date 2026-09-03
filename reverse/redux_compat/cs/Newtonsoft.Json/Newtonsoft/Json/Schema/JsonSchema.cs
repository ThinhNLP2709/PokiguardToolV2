/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Schema
{
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	public class JsonSchema // TypeDefIndex: 10264
	{
		// Fields
		[CompilerGenerated]
		private string _Id_k__BackingField; // 0x10
		[CompilerGenerated]
		private string _Title_k__BackingField; // 0x18
		[CompilerGenerated]
		private bool? _Required_k__BackingField; // 0x20
		[CompilerGenerated]
		private bool? _ReadOnly_k__BackingField; // 0x22
		[CompilerGenerated]
		private bool? _Hidden_k__BackingField; // 0x24
		[CompilerGenerated]
		private bool? _Transient_k__BackingField; // 0x26
		[CompilerGenerated]
		private string _Description_k__BackingField; // 0x28
		[CompilerGenerated]
		private JsonSchemaType? _Type_k__BackingField; // 0x30
		[CompilerGenerated]
		private string _Pattern_k__BackingField; // 0x38
		[CompilerGenerated]
		private int? _MinimumLength_k__BackingField; // 0x40
		[CompilerGenerated]
		private int? _MaximumLength_k__BackingField; // 0x48
		[CompilerGenerated]
		private double? _DivisibleBy_k__BackingField; // 0x50
		[CompilerGenerated]
		private double? _Minimum_k__BackingField; // 0x60
		[CompilerGenerated]
		private double? _Maximum_k__BackingField; // 0x70
		[CompilerGenerated]
		private bool? _ExclusiveMinimum_k__BackingField; // 0x80
		[CompilerGenerated]
		private bool? _ExclusiveMaximum_k__BackingField; // 0x82
		[CompilerGenerated]
		private int? _MinimumItems_k__BackingField; // 0x84
		[CompilerGenerated]
		private int? _MaximumItems_k__BackingField; // 0x8C
		[CompilerGenerated]
		private IList<JsonSchema> _Items_k__BackingField; // 0x98
		[CompilerGenerated]
		private bool _PositionalItemsValidation_k__BackingField; // 0xA0
		[CompilerGenerated]
		private JsonSchema _AdditionalItems_k__BackingField; // 0xA8
		[CompilerGenerated]
		private bool _AllowAdditionalItems_k__BackingField; // 0xB0
		[CompilerGenerated]
		private bool _UniqueItems_k__BackingField; // 0xB1
		[CompilerGenerated]
		private IDictionary<string, JsonSchema> _Properties_k__BackingField; // 0xB8
		[CompilerGenerated]
		private JsonSchema _AdditionalProperties_k__BackingField; // 0xC0
		[CompilerGenerated]
		private IDictionary<string, JsonSchema> _PatternProperties_k__BackingField; // 0xC8
		[CompilerGenerated]
		private bool _AllowAdditionalProperties_k__BackingField; // 0xD0
		[CompilerGenerated]
		private string _Requires_k__BackingField; // 0xD8
		[CompilerGenerated]
		private IList<JToken> _Enum_k__BackingField; // 0xE0
		[CompilerGenerated]
		private JsonSchemaType? _Disallow_k__BackingField; // 0xE8
		[CompilerGenerated]
		private JToken _Default_k__BackingField; // 0xF0
		[CompilerGenerated]
		private IList<JsonSchema> _Extends_k__BackingField; // 0xF8
		[CompilerGenerated]
		private string _Format_k__BackingField; // 0x100
		[CompilerGenerated]
		private string _Location_k__BackingField; // 0x108
		private readonly string _internalId; // 0x110
		[CompilerGenerated]
		private string _DeferredReference_k__BackingField; // 0x118
		[CompilerGenerated]
		private bool _ReferencesResolved_k__BackingField; // 0x120
	
		// Properties
		public string Id { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377550-0x0000000180377560 0x00000001803780D0-0x00000001803780E0
		public string Title { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public bool? Required { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001816A1C50-0x00000001816A1C60 0x00000001816A1E50-0x00000001816A1E60
		public bool? ReadOnly { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018172A3A0-0x000000018172A3B0 0x000000018172A490-0x000000018172A4A0
		public bool? Hidden { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018172A360-0x000000018172A370 0x000000018172A420-0x000000018172A430
		public bool? Transient { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018172A3B0-0x000000018172A3C0 0x000000018172A4A0-0x000000018172A4B0
		public string Description { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		public JsonSchemaType? Type { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018031E110-0x000000018031E120 0x000000018172A4B0-0x000000018172A4C0
		public string Pattern { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018033E850-0x000000018033E860
		public int? MinimumLength { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180377940-0x0000000180377950 0x000000018172A470-0x000000018172A480
		public int? MaximumLength { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001803272B0-0x00000001803272C0 0x000000018172A440-0x000000018172A450
		public double? DivisibleBy { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180E14960-0x0000000180E14970 0x000000018172A3F0-0x000000018172A400
		public double? Minimum { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001816A56A0-0x00000001816A56B0 0x000000018172A480-0x000000018172A490
		public double? Maximum { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018172A380-0x000000018172A390 0x000000018172A450-0x000000018172A460
		public bool? ExclusiveMinimum { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001816BD420-0x00000001816BD430 0x000000018172A410-0x000000018172A420
		public bool? ExclusiveMaximum { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018172A350-0x000000018172A360 0x000000018172A400-0x000000018172A410
		public int? MinimumItems { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018172A390-0x000000018172A3A0 0x000000018172A460-0x000000018172A470
		public int? MaximumItems { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018172A370-0x000000018172A380 0x000000018172A430-0x000000018172A440
		public IList<JsonSchema> Items { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
		public bool PositionalItemsValidation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018165FFF0-0x0000000181660000 0x0000000181727470-0x0000000181727480
		public JsonSchema AdditionalItems { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D510-0x000000018033D520 0x000000018033EAB0-0x000000018033EAD0
		public bool AllowAdditionalItems { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001807186D0-0x00000001807186E0 0x0000000180718740-0x0000000180718750
		public bool UniqueItems { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018172A3C0-0x000000018172A3D0 0x000000018172A4C0-0x000000018172A4D0
		public IDictionary<string, JsonSchema> Properties { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x00000001806CCDE0-0x00000001806CCE00
		public JsonSchema AdditionalProperties { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB70-0x00000001806CCB80 0x00000001806CCDA0-0x00000001806CCDC0
		public IDictionary<string, JsonSchema> PatternProperties { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB50-0x00000001806CCB60 0x00000001806CCD60-0x00000001806CCD80
		public bool AllowAdditionalProperties { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018158AF70-0x000000018158AF80 0x000000018172A3D0-0x000000018172A3E0
		public string Requires { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBB0-0x00000001806CCBC0 0x00000001806CCE00-0x00000001806CCE20
		public IList<JToken> Enum { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB80-0x00000001806CCB90 0x00000001806CCDC0-0x00000001806CCDE0
		public JsonSchemaType? Disallow { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806BAE70-0x00000001806BAE80 0x000000018172A3E0-0x000000018172A3F0
		public JToken Default { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CC3740-0x0000000180CC3750 0x0000000180CC3C60-0x0000000180CC3C80
		public IList<JsonSchema> Extends { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CDCEE0-0x0000000180CDCEF0 0x00000001816A2DA0-0x00000001816A2DC0
		public string Format { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001816A28C0-0x00000001816A28D0 0x00000001816A2D50-0x00000001816A2D70
		internal string Location { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180CDC950-0x0000000180CDC960 0x0000000180CDC990-0x0000000180CDC9B0
		internal string InternalId { get; } // 0x000000018170B050-0x000000018170B060 
		internal string DeferredReference { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018171E0D0-0x000000018171E0E0 0x0000000180504EA0-0x0000000180504EC0
		internal bool ReferencesResolved { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018170B040-0x000000018170B050 0x000000018170B150-0x000000018170B160
	
		// Constructors
		public JsonSchema(); // 0x000000018172A2C0-0x000000018172A350
	
		// Methods
		public static JsonSchema Read(JsonReader reader); // 0x0000000181729BE0-0x0000000181729C40
		public static JsonSchema Read(JsonReader reader, JsonSchemaResolver resolver); // 0x0000000181729C40-0x0000000181729E90
		public static JsonSchema Parse(string json); // 0x0000000181729A30-0x0000000181729A90
		public static JsonSchema Parse(string json, JsonSchemaResolver resolver); // 0x0000000181729A90-0x0000000181729BE0
		public void WriteTo(JsonWriter writer); // 0x000000018172A190-0x000000018172A2C0
		public void WriteTo(JsonWriter writer, JsonSchemaResolver resolver); // 0x000000018172A090-0x000000018172A190
		public override string ToString(); // 0x0000000181729E90-0x000000018172A090
	}
}
