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

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	public class ErrorEventArgs : EventArgs // TypeDefIndex: 10211
	{
		// Fields
		[CompilerGenerated]
		[Nullable(2)]
		private readonly object _CurrentObject_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly ErrorContext _ErrorContext_k__BackingField; // 0x18
	
		// Properties
		[Nullable(2)]
		public object CurrentObject { [NullableContext(2)] [CompilerGenerated] get; } // 0x0000000180377550-0x0000000180377560 
		public ErrorContext ErrorContext { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		public ErrorEventArgs([Nullable(2)] object currentObject, ErrorContext errorContext); // 0x00000001817074C0-0x0000000181707550
	}
}
