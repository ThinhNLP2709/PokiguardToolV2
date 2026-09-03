/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(2)]
	public class JsonContainerContract : JsonContract // TypeDefIndex: 10219
	{
		// Fields
		private JsonContract _itemContract; // 0x90
		private JsonContract _finalItemContract; // 0x98
		[CompilerGenerated]
		private JsonConverter _ItemConverter_k__BackingField; // 0xA0
		[CompilerGenerated]
		private bool? _ItemIsReference_k__BackingField; // 0xA8
		[CompilerGenerated]
		private ReferenceLoopHandling? _ItemReferenceLoopHandling_k__BackingField; // 0xAC
		[CompilerGenerated]
		private TypeNameHandling? _ItemTypeNameHandling_k__BackingField; // 0xB4
	
		// Properties
		internal JsonContract ItemContract { get; set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x00000001817091B0-0x0000000181709220
		internal JsonContract FinalItemContract { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		public JsonConverter ItemConverter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805B5990-0x00000001805B59A0 0x00000001806CCE40-0x00000001806CCE60
		public bool? ItemIsReference { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181709180-0x0000000181709190 0x0000000181709220-0x0000000181709230
		public ReferenceLoopHandling? ItemReferenceLoopHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000181709190-0x00000001817091A0 0x0000000181709230-0x0000000181709240
		public TypeNameHandling? ItemTypeNameHandling { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001817091A0-0x00000001817091B0 0x0000000181709240-0x0000000181709250
	
		// Constructors
		[NullableContext(1)]
		internal JsonContainerContract(Type underlyingType); // 0x0000000181709080-0x0000000181709180
	}
}
