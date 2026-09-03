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
using UnityEngine.Scripting;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[NativeHeader("Modules/UIElements/Core/Native/UIElementsRuntimeUtilityNative.h")]
	internal static class UIElementsRuntimeUtilityNative // TypeDefIndex: 4264
	{
		// Fields
		private static Action UpdatePanelsCallback; // 0x00
		private static Action<bool> RepaintPanelsCallback; // 0x08
		private static Action RenderOffscreenPanelsCallback; // 0x10
	
		// Methods
		[RequiredByNativeCode]
		public static void UpdatePanels(); // 0x00000001824DF4B0-0x00000001824DF500
		[RequiredByNativeCode]
		public static void RepaintPanels(bool onlyOffscreen); // 0x00000001824DF260-0x00000001824DF2C0
		[RequiredByNativeCode]
		public static void RenderOffscreenPanels(); // 0x00000001824DF210-0x00000001824DF260
		public static void SetUpdateCallback(Action callback); // 0x00000001824DF370-0x00000001824DF3D0
		public static void SetRenderingCallbacks(Action<bool> repaintPanels, Action renderOffscreenPanels); // 0x00000001824DF2C0-0x00000001824DF370
		public static void UnsetRenderingCallbacks(); // 0x00000001824DF400-0x00000001824DF4B0
		private static void RegisterRenderingCallbacks(); // 0x00000001824DF1E0-0x00000001824DF210
		private static void UnregisterRenderingCallbacks(); // 0x00000001824DF3D0-0x00000001824DF400
		public static void VisualElementCreation(); // 0x00000001824DF500-0x00000001824DF530
	}
}
