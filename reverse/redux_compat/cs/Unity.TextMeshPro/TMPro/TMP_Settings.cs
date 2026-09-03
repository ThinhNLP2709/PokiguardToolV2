/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TextCore;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	[ExcludeFromPreset]
	[HelpURL("https://docs.unity3d.com/Packages/com.unity.ugui@2.0/manual/TextMeshPro/Settings.html")]
	public class TMP_Settings : ScriptableObject // TypeDefIndex: 11871
	{
		// Fields
		private static TMP_Settings s_Instance; // 0x00
		[SerializeField]
		internal string assetVersion; // 0x18
		internal const string s_CurrentAssetVersion = "2"; // Metadata: 0x006A2239
		[FormerlySerializedAs("m_enableWordWrapping")]
		[SerializeField]
		private TextWrappingModes m_TextWrappingMode; // 0x20
		[SerializeField]
		private bool m_enableKerning; // 0x24
		[SerializeField]
		private List<OTL_FeatureTag> m_ActiveFontFeatures; // 0x28
		[SerializeField]
		private bool m_enableExtraPadding; // 0x30
		[SerializeField]
		private bool m_enableTintAllSprites; // 0x31
		[SerializeField]
		private bool m_enableParseEscapeCharacters; // 0x32
		[SerializeField]
		private bool m_EnableRaycastTarget; // 0x33
		[SerializeField]
		private bool m_GetFontFeaturesAtRuntime; // 0x34
		[SerializeField]
		private int m_missingGlyphCharacter; // 0x38
		[SerializeField]
		private bool m_ClearDynamicDataOnBuild; // 0x3C
		[SerializeField]
		private bool m_warningsDisabled; // 0x3D
		[SerializeField]
		private TMP_FontAsset m_defaultFontAsset; // 0x40
		[SerializeField]
		private string m_defaultFontAssetPath; // 0x48
		[SerializeField]
		private float m_defaultFontSize; // 0x50
		[SerializeField]
		private float m_defaultAutoSizeMinRatio; // 0x54
		[SerializeField]
		private float m_defaultAutoSizeMaxRatio; // 0x58
		[SerializeField]
		private Vector2 m_defaultTextMeshProTextContainerSize; // 0x5C
		[SerializeField]
		private Vector2 m_defaultTextMeshProUITextContainerSize; // 0x64
		[SerializeField]
		private bool m_autoSizeTextContainer; // 0x6C
		[SerializeField]
		private bool m_IsTextObjectScaleStatic; // 0x6D
		[SerializeField]
		private List<TMP_FontAsset> m_fallbackFontAssets; // 0x70
		[SerializeField]
		private bool m_matchMaterialPreset; // 0x78
		[SerializeField]
		private bool m_HideSubTextObjects; // 0x79
		[SerializeField]
		private TMP_SpriteAsset m_defaultSpriteAsset; // 0x80
		[SerializeField]
		private string m_defaultSpriteAssetPath; // 0x88
		[SerializeField]
		private bool m_enableEmojiSupport; // 0x90
		[SerializeField]
		private uint m_MissingCharacterSpriteUnicode; // 0x94
		[SerializeField]
		private List<TMP_Asset> m_EmojiFallbackTextAssets; // 0x98
		[SerializeField]
		private string m_defaultColorGradientPresetsPath; // 0xA0
		[SerializeField]
		private TMP_StyleSheet m_defaultStyleSheet; // 0xA8
		[SerializeField]
		private string m_StyleSheetsResourcePath; // 0xB0
		[SerializeField]
		private TextAsset m_leadingCharacters; // 0xB8
		[SerializeField]
		private TextAsset m_followingCharacters; // 0xC0
		private LineBreakingTable m_linebreakingRules; // 0xC8
		[SerializeField]
		private bool m_UseModernHangulLineBreakingRules; // 0xD0
	
		// Properties
		public static string version { get; } // 0x00000001820C9E50-0x00000001820C9E80 
		public static TextWrappingModes textWrappingMode { get; } // 0x00000001820C9E00-0x00000001820C9E20 
		[Obsolete("The \"enableKerning\" property has been deprecated. Use the \"fontFeatures\" property to control what features are enabled by default on newly created text components.")]
		public static bool enableKerning { get; } // 0x00000001820C9760-0x00000001820C97E0 
		public static List<OTL_FeatureTag> fontFeatures { get; } // 0x00000001820C9890-0x00000001820C98B0 
		public static bool enableExtraPadding { get; } // 0x00000001820C9740-0x00000001820C9760 
		public static bool enableTintAllSprites { get; } // 0x00000001820C9820-0x00000001820C9840 
		public static bool enableParseEscapeCharacters { get; } // 0x00000001820C97E0-0x00000001820C9800 
		public static bool enableRaycastTarget { get; } // 0x00000001820C9800-0x00000001820C9820 
		public static bool getFontFeaturesAtRuntime { get; } // 0x00000001820C98B0-0x00000001820C98D0 
		public static int missingGlyphCharacter { get; set; } // 0x00000001820C9DB0-0x00000001820C9DD0 0x00000001820CA050-0x00000001820CA080
		public static bool clearDynamicDataOnBuild { get; } // 0x00000001820C9500-0x00000001820C9520 
		public static bool warningsDisabled { get; } // 0x00000001820C9E80-0x00000001820C9EA0 
		public static TMP_FontAsset defaultFontAsset { get; set; } // 0x00000001820C9570-0x00000001820C9590 0x00000001820C9EA0-0x00000001820C9ED0
		public static string defaultFontAssetPath { get; } // 0x00000001820C9550-0x00000001820C9570 
		public static float defaultFontSize { get; } // 0x00000001820C9590-0x00000001820C95B0 
		public static float defaultTextAutoSizingMinRatio { get; } // 0x00000001820C9660-0x00000001820C9680 
		public static float defaultTextAutoSizingMaxRatio { get; } // 0x00000001820C9640-0x00000001820C9660 
		public static Vector2 defaultTextMeshProTextContainerSize { get; } // 0x00000001820C9680-0x00000001820C96B0 
		public static Vector2 defaultTextMeshProUITextContainerSize { get; } // 0x00000001820C96B0-0x00000001820C96E0 
		public static bool autoSizeTextContainer { get; } // 0x00000001820C94E0-0x00000001820C9500 
		public static bool isTextObjectScaleStatic { get; set; } // 0x00000001820C9B70-0x00000001820C9B90 0x00000001820C9FF0-0x00000001820CA020
		public static List<TMP_FontAsset> fallbackFontAssets { get; set; } // 0x00000001820C9840-0x00000001820C9860 0x00000001820C9FC0-0x00000001820C9FF0
		public static bool matchMaterialPreset { get; } // 0x00000001820C9D60-0x00000001820C9D80 
		public static bool hideSubTextObjects { get; } // 0x00000001820C98D0-0x00000001820C98F0 
		public static TMP_SpriteAsset defaultSpriteAsset { get; set; } // 0x00000001820C95E0-0x00000001820C9610 0x00000001820C9ED0-0x00000001820C9F10
		public static string defaultSpriteAssetPath { get; } // 0x00000001820C95B0-0x00000001820C95E0 
		public static bool enableEmojiSupport { get; set; } // 0x00000001820C9710-0x00000001820C9740 0x00000001820C9F90-0x00000001820C9FC0
		public static uint missingCharacterSpriteUnicode { get; set; } // 0x00000001820C9D80-0x00000001820C9DB0 0x00000001820CA020-0x00000001820CA050
		public static List<TMP_Asset> emojiFallbackTextAssets { get; set; } // 0x00000001820C96E0-0x00000001820C9710 0x00000001820C9F50-0x00000001820C9F90
		public static string defaultColorGradientPresetsPath { get; } // 0x00000001820C9520-0x00000001820C9550 
		public static TMP_StyleSheet defaultStyleSheet { get; set; } // 0x00000001820C9610-0x00000001820C9640 0x00000001820C9F10-0x00000001820C9F50
		public static string styleSheetsResourcePath { get; } // 0x00000001820C9DD0-0x00000001820C9E00 
		public static TextAsset leadingCharacters { get; } // 0x00000001820C9B90-0x00000001820C9BC0 
		public static TextAsset followingCharacters { get; } // 0x00000001820C9860-0x00000001820C9890 
		public static LineBreakingTable linebreakingRules { get; } // 0x00000001820C9BC0-0x00000001820C9D60 
		public static bool useModernHangulLineBreakingRules { get; set; } // 0x00000001820C9E20-0x00000001820C9E50 0x00000001820CA080-0x00000001820CA0B0
		public static TMP_Settings instance { get; } // 0x00000001820C98F0-0x00000001820C9B00 
		internal static bool isTMPSettingsNull { get; } // 0x00000001820C9B00-0x00000001820C9B70 
	
		// Nested types
		public class LineBreakingTable // TypeDefIndex: 11872
		{
			// Fields
			public HashSet<uint> leadingCharacters; // 0x10
			public HashSet<uint> followingCharacters; // 0x18
	
			// Constructors
			public LineBreakingTable(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		// Constructors
		public TMP_Settings(); // 0x00000001820C93F0-0x00000001820C94E0
	
		// Methods
		internal void SetAssetVersion(); // 0x00000001820C93A0-0x00000001820C93F0
		public static TMP_Settings LoadDefaultSettings(); // 0x00000001820C9140-0x00000001820C9230
		public static TMP_Settings GetSettings(); // 0x00000001820C8FD0-0x00000001820C9040
		public static TMP_FontAsset GetFontAsset(); // 0x00000001820C8F50-0x00000001820C8FD0
		public static TMP_SpriteAsset GetSpriteAsset(); // 0x00000001820C9040-0x00000001820C90C0
		public static TMP_StyleSheet GetStyleSheet(); // 0x00000001820C90C0-0x00000001820C9140
		public static void LoadLinebreakingRules(); // 0x00000001820C9230-0x00000001820C93A0
		private static HashSet<uint> GetCharacters(TextAsset file); // 0x00000001820C8E80-0x00000001820C8F50
	}
}
