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
using UnityEngine.Scripting;

// Image 62: UnityEngine.TextRenderingModule.dll - Assembly: UnityEngine.TextRenderingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15763-15782

namespace UnityEngine
{
	[NativeClass("TextRendering::Font", PersistentTypeId = 128)]
	[NativeHeader("Modules/TextRendering/Public/Font.h")]
	[NativeHeader("Modules/TextRendering/Public/FontImpl.h")]
	[StaticAccessor("TextRenderingPrivate", StaticAccessorType.DoubleColon)]
	public sealed class Font : Object // TypeDefIndex: 15781
	{
		// Fields
		[CompilerGenerated]
		private static Action<Font> textureRebuilt; // 0x00
		[CompilerGenerated]
		private FontTextureRebuildCallback m_FontTextureRebuildCallback; // 0x18
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0x08
	
		// Properties
		public Material material { get; set; } // 0x000000018234F8C0-0x000000018234F970 0x000000018234FD90-0x000000018234FE50
		public string[] fontNames { get; set; } // 0x000000018234F580-0x000000018234F610 0x000000018234FCA0-0x000000018234FD40
		public bool dynamic { get; } // 0x000000018234F4B0-0x000000018234F540 
		internal bool includeFontData { [VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })] get; } // 0x000000018234F720-0x000000018234F7B0 
		public int ascent { get; } // 0x000000018234F260-0x000000018234F2F0 
		public int fontSize { get; } // 0x000000018234F650-0x000000018234F6E0 
		public CharacterInfo[] characterInfo { [FreeFunction("TextRenderingPrivate::GetFontCharacterInfo", HasExplicitThis = true)] get; [FreeFunction("TextRenderingPrivate::SetFontCharacterInfo", HasExplicitThis = true)] set; } // 0x000000018234F340-0x000000018234F470 0x000000018234FB50-0x000000018234FC50
		[NativeProperty("LineSpacing", false, TargetType.Function)]
		public int lineHeight { get; } // 0x000000018234F7F0-0x000000018234F880 
		[Obsolete("Font.textureRebuildCallback has been deprecated. Use Font.textureRebuilt instead.")]
		public FontTextureRebuildCallback textureRebuildCallback { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Events
		[AutoStaticsCleanupOnCodeReload]
		public static event Action<Font> textureRebuilt {
			add; // 0x000000018234F130-0x000000018234F220
			remove; // 0x000000018234FA10-0x000000018234FB00
		}
		private event FontTextureRebuildCallback m_FontTextureRebuildCallback {
			add; // 0x000000018234F090-0x000000018234F130
			remove; // 0x000000018234F970-0x000000018234FA10
		}
	
		// Nested types
		public delegate void FontTextureRebuildCallback(); // TypeDefIndex: 15782; 0x0000000180313920-0x00000001803139C0
	
		// Constructors
		public Font(); // 0x000000018234EE60-0x000000018234EEE0
		public Font(string name); // 0x000000018234EF90-0x000000018234F090
		private Font(string[] names, int size); // 0x000000018234EEE0-0x000000018234EF90
		static Font(); // 0x000000018234ED40-0x000000018234EE60
	
		// Methods
		public static Font CreateDynamicFontFromOSFont(string fontname, int size); // 0x000000018234DD80-0x000000018234DE30
		public static Font CreateDynamicFontFromOSFont(string[] fontnames, int size); // 0x000000018234DD10-0x000000018234DD80
		[RequiredByNativeCode]
		internal static void InvokeTextureRebuilt_Internal(Font font); // 0x000000018234E7F0-0x000000018234E890
		public static int GetMaxVertsForString(string str); // 0x000000018234E1A0-0x000000018234E1C0
		[VisibleToOtherModules(new string[2] {"UnityEditor.TextRenderingModule", "UnityEngine.TextCoreTextEngineModule" })]
		internal static Font GetDefault(); // 0x000000018234E120-0x000000018234E1A0
		public bool HasCharacter(char c); // 0x000000018234E290-0x000000018234E330
		private bool HasCharacter(int c); // 0x000000018234E330-0x000000018234E3D0
		public static string[] GetOSInstalledFontNames(); // 0x000000018234E1F0-0x000000018234E220
		public static string[] GetPathsToOSFonts(); // 0x000000018234E220-0x000000018234E250
		[VisibleToOtherModules(new string[1] {"UnityEngine.TextCoreTextEngineModule" })]
		internal static string[] GetOSFallbacks(); // 0x000000018234E1C0-0x000000018234E1F0
		[NativeMethod(IsThreadSafe = true)]
		[VisibleToOtherModules(new string[2] {"UnityEngine.UIElementsModule", "UnityEditor.CoreModule" })]
		internal static bool IsFontSmoothingEnabled(); // 0x000000018234E890-0x000000018234E8C0
		private static void Internal_CreateFont([Writable] Font self, string name); // 0x000000018234E660-0x000000018234E7F0
		private static void Internal_CreateFontFromPath([Writable] Font self, string fontPath); // 0x000000018234E480-0x000000018234E610
		private static void Internal_CreateDynamicFont([Writable] Font self, [UnityMarshalAs(NativeType.ScriptingObjectPtr)] string[] _names, int size); // 0x000000018234E3D0-0x000000018234E430
		[FreeFunction("TextRenderingPrivate::GetCharacterInfo", HasExplicitThis = true)]
		public bool GetCharacterInfo(char ch, out CharacterInfo info, [DefaultValue("0")] int size, [DefaultValue("FontStyle.Normal")] FontStyle style); // 0x000000018234DF70-0x000000018234E030
		[ExcludeFromDocs]
		public bool GetCharacterInfo(char ch, out CharacterInfo info, int size); // 0x000000018234DEA0-0x000000018234DF70
		[ExcludeFromDocs]
		public bool GetCharacterInfo(char ch, out CharacterInfo info); // 0x000000018234E030-0x000000018234E0F0
		public void RequestCharactersInTexture(string characters, [DefaultValue("0")] int size, [DefaultValue("FontStyle.Normal")] FontStyle style); // 0x000000018234E930-0x000000018234EB00
		[ExcludeFromDocs]
		public void RequestCharactersInTexture(string characters, int size); // 0x000000018234EB20-0x000000018234EB40
		[ExcludeFromDocs]
		public void RequestCharactersInTexture(string characters); // 0x000000018234EB00-0x000000018234EB20
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018234EB40-0x000000018234ED40
		private static IntPtr get_material_Injected(IntPtr _unity_self); // 0x000000018234F880-0x000000018234F8C0
		private static void set_material_Injected(IntPtr _unity_self, IntPtr value); // 0x000000018234FD40-0x000000018234FD90
		private static string[] get_fontNames_Injected(IntPtr _unity_self); // 0x000000018234F540-0x000000018234F580
		private static void set_fontNames_Injected(IntPtr _unity_self, string[] value); // 0x000000018234FC50-0x000000018234FCA0
		private static bool get_dynamic_Injected(IntPtr _unity_self); // 0x000000018234F470-0x000000018234F4B0
		private static bool get_includeFontData_Injected(IntPtr _unity_self); // 0x000000018234F6E0-0x000000018234F720
		private static int get_ascent_Injected(IntPtr _unity_self); // 0x000000018234F220-0x000000018234F260
		private static int get_fontSize_Injected(IntPtr _unity_self); // 0x000000018234F610-0x000000018234F650
		private static void get_characterInfo_Injected(IntPtr _unity_self, ); // 0x000000018234F2F0-0x000000018234F340
		private static void set_characterInfo_Injected(IntPtr _unity_self, ref ManagedSpanWrapper value); // 0x000000018234FB00-0x000000018234FB50
		private static int get_lineHeight_Injected(IntPtr _unity_self); // 0x000000018234F7B0-0x000000018234F7F0
		private static IntPtr GetDefault_Injected(); // 0x000000018234E0F0-0x000000018234E120
		private static bool HasCharacter_Injected(IntPtr _unity_self, int c); // 0x000000018234E250-0x000000018234E290
		private static void Internal_CreateFont_Injected([Writable] Font self, ref ManagedSpanWrapper name); // 0x000000018234E610-0x000000018234E660
		private static void Internal_CreateFontFromPath_Injected([Writable] Font self, ref ManagedSpanWrapper fontPath); // 0x000000018234E430-0x000000018234E480
		private static bool GetCharacterInfo_Injected(IntPtr _unity_self, char ch, out CharacterInfo info, [DefaultValue("0")] int size, [DefaultValue("FontStyle.Normal")] FontStyle style); // 0x000000018234DE30-0x000000018234DEA0
		private static void RequestCharactersInTexture_Injected(IntPtr _unity_self, ref ManagedSpanWrapper characters, [DefaultValue("0")] int size, [DefaultValue("FontStyle.Normal")] FontStyle style); // 0x000000018234E8C0-0x000000018234E930
	}
}
