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
	[VisibleToOtherModules(new string[2] {"UnityEngine.IMGUIModule", "UnityEngine.UIElementsModule" })]
	internal class TextInfo // TypeDefIndex: 12715
	{
		// Fields
		private static Vector2 s_InfinityVectorPositive; // 0x00
		private static Vector2 s_InfinityVectorNegative; // 0x08
		public int characterCount; // 0x10
		public int spriteCount; // 0x14
		public int spaceCount; // 0x18
		public int wordCount; // 0x1C
		public int linkCount; // 0x20
		public int lineCount; // 0x24
		public int materialCount; // 0x28
		public TextElementInfo[] textElementInfo; // 0x30
		public WordInfo[] wordInfo; // 0x38
		public LinkInfo[] linkInfo; // 0x40
		public LineInfo[] lineInfo; // 0x48
		public MeshInfo[] meshInfo; // 0x50
		public bool hasMultipleColors; // 0x58
	
		// Constructors
		public TextInfo(); // 0x0000000182346450-0x00000001823465C0
		static TextInfo(); // 0x00000001823463F0-0x0000000182346450
	
		// Methods
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal void Clear(); // 0x0000000182344B10-0x0000000182344B80
		internal void ClearMeshInfo(bool updateMesh); // 0x0000000182344A90-0x0000000182344B10
		internal void ClearLineInfo(); // 0x0000000182344800-0x0000000182344A90
		internal static void Resize<T>(ref ref T[] array, int size);
		internal static void Resize<T>(ref ref T[] array, int size, bool isBlockAllocated);
		public virtual Vector2 GetCursorPositionFromStringIndexUsingCharacterHeight(int index, Rect screenRect, float lineHeight, bool inverseYAxis = true /* Metadata: 0x006A498C */); // 0x00000001823458A0-0x00000001823459D0
		public Vector2 GetCursorPositionFromStringIndexUsingLineHeight(int index, Rect screenRect, float lineHeight, bool useXAdvance = false /* Metadata: 0x006A498D */, bool inverseYAxis = true /* Metadata: 0x006A498E */); // 0x00000001823459D0-0x0000000182345B60
		public int GetCursorIndexFromPosition(Vector2 position, Rect screenRect, bool inverseYAxis = true /* Metadata: 0x006A498F */); // 0x00000001823456C0-0x00000001823458A0
		public int LineDownCharacterPosition(int originalPos); // 0x0000000182345EC0-0x00000001823460B0
		public int LineUpCharacterPosition(int originalPos); // 0x00000001823460B0-0x0000000182346270
		public int FindNearestLine(Vector2 position); // 0x0000000182345520-0x0000000182345600
		public int FindNearestCharacterOnLine(Vector2 position, int line, bool visibleOnly); // 0x0000000182345090-0x0000000182345520
		public int FindIntersectingLink(Vector3 position, Rect screenRect, bool inverseYAxis = true /* Metadata: 0x006A4990 */); // 0x0000000182344B80-0x0000000182345090
		public int GetCorrespondingStringIndex(int index); // 0x0000000182345660-0x00000001823456C0
		public LineInfo GetLineInfoFromCharacterIndex(int index); // 0x0000000182345C50-0x0000000182345D00
		private static bool PointIntersectRectangle(Vector3 m, Vector3 a, Vector3 b, Vector3 c, Vector3 d); // 0x00000001820F0810-0x00000001820F0A70
		private static float DistanceToLine(Vector3 a, Vector3 b, Vector3 point); // 0x00000001820EC3C0-0x00000001820EC630
		public int GetLineNumber(int index); // 0x0000000182345D00-0x0000000182345D50
		public float GetLineHeight(int lineNumber); // 0x0000000182345BF0-0x0000000182345C50
		public float GetLineHeightFromCharacterIndex(int index); // 0x0000000182345B60-0x0000000182345BF0
		public float GetCharacterHeightFromIndex(int index); // 0x0000000182345600-0x0000000182345660
		public string Substring(int startIndex, int length); // 0x0000000182346270-0x00000001823463F0
		public int IndexOf(char value, int startIndex); // 0x0000000182345D50-0x0000000182345E10
		public int LastIndexOf(char value, int startIndex); // 0x0000000182345E10-0x0000000182345EC0
	}
}
