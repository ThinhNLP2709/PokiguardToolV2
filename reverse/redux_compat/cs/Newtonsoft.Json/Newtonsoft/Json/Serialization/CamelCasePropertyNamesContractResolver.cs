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
	public class CamelCasePropertyNamesContractResolver : DefaultContractResolver // TypeDefIndex: 10193
	{
		// Fields
		private static readonly object TypeContractCacheLock; // 0x00
		private static readonly DefaultJsonNameTable NameTable; // 0x08
		[Nullable(new byte[5] {2, 0, 1, 1, 1 })]
		private static Dictionary<StructMultiKey<Type, Type>, JsonContract> _contractCache; // 0x10
	
		// Constructors
		public CamelCasePropertyNamesContractResolver(); // 0x00000001816FE180-0x00000001816FE220
		static CamelCasePropertyNamesContractResolver(); // 0x00000001816FE0C0-0x00000001816FE180
	
		// Methods
		public override JsonContract ResolveContract(Type type); // 0x00000001816FDDC0-0x00000001816FE0C0
		internal override DefaultJsonNameTable GetNameTable(); // 0x00000001816FDD70-0x00000001816FDDC0
	}
}
