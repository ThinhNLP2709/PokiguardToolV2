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
using UnityEngine.Scripting;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	[NativeHeader("Modules/IMGUI/Event.bindings.h")]
	[StaticAccessor("GUIEvent", StaticAccessorType.DoubleColon)]
	public sealed class Event // TypeDefIndex: 13915
	{
		// Fields
		[NonSerialized]
		internal IntPtr m_Ptr; // 0x10
		[NoAutoStaticsCleanup]
		private static Event s_Current; // 0x00
		[NoAutoStaticsCleanup]
		private static Event s_MasterEvent; // 0x08
	
		// Properties
		[NativeProperty("type", false, TargetType.Field)]
		public EventType rawType { get; } // 0x00000001822794F0-0x0000000182279550 
		[NativeProperty("mousePosition", false, TargetType.Field)]
		public Vector2 mousePosition { get; set; } // 0x0000000182279340-0x00000001822793B0 0x0000000182279C40-0x0000000182279CA0
		[NativeProperty("delta", false, TargetType.Field)]
		public Vector2 delta { get; set; } // 0x0000000182278CA0-0x0000000182278D10 0x0000000182279A50-0x0000000182279AB0
		[NativeProperty("pointerType", false, TargetType.Field)]
		public PointerType pointerType { get; } // 0x0000000182279450-0x00000001822794B0 
		[NativeProperty("button", false, TargetType.Field)]
		public int button { get; set; } // 0x0000000182278810-0x0000000182278870 0x0000000182279690-0x00000001822796F0
		[NativeProperty("modifiers", false, TargetType.Field)]
		public EventModifiers modifiers { get; set; } // 0x0000000182279290-0x00000001822792F0 0x0000000182279B90-0x0000000182279BF0
		[NativeProperty("clickCount", false, TargetType.Field)]
		public int clickCount { get; set; } // 0x00000001822789B0-0x0000000182278A10 0x0000000182279730-0x0000000182279790
		[NativeProperty("character", false, TargetType.Field)]
		public char character { get; } // 0x0000000182278910-0x0000000182278970 
		[NativeProperty("keycode", false, TargetType.Field)]
		private KeyCode Internal_keyCode { get; } // 0x0000000182278710-0x0000000182278770 
		public KeyCode keyCode { get; } // 0x0000000182279000-0x0000000182279250 
		[NativeProperty("displayIndex", false, TargetType.Field)]
		public int displayIndex { get; set; } // 0x0000000182278D50-0x0000000182278DB0 0x0000000182279AF0-0x0000000182279B50
		public EventType type { [FreeFunction("GUIEvent::GetType", HasExplicitThis = true)] get; [FreeFunction("GUIEvent::SetType", HasExplicitThis = true)] set; } // 0x00000001822795F0-0x0000000182279650 0x0000000182279CE0-0x0000000182279D40
		public string commandName { [FreeFunction("GUIEvent::GetCommandName", HasExplicitThis = true)] get; [FreeFunction("GUIEvent::SetCommandName", HasExplicitThis = true)] set; } // 0x0000000182278A60-0x0000000182278B50 0x00000001822797E0-0x0000000182279950
		public bool shift { get; } // 0x0000000182279550-0x00000001822795B0 
		public bool control { get; } // 0x0000000182278BB0-0x0000000182278C10 
		public bool alt { get; } // 0x0000000182278770-0x00000001822787D0 
		public bool command { get; } // 0x0000000182278B50-0x0000000182278BB0 
		public bool capsLock { get; } // 0x0000000182278870-0x00000001822788D0 
		public bool numeric { get; } // 0x00000001822793B0-0x0000000182279410 
		public bool functionKey { get; } // 0x0000000182278DB0-0x0000000182278E10 
		public static Event current { get; set; } // 0x0000000182278C10-0x0000000182278C50 0x0000000182279950-0x0000000182279A00
		public bool isKey { get; } // 0x0000000182278EC0-0x0000000182278F30 
		public bool isMouse { get; } // 0x0000000182278F30-0x0000000182278FA0 
		public bool isScrollWheel { get; } // 0x0000000182278FA0-0x0000000182279000 
		internal bool isDirectManipulationDevice { [VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })] get; } // 0x0000000182278E10-0x0000000182278EC0 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 13916
		{
			// Methods
			public static IntPtr ConvertToNative(Event e); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public Event(); // 0x0000000182278640-0x0000000182278680
		public Event(int displayIndex); // 0x0000000182278680-0x00000001822786D0
	
		// Methods
		[NativeMethod("Use")]
		private void Internal_Use(); // 0x0000000182277C10-0x0000000182277C70
		[FreeFunction("GUIEvent::Internal_Create", IsThreadSafe = true)]
		private static IntPtr Internal_Create(int displayIndex); // 0x00000001822779A0-0x00000001822779E0
		[FreeFunction("GUIEvent::Internal_Destroy", IsThreadSafe = true)]
		private static void Internal_Destroy(IntPtr ptr); // 0x00000001822779E0-0x0000000182277A20
		[FreeFunction("GUIEvent::GetTypeForControl", HasExplicitThis = true)]
		public EventType GetTypeForControl(int controlID); // 0x0000000182277940-0x00000001822779A0
		[FreeFunction("GUIEvent::CopyFromPtr", IsThreadSafe = true, HasExplicitThis = true)]
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void CopyFromPtr(IntPtr ptr); // 0x00000001822771A0-0x0000000182277200
		public static bool PopEvent([NotNull] Event outEvent); // 0x0000000182277CB0-0x0000000182277D40
		[VisibleToOtherModules(new string[1] {"UnityEngine.InputForUIModule" })]
		internal static void GetEventAtIndex(int index, [NotNull] Event outEvent); // 0x00000001822776A0-0x0000000182277740
		public static int GetEventCount(); // 0x0000000182277740-0x0000000182277770
		private static void Internal_SetNativeEvent(IntPtr ptr); // 0x0000000182277B90-0x0000000182277BD0
		[RequiredByNativeCode]
		internal static void Internal_MakeMasterEventCurrent(int displayIndex); // 0x0000000182277A20-0x0000000182277B90
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.InputForUIModule" })]
		internal static int GetDoubleClickTime(); // 0x0000000182277630-0x0000000182277660
		~Event(); // 0x0000000182277590-0x0000000182277630
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void CopyFrom(Event e); // 0x0000000182277200-0x0000000182277270
		public override int GetHashCode(); // 0x0000000182277770-0x0000000182277900
		public override bool Equals(object obj); // 0x0000000182277270-0x0000000182277590
		public override string ToString(); // 0x0000000182277D40-0x00000001822784B0
		public void Use(); // 0x00000001822784B0-0x0000000182278640
		private static EventType get_rawType_Injected(IntPtr _unity_self); // 0x00000001822794B0-0x00000001822794F0
		private static void get_mousePosition_Injected(IntPtr _unity_self, ); // 0x00000001822792F0-0x0000000182279340
		private static void set_mousePosition_Injected(IntPtr _unity_self, in Vector2 value); // 0x0000000182279BF0-0x0000000182279C40
		private static void get_delta_Injected(IntPtr _unity_self, ); // 0x0000000182278C50-0x0000000182278CA0
		private static void set_delta_Injected(IntPtr _unity_self, in Vector2 value); // 0x0000000182279A00-0x0000000182279A50
		private static PointerType get_pointerType_Injected(IntPtr _unity_self); // 0x0000000182279410-0x0000000182279450
		private static int get_button_Injected(IntPtr _unity_self); // 0x00000001822787D0-0x0000000182278810
		private static void set_button_Injected(IntPtr _unity_self, int value); // 0x0000000182279650-0x0000000182279690
		private static EventModifiers get_modifiers_Injected(IntPtr _unity_self); // 0x0000000182279250-0x0000000182279290
		private static void set_modifiers_Injected(IntPtr _unity_self, EventModifiers value); // 0x0000000182279B50-0x0000000182279B90
		private static int get_clickCount_Injected(IntPtr _unity_self); // 0x0000000182278970-0x00000001822789B0
		private static void set_clickCount_Injected(IntPtr _unity_self, int value); // 0x00000001822796F0-0x0000000182279730
		private static char get_character_Injected(IntPtr _unity_self); // 0x00000001822788D0-0x0000000182278910
		private static KeyCode get_Internal_keyCode_Injected(IntPtr _unity_self); // 0x00000001822786D0-0x0000000182278710
		private static int get_displayIndex_Injected(IntPtr _unity_self); // 0x0000000182278D10-0x0000000182278D50
		private static void set_displayIndex_Injected(IntPtr _unity_self, int value); // 0x0000000182279AB0-0x0000000182279AF0
		private static EventType get_type_Injected(IntPtr _unity_self); // 0x00000001822795B0-0x00000001822795F0
		private static void set_type_Injected(IntPtr _unity_self, EventType value); // 0x0000000182279CA0-0x0000000182279CE0
		private static void get_commandName_Injected(IntPtr _unity_self, ); // 0x0000000182278A10-0x0000000182278A60
		private static void set_commandName_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value); // 0x0000000182279790-0x00000001822797E0
		private static void Internal_Use_Injected(IntPtr _unity_self); // 0x0000000182277BD0-0x0000000182277C10
		private static EventType GetTypeForControl_Injected(IntPtr _unity_self, int controlID); // 0x0000000182277900-0x0000000182277940
		private static void CopyFromPtr_Injected(IntPtr _unity_self, IntPtr ptr); // 0x0000000182277150-0x00000001822771A0
		private static bool PopEvent_Injected(IntPtr outEvent); // 0x0000000182277C70-0x0000000182277CB0
		private static void GetEventAtIndex_Injected(int index, IntPtr outEvent); // 0x0000000182277660-0x00000001822776A0
	}
}
