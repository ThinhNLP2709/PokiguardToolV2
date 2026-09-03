/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Diagnostics
{
	[Serializable]
	[ComVisible(true)]
	[MonoTODO("Serialized objects are not compatible with .NET")]
	public class StackTrace // TypeDefIndex: 3470
	{
		// Fields
		private StackFrame[] frames; // 0x10
		private readonly StackTrace[] captured_traces; // 0x18
		private bool debug_info; // 0x20
		private static bool isAotidSet; // 0x00
		private static string aotid; // 0x08
	
		// Properties
		public virtual int FrameCount { get; } // 0x00000001815A1DC0-0x00000001815A1DE0 
	
		// Nested types
		internal enum TraceFormat // TypeDefIndex: 3471
		{
			Normal = 0,
			TrailingNewLine = 1,
			NoResourceLookup = 2
		}
	
		// Constructors
		public StackTrace(); // 0x00000001815A1D90-0x00000001815A1DC0
		public StackTrace(bool fNeedFileInfo); // 0x00000001815A1B40-0x00000001815A1B80
		public StackTrace(int skipFrames, bool fNeedFileInfo); // 0x00000001815A1CA0-0x00000001815A1CE0
		public StackTrace(Exception e, bool fNeedFileInfo); // 0x00000001815A1CE0-0x00000001815A1D90
		public StackTrace(Exception e, int skipFrames, bool fNeedFileInfo); // 0x00000001815A1B80-0x00000001815A1CA0
	
		// Methods
		private void init_frames(int skipFrames, bool fNeedFileInfo); // 0x00000001815A1DF0-0x00000001815A2020
		private static StackFrame[] get_trace(Exception e, int skipFrames, bool fNeedFileInfo); // 0x00000001815A1DE0-0x00000001815A1DF0
		public virtual StackFrame GetFrame(int index); // 0x00000001815A12B0-0x00000001815A1320
		private static string GetAotId(); // 0x00000001815A11C0-0x00000001815A12B0
		private bool AddFrames(StringBuilder sb, bool separator, out bool isAsync); // 0x00000001815A09E0-0x00000001815A0EF0
		private void GetFullNameForStackTrace(StringBuilder sb, MethodBase mi, bool needsNewLine, out bool skipped, out bool isAsync); // 0x00000001815A1320-0x00000001815A19B0
		private static void ConvertAsyncStateMachineMethod(ref MethodBase method, ref Type declaringType); // 0x00000001815A0EF0-0x00000001815A11C0
		public override string ToString(); // 0x00000001815A19B0-0x00000001815A1B20
		internal string ToString(TraceFormat traceFormat); // 0x00000001815A1B20-0x00000001815A1B40
	}
}
