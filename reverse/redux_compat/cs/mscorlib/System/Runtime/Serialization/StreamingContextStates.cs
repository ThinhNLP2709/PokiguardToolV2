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

namespace System.Runtime.Serialization
{
	[Serializable]
	[ComVisible(true)]
	[Flags]
	public enum StreamingContextStates // TypeDefIndex: 3053
	{
		CrossProcess = 1,
		CrossMachine = 2,
		File = 4,
		Persistence = 8,
		Remoting = 16,
		Other = 32,
		Clone = 64,
		CrossAppDomain = 128,
		All = 255
	}
}
