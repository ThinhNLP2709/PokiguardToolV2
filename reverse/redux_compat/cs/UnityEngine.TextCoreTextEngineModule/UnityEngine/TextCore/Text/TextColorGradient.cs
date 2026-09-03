/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[Serializable]
	[ExcludeFromObjectFactory]
	[ExcludeFromPreset]
	[HelpURL("UIE-color-gradient")]
	[NativeHeader("Modules/TextCoreTextEngine/TextColorGradient.h")]
	public class TextColorGradient : ScriptableObject // TypeDefIndex: 12669
	{
		// Fields
		public ColorGradientMode colorMode; // 0x18
		public Color topLeft; // 0x1C
		public Color topRight; // 0x2C
		public Color bottomLeft; // 0x3C
		public Color bottomRight; // 0x4C
		private const ColorGradientMode k_DefaultColorMode = ColorGradientMode.FourCornersGradient; // Metadata: 0x006A4902
		private static readonly Color k_DefaultColor; // 0x00
		private IntPtr m_NativeInstance; // 0x60
	
		// Properties
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal IntPtr nativeInstance { get; } // 0x00000001823362F0-0x0000000182336480 
	
		// Constructors
		public TextColorGradient(); // 0x0000000182336230-0x00000001823362F0
		public TextColorGradient(Color color); // 0x0000000182336160-0x00000001823361B0
		public TextColorGradient(Color color0, Color color1, Color color2, Color color3); // 0x00000001823361B0-0x0000000182336230
		static TextColorGradient(); // 0x0000000182336120-0x0000000182336160
	
		// Methods
		private void OnValidate(); // 0x0000000182335E10-0x0000000182335F80
		private void OnDisable(); // 0x0000000182335F80-0x0000000182336020
		internal void MarkNativeDirty(); // 0x0000000182335E10-0x0000000182335F80
		private static IntPtr CreateNative(Color32 tl, Color32 tr, Color32 bl, Color32 br, IntPtr managedObject); // 0x0000000182335D30-0x0000000182335DC0
		private static void DestroyNative(IntPtr nativeInstance, IntPtr managedObject); // 0x0000000182335DC0-0x0000000182335E10
		private static void UpdateNative(IntPtr instance, Color32 tl, Color32 tr, Color32 bl, Color32 br); // 0x0000000182336090-0x0000000182336120
		private static IntPtr CreateNative_Injected(in Color32 tl, in Color32 tr, in Color32 bl, in Color32 br, IntPtr managedObject); // 0x0000000182335CC0-0x0000000182335D30
		private static void UpdateNative_Injected(IntPtr instance, in Color32 tl, in Color32 tr, in Color32 bl, in Color32 br); // 0x0000000182336020-0x0000000182336090
	}
}
