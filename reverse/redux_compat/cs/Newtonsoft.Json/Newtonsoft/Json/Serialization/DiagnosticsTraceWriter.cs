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
	public class DiagnosticsTraceWriter : ITraceWriter // TypeDefIndex: 10209
	{
		// Fields
		[CompilerGenerated]
		private TraceLevel _LevelFilter_k__BackingField; // 0x10
	
		// Properties
		public TraceLevel LevelFilter { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
	
		// Constructors
		public DiagnosticsTraceWriter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private TraceEventType GetTraceEventType(TraceLevel level); // 0x0000000181706F40-0x0000000181706FE0
		[NullableContext(1)]
		public void Trace(TraceLevel level, string message, [Nullable(2)] Exception ex); // 0x0000000181706FE0-0x0000000181707440
	}
}
