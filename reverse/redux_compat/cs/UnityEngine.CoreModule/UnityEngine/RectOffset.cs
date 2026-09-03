/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[NativeHeader("Modules/IMGUI/GUIStyle.h")]
	[UsedByNativeCode]
	public class RectOffset : IFormattable // TypeDefIndex: 7530
	{
		// Fields
		[NonSerialized]
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal IntPtr m_Ptr; // 0x10
		private readonly object m_SourceStyle; // 0x18
	
		// Properties
		[NativeProperty("left", false, TargetType.Field)]
		public int left { get; set; } // 0x00000001821BC710-0x00000001821BC770 0x00000001821BCA30-0x00000001821BCA90
		[NativeProperty("right", false, TargetType.Field)]
		public int right { get; set; } // 0x00000001821BC7B0-0x00000001821BC810 0x00000001821BCAD0-0x00000001821BCB30
		[NativeProperty("top", false, TargetType.Field)]
		public int top { get; set; } // 0x00000001821BC850-0x00000001821BC8B0 0x00000001821BCB70-0x00000001821BCBD0
		[NativeProperty("bottom", false, TargetType.Field)]
		public int bottom { get; set; } // 0x00000001821BC5D0-0x00000001821BC630 0x00000001821BC990-0x00000001821BC9F0
		public int horizontal { get; } // 0x00000001821BC670-0x00000001821BC6D0 
		public int vertical { get; } // 0x00000001821BC8F0-0x00000001821BC950 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 7531
		{
			// Methods
			public static IntPtr ConvertToNative(RectOffset rectOffset); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public RectOffset(); // 0x00000001821BC550-0x00000001821BC590
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal RectOffset(object sourceStyle, IntPtr source); // 0x00000001821BC3A0-0x00000001821BC3F0
		public RectOffset(int left, int right, int top, int bottom); // 0x00000001821BC3F0-0x00000001821BC550
	
		// Methods
		~RectOffset(); // 0x00000001821BBE50-0x00000001821BBF00
		public override string ToString(); // 0x00000001821BC050-0x00000001821BC060
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821BC060-0x00000001821BC3A0
		private void Destroy(); // 0x00000001821BBE00-0x00000001821BBE50
		[NativeMethod(IsThreadSafe = true)]
		private static IntPtr InternalCreate(); // 0x00000001821BBF00-0x00000001821BBF30
		[NativeMethod(IsThreadSafe = true)]
		private static void InternalDestroy(IntPtr ptr); // 0x00000001821BBF30-0x00000001821BBF70
		public Rect Remove(Rect rect); // 0x00000001821BBFD0-0x00000001821BC050
		private static int get_left_Injected(IntPtr _unity_self); // 0x00000001821BC6D0-0x00000001821BC710
		private static void set_left_Injected(IntPtr _unity_self, int value); // 0x00000001821BC9F0-0x00000001821BCA30
		private static int get_right_Injected(IntPtr _unity_self); // 0x00000001821BC770-0x00000001821BC7B0
		private static void set_right_Injected(IntPtr _unity_self, int value); // 0x00000001821BCA90-0x00000001821BCAD0
		private static int get_top_Injected(IntPtr _unity_self); // 0x00000001821BC810-0x00000001821BC850
		private static void set_top_Injected(IntPtr _unity_self, int value); // 0x00000001821BCB30-0x00000001821BCB70
		private static int get_bottom_Injected(IntPtr _unity_self); // 0x00000001821BC590-0x00000001821BC5D0
		private static void set_bottom_Injected(IntPtr _unity_self, int value); // 0x00000001821BC950-0x00000001821BC990
		private static int get_horizontal_Injected(IntPtr _unity_self); // 0x00000001821BC630-0x00000001821BC670
		private static int get_vertical_Injected(IntPtr _unity_self); // 0x00000001821BC8B0-0x00000001821BC8F0
		private static void Remove_Injected(IntPtr _unity_self, in Rect rect, ); // 0x00000001821BBF70-0x00000001821BBFD0
	}
}
