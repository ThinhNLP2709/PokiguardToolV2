/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace Unity.Profiling.Memory
{
	[NativeHeader("Runtime/Profiler/Runtime/MemorySnapshotManager.h")]
	public static class MemoryProfiler // TypeDefIndex: 7363
	{
		// Fields
		[CompilerGenerated]
		private static Action<string, bool> m_SnapshotFinished; // 0x00
		[CompilerGenerated]
		private static Action<string, bool, DebugScreenCapture> m_SaveScreenshotToDisk; // 0x08
		[CompilerGenerated]
		private static Action<MemorySnapshotMetadata> CreatingMetadata; // 0x10
	
		// Methods
		[RequiredByNativeCode]
		private static byte[] PrepareMetadata(); // 0x00000001821907D0-0x0000000182190B40
		internal static int WriteIntToByteArray(byte[] array, int offset, int value); // 0x0000000182190C60-0x0000000182190CE0
		internal static int WriteStringToByteArray(byte[] array, int offset, string value); // 0x0000000182190CE0-0x0000000182190D80
		[RequiredByNativeCode]
		private static void FinalizeSnapshot(string path, bool result); // 0x0000000182190740-0x00000001821907D0
		[RequiredByNativeCode]
		private static void SaveScreenshotToDisk(string path, bool result, IntPtr pixelsPtr, int pixelsCount, TextureFormat format, int width, int height); // 0x0000000182190B40-0x0000000182190C60
	}
}
