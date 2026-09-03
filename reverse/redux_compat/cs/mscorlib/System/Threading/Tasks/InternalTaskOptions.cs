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

namespace System.Threading.Tasks
{
	[Flags]
	internal enum InternalTaskOptions // TypeDefIndex: 2656
	{
		None = 0,
		ContinuationTask = 512,
		PromiseTask = 1024,
		LazyCancellation = 4096,
		QueuedByRuntime = 8192,
		DoNotDispose = 16384,
		InternalOptionsMask = 65280
	}
}
