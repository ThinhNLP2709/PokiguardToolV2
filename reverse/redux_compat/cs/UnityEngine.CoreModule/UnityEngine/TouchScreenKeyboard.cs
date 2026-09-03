/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeConditional("ENABLE_ONSCREEN_KEYBOARD")]
	[NativeHeader("Runtime/Input/KeyboardOnScreen.h")]
	[NativeHeader("Runtime/Export/TouchScreenKeyboard/TouchScreenKeyboard.bindings.h")]
	public class TouchScreenKeyboard // TypeDefIndex: 7828
	{
		// Fields
		[NonSerialized]
		internal IntPtr m_Ptr; // 0x10
		[CompilerGenerated]
		private static InPlaceEditingBehavior _inPlaceEditingBehavior_k__BackingField; // 0x00
	
		// Properties
		public static bool isSupported { get; } // 0x000000018221F5B0-0x000000018221F640 
		[AutoStaticsCleanupOnCodeReload]
		public static InPlaceEditingBehavior inPlaceEditingBehavior { [CompilerGenerated] get; } // 0x000000018221F4D0-0x000000018221F510 
		public static bool isInPlaceEditingAllowed { get; } // 0x000000018221F540-0x000000018221F5B0 
		public string text { [NativeName("GetText")] get; [NativeName("SetText")] set; } // 0x000000018221F780-0x000000018221F870 0x000000018221FB50-0x000000018221FCC0
		public static bool hideInput { [NativeName("SetInputHidden")] set; } // 0x000000018221F9C0-0x000000018221FA00
		public static InputFieldAppearance inputFieldAppearance { [NativeName("GetInputFieldAppearance")] get; } // 0x000000018221F510-0x000000018221F540 
		public bool active { [NativeName("IsActive")] get; [NativeName("SetActive")] set; } // 0x000000018221F330-0x000000018221F390 0x000000018221F8C0-0x000000018221F920
		public Status status { [NativeName("GetKeyboardStatus")] get; } // 0x000000018221F6D0-0x000000018221F730 
		public int characterLimit { [NativeName("SetCharacterLimit")] set; } // 0x000000018221F960-0x000000018221F9C0
		public bool canGetSelection { [NativeName("CanGetSelection")] get; } // 0x000000018221F3D0-0x000000018221F430 
		public bool canSetSelection { [NativeName("CanSetSelection")] get; } // 0x000000018221F470-0x000000018221F4D0 
		public RangeInt selection { get; set; } // 0x000000018221F640-0x000000018221F690 0x000000018221FA00-0x000000018221FB00
	
		// Nested types
		public enum Status // TypeDefIndex: 7829
		{
			Visible = 0,
			Done = 1,
			Canceled = 2,
			LostFocus = 3
		}
	
		public enum InputFieldAppearance // TypeDefIndex: 7830
		{
			Customizable = 0,
			AlwaysVisible = 1,
			AlwaysHidden = 2
		}
	
		public enum InPlaceEditingBehavior // TypeDefIndex: 7831
		{
			Auto = 0,
			AlwaysAllowed = 1,
			AlwaysDisallowed = 2
		}
	
		internal static class BindingsMarshaller // TypeDefIndex: 7832
		{
			// Methods
			public static IntPtr ConvertToNative(TouchScreenKeyboard touchScreenKeyboard); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public TouchScreenKeyboard(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure, bool alert, string textPlaceholder, int characterLimit); // 0x000000018221F1C0-0x000000018221F2F0
	
		// Methods
		[FreeFunction("TouchScreenKeyboard_Destroy", IsThreadSafe = true)]
		private static void Internal_Destroy(IntPtr ptr); // 0x000000018221EB80-0x000000018221EBC0
		private void Destroy(); // 0x000000018221E9B0-0x000000018221EA40
		~TouchScreenKeyboard(); // 0x000000018221EA40-0x000000018221EB30
		[FreeFunction("TouchScreenKeyboard_InternalConstructorHelper")]
		private static IntPtr TouchScreenKeyboard_InternalConstructorHelper(ref TouchScreenKeyboard_InternalConstructorHelperArguments arguments, string text, string textPlaceholder); // 0x000000018221EF70-0x000000018221F1C0
		private static bool IsInPlaceEditingAllowed(); // 0x000000018221EBC0-0x000000018221EBF0
		public static TouchScreenKeyboard Open(string text, [DefaultValue("TouchScreenKeyboardType.Default")] TouchScreenKeyboardType keyboardType, [DefaultValue("true")] bool autocorrection, [DefaultValue("false")] bool multiline, [DefaultValue("false")] bool secure, [DefaultValue("false")] bool alert, [DefaultValue("\"\"")] string textPlaceholder, [DefaultValue("0")] int characterLimit); // 0x000000018221EBF0-0x000000018221ED50
		[ExcludeFromDocs]
		public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType keyboardType, bool autocorrection, bool multiline, bool secure); // 0x000000018221ED50-0x000000018221EED0
		private static void GetSelection(out int start, out int length); // 0x000000018221EB30-0x000000018221EB80
		private static void SetSelection(int start, int length); // 0x000000018221EED0-0x000000018221EF10
		private static IntPtr TouchScreenKeyboard_InternalConstructorHelper_Injected(ref TouchScreenKeyboard_InternalConstructorHelperArguments arguments, ref ManagedSpanWrapper text, ref ManagedSpanWrapper textPlaceholder); // 0x000000018221EF10-0x000000018221EF70
		private static void get_text_Injected(IntPtr _unity_self, ); // 0x000000018221F730-0x000000018221F780
		private static void set_text_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value); // 0x000000018221FB00-0x000000018221FB50
		private static bool get_active_Injected(IntPtr _unity_self); // 0x000000018221F2F0-0x000000018221F330
		private static void set_active_Injected(IntPtr _unity_self, bool value); // 0x000000018221F870-0x000000018221F8C0
		private static Status get_status_Injected(IntPtr _unity_self); // 0x000000018221F690-0x000000018221F6D0
		private static void set_characterLimit_Injected(IntPtr _unity_self, int value); // 0x000000018221F920-0x000000018221F960
		private static bool get_canGetSelection_Injected(IntPtr _unity_self); // 0x000000018221F390-0x000000018221F3D0
		private static bool get_canSetSelection_Injected(IntPtr _unity_self); // 0x000000018221F430-0x000000018221F470
	}
}
