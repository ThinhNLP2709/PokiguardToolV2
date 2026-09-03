/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;
using UnityEngine.UIElements.UIR;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[NativeClass("UIRenderer", PersistentTypeId = 1931382933)]
	[NativeHeader("Modules/UIElements/Core/Native/Renderer/UIRenderer.h")]
	public sealed class UIRenderer : Renderer // TypeDefIndex: 4252
	{
		// Fields
		internal List<CommandList>[] commandLists; // 0x18
	
		// Methods
		internal void AddDrawCallData(int safeFrameIndex, Material mat, uint textureSlotCount, uint forceRenderType, IntPtr serializedCommandsPtr, int commandCount, CommandListState state); // 0x00000001824C9AB0-0x00000001824C9B80
		internal void ResetDrawCallData(int safeFrameIndex); // 0x00000001824C9C60-0x00000001824C9CC0
		internal void ResetAllDrawCallData(); // 0x00000001824C9BC0-0x00000001824C9C20
		private static void AddDrawCallData_Injected(IntPtr _unity_self, int safeFrameIndex, IntPtr mat, uint textureSlotCount, uint forceRenderType, IntPtr serializedCommandsPtr, int commandCount, in CommandListState state); // 0x00000001824C9A50-0x00000001824C9AB0
		private static void ResetDrawCallData_Injected(IntPtr _unity_self, int safeFrameIndex); // 0x00000001824C9C20-0x00000001824C9C60
		private static void ResetAllDrawCallData_Injected(IntPtr _unity_self); // 0x00000001824C9B80-0x00000001824C9BC0
	}
}
