/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class BestFitAllocator // TypeDefIndex: 5038
	{
		// Fields
		[CompilerGenerated]
		private readonly uint _totalSize_k__BackingField; // 0x10
		private Block m_FirstBlock; // 0x18
		private Block m_FirstAvailableBlock; // 0x20
		private BlockPool m_BlockPool; // 0x28
		private uint m_HighWatermark; // 0x30
	
		// Properties
		public uint totalSize { [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public uint highWatermark { get; } // 0x000000018033D100-0x000000018033D110 
	
		// Nested types
		private class BlockPool : LinkedPool<Block> // TypeDefIndex: 5039
		{
			// Nested types
			[CompilerGenerated]
			private static class __O // TypeDefIndex: 5040
			{
				// Fields
				public static Func<Block> _0___CreateBlock; // 0x00
				public static Action<Block> _1___ResetBlock; // 0x08
			}
	
			// Constructors
			public BlockPool(); // 0x000000018240ACD0-0x000000018240AE30
	
			// Methods
			private static Block CreateBlock(); // 0x000000018240AC80-0x000000018240ACD0
			private static void ResetBlock(Block block); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		private class Block : LinkedPoolItem<Block> // TypeDefIndex: 5041
		{
			// Fields
			public uint start; // 0x18
			public uint end; // 0x1C
			public Block prev; // 0x20
			public Block next; // 0x28
			public Block prevAvailable; // 0x30
			public Block nextAvailable; // 0x38
			public bool allocated; // 0x40
	
			// Properties
			public uint size { get; } // 0x000000018240AE30-0x000000018240AE40 
	
			// Constructors
			public Block(); // 0x00000001802F4070-0x00000001802F4080
		}
	
		// Constructors
		public BestFitAllocator(uint size); // 0x000000018240AA80-0x000000018240AC80
	
		// Methods
		public Alloc Allocate(uint size); // 0x000000018240A270-0x000000018240A560
		public void Free(Alloc alloc); // 0x000000018240A6D0-0x000000018240A930
		private Block CoalesceBlockWithPrevious(Block block); // 0x000000018240A5A0-0x000000018240A6D0
		private Block BestFitFindAvailableBlock(uint size); // 0x000000018240A560-0x000000018240A5A0
		private void SplitBlock(Block block, uint size); // 0x000000018240A930-0x000000018240AA80
	}
}
