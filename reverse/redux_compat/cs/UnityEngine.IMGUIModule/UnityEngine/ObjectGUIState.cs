/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[NativeHeader("Modules/IMGUI/GUIState.h")]
	[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
	internal class ObjectGUIState : IDisposable // TypeDefIndex: 13949
	{
		// Fields
		internal IntPtr m_Ptr; // 0x10
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 13950
		{
			// Methods
			public static IntPtr ConvertToNative(ObjectGUIState objectGUIState); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public ObjectGUIState(); // 0x000000018229E880-0x000000018229E8C0
	
		// Methods
		public void Dispose(); // 0x000000018229E6D0-0x000000018229E760
		~ObjectGUIState(); // 0x000000018229E760-0x000000018229E810
		private void Destroy(); // 0x000000018229E680-0x000000018229E6D0
		private static IntPtr Internal_Create(); // 0x000000018229E810-0x000000018229E840
		[NativeMethod(IsThreadSafe = true)]
		private static void Internal_Destroy(IntPtr ptr); // 0x000000018229E840-0x000000018229E880
	}
}
