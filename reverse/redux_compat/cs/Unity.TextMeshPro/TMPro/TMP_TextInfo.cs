/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	[Serializable]
	public class TMP_TextInfo // TypeDefIndex: 11909
	{
		// Fields
		internal static readonly Vector2 k_InfinityVectorPositive; // 0x00
		internal static readonly Vector2 k_InfinityVectorNegative; // 0x08
		public TMP_Text textComponent; // 0x10
		public int characterCount; // 0x18
		public int spriteCount; // 0x1C
		public int spaceCount; // 0x20
		public int wordCount; // 0x24
		public int linkCount; // 0x28
		public int lineCount; // 0x2C
		public int pageCount; // 0x30
		public int materialCount; // 0x34
		[NonSerialized]
		public TMP_CharacterInfo[] characterInfo; // 0x38
		[NonSerialized]
		public TMP_WordInfo[] wordInfo; // 0x40
		[NonSerialized]
		public TMP_LinkInfo[] linkInfo; // 0x48
		[NonSerialized]
		public TMP_LineInfo[] lineInfo; // 0x50
		[NonSerialized]
		public TMP_PageInfo[] pageInfo; // 0x58
		[NonSerialized]
		public TMP_MeshInfo[] meshInfo; // 0x60
		private TMP_MeshInfo[] m_CachedMeshInfo; // 0x68
	
		// Constructors
		public TMP_TextInfo(); // 0x00000001820D0310-0x00000001820D0450
		internal TMP_TextInfo(int characterCount); // 0x00000001820D0600-0x00000001820D0740
		public TMP_TextInfo(TMP_Text textComponent); // 0x00000001820D0450-0x00000001820D0600
		static TMP_TextInfo(); // 0x00000001820D02B0-0x00000001820D0310
	
		// Methods
		internal void Clear(); // 0x00000001820CFC30-0x00000001820CFCA0
		internal void ClearAllData(); // 0x00000001820CF480-0x00000001820CF5D0
		public void ClearMeshInfo(bool updateMesh); // 0x00000001820CF970-0x00000001820CFA50
		public void ClearAllMeshInfo(); // 0x00000001820CF5D0-0x00000001820CF690
		public void ResetVertexLayout(bool isVolumetric); // 0x00000001820D01D0-0x00000001820D02B0
		public void ClearUnusedVertices(MaterialReference[] materials); // 0x00000001820CFB50-0x00000001820CFC30
		internal void ClearLineInfo(); // 0x00000001820CF690-0x00000001820CF970
		internal void ClearPageInfo(); // 0x00000001820CFA50-0x00000001820CFB50
		public TMP_MeshInfo[] CopyMeshInfoVertexData(); // 0x00000001820CFCA0-0x00000001820D01D0
		public static void Resize<T>(ref ref T[] array, int size);
		public static void Resize<T>(ref ref T[] array, int size, bool isBlockAllocated);
	}
}
