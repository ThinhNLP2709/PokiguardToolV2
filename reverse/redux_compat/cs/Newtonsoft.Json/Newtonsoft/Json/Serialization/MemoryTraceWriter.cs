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

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Serialization
{
	[Nullable(0)]
	[NullableContext(1)]
	public class MemoryTraceWriter : ITraceWriter // TypeDefIndex: 10251
	{
		// Fields
		private readonly Queue<string> _traceMessages; // 0x10
		private readonly object _lock; // 0x18
		[CompilerGenerated]
		private TraceLevel _LevelFilter_k__BackingField; // 0x20
	
		// Properties
		public TraceLevel LevelFilter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
	
		// Constructors
		public MemoryTraceWriter(); // 0x0000000181734BB0-0x0000000181734C60
	
		// Methods
		public void Trace(TraceLevel level, string message, [Nullable(2)] Exception ex); // 0x0000000181734920-0x0000000181734BB0
		public IEnumerable<string> GetTraceMessages(); // 0x0000000180377550-0x0000000180377560
		public override string ToString(); // 0x00000001817346C0-0x0000000181734920
	}
}
