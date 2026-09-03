/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 62: UnityEngine.TextRenderingModule.dll - Assembly: UnityEngine.TextRenderingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15763-15782

namespace UnityEngine
{
	[NativeClass("TextRenderingPrivate::TextMesh", PersistentTypeId = 102)]
	[NativeHeader("Modules/TextRendering/Public/TextMesh.h")]
	[RequireComponent(typeof(Transform), typeof(MeshRenderer))]
	public sealed class TextMesh : Component // TypeDefIndex: 15776
	{
		// Properties
		public string text { set; } // 0x0000000182352D50-0x0000000182352EC0
		public Font font { get; set; } // 0x0000000182352700-0x0000000182352790 0x0000000182352B10-0x0000000182352B90
		public int fontSize { set; } // 0x00000001823529C0-0x0000000182352A20
		public FontStyle fontStyle { set; } // 0x0000000182352A60-0x0000000182352AC0
		public float offsetZ { set; } // 0x0000000182352BE0-0x0000000182352C50
		public TextAlignment alignment { set; } // 0x00000001823527D0-0x0000000182352830
		public TextAnchor anchor { set; } // 0x0000000182352870-0x00000001823528D0
		public bool richText { set; } // 0x0000000182352CA0-0x0000000182352D00
		public Color color { get; set; } // 0x0000000182352650-0x00000001823526C0 0x0000000182352920-0x0000000182352980
	
		// Constructors
		public TextMesh(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private static void set_text_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value); // 0x0000000182352D00-0x0000000182352D50
		private static IntPtr get_font_Injected(IntPtr _unity_self); // 0x00000001823526C0-0x0000000182352700
		private static void set_font_Injected(IntPtr _unity_self, IntPtr value); // 0x0000000182352AC0-0x0000000182352B10
		private static void set_fontSize_Injected(IntPtr _unity_self, int value); // 0x0000000182352980-0x00000001823529C0
		private static void set_fontStyle_Injected(IntPtr _unity_self, FontStyle value); // 0x0000000182352A20-0x0000000182352A60
		private static void set_offsetZ_Injected(IntPtr _unity_self, float value); // 0x0000000182352B90-0x0000000182352BE0
		private static void set_alignment_Injected(IntPtr _unity_self, TextAlignment value); // 0x0000000182352790-0x00000001823527D0
		private static void set_anchor_Injected(IntPtr _unity_self, TextAnchor value); // 0x0000000182352830-0x0000000182352870
		private static void set_richText_Injected(IntPtr _unity_self, bool value); // 0x0000000182352C50-0x0000000182352CA0
		private static void get_color_Injected(IntPtr _unity_self, ); // 0x0000000182352600-0x0000000182352650
		private static void set_color_Injected(IntPtr _unity_self, in Color value); // 0x00000001823528D0-0x0000000182352920
	}
}
