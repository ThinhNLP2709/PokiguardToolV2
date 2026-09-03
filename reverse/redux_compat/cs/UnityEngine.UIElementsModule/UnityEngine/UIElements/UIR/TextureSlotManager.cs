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
	internal class TextureSlotManager // TypeDefIndex: 5157
	{
		// Fields
		internal static readonly int k_MaxSlotCount; // 0x00
		internal static readonly int k_SlotSize; // 0x04
		internal static readonly int[] slotIds; // 0x08
		internal static readonly int textureTableId; // 0x10
		private TextureId[] m_Textures; // 0x10
		private int[] m_LastUseTime; // 0x18
		private int m_CurrentTime; // 0x20
		private int m_BatchTime; // 0x24
		private Vector4[] m_GpuTextures; // 0x28
		private int m_SlotCount; // 0x30
		[CompilerGenerated]
		private int _FreeSlots_k__BackingField; // 0x34
		internal TextureRegistry textureRegistry; // 0x38
	
		// Properties
		public int FreeSlots { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x000000018033D0F0-0x000000018033D100 0x000000018033E770-0x000000018033E780
	
		// Constructors
		public TextureSlotManager(); // 0x000000018244A240-0x000000018244A440
		static TextureSlotManager(); // 0x000000018244A0B0-0x000000018244A240
	
		// Methods
		private static int[] BuildSlotIds(); // 0x0000000182449A40-0x0000000182449B40
		public void Reset(); // 0x0000000182449CD0-0x0000000182449D40
		private void Unbind(int first, int count = 1 /* Metadata: 0x00660AE4 */); // 0x0000000182449F50-0x000000018244A0B0
		public void StartNewBatch(int slotCount); // 0x0000000182449F10-0x0000000182449F50
		public int IndexOf(TextureId id); // 0x0000000182449BB0-0x0000000182449C70
		public void MarkUsed(int slotIndex); // 0x0000000182449C70-0x0000000182449CD0
		public int FindOldestSlot(); // 0x0000000182449B40-0x0000000182449BB0
		public void Bind(TextureId id, float sdfScale, float sharpness, bool isPremultiplied, int slot, MaterialPropertyBlock mat, CommandList commandList = null); // 0x0000000182449730-0x0000000182449A40
		public void SetGpuData(int slotIndex, TextureId id, int textureWidth, int textureHeight, float sdfScale, float sharpness, bool isPremultiplied); // 0x0000000182449D40-0x0000000182449F10
	}
}
