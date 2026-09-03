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
	public class ErrorContext // TypeDefIndex: 10210
	{
		// Fields
		[CompilerGenerated]
		private bool _Traced_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly Exception _Error_k__BackingField; // 0x18
		[CompilerGenerated]
		[Nullable(2)]
		private readonly object _OriginalObject_k__BackingField; // 0x20
		[CompilerGenerated]
		[Nullable(2)]
		private readonly object _Member_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly string _Path_k__BackingField; // 0x30
		[CompilerGenerated]
		private bool _Handled_k__BackingField; // 0x38
	
		// Properties
		internal bool Traced { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		public Exception Error { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		[Nullable(2)]
		public object OriginalObject { [NullableContext(2)] [CompilerGenerated] get; } // 0x00000001802F8630-0x00000001802F8640 
		[Nullable(2)]
		public object Member { [NullableContext(2)] [CompilerGenerated] get; } // 0x000000018033D240-0x000000018033D250 
		public string Path { [CompilerGenerated] get; } // 0x000000018031E110-0x000000018031E120 
		public bool Handled { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180476380-0x0000000180476390 0x00000001804763A0-0x00000001804763B0
	
		// Constructors
		internal ErrorContext([Nullable(2)] object originalObject, [Nullable(2)] object member, string path, Exception error); // 0x0000000181707440-0x00000001817074C0
	}
}
