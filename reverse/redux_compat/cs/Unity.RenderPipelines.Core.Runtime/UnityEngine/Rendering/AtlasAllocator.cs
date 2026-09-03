/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Pool;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	internal class AtlasAllocator // TypeDefIndex: 5721
	{
		// Fields
		private AtlasNode m_Root; // 0x10
		private int m_Width; // 0x18
		private int m_Height; // 0x1C
		private bool powerOfTwoPadding; // 0x20
		private ObjectPool<AtlasNode> m_NodePool; // 0x28
	
		// Nested types
		private class AtlasNode // TypeDefIndex: 5722
		{
			// Fields
			public AtlasNode m_RightChild; // 0x10
			public AtlasNode m_BottomChild; // 0x18
			public Vector4 m_Rect; // 0x20
	
			// Constructors
			public AtlasNode(); // 0x0000000181E8BE60-0x0000000181E8BE70
	
			// Methods
			public AtlasNode Allocate(ref ObjectPool<AtlasNode> pool, int width, int height, bool powerOfTwoPadding); // 0x0000000181E8BA70-0x0000000181E8BD90
			public void Release(ref ObjectPool<AtlasNode> pool); // 0x0000000181E8BD90-0x0000000181E8BE60
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 5723
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<AtlasNode> __9__6_0; // 0x08
			public static Action<AtlasNode> __9__6_1; // 0x10
			public static Action<AtlasNode> __9__6_2; // 0x18
	
			// Constructors
			static __c(); // 0x0000000181EA1F20-0x0000000181EA1F90
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal AtlasNode _.ctor_b__6_0(); // 0x0000000181EA1DB0-0x0000000181EA1E00
			internal void _.ctor_b__6_1(AtlasNode _); // 0x00000001802E76C0-0x00000001802E76D0
			internal void _.ctor_b__6_2(AtlasNode _); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		public AtlasAllocator(int width, int height, bool potPadding); // 0x0000000181E8B790-0x0000000181E8BA70
	
		// Methods
		public bool Allocate(ref Vector4 result, int width, int height); // 0x0000000181E8B6C0-0x0000000181E8B730
		public void Reset(); // 0x0000000181E8B730-0x0000000181E8B790
	}
}
