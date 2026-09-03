/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 59: UnityEngine.ContentLoadModule.dll - Assembly: UnityEngine.ContentLoadModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15722-15736

namespace Unity.Loading.LowLevel
{
	[NativeHeader("Modules/ContentLoad/Public/L0LoadingSystem.bindings.h")]
	[StaticAccessor("ContentLoad::L0Bindings", StaticAccessorType.DoubleColon)]
	internal sealed class NativeLoadingSystem // TypeDefIndex: 15736
	{
		// Methods
		public static unsafe void ReleaseAsync(ResourceHandle* handles, int count, LoadingResponseQueue resultQueue); // 0x0000000182175AA0-0x0000000182175AF0
		public static unsafe void WaitForReleaseCompletion(ResourceHandle* handles, int count); // 0x0000000182175AF0-0x0000000182175B30
		private static unsafe void ReleaseAsync_Injected(ResourceHandle* handles, int count, in LoadingResponseQueue resultQueue); // 0x0000000182175A50-0x0000000182175AA0
	}
}
