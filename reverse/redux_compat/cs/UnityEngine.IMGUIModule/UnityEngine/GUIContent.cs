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
	[Serializable]
	[NativeHeader("Modules/IMGUI/GUIContent.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public class GUIContent // TypeDefIndex: 13924
	{
		// Fields
		[SerializeField]
		private string m_Text; // 0x10
		[SerializeField]
		private Texture m_Image; // 0x18
		[SerializeField]
		private string m_Tooltip; // 0x20
		[SerializeField]
		private string m_TextWithWhitespace; // 0x28
		[CompilerGenerated]
		private Action OnTextChanged; // 0x30
		[NoAutoStaticsCleanup]
		private static readonly GUIContent s_Text; // 0x00
		[NoAutoStaticsCleanup]
		private static readonly GUIContent s_Image; // 0x08
		[NoAutoStaticsCleanup]
		private static readonly GUIContent s_TextImage; // 0x10
		internal static readonly string k_ZeroWidthSpace; // 0x18
		[NoAutoStaticsCleanup]
		public static GUIContent none; // 0x20
	
		// Properties
		public string text { get; set; } // 0x0000000180377550-0x0000000180377560 0x000000018227B0C0-0x000000018227B120
		internal string textWithWhitespace { get; set; } // 0x000000018227AF30-0x000000018227AFA0 0x000000018227B040-0x000000018227B0C0
		public Texture image { set; } // 0x00000001802FAF70-0x00000001802FAF80
		public string tooltip { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
		// Events
		internal event Action OnTextChanged {
			add; // 0x000000018227AE90-0x000000018227AF30
			remove; // 0x000000018227AFA0-0x000000018227B040
		}
	
		// Constructors
		public GUIContent(); // 0x000000018227ADE0-0x000000018227AE60
		public GUIContent(string text); // 0x000000018227AE60-0x000000018227AE90
		public GUIContent(string text, string tooltip); // 0x000000018227ACB0-0x000000018227ACD0
		public GUIContent(string text, Texture image, string tooltip); // 0x000000018227ABB0-0x000000018227ACB0
		public GUIContent(GUIContent src); // 0x000000018227ACD0-0x000000018227ADE0
		static GUIContent(); // 0x000000018227A950-0x000000018227ABB0
	
		// Methods
		internal void SetTextWithoutNotify(string value); // 0x000000018227A810-0x000000018227A850
		internal static GUIContent Temp(string t); // 0x000000018227A850-0x000000018227A930
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static void ClearStaticCache(); // 0x000000018227A630-0x000000018227A810
		public override string ToString(); // 0x000000018227A930-0x000000018227A950
	}
}
