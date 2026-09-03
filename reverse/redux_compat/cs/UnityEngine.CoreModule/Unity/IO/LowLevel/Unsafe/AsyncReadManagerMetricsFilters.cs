/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.IO.LowLevel.Unsafe
{
	[NativeAsStruct]
	[NativeConditional("ENABLE_PROFILER")]
	[RequiredByNativeCode]
	public class AsyncReadManagerMetricsFilters // TypeDefIndex: 7405
	{
		// Fields
		[NativeName("typeIDs")]
		internal ulong[] TypeIDs; // 0x10
		[NativeName("states")]
		internal ProcessingState[] States; // 0x18
		[NativeName("readTypes")]
		internal FileReadType[] ReadTypes; // 0x20
		[NativeName("priorityLevels")]
		internal Priority[] PriorityLevels; // 0x28
		[NativeName("subsystems")]
		internal AssetLoadingSubsystem[] Subsystems; // 0x30
	}
}
