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
using Newtonsoft.Json.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Schema
{
	[Obsolete("JSON Schema validation has been moved to its own package. See https://www.newtonsoft.com/jsonschema for more details.")]
	internal class JsonSchemaModel // TypeDefIndex: 10272
	{
		// Fields
		[CompilerGenerated]
		private bool _Required_k__BackingField; // 0x10
		[CompilerGenerated]
		private JsonSchemaType _Type_k__BackingField; // 0x14
		[CompilerGenerated]
		private int? _MinimumLength_k__BackingField; // 0x18
		[CompilerGenerated]
		private int? _MaximumLength_k__BackingField; // 0x20
		[CompilerGenerated]
		private double? _DivisibleBy_k__BackingField; // 0x28
		[CompilerGenerated]
		private double? _Minimum_k__BackingField; // 0x38
		[CompilerGenerated]
		private double? _Maximum_k__BackingField; // 0x48
		[CompilerGenerated]
		private bool _ExclusiveMinimum_k__BackingField; // 0x58
		[CompilerGenerated]
		private bool _ExclusiveMaximum_k__BackingField; // 0x59
		[CompilerGenerated]
		private int? _MinimumItems_k__BackingField; // 0x5C
		[CompilerGenerated]
		private int? _MaximumItems_k__BackingField; // 0x64
		[CompilerGenerated]
		private IList<string> _Patterns_k__BackingField; // 0x70
		[CompilerGenerated]
		private IList<JsonSchemaModel> _Items_k__BackingField; // 0x78
		[CompilerGenerated]
		private IDictionary<string, JsonSchemaModel> _Properties_k__BackingField; // 0x80
		[CompilerGenerated]
		private IDictionary<string, JsonSchemaModel> _PatternProperties_k__BackingField; // 0x88
		[CompilerGenerated]
		private JsonSchemaModel _AdditionalProperties_k__BackingField; // 0x90
		[CompilerGenerated]
		private JsonSchemaModel _AdditionalItems_k__BackingField; // 0x98
		[CompilerGenerated]
		private bool _PositionalItemsValidation_k__BackingField; // 0xA0
		[CompilerGenerated]
		private bool _AllowAdditionalProperties_k__BackingField; // 0xA1
		[CompilerGenerated]
		private bool _AllowAdditionalItems_k__BackingField; // 0xA2
		[CompilerGenerated]
		private bool _UniqueItems_k__BackingField; // 0xA3
		[CompilerGenerated]
		private IList<JToken> _Enum_k__BackingField; // 0xA8
		[CompilerGenerated]
		private JsonSchemaType _Disallow_k__BackingField; // 0xB0
	
		// Properties
		public bool Required { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		public JsonSchemaType Type { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public int? MinimumLength { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001804C2E30-0x00000001804C2E40
		public int? MaximumLength { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802F8630-0x00000001802F8640 0x0000000181727440-0x0000000181727450
		public double? DivisibleBy { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C46B90-0x0000000180C46BA0 0x00000001815D9CA0-0x00000001815D9CB0
		public double? Minimum { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001817273D0-0x00000001817273E0 0x0000000181727460-0x0000000181727470
		public double? Maximum { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001817273C0-0x00000001817273D0 0x0000000181727450-0x0000000181727460
		public bool ExclusiveMinimum { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181424750-0x0000000181424760 0x0000000181424790-0x00000001814247A0
		public bool ExclusiveMaximum { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E7880-0x00000001802E7890 0x0000000181727420-0x0000000181727430
		public int? MinimumItems { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181424760-0x0000000181424770 0x00000001814247A0-0x00000001814247B0
		public int? MaximumItems { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001817273B0-0x00000001817273C0 0x0000000181727430-0x0000000181727440
		public IList<string> Patterns { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		public IList<JsonSchemaModel> Items { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4E0-0x000000018033D4F0 0x000000018033EA70-0x000000018033EA80
		public IDictionary<string, JsonSchemaModel> Properties { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
		public IDictionary<string, JsonSchemaModel> PatternProperties { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000180664140-0x0000000180664160
		public JsonSchemaModel AdditionalProperties { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000180664160-0x0000000180664180
		public JsonSchemaModel AdditionalItems { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCBC0-0x00000001806CCBD0 0x00000001806CCE20-0x00000001806CCE40
		public bool PositionalItemsValidation { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018165FFF0-0x0000000181660000 0x0000000181727470-0x0000000181727480
		public bool AllowAdditionalProperties { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001817273A0-0x00000001817273B0 0x0000000181727400-0x0000000181727410
		public bool AllowAdditionalItems { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181727390-0x00000001817273A0 0x00000001817273F0-0x0000000181727400
		public bool UniqueItems { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001817273E0-0x00000001817273F0 0x0000000181727480-0x0000000181727490
		public IList<JToken> Enum { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D510-0x000000018033D520 0x000000018033EAB0-0x000000018033EAD0
		public JsonSchemaType Disallow { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018158ACB0-0x000000018158ACC0 0x0000000181727410-0x0000000181727420
	
		// Constructors
		public JsonSchemaModel(); // 0x0000000181727360-0x0000000181727390
	
		// Methods
		public static JsonSchemaModel Create(IList<JsonSchema> schemata); // 0x0000000181727150-0x0000000181727360
		private static void Combine(JsonSchemaModel model, JsonSchema schema); // 0x0000000181726DE0-0x0000000181727150
	}
}
