/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 20: Unity.PathTracing.Runtime.dll - Assembly: Unity.PathTracing.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13540-13662

namespace UnityEngine.PathTracing.Core
{
	internal class TextureQuadTree // TypeDefIndex: 13567
	{
		// Fields
		private readonly int _size; // 0x10
		private readonly List<TextureNode> _leaves; // 0x18
	
		// Properties
		public bool IsFull { get; } // 0x0000000181DFD910-0x0000000181DFD930 
	
		// Nested types
		public class TextureNode // TypeDefIndex: 13568
		{
			// Fields
			public TextureNode TopLeft; // 0x10
			public TextureNode TopRight; // 0x18
			public TextureNode BottomLeft; // 0x20
			public TextureNode BottomRight; // 0x28
			public TextureNode Parent; // 0x30
			public int PosX; // 0x38
			public int PosY; // 0x3C
			public int Size; // 0x40
	
			// Constructors
			public TextureNode(); // 0x00000001802E5CB0-0x00000001802E5CC0
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass7_0 // TypeDefIndex: 13569
		{
			// Fields
			public int textureSize; // 0x10
	
			// Constructors
			public __c__DisplayClass7_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _HasSpaceForTexture_b__0(TextureNode leaf); // 0x0000000181DFEEA0-0x0000000181DFEEC0
		}
	
		// Constructors
		public TextureQuadTree(int size); // 0x0000000181DFD7E0-0x0000000181DFD910
	
		// Methods
		private void SubdivideNode(TextureNode node); // 0x0000000181DFD520-0x0000000181DFD6F0
		public bool AddTexture(int size, out TextureNode node); // 0x0000000181DFCE50-0x0000000181DFD150
		public void RemoveTexture(TextureNode node); // 0x0000000181DFD210-0x0000000181DFD520
		public bool HasSpaceForTexture(int textureSize); // 0x0000000181DFD150-0x0000000181DFD210
		[CompilerGenerated]
		private bool _RemoveTexture_g__ShouldCollapse_6_0(TextureNode node); // 0x0000000181DFD6F0-0x0000000181DFD7E0
	}
}
