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
	[Serializable]
	[NativeHeader("Modules/IMGUI/GUIStyle.bindings.h")]
	public sealed class GUIStyleState // TypeDefIndex: 13936
	{
		// Fields
		[NonSerialized]
		internal IntPtr m_Ptr; // 0x10
		private readonly GUIStyle m_SourceStyle; // 0x18
	
		// Properties
		[NativeProperty("textColor", false, TargetType.Field)]
		public Color textColor { get; set; } // 0x0000000182284180-0x00000001822841F0 0x0000000182284240-0x00000001822842A0
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 13937
		{
			// Methods
			public static IntPtr ConvertToNative(GUIStyleState guiStyleState); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public GUIStyleState(); // 0x00000001822840F0-0x0000000182284130
		private GUIStyleState(GUIStyle sourceStyle, IntPtr source); // 0x00000001821BC3A0-0x00000001821BC3F0
	
		// Methods
		[FreeFunction(Name = "GUIStyleState_Bindings::Init", IsThreadSafe = true)]
		private static IntPtr Init(); // 0x0000000182284040-0x0000000182284070
		[FreeFunction(Name = "GUIStyleState_Bindings::Cleanup", IsThreadSafe = true, HasExplicitThis = true)]
		private void Cleanup(); // 0x0000000182283EB0-0x0000000182283F10
		internal static GUIStyleState ProduceGUIStyleStateFromDeserialization(GUIStyle sourceStyle, IntPtr source); // 0x0000000182284070-0x00000001822840F0
		internal static GUIStyleState GetGUIStyleState(GUIStyle sourceStyle, IntPtr source); // 0x0000000182283FC0-0x0000000182284040
		~GUIStyleState(); // 0x0000000182283F10-0x0000000182283FC0
		private static void get_textColor_Injected(IntPtr _unity_self, ); // 0x0000000182284130-0x0000000182284180
		private static void set_textColor_Injected(IntPtr _unity_self, in Color value); // 0x00000001822841F0-0x0000000182284240
		private static void Cleanup_Injected(IntPtr _unity_self); // 0x0000000182283E70-0x0000000182283EB0
	}
}
