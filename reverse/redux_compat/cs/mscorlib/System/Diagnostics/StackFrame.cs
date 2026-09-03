/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Diagnostics
{
	[Serializable]
	[ComVisible(true)]
	[MonoTODO("Serialized objects are not compatible with MS.NET")]
	public class StackFrame // TypeDefIndex: 3469
	{
		// Fields
		public const int OFFSET_UNKNOWN = -1; // Metadata: 0x0064F01A
		private int ilOffset; // 0x10
		private int nativeOffset; // 0x14
		private long methodAddress; // 0x18
		private uint methodIndex; // 0x20
		private MethodBase methodBase; // 0x28
		private string fileName; // 0x30
		private int lineNumber; // 0x38
		private int columnNumber; // 0x3C
		private string internalMethodName; // 0x40
	
		// Constructors
		public StackFrame(); // 0x00000001815A0970-0x00000001815A09D0
		public StackFrame(int skipFrames, bool fNeedFileInfo); // 0x00000001815A08F0-0x00000001815A0970
	
		// Methods
		private static bool get_frame_info(int skip, bool needFileInfo, out MethodBase method, out int iloffset, out int native_offset, out string file, out int line, out int column); // 0x00000001815A09D0-0x00000001815A09E0
		public virtual int GetFileLineNumber(); // 0x000000018047EDE0-0x000000018047EDF0
		public virtual string GetFileName(); // 0x000000018031E110-0x000000018031E120
		internal string GetSecureFileName(); // 0x00000001815A0690-0x00000001815A06F0
		public virtual int GetILOffset(); // 0x00000001802E64B0-0x00000001802E64C0
		public virtual MethodBase GetMethod(); // 0x000000018033D240-0x000000018033D250
		public virtual int GetNativeOffset(); // 0x0000000180A5E110-0x0000000180A5E120
		internal long GetMethodAddress(); // 0x00000001802F8EC0-0x00000001802F8ED0
		internal uint GetMethodIndex(); // 0x0000000180C4F680-0x0000000180C4F690
		internal string GetInternalMethodName(); // 0x0000000180377940-0x0000000180377950
		public override string ToString(); // 0x00000001815A06F0-0x00000001815A08F0
	}
}
