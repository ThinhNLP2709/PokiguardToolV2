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
	public enum TaskContinuationOptions // TypeDefIndex: 2657
	{
		None = 0,
		PreferFairness = 1,
		LongRunning = 2,
		AttachedToParent = 4,
		DenyChildAttach = 8,
		HideScheduler = 16,
		LazyCancellation = 32,
		RunContinuationsAsynchronously = 64,
		NotOnRanToCompletion = 65536,
		NotOnFaulted = 131072,
		OnlyOnCanceled = 196608,
		NotOnCanceled = 262144,
		OnlyOnFaulted = 327680,
		OnlyOnRanToCompletion = 393216,
		ExecuteSynchronously = 524288
	}
}
