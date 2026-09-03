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
using Newtonsoft.Json.Utilities;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	public class DefaultSerializationBinder : SerializationBinder, ISerializationBinder // TypeDefIndex: 10208
	{
		// Fields
		internal static readonly DefaultSerializationBinder Instance; // 0x00
		[Nullable(new byte[5] {1, 0, 2, 1, 1 })]
		private readonly ThreadSafeStore<StructMultiKey<string, string>, Type> _typeCache; // 0x10
	
		// Constructors
		public DefaultSerializationBinder(); // 0x0000000181706E80-0x0000000181706F40
		static DefaultSerializationBinder(); // 0x0000000181706D70-0x0000000181706E80
	
		// Methods
		private Type GetTypeFromTypeNameKey([Nullable(new byte[3] {0, 2, 1 })] StructMultiKey<string, string> typeNameKey); // 0x0000000181706950-0x0000000181706D70
		private Type GetGenericTypeFromTypeName(string typeName, Assembly assembly); // 0x0000000181706650-0x00000001817068F0
		private Type GetTypeByName([Nullable(new byte[3] {0, 2, 1 })] StructMultiKey<string, string> typeNameKey); // 0x00000001817068F0-0x0000000181706950
		public override Type BindToType([Nullable(2)] string assemblyName, string typeName); // 0x00000001817065D0-0x0000000181706650
		[NullableContext(2)]
		public override void BindToName([Nullable(1)] Type serializedType, out string assemblyName, out string typeName); // 0x0000000181706530-0x00000001817065D0
	}
}
