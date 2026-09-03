/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 51: UnityEngine.TerrainModule.dll - Assembly: UnityEngine.TerrainModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15533-15553

namespace UnityEngine.Rendering
{
	[NativeHeader("Modules/Terrain/Public/SpeedTreeWindManager.h")]
	[StaticAccessor("GetSpeedTreeWindManager()", StaticAccessorType.Dot)]
	internal static class SpeedTreeWindManager // TypeDefIndex: 15551
	{
		// Methods
		public static void UpdateWindAndWriteBufferWindParams(ReadOnlySpan<EntityId> renderersID, SpeedTreeWindParamsBufferIterator windParams, bool history); // 0x00000001822E9EB0-0x00000001822E9F30
		private static void UpdateWindAndWriteBufferWindParams_Injected(ref ManagedSpanWrapper renderersID, in SpeedTreeWindParamsBufferIterator windParams, bool history); // 0x00000001822E9E50-0x00000001822E9EB0
	}
}
