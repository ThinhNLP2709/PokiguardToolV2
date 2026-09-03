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
using UnityEngine.TextCore;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[DebuggerDisplay("{settings.text}")]
	[VisibleToOtherModules(new string[3] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule", "UnityEditor.QuickSearchModule" })]
	internal class TextHandle // TypeDefIndex: 12707
	{
		// Fields
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static TextHandleTemporaryCache s_TemporaryCache; // 0x00
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static TextHandlePermanentCache s_PermanentCache; // 0x08
		private static TextGenerationSettings[] s_Settings; // 0x10
		private static TextGenerator[] s_Generators; // 0x18
		private static TextInfo[] s_TextInfosCommon; // 0x20
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal NativeTextGenerationSettings nativeSettings; // 0x10
		protected Vector2 pixelPreferedSize; // 0x88
		private Rect m_ScreenRect; // 0x90
		private float m_LineHeightDefault; // 0xA0
		private bool m_IsPlaceholder; // 0xA4
		protected bool m_IsElided; // 0xA5
		private int m_CreateGenerationIteration; // 0xA8
		private IntPtr m_TextGenerationInfo; // 0xB0
		[CompilerGenerated]
		private LinkedListNode<TextCacheEntry> _TextInfoNode_k__BackingField; // 0xB8
		[CompilerGenerated]
		private bool _IsCachedTemporary_k__BackingField; // 0xC0
		private protected TextHandleFlags m_TextHandleFlags; // 0xC4
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal int m_PreviousGenerationSettingsHash; // 0xC8
		protected bool isDirty; // 0xCC
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal RichTextLinkInfo[] m_Links; // 0xD0
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal int m_HoveredTag; // 0xD8
		private static TextLib s_TextLib; // 0x28
	
		// Properties
		internal static TextGenerationSettings[] settingsArray { get; } // 0x0000000182343D10-0x0000000182343E70 
		internal static TextGenerator[] generators { get; } // 0x0000000182343B60-0x0000000182343CC0 
		internal static TextInfo[] textInfosCommon { get; } // 0x00000001823443B0-0x0000000182344510 
		internal static TextInfo textInfoCommon { get; } // 0x0000000182344120-0x00000001823442F0 
		private static TextGenerator generator { get; } // 0x0000000182343990-0x0000000182343B60 
		internal static TextGenerationSettings settings { [VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })] get; } // 0x0000000182343E70-0x0000000182344040 
		internal Vector2 preferredSize { [VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })] get; } // 0x0000000182343CC0-0x0000000182343D10 
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal IntPtr textGenerationInfo { get; set; } // 0x0000000182344040-0x0000000182344120 0x0000000182344730-0x0000000182344800
		internal LinkedListNode<TextCacheEntry> TextInfoNode { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x00000001806CCB90-0x00000001806CCBA0 0x00000001806CCDE0-0x00000001806CCE00
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		protected internal bool IsCachedPermanent { get; } // 0x0000000182343910-0x0000000182343920 
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal bool IsCachedPermanentATG { get; set; } // 0x00000001823436C0-0x0000000182343750 0x00000001823446F0-0x0000000182344710
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal bool IsCachedPermanentTextCore { get; set; } // 0x0000000182343750-0x0000000182343910 0x0000000182344710-0x0000000182344730
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal bool IsCachedTemporary { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018183E570-0x000000018183E580 0x0000000181F64A30-0x0000000181F64A40
		internal bool useAdvancedText { [VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })] get; } // 0x000000018178B5A0-0x000000018178B5C0 
		internal int characterCount { [VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })] get; } // 0x0000000182343920-0x0000000182343990 
		internal TextInfo textInfo { [VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })] get; } // 0x00000001823442F0-0x00000001823443B0 
		public virtual bool IsPlaceholder { get; } // 0x0000000181E76EE0-0x0000000181E76EF0 
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		protected internal TextLib textLib { get; } // 0x0000000182344510-0x00000001823446F0 
	
		// Nested types
		[Flags]
		private protected enum TextHandleFlags // TypeDefIndex: 12708
		{
			IsCachedPermanentTextCore = 2,
			IsCachedPermanentATG = 4
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 12709
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<TextGenerationSettings> __9__3_0; // 0x08
			public static Func<TextGenerator> __9__3_1; // 0x10
			public static Func<TextInfo> __9__3_2; // 0x18
			public static Func<TextGenerationSettings> __9__6_0; // 0x20
			public static Func<TextGenerator> __9__9_0; // 0x28
			public static Func<TextInfo> __9__12_0; // 0x30
	
			// Constructors
			static __c(); // 0x000000018234B950-0x000000018234B9C0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal TextGenerationSettings _InitThreadArrays_b__3_0(); // 0x000000018234B660-0x000000018234B700
			internal TextGenerator _InitThreadArrays_b__3_1(); // 0x000000018234B700-0x000000018234B750
			internal TextInfo _InitThreadArrays_b__3_2(); // 0x000000018234B750-0x000000018234B7A0
			internal TextGenerationSettings _get_settingsArray_b__6_0(); // 0x000000018234B7F0-0x000000018234B890
			internal TextGenerator _get_generators_b__9_0(); // 0x000000018234B7A0-0x000000018234B7F0
			internal TextInfo _get_textInfosCommon_b__12_0(); // 0x000000018234B890-0x000000018234B8E0
		}
	
		// Constructors
		public TextHandle(); // 0x0000000182343620-0x00000001823436C0
		static TextHandle(); // 0x0000000182343470-0x0000000182343620
	
		// Methods
		~TextHandle(); // 0x0000000182340C00-0x0000000182340D40
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal static void InitThreadArrays(); // 0x0000000182341F90-0x0000000182342260
		private static void InitArray<T>(ref ref T[] array, Func<T> createInstance);
		protected float PixelsToPoints(float pixel); // 0x00000001823427F0-0x0000000182342820
		protected internal Vector2 PointsToPixels(Vector2 point); // 0x0000000182342820-0x0000000182342860
		protected internal Vector2 PixelsToPoints(Vector2 pixel); // 0x00000001823427B0-0x00000001823427F0
		protected virtual float GetPixelsPerPoint(); // 0x0000000181E471E0-0x0000000181E471F0
		public virtual void AddToPermanentCacheAndGenerateMesh(); // 0x0000000182340930-0x0000000182340A00
		public virtual void AddToPermanentCache(); // 0x0000000182340A00-0x0000000182340A80
		public void AddTextInfoToTemporaryCache(int hashCode); // 0x0000000182340890-0x0000000182340930
		public void RemoveFromTemporaryCache(); // 0x0000000182342AD0-0x0000000182342B40
		public void RemoveFromPermanentCache(); // 0x0000000182342A50-0x0000000182342AD0
		public void RemoveFromPermanentCacheTextCore(); // 0x00000001823429E0-0x0000000182342A50
		public virtual void RemoveFromPermanentCacheATG(); // 0x0000000182342970-0x00000001823429E0
		public static void UpdateCurrentFrame(); // 0x0000000182342CD0-0x0000000182342D40
		public virtual void SetDirty(); // 0x0000000182342B40-0x0000000182342B50
		public bool IsDirty(int hashCode); // 0x0000000182342260-0x0000000182342290
		protected void UpdatePreferredValues(TextGenerationSettings tgs); // 0x0000000182343070-0x0000000182343120
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal TextInfo Update(); // 0x0000000182343390-0x0000000182343470
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal TextInfo UpdateWithHash(int hashCode); // 0x0000000182343120-0x0000000182343390
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal bool PrepareFontAsset(); // 0x0000000182342860-0x0000000182342970
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal void UpdatePreferredSize(); // 0x0000000182342D40-0x0000000182343070
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static float ConvertPixelUnitsToTextCoreRelativeUnits(float fontSize, FontAsset fontAsset); // 0x0000000182340BB0-0x0000000182340C00
		[VisibleToOtherModules(new string[1] {"UnityEngine.IMGUIModule" })]
		internal static float GetLineHeightDefault(FontAsset fontAsset, int fontSize); // 0x0000000182341780-0x0000000182341830
		public virtual Vector2 GetCursorPositionFromStringIndexUsingCharacterHeight(int index, bool inverseYAxis = true /* Metadata: 0x006A4981 */); // 0x0000000182341110-0x0000000182341240
		public Vector2 GetCursorPositionFromStringIndexUsingLineHeight(int index, bool useXAdvance = false /* Metadata: 0x006A4982 */, bool inverseYAxis = true /* Metadata: 0x006A4983 */); // 0x0000000182341240-0x0000000182341480
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal Rect[] GetHighlightRectangles(int cursorIndex, int selectIndex); // 0x00000001823414B0-0x0000000182341690
		public int GetCursorIndexFromPosition(Vector2 position, bool inverseYAxis = true /* Metadata: 0x006A4984 */); // 0x0000000182341010-0x0000000182341110
		public int LineDownCharacterPosition(int originalLogicalPos); // 0x00000001823423F0-0x00000001823425D0
		public int LineUpCharacterPosition(int originalLogicalPos); // 0x00000001823425D0-0x00000001823427B0
		public int FindIntersectingLink(Vector3 position, bool inverseYAxis = true /* Metadata: 0x006A4985 */); // 0x0000000182340D40-0x0000000182340E90
		public int GetCorrespondingStringIndex(int index); // 0x0000000182340FA0-0x0000000182341010
		public LineInfo GetLineInfoFromCharacterIndex(int index); // 0x0000000182341A50-0x0000000182341BD0
		public int GetLineNumber(int index); // 0x0000000182341BD0-0x0000000182341C90
		public float GetLineHeight(int lineNumber); // 0x0000000182341960-0x0000000182341A50
		public float GetLineHeightFromCharacterIndex(int index); // 0x0000000182341830-0x0000000182341960
		public float GetCharacterHeightFromIndex(int index); // 0x0000000182340E90-0x0000000182340FA0
		public string Substring(int startIndex, int length); // 0x0000000182342B50-0x0000000182342CD0
		public int GetFirstCharacterIndexOnLine(int currentIndex); // 0x0000000182341480-0x00000001823414B0
		public int GetLastCharacterIndexOnLine(int currentIndex); // 0x0000000182341750-0x0000000182341780
		public int IndexOf(char value, int startIndex); // 0x0000000182341C90-0x0000000182341DF0
		public int LastIndexOf(char value, int startIndex); // 0x0000000182342290-0x00000001823423F0
		internal virtual bool IsAdvancedTextEnabledForElement(); // 0x00000001802E7840-0x00000001802E7850
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal virtual TextAsset GetICUAsset(); // 0x00000001802E7860-0x00000001802E7870
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal static TextAsset GetICUAssetStaticFalback(); // 0x0000000182341690-0x0000000182341750
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		protected internal void InitTextLib(); // 0x0000000182341DF0-0x0000000182341F90
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		internal RichTextLinkInfo ATGFindIntersectingLink(Vector2 point); // 0x0000000182340720-0x0000000182340890
		[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
		public void CacheTextGenerationInfo(); // 0x0000000182340A80-0x0000000182340BB0
	}
}
