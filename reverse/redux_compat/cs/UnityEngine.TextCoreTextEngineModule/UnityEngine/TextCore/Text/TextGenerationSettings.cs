/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal class TextGenerationSettings : IEquatable<TextGenerationSettings> // TypeDefIndex: 12687
	{
		// Fields
		private RenderedText m_RenderedText; // 0x10
		private string m_CachedRenderedText; // 0x30
		public Rect screenRect; // 0x38
		public FontAsset fontAsset; // 0x48
		public FontStyles fontStyle; // 0x50
		public TextSettings textSettings; // 0x58
		public TextAlignment textAlignment; // 0x60
		public TextOverflowMode overflowMode; // 0x64
		public Color color; // 0x68
		public bool shouldConvertToLinearSpace; // 0x78
		public int fontSize; // 0x7C
		internal static readonly List<OTL_FeatureTag> fontFeatures; // 0x00
		public bool emojiFallbackSupport; // 0x80
		public bool richText; // 0x81
		public bool isRightToLeft; // 0x82
		public float extraPadding; // 0x84
		public bool parseControlCharacters; // 0x88
		public bool isPlaceholder; // 0x89
		public float characterSpacing; // 0x8C
		public float wordSpacing; // 0x90
		public float paragraphSpacing; // 0x94
		public TextWrappingMode textWrappingMode; // 0x98
		public TextFontWeight fontWeight; // 0x9C
		public bool isIMGUI; // 0xA0
		public float pixelsPerPoint; // 0xA4
	
		// Properties
		public RenderedText renderedText { get; set; } // 0x00000001807189F0-0x0000000180718A10 0x000000018233AF40-0x000000018233AF80
		public string text { get; set; } // 0x000000018233AD50-0x000000018233AF40 0x000000018233AF80-0x000000018233B090
	
		// Constructors
		public TextGenerationSettings(); // 0x000000018233ACF0-0x000000018233AD50
		static TextGenerationSettings(); // 0x000000018233AC00-0x000000018233ACF0
	
		// Methods
		public bool Equals(TextGenerationSettings other); // 0x00000001823392D0-0x0000000182339630
		public override bool Equals(object obj); // 0x0000000182339630-0x0000000182339730
		public override int GetHashCode(); // 0x0000000182339730-0x00000001823399B0
		public override string ToString(); // 0x00000001823399B0-0x000000018233AC00
	}
}
