/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class SerializationBinderAdapter : ISerializationBinder // TypeDefIndex: 10257
	{
		// Fields
		public readonly SerializationBinder SerializationBinder; // 0x10
	
		// Constructors
		public SerializationBinderAdapter(SerializationBinder serializationBinder); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public Type BindToType([Nullable(2)] string assemblyName, string typeName); // 0x00000001817354C0-0x00000001817354F0
		[NullableContext(2)]
		public void BindToName([Nullable(1)] Type serializedType, out string assemblyName, out string typeName); // 0x0000000181735490-0x00000001817354C0
	}
}
