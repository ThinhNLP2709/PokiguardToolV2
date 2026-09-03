/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Profiling;
using Unity.Properties;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal class UIRAtlasAllocator : IDisposable // TypeDefIndex: 4308
	{
		// Fields
		[CompilerGenerated]
		private readonly int _maxAtlasSize_k__BackingField; // 0x10
		[CompilerGenerated]
		private readonly int _maxImageWidth_k__BackingField; // 0x14
		[CompilerGenerated]
		private readonly int _maxImageHeight_k__BackingField; // 0x18
		[CompilerGenerated]
		private int _virtualWidth_k__BackingField; // 0x1C
		[CompilerGenerated]
		private int _virtualHeight_k__BackingField; // 0x20
		[CompilerGenerated]
		private int _physicalWidth_k__BackingField; // 0x24
		[CompilerGenerated]
		private int _physicalHeight_k__BackingField; // 0x28
		private AreaNode m_FirstUnpartitionedArea; // 0x30
		private Row[] m_OpenRows; // 0x38
		private int m_1SidePadding; // 0x40
		private int m_2SidePadding; // 0x44
		private static readonly ProfilerMarker s_MarkerTryAllocate; // 0x00
		[CompilerGenerated]
		private bool _disposed_k__BackingField; // 0x48
	
		// Properties
		public int maxAtlasSize { [CompilerGenerated] get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public int maxImageWidth { [CompilerGenerated] get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public int maxImageHeight { [CompilerGenerated] get; } // 0x0000000180B23260-0x0000000180B23270 
		public int virtualWidth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B232F0-0x0000000180B23300 0x0000000180E025C0-0x0000000180E025D0
		public int virtualHeight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180C4F680-0x0000000180C4F690 0x0000000180E332D0-0x0000000180E332E0
		public int physicalWidth { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180D17D10-0x0000000180D17D20 0x0000000180E02560-0x0000000180E02570
		public int physicalHeight { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180377930-0x0000000180377940 0x0000000180378100-0x0000000180378110
		protected bool disposed { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001804EFDA0-0x00000001804EFDB0 0x0000000180C47C30-0x0000000180C47C40
	
		// Nested types
		private class Row // TypeDefIndex: 4309
		{
			// Fields
			[NoAutoStaticsCleanup]
			private static readonly ObjectPool<Row> s_Pool; // 0x00
			[CompilerGenerated]
			private int _offsetX_k__BackingField; // 0x10
			[CompilerGenerated]
			private int _offsetY_k__BackingField; // 0x14
			[CompilerGenerated]
			private int _width_k__BackingField; // 0x18
			[CompilerGenerated]
			private int _height_k__BackingField; // 0x1C
			public int Cursor; // 0x20
	
			// Properties
			public int offsetX { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
			public int offsetY { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
			public int width { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
			private int height { [CompilerGenerated] set; } // 0x0000000180E025C0-0x0000000180E025D0
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 4310
			{
				// Fields
				public static readonly __c __9; // 0x00
	
				// Constructors
				static __c(); // 0x00000001824DEFB0-0x00000001824DF020
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal Row _.cctor_b__21_0(); // 0x00000001824DECB0-0x00000001824DED00
			}
	
			// Constructors
			public Row(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static Row(); // 0x00000001824DCA40-0x00000001824DCB50
	
			// Methods
			public static Row Acquire(int offsetX, int offsetY, int width, int height); // 0x00000001824DC8E0-0x00000001824DC9A0
			public void Release(); // 0x00000001824DC9A0-0x00000001824DCA40
		}
	
		private class AreaNode // TypeDefIndex: 4311
		{
			// Fields
			[NoAutoStaticsCleanup]
			private static readonly ObjectPool<AreaNode> s_Pool; // 0x00
			public RectInt rect; // 0x10
			public AreaNode previous; // 0x20
			public AreaNode next; // 0x28
	
			// Nested types
			[Serializable]
			[CompilerGenerated]
			private sealed class __c // TypeDefIndex: 4312
			{
				// Fields
				public static readonly __c __9; // 0x00
	
				// Constructors
				static __c(); // 0x00000001824DEED0-0x00000001824DEF40
				public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
				// Methods
				internal AreaNode _.cctor_b__9_0(); // 0x00000001824DEDD0-0x00000001824DEE20
			}
	
			// Constructors
			public AreaNode(); // 0x00000001802E5CB0-0x00000001802E5CC0
			static AreaNode(); // 0x00000001824CCA00-0x00000001824CCB10
	
			// Methods
			public static AreaNode Acquire(RectInt rect); // 0x00000001824CC770-0x00000001824CC830
			public void Release(); // 0x00000001824CC910-0x00000001824CC990
			public void RemoveFromChain(); // 0x00000001824CC990-0x00000001824CCA00
			public void AddAfter(AreaNode previous); // 0x00000001824CC830-0x00000001824CC910
		}
	
		// Constructors
		public UIRAtlasAllocator(int initialAtlasSize, int maxAtlasSize, int sidePadding = 1 /* Metadata: 0x006606E4 */); // 0x00000001824DFFD0-0x00000001824E02E0
		static UIRAtlasAllocator(); // 0x00000001824DFF60-0x00000001824DFFD0
	
		// Methods
		public void Dispose(); // 0x00000001824DF7E0-0x00000001824DF850
		protected virtual void Dispose(bool disposing); // 0x00000001824DF690-0x00000001824DF7E0
		private static int GetLog2OfNextPower(int n); // 0x00000001824DF850-0x00000001824DF8F0
		public bool TryAllocate(int width, int height, out RectInt location); // 0x00000001824DF8F0-0x00000001824DFCA0
		private bool TryPartitionArea(AreaNode areaNode, int rowIndex, int rowHeight, int minWidth); // 0x00000001824DFCA0-0x00000001824DFF60
		private void BuildAreas(); // 0x00000001824DF530-0x00000001824DF690
	}
}
