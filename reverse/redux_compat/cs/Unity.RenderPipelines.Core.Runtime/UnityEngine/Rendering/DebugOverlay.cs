/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	public class DebugOverlay // TypeDefIndex: 5447
	{
		// Fields
		[CompilerGenerated]
		private int _x_k__BackingField; // 0x10
		[CompilerGenerated]
		private int _y_k__BackingField; // 0x14
		[CompilerGenerated]
		private int _overlaySize_k__BackingField; // 0x18
		private int m_InitialPositionX; // 0x1C
		private int m_ScreenWidth; // 0x20
	
		// Properties
		public int x { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public int y { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public int overlaySize { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
	
		// Constructors
		public DebugOverlay(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void StartOverlay(int initialX, int initialY, int overlaySize, int screenWidth); // 0x0000000181E442C0-0x0000000181E442E0
		public Rect Next(float aspect = 1f /* Metadata: 0x00661558 */); // 0x0000000181E441E0-0x0000000181E44260
		public void SetViewport(CommandBuffer cmd); // 0x0000000181E44260-0x0000000181E442C0
	}
}
