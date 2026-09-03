/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.TextCore;
using UnityEngine.TextCore.Text;

// Image 23: UnityEngine.IMGUIModule.dll - Assembly: UnityEngine.IMGUIModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13910-13956

namespace UnityEngine
{
	internal class IMGUITextHandle : TextHandle // TypeDefIndex: 13913
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		internal static Func<Color> GetHyperlinkColor; // 0x00
		internal int hashCode; // 0xE0
		[NoAutoStaticsCleanup]
		internal static NativeTextGenerationSettings nativeSettingsIMGUI; // 0x08
		[NoAutoStaticsCleanup]
		private static string s_IMGUICurrentText; // 0x80
		private NativeTextBuffer m_IMGUITextBuffer; // 0xE8
		internal NativeTextInfo nativeTextInfo; // 0x100
		[NoAutoStaticsCleanup]
		private static List<List<List<int>>> s_TextElementIndicesByMesh; // 0x88
		[NoAutoStaticsCleanup]
		private static Dictionary<EntityId, HashSet<uint>> s_MissingGlyphsPerFontAsset; // 0x90
		internal LinkedListNode<TextHandleTuple> tuple; // 0x118
		[NoAutoStaticsCleanup]
		private static Dictionary<int, IMGUITextHandle> textHandles; // 0x98
		[NoAutoStaticsCleanup]
		private static LinkedList<TextHandleTuple> textHandlesTuple; // 0xA0
		[NoAutoStaticsCleanup]
		private static float lastCleanupTime; // 0xA8
		[NoAutoStaticsCleanup]
		private static int newHandlesSinceCleanup; // 0xAC
		internal bool isCachedOnNative; // 0x120
		[CompilerGenerated]
		private static readonly DelegateAutoCleanup __autoCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting; // 0xB0
	
		// Nested types
		internal class TextHandleTuple // TypeDefIndex: 13914
		{
			// Fields
			public float lastTimeUsed; // 0x10
			public int hashCode; // 0x14
	
			// Constructors
			public TextHandleTuple(float lastTimeUsed, int hashCode); // 0x000000018229B4E0-0x000000018229B5D0
		}
	
		// Constructors
		public IMGUITextHandle(); // 0x000000018229AF20-0x000000018229AF90
		static IMGUITextHandle(); // 0x000000018229AC20-0x000000018229AF20
	
		// Methods
		internal override TextAsset GetICUAsset(); // 0x0000000182299210-0x0000000182299250
		private static void GetMeshInfoNative(GUIStyle style, Color color, string content, Rect rect, ref MeshInfoBindings[] meshInfos, ref Vector2 dimensions, ref int generationId); // 0x0000000182299410-0x0000000182299510
		internal static void ConvertGUIStyleToNativeTextGenerationSettings(ref NativeTextGenerationSettings nativeSettings, GUIStyle style, Color textColor, Rect rect, IntPtr textBufferPtr, int textBufferLength); // 0x0000000182298210-0x0000000182298970
		private void SyncLinksFromNative(); // 0x000000018229A850-0x000000018229A8B0
		internal static ValueTuple<TextSettings, FontAsset, int> GetTextSettingsFontAssetAndFontSize(GUIStyle style); // 0x000000018229A170-0x000000018229A4B0
		internal static IMGUITextHandle GetATGTextHandle(GUIStyle style, Rect position, string content, Color32 textColor, bool update); // 0x0000000182298FD0-0x0000000182299210
		internal static IMGUITextHandle GetATGTextHandle(GUIStyle style, Rect position, string content, Color32 textColor, ref bool isCached); // 0x0000000182298DA0-0x0000000182298FD0
		private static IMGUITextHandle GetATGTextHandle(NativeTextGenerationSettings nativeSettings, bool isCalledFromNative, ref bool isCached, bool update); // 0x0000000182298A00-0x0000000182298DA0
		internal void ComputeMeshInfos(ref MeshInfoBindings[] meshInfos); // 0x0000000182296910-0x0000000182297A00
		private static void PopulateGlyphs(Dictionary<EntityId, HashSet<uint>> missingGlyphsPerFontAsset); // 0x000000018229A530-0x000000018229A800
		public override void AddToPermanentCacheAndGenerateMesh(); // 0x0000000182296630-0x0000000182296680
		public override void RemoveFromPermanentCacheATG(); // 0x000000018229A800-0x000000018229A830
		public void UpdateNative(ref bool isCached); // 0x000000018229A8B0-0x000000018229ABB0
		internal static float GetNativeLineHeightDefault(GUIStyle style); // 0x00000001822999D0-0x0000000182299AF0
		internal static void GetMeshInfo(GUIStyle style, Color color, string content, Rect rect, ref MeshInfoBindings[] meshInfos, ref Vector2 dimensions, ref int generationId); // 0x0000000182299510-0x00000001822999D0
		internal static void EmptyManagedCache(); // 0x0000000182298970-0x0000000182298A00
		internal static IMGUITextHandle GetTextHandle(GUIStyle style, Rect position, string content, Color32 textColor, bool update = true /* Metadata: 0x006A9103 */); // 0x0000000182299B50-0x0000000182299CA0
		internal static IMGUITextHandle GetTextHandle(GUIStyle style, Rect position, string content, Color32 textColor, ref bool isCached); // 0x0000000182299CA0-0x0000000182299DF0
		private static bool ShouldCleanup(float currentTime, float lastTime, float cleanupThreshold); // 0x000000018229A830-0x000000018229A850
		private static void ClearUnusedTextHandles(); // 0x0000000182296680-0x0000000182296910
		private static IMGUITextHandle GetTextHandle(TextGenerationSettings settings, bool isCalledFromNative, ref bool isCached); // 0x0000000182299DF0-0x000000018229A170
		protected override float GetPixelsPerPoint(); // 0x0000000182299AF0-0x0000000182299B50
		internal static float GetLineHeight(GUIStyle style); // 0x0000000182299250-0x0000000182299410
		private static void ConvertGUIStyleToGenerationSettings(TextGenerationSettings settings, GUIStyle style, Color textColor, string text, Rect rect); // 0x0000000182297A00-0x0000000182298210
		private static TextOverflowMode LegacyClippingToNewOverflow(TextClipping clipping); // 0x000000018229A510-0x000000018229A530
		private static TextOverflow LegacyClippingToNativeOverflow(TextClipping clipping); // 0x000000018229A4F0-0x000000018229A510
		internal override bool IsAdvancedTextEnabledForElement(); // 0x000000018229A4B0-0x000000018229A4F0
		internal static bool IsAdvancedTextEnabled(); // 0x00000001802E7840-0x00000001802E7850
		[CompilerGenerated]
		private static void __AutoStaticsCleanup_Unity_Scripting_LifecycleManagement_CodeLoadedScope_Exiting(); // 0x000000018229ABB0-0x000000018229AC20
	}
}
