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
using UnityEngine.Serialization;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[Serializable]
	[ExcludeFromObjectFactory]
	[ExcludeFromPreset]
	[NativeHeader("Modules/TextCoreTextEngine/Native/TextSettings.h")]
	public class TextSettings : ScriptableObject // TypeDefIndex: 12670
	{
		// Fields
		[SerializeField]
		protected string m_Version; // 0x18
		[SerializeField]
		internal bool m_ShowObsoleteProperties; // 0x20
		[FormerlySerializedAs("m_defaultFontAsset")]
		[SerializeField]
		protected FontAsset m_DefaultFontAsset; // 0x28
		[FormerlySerializedAs("m_defaultFontAssetPath")]
		[SerializeField]
		protected string m_DefaultFontAssetPath; // 0x30
		[FormerlySerializedAs("m_fallbackFontAssets")]
		[SerializeField]
		protected List<FontAsset> m_FallbackFontAssets; // 0x38
		[FormerlySerializedAs("m_matchMaterialPreset")]
		[SerializeField]
		protected bool m_MatchMaterialPreset; // 0x40
		[FormerlySerializedAs("m_missingGlyphCharacter")]
		[SerializeField]
		protected int m_MissingCharacterUnicode; // 0x44
		private List<FontAsset> m_FallbackOSFontAssets; // 0x48
		private bool m_FallbackOSFontAssetsInitialized; // 0x50
		private static List<FontAsset> s_GlobalOSFallbackFontAssets; // 0x00
		private static int s_GlobalOSFallbackVersion; // 0x08
		private static FontAsset s_RuntimeDefault; // 0x10
		[SerializeField]
		protected bool m_ClearDynamicDataOnBuild; // 0x51
		[SerializeField]
		private bool m_EnableEmojiSupport; // 0x52
		[SerializeField]
		private List<TextAsset> m_EmojiFallbackTextAssets; // 0x58
		[FormerlySerializedAs("m_defaultSpriteAsset")]
		[SerializeField]
		protected SpriteAsset m_DefaultSpriteAsset; // 0x60
		[FormerlySerializedAs("m_defaultSpriteAssetPath")]
		[SerializeField]
		protected string m_DefaultSpriteAssetPath; // 0x68
		[SerializeField]
		protected List<SpriteAsset> m_FallbackSpriteAssets; // 0x70
		[CompilerGenerated]
		private static SpriteAsset _s_GlobalSpriteAsset_k__BackingField; // 0x18
		[SerializeField]
		protected uint m_MissingSpriteCharacterUnicode; // 0x78
		[FormerlySerializedAs("m_defaultStyleSheet")]
		[SerializeField]
		protected TextStyleSheet m_DefaultStyleSheet; // 0x80
		[FormerlySerializedAs("m_defaultColorGradientPresetsPath")]
		[SerializeField]
		protected string m_DefaultColorGradientPresetsPath; // 0x88
		[SerializeField]
		protected UnicodeLineBreakingRules m_UnicodeLineBreakingRules; // 0x90
		[FormerlySerializedAs("m_warningsDisabled")]
		[SerializeField]
		protected bool m_DisplayWarnings; // 0x98
		internal Dictionary<int, FontAsset> m_FontLookup; // 0xA0
		internal List<FontReferenceMap> m_FontReferences; // 0xA8
		private const string k_LegacyRuntimeFontName = "LegacyRuntime"; // Metadata: 0x006A4904
		private IntPtr m_NativeTextSettings; // 0xB0
		private bool m_IsNativeTextSettingsDirty; // 0xB8
		private int m_GlobalOSFallbackVersionUploaded; // 0xBC
		private string m_StyleSheetsResourcePath; // 0xC0
	
		// Properties
		public string version { get; internal set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public string defaultFontAssetPath { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public List<FontAsset> fallbackFontAssets { get; set; } // 0x00000001803272A0-0x00000001803272B0 0x000000018234AD80-0x000000018234ADB0
		internal List<FontAsset> fallbackOSFontAssets { [VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })] get; } // 0x000000018234AB00-0x000000018234AC60 
		internal bool isFallbackOSFontAssetsInitialized { [VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })] get; } // 0x0000000180377920-0x0000000180377930 
		public bool clearDynamicDataOnBuild { get; set; } // 0x00000001802F4040-0x00000001802F4050 0x00000001802F4060-0x00000001802F4070
		public SpriteAsset defaultSpriteAsset { get; set; } // 0x0000000180333260-0x0000000180333490 0x00000001803780F0-0x0000000180378100
		public string defaultSpriteAssetPath { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		internal static SpriteAsset s_GlobalSpriteAsset { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018234AD10-0x000000018234AD50 0x000000018234ADB0-0x000000018234AE10
		public List<TextAsset> emojiFallbackTextAssets { get; set; } // 0x00000001802F4000-0x00000001802F4010 0x000000018234AD50-0x000000018234AD80
		public TextStyleSheet defaultStyleSheet { get; set; } // 0x000000018033D4A0-0x000000018033D4B0 0x000000018033EA30-0x000000018033EA40
		public string defaultColorGradientPresetsPath { get; set; } // 0x000000018038B8A0-0x000000018038B8B0 0x0000000180664140-0x0000000180664160
		public bool displayWarnings { get; set; } // 0x0000000180665210-0x0000000180665220 0x0000000180BE5F30-0x0000000180BE5F40
		internal virtual bool persistsFontAssetCaches { get; } // 0x00000001802E7840-0x00000001802E7850 
		internal IntPtr nativeTextSettings { [VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEngine.IMGUIModule" })] get; } // 0x000000018234ACF0-0x000000018234AD10 
		[Obsolete("The Fallback Sprite Assets list is now obsolete. Use the emojiFallbackTextAssets instead.", true)]
		public List<SpriteAsset> fallbackSpriteAssets { get; set; } // 0x000000018033D4D0-0x000000018033D4E0 0x0000000180434A10-0x0000000180434A20
		[Obsolete("styleSheetsResourcePath is no longer used and will be removed in a future version.", false)]
		public string styleSheetsResourcePath { get; set; } // 0x00000001806CCB70-0x00000001806CCB80 0x00000001806CCDA0-0x00000001806CCDC0
		[Obsolete("defaultFontAsset is obsolete and will be removed in a future version.", false)]
		public FontAsset defaultFontAsset { get; set; } // 0x000000018033D240-0x000000018033D250 0x000000018033E840-0x000000018033E850
		[Obsolete("matchMaterialPreset is obsolete and will be removed in a future version.", false)]
		public bool matchMaterialPreset { get; set; } // 0x00000001803B1170-0x00000001803B1180 0x000000018042B340-0x000000018042B350
		[Obsolete("missingCharacterUnicode is obsolete and will be removed in a future version.", false)]
		public int missingCharacterUnicode { get; set; } // 0x000000018033D780-0x000000018033D790 0x000000018033ED00-0x000000018033ED10
		[Obsolete("enableEmojiSupport is obsolete and will be removed in a future version. It is now support by default with the Advanced Text Generator (ATG).", false)]
		public bool enableEmojiSupport { get; set; } // 0x00000001818986C0-0x00000001818986D0 0x0000000181C64010-0x0000000181C64020
		[Obsolete("missingSpriteCharacterUnicode is obsolete and will be removed in a future version.", false)]
		public uint missingSpriteCharacterUnicode { get; set; } // 0x000000018169BB50-0x000000018169BB60 0x00000001805936B0-0x00000001805936C0
		[Obsolete("lineBreakingRules is obsolete and will be removed in a future version. It is now support by default with the Advanced Text Generator (ATG).", false)]
		public UnicodeLineBreakingRules lineBreakingRules { get; set; } // 0x000000018234AC60-0x000000018234ACF0 0x0000000180664160-0x0000000180664180
	
		// Nested types
		[Serializable]
		internal struct FontReferenceMap // TypeDefIndex: 12671
		{
			// Fields
			public Font font; // 0x00
			public FontAsset fontAsset; // 0x08
	
			// Constructors
			public FontReferenceMap(Font font, FontAsset fontAsset); // 0x0000000180CC3FE0-0x0000000180CC4020
		}
	
		[CompilerGenerated]
		private struct __c__DisplayClass87_0 // TypeDefIndex: 12672
		{
			// Fields
			public List<IntPtr> globalFontAssetFallbacks; // 0x00
		}
	
		// Constructors
		public TextSettings(); // 0x000000018234A9B0-0x000000018234AB00
	
		// Methods
		internal static void RegisterGlobalOSFallback(FontAsset fontAsset); // 0x000000018234A300-0x000000018234A460
		internal static void SetGlobalOSFallbackStore(List<FontAsset> store); // 0x000000018234A460-0x000000018234A4D0
		private FontAsset GetDefaultFont(); // 0x0000000182349300-0x00000001823493F0
		internal virtual List<FontAsset> GetFallbackFontAssets(bool isRaster, int textPixelSize = -1 /* Metadata: 0x006A4903 */); // 0x00000001803272A0-0x00000001803272B0
		private void OnEnable(); // 0x000000018234A170-0x000000018234A300
		private void OnDisable(); // 0x0000000182348F30-0x0000000182348FA0
		private void OnDestroy(); // 0x0000000182348F30-0x0000000182348FA0
		private void DestroyNativeTextSettings(); // 0x0000000182348F30-0x0000000182348FA0
		protected void InitializeFontReferenceLookup(); // 0x0000000182349EB0-0x000000018234A110
		internal void UsePersistedCaches(List<FontReferenceMap> fontReferences, List<FontAsset> osFallbacks, List<FontAsset> globalOSFallbacks); // 0x000000018234A880-0x000000018234A9B0
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal FontAsset GetCachedFontAsset(Font font); // 0x0000000182348FA0-0x0000000182349300
		private static bool IsLegacyRuntimeFont(Font font); // 0x000000018234A110-0x000000018234A170
		private FontAsset GetLegacyRuntimeFontAsset(Font font); // 0x0000000182349C00-0x0000000182349E00
		private List<FontAsset> GetOSFontAssetList(); // 0x0000000182349E00-0x0000000182349EB0
		[NativeMethod(Name = "TextSettings::Create")]
		private static IntPtr CreateNativeObject(IntPtr[] fallbacks, IntPtr managedObject, EntityId managedEntityId); // 0x0000000182348E50-0x0000000182348EE0
		[NativeMethod(Name = "TextSettings::Destroy")]
		private static void DestroyNativeObject(IntPtr m_NativeTextSettings, IntPtr managedObject); // 0x0000000182348EE0-0x0000000182348F30
		private static void UpdateFallbacks(IntPtr ptr, IntPtr[] fallbacks); // 0x000000018234A620-0x000000018234A6B0
		private IntPtr[] GetGlobalFallbacks(); // 0x0000000182349540-0x0000000182349C00
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void SetNativeTextSettingsDirty(); // 0x000000018234A4D0-0x000000018234A4E0
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void UpdateNativeTextSettings(); // 0x000000018234A6B0-0x000000018234A880
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal FontAsset GetFontAsset(); // 0x00000001823493F0-0x0000000182349540
		[CompilerGenerated]
		internal static void _GetGlobalFallbacks_g__AddNativeFallback_87_0(FontAsset fallback, ref __c__DisplayClass87_0 param_0001816a); // 0x000000018234A4E0-0x000000018234A5D0
		private static IntPtr CreateNativeObject_Injected(ref ManagedSpanWrapper fallbacks, IntPtr managedObject, in EntityId managedEntityId); // 0x0000000182348DF0-0x0000000182348E50
		private static void UpdateFallbacks_Injected(IntPtr ptr, ref ManagedSpanWrapper fallbacks); // 0x000000018234A5D0-0x000000018234A620
	}
}
