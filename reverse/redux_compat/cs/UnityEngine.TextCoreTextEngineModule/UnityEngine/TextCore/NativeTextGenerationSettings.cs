/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.TextCore.Text;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore
{
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextGenerationSettings.h")]
	[UsedByNativeCode("TextGenerationSettings")]
	[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal struct NativeTextGenerationSettings // TypeDefIndex: 12627
	{
		// Fields
		public IntPtr fontAsset; // 0x00
		public IntPtr textSettings; // 0x08
		public IntPtr textBufferPtr; // 0x10
		public int textBufferLength; // 0x18
		public int screenWidth; // 0x1C
		public int screenHeight; // 0x20
		public bool wordWrapEnabled; // 0x24
		public TextOverflow overflow; // 0x28
		public LanguageDirection languageDirection; // 0x2C
		public int vertexPadding; // 0x30
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
		internal HorizontalAlignment horizontalAlignment; // 0x34
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
		internal VerticalAlignment verticalAlignment; // 0x38
		public PreProcessFlags preProcessFlags; // 0x3C
		public int fontSize; // 0x40
		public bool bestFit; // 0x44
		public int maxFontSize; // 0x48
		public int minFontSize; // 0x4C
		public FontStyles fontStyle; // 0x50
		public TextFontWeight fontWeight; // 0x54
		public int characterSpacing; // 0x58
		public int wordSpacing; // 0x5C
		public int paragraphSpacing; // 0x60
		public Color32 color; // 0x64
		public bool disableAdvancedFontFeatures; // 0x68
		public bool richTextEnabled; // 0x69
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
		internal HoveredTag hoveredTag; // 0x6C
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
		internal int pixelsPerPointFixed64; // 0x70
	
		// Properties
		public static NativeTextGenerationSettings Default { get; } // 0x0000000182307FD0-0x0000000182308070 
	
		// Methods
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })]
		internal void SetTextBuffer(NativeArray<char> buffer, int length); // 0x0000000182307660-0x00000001823076B0
		public override string ToString(); // 0x00000001823076B0-0x0000000182307FD0
		public override int GetHashCode(); // 0x0000000182307500-0x0000000182307660
	}
}
