/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeHeader("Runtime/VirtualFileSystem/ManagedVFS/ManagedVirtualFileSystem.h")]
	internal static class ManagedVFSNative // TypeDefIndex: 7865
	{
		// Methods
		[FreeFunction("ManagedVirtualFileSystem::CompleteReadAsync", IsThreadSafe = true)]
		internal static void CompleteReadAsync(ManagedReadAsyncCommand command, long bytesRead, bool success); // 0x0000000182206C70-0x0000000182206CD0
		private static void CompleteReadAsync_Injected(in ManagedReadAsyncCommand command, long bytesRead, bool success); // 0x0000000182206C10-0x0000000182206C70
	}
}
