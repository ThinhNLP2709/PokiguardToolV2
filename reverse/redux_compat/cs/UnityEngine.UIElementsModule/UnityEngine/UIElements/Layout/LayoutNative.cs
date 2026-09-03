/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using JetBrains.Annotations;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Layout
{
	[NativeHeader("External/Yoga/LayoutNative.h")]
	internal static class LayoutNative // TypeDefIndex: 5213
	{
		// Fields
		[CompilerGenerated]
		private static Action<LayoutLogData> onLayoutLog; // 0x00
	
		// Nested types
		internal enum LayoutLogEventType // TypeDefIndex: 5214
		{
			None = 0,
			Error = 1,
			Measure = 2,
			Layout = 3,
			CacheUsage = 4,
			BeginLayout = 5,
			EndLayout = 6
		}
	
		internal class LayoutLogData // TypeDefIndex: 5215
		{
			// Fields
			public LayoutNode node; // 0x10
			public LayoutLogEventType eventType; // 0x50
			public string message; // 0x58
	
			// Constructors
			public LayoutLogData(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Methods
		[NativeMethod(IsThreadSafe = false)]
		internal static void CalculateLayout(IntPtr node, float parentWidth, float parentHeight, int parentDirection, IntPtr state, IntPtr exceptionGCHandle); // 0x000000018243C2D0-0x000000018243C340
		[RequiredByNativeCode(Optional = true)]
		[UsedImplicitly]
		private static void LayoutLog_Internal(IntPtr nodePtr, LayoutLogEventType type, string message); // 0x000000018243C340-0x000000018243C420
	}
}
