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

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	internal abstract class JsonSerializerInternalBase // TypeDefIndex: 10237
	{
		// Fields
		[Nullable(2)]
		private ErrorContext _currentErrorContext; // 0x10
		[Nullable(new byte[3] {2, 1, 1 })]
		private BidirectionalDictionary<string, object> _mappings; // 0x18
		internal readonly JsonSerializer Serializer; // 0x20
		[Nullable(2)]
		internal readonly ITraceWriter TraceWriter; // 0x28
		[Nullable(2)]
		protected JsonSerializerProxy InternalSerializer; // 0x30
	
		// Properties
		internal BidirectionalDictionary<string, object> DefaultReferenceMappings { get; } // 0x000000018170DC50-0x000000018170DDC0 
	
		// Nested types
		[NullableContext(0)]
		private class ReferenceEqualsEqualityComparer : IEqualityComparer<object> // TypeDefIndex: 10238
		{
			// Constructors
			public ReferenceEqualsEqualityComparer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			[NullableContext(2)]
			bool IEqualityComparer<object>.Equals(object x, object y); // 0x000000018171AC80-0x000000018171AC90
			[NullableContext(1)]
			int IEqualityComparer<object>.GetHashCode(object obj); // 0x000000018171AC90-0x000000018171ACA0
		}
	
		// Constructors
		protected JsonSerializerInternalBase(JsonSerializer serializer); // 0x000000018170DB80-0x000000018170DC50
	
		// Methods
		protected NullValueHandling ResolvedNullValueHandling([Nullable(2)] JsonObjectContract containerContract, JsonProperty property); // 0x000000018170DB30-0x000000018170DB80
		private ErrorContext GetErrorContext([Nullable(2)] object currentObject, [Nullable(2)] object member, string path, Exception error); // 0x000000018170D5F0-0x000000018170D730
		protected void ClearErrorContext(); // 0x000000018170D570-0x000000018170D5F0
		[NullableContext(2)]
		protected bool IsErrorHandled(object currentObject, JsonContract contract, object keyValue, IJsonLineInfo lineInfo, [Nullable(1)] string path, [Nullable(1)] Exception ex); // 0x000000018170D730-0x000000018170DB30
	}
}
