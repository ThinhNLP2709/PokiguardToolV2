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
	[NativeConditional("ENABLE_PROFILER")]
	[RequiredByNativeCode]
	public struct AsyncReadManagerRequestMetric // TypeDefIndex: 7404
	{
		// Fields
		[CompilerGenerated]
		private readonly string _AssetName_k__BackingField; // 0x00
		[CompilerGenerated]
		private readonly string _FileName_k__BackingField; // 0x08
		[CompilerGenerated]
		private readonly ulong _OffsetBytes_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly ulong _SizeBytes_k__BackingField; // 0x18
		[CompilerGenerated]
		private readonly ulong _AssetTypeId_k__BackingField; // 0x20
		[CompilerGenerated]
		private readonly ulong _CurrentBytesRead_k__BackingField; // 0x28
		[CompilerGenerated]
		private readonly uint _BatchReadCount_k__BackingField; // 0x30
		[CompilerGenerated]
		private readonly bool _IsBatchRead_k__BackingField; // 0x34
		[CompilerGenerated]
		private readonly ProcessingState _State_k__BackingField; // 0x38
		[CompilerGenerated]
		private readonly FileReadType _ReadType_k__BackingField; // 0x3C
		[CompilerGenerated]
		private readonly Priority _PriorityLevel_k__BackingField; // 0x40
		[CompilerGenerated]
		private readonly AssetLoadingSubsystem _Subsystem_k__BackingField; // 0x44
		[CompilerGenerated]
		private readonly double _RequestTimeMicroseconds_k__BackingField; // 0x48
		[CompilerGenerated]
		private readonly double _TimeInQueueMicroseconds_k__BackingField; // 0x50
		[CompilerGenerated]
		private readonly double _TotalTimeMicroseconds_k__BackingField; // 0x58
	}
}
