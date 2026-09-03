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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json
{
	[Nullable(0)]
	[NullableContext(1)]
	public abstract class JsonConverter // TypeDefIndex: 9971
	{
		// Properties
		public virtual bool CanRead { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public virtual bool CanWrite { get; } // 0x00000001802E7990-0x00000001802E79A0 
	
		// Constructors
		protected JsonConverter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract void WriteJson(JsonWriter writer, [Nullable(2)] object value, JsonSerializer serializer);
		public abstract object ReadJson(JsonReader reader, Type objectType, [Nullable(2)] object existingValue, JsonSerializer serializer);
		public abstract bool CanConvert(Type objectType);
	}
}
