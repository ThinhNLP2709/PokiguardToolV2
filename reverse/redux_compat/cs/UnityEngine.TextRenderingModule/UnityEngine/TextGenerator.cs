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
using UnityEngine.Scripting;

// Image 62: UnityEngine.TextRenderingModule.dll - Assembly: UnityEngine.TextRenderingModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15763-15782

namespace UnityEngine
{
	[NativeHeader("Modules/TextRendering/TextGenerator.h")]
	[UsedByNativeCode]
	public sealed class TextGenerator : IDisposable // TypeDefIndex: 15769
	{
		// Fields
		internal IntPtr m_Ptr; // 0x10
		private string m_LastString; // 0x18
		private TextGenerationSettings m_LastSettings; // 0x20
		private bool m_HasGenerated; // 0x80
		private TextGenerationError m_LastValid; // 0x84
		private readonly List<UIVertex> m_Verts; // 0x88
		private readonly List<UICharInfo> m_Characters; // 0x90
		private readonly List<UILineInfo> m_Lines; // 0x98
		private bool m_CachedVerts; // 0xA0
		private bool m_CachedCharacters; // 0xA1
		private bool m_CachedLines; // 0xA2
	
		// Properties
		public int characterCountVisible { get; } // 0x00000001823522B0-0x0000000182352310 
		public IList<UIVertex> verts { get; } // 0x00000001823525B0-0x0000000182352600 
		public IList<UICharInfo> characters { get; } // 0x00000001823523B0-0x0000000182352400 
		public IList<UILineInfo> lines { get; } // 0x00000001823524A0-0x00000001823524F0 
		public Rect rectExtents { get; } // 0x0000000182352540-0x00000001823525B0 
		public int characterCount { get; } // 0x0000000182352350-0x00000001823523B0 
		public int lineCount { get; } // 0x0000000182352440-0x00000001823524A0 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15770
		{
			// Methods
			public static IntPtr ConvertToNative(TextGenerator textGenerator); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public TextGenerator(); // 0x0000000182352160-0x00000001823522B0
		public TextGenerator(int initialCapacity); // 0x0000000182352000-0x0000000182352160
	
		// Methods
		~TextGenerator(); // 0x00000001823502E0-0x00000001823503D0
		void IDisposable.Dispose(); // 0x0000000182351C70-0x0000000182351CC0
		private TextGenerationSettings ValidatedSettings(TextGenerationSettings settings); // 0x0000000182351CC0-0x0000000182352000
		public void Invalidate(); // 0x00000001804F3630-0x00000001804F3640
		public void GetCharacters(List<UICharInfo> characters); // 0x00000001823505E0-0x00000001823505F0
		public void GetLines(List<UILineInfo> lines); // 0x0000000182350800-0x0000000182350810
		public void GetVertices(List<UIVertex> vertices); // 0x0000000182350C50-0x0000000182350C60
		public float GetPreferredWidth(string str, TextGenerationSettings settings); // 0x0000000182350920-0x0000000182350A40
		public float GetPreferredHeight(string str, TextGenerationSettings settings); // 0x0000000182350810-0x0000000182350920
		public bool PopulateWithErrors(string str, TextGenerationSettings settings, GameObject context); // 0x0000000182351450-0x0000000182351680
		public bool Populate(string str, TextGenerationSettings settings); // 0x0000000182351C10-0x0000000182351C70
		private TextGenerationError PopulateWithError(string str, TextGenerationSettings settings); // 0x0000000182351040-0x0000000182351450
		private TextGenerationError PopulateAlways(string str, TextGenerationSettings settings); // 0x0000000182350CD0-0x0000000182351040
		[NativeMethod(IsThreadSafe = true)]
		private static IntPtr Internal_Create(); // 0x0000000182350C60-0x0000000182350C90
		[NativeMethod(IsThreadSafe = true)]
		private static void Internal_Destroy(IntPtr ptr); // 0x0000000182350C90-0x0000000182350CD0
		internal bool Populate_Internal(string str, Font font, Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, int verticalOverFlow, int horizontalOverflow, bool updateBounds, TextAnchor anchor, float extentsX, float extentsY, float pivotX, float pivotY, bool generateOutOfBounds, bool alignByGeometry, out uint error); // 0x0000000182351930-0x0000000182351C10
		internal bool Populate_Internal(string str, Font font, Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, VerticalWrapMode verticalOverFlow, HorizontalWrapMode horizontalOverflow, bool updateBounds, TextAnchor anchor, Vector2 extents, Vector2 pivot, bool generateOutOfBounds, bool alignByGeometry, out TextGenerationError error); // 0x0000000182351740-0x0000000182351930
		private void GetVerticesInternal([NotNull] out List<UIVertex> vertices); // 0x0000000182350A90-0x0000000182350C50
		private void GetCharactersInternal([NotNull] out List<UICharInfo> characters); // 0x0000000182350420-0x00000001823505E0
		private void GetLinesInternal([NotNull] out List<UILineInfo> lines); // 0x0000000182350640-0x0000000182350800
		private static void get_rectExtents_Injected(IntPtr _unity_self, ); // 0x00000001823524F0-0x0000000182352540
		private static int get_characterCount_Injected(IntPtr _unity_self); // 0x0000000182352310-0x0000000182352350
		private static int get_lineCount_Injected(IntPtr _unity_self); // 0x0000000182352400-0x0000000182352440
		private static bool Populate_Internal_Injected(IntPtr _unity_self, ref ManagedSpanWrapper str, IntPtr font, in Color color, int fontSize, float scaleFactor, float lineSpacing, FontStyle style, bool richText, bool resizeTextForBestFit, int resizeTextMinSize, int resizeTextMaxSize, int verticalOverFlow, int horizontalOverflow, bool updateBounds, TextAnchor anchor, float extentsX, float extentsY, float pivotX, float pivotY, bool generateOutOfBounds, bool alignByGeometry, out uint error); // 0x0000000182351680-0x0000000182351740
		private static void GetVerticesInternal_Injected(IntPtr _unity_self, out BlittableListWrapper vertices); // 0x0000000182350A40-0x0000000182350A90
		private static void GetCharactersInternal_Injected(IntPtr _unity_self, out BlittableListWrapper characters); // 0x00000001823503D0-0x0000000182350420
		private static void GetLinesInternal_Injected(IntPtr _unity_self, out BlittableListWrapper lines); // 0x00000001823505F0-0x0000000182350640
	}
}
