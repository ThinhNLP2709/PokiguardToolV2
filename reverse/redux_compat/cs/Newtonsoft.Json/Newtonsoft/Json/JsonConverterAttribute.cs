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
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Parameter, AllowMultiple = false)]
	[Nullable(0)]
	[NullableContext(1)]
	public sealed class JsonConverterAttribute : Attribute // TypeDefIndex: 9973
	{
		// Fields
		private readonly Type _converterType; // 0x10
		[CompilerGenerated]
		[Nullable(new byte[2] {2, 1 })]
		private readonly object[] _ConverterParameters_k__BackingField; // 0x18
	
		// Properties
		public Type ConverterType { get; } // 0x0000000180377550-0x0000000180377560 
		[Nullable(new byte[2] {2, 1 })]
		public object[] ConverterParameters { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		public JsonConverterAttribute(Type converterType); // 0x000000018169B970-0x000000018169BA10
		public JsonConverterAttribute(Type converterType, params object[] converterParameters); // 0x000000018169B8B0-0x000000018169B970
	}
}
