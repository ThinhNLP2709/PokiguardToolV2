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
using Newtonsoft.Json.Utilities;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Converters
{
	[Nullable(0)]
	[NullableContext(1)]
	public class DiscriminatedUnionConverter : JsonConverter // TypeDefIndex: 10377
	{
		// Fields
		private const string CasePropertyName = "Case"; // Metadata: 0x006A0F88
		private const string FieldsPropertyName = "Fields"; // Metadata: 0x006A0F8D
		private static readonly ThreadSafeStore<Type, Union> UnionCache; // 0x00
		private static readonly ThreadSafeStore<Type, Type> UnionTypeLookupCache; // 0x08
	
		// Nested types
		[Nullable(0)]
		internal class Union // TypeDefIndex: 10378
		{
			// Fields
			public readonly FSharpFunction TagReader; // 0x10
			public readonly List<UnionCase> Cases; // 0x18
	
			// Constructors
			public Union(FSharpFunction tagReader, List<UnionCase> cases); // 0x0000000180CB0730-0x0000000180CB0780
		}
	
		[Nullable(0)]
		internal class UnionCase // TypeDefIndex: 10379
		{
			// Fields
			public readonly int Tag; // 0x10
			public readonly string Name; // 0x18
			public readonly PropertyInfo[] Fields; // 0x20
			public readonly FSharpFunction FieldReader; // 0x28
			public readonly FSharpFunction Constructor; // 0x30
	
			// Constructors
			public UnionCase(int tag, string name, PropertyInfo[] fields, FSharpFunction fieldReader, FSharpFunction constructor); // 0x000000018176F820-0x000000018176F8B0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass8_0 // TypeDefIndex: 10380
		{
			// Fields
			public int tag; // 0x10
	
			// Constructors
			public __c__DisplayClass8_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _WriteJson_b__0(UnionCase c); // 0x0000000180513030-0x0000000180513050
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass9_0 // TypeDefIndex: 10381
		{
			// Fields
			[Nullable(0)]
			public string caseName; // 0x10
			[Nullable(0)]
			public Func<UnionCase, bool> __9__0; // 0x18
	
			// Constructors
			public __c__DisplayClass9_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(0)]
			internal bool _ReadJson_b__0(UnionCase c); // 0x000000018176F780-0x000000018176F7B0
		}
	
		// Constructors
		public DiscriminatedUnionConverter(); // 0x00000001802F4070-0x00000001802F4080
		static DiscriminatedUnionConverter(); // 0x000000018175B600-0x000000018175B770
	
		// Methods
		private static Type CreateUnionTypeLookup(Type t); // 0x0000000181759DA0-0x0000000181759FF0
		private static Union CreateUnion(Type t); // 0x0000000181759FF0-0x000000018175A8F0
		public override void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer); // 0x000000018175B0C0-0x000000018175B600
		public override object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer); // 0x000000018175A8F0-0x000000018175B0C0
		public override bool CanConvert(Type objectType); // 0x0000000181759B50-0x0000000181759DA0
	}
}
