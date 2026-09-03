/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[NativeHeader("Modules/UIElements/Core/Native/Renderer/UIPainter2D.bindings.h")]
	internal static class UIPainter2D // TypeDefIndex: 4250
	{
		// Methods
		public static IntPtr Create(bool computeBBox = false /* Metadata: 0x00660655 */); // 0x00000001824C98E0-0x00000001824C9920
		public static void Destroy(IntPtr handle); // 0x00000001824C9920-0x00000001824C9960
		public static void Reset(IntPtr handle); // 0x00000001824C9A10-0x00000001824C9A50
		public static void ClearSnapshots(IntPtr handle); // 0x00000001824C98A0-0x00000001824C98E0
		[NativeMethod(IsThreadSafe = true)]
		public static MeshWriteDataInterface ExecuteSnapshotFromJob(IntPtr painterHandle, int i); // 0x00000001824C99B0-0x00000001824C9A10
		private static void ExecuteSnapshotFromJob_Injected(IntPtr painterHandle, int i, ); // 0x00000001824C9960-0x00000001824C99B0
	}
}
