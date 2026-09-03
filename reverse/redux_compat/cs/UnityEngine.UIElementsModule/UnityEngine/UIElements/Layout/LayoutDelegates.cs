/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using AOT;
using Unity.Profiling;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.Layout
{
	internal static class LayoutDelegates // TypeDefIndex: 5184
	{
		// Fields
		private static readonly ProfilerMarker s_InvokeMeasureFunctionMarker; // 0x00
		private static readonly ProfilerMarker s_InvokeBaselineFunctionMarker; // 0x08
		private static readonly InvokeMeasureFunctionDelegate s_InvokeMeasureDelegate; // 0x10
		private static readonly InvokeBaselineFunctionDelegate s_InvokeBaselineDelegate; // 0x18
		internal static readonly IntPtr s_InvokeMeasureFunction; // 0x20
		internal static readonly IntPtr s_InvokeBaselineFunction; // 0x28
	
		// Constructors
		static LayoutDelegates(); // 0x0000000182439E70-0x000000018243A190
	
		// Methods
		[MonoPInvokeCallback(typeof(InvokeMeasureFunctionDelegate))]
		private static void InvokeMeasureFunction(ref LayoutNode node, float width, LayoutMeasureMode widthMode, float height, LayoutMeasureMode heightMode, ref IntPtr exception, out LayoutSize result); // 0x0000000182439BA0-0x0000000182439E70
		[MonoPInvokeCallback(typeof(InvokeBaselineFunctionDelegate))]
		private static float InvokeBaselineFunction(ref LayoutNode node, float width, float height); // 0x0000000182439920-0x0000000182439BA0
	}
}
