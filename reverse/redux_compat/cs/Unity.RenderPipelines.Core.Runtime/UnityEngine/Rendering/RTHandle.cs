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
	public class RTHandle // TypeDefIndex: 5711
	{
		// Fields
		internal RTHandleSystem m_Owner; // 0x10
		internal RenderTexture m_RT; // 0x18
		internal Texture m_ExternalTexture; // 0x20
		internal RenderTargetIdentifier m_NameID; // 0x28
		internal bool m_EnableMSAA; // 0x50
		internal bool m_EnableRandomWrite; // 0x51
		internal bool m_EnableHWDynamicScale; // 0x52
		internal bool m_RTHasOwnership; // 0x53
		internal string m_Name; // 0x58
		internal bool m_UseCustomHandleScales; // 0x60
		internal RTHandleProperties m_CustomHandleProperties; // 0x64
		[CompilerGenerated]
		private Vector2 _scaleFactor_k__BackingField; // 0x94
		internal ScaleFunc scaleFunc; // 0xA0
		[CompilerGenerated]
		private bool _useScaling_k__BackingField; // 0xA8
		[CompilerGenerated]
		private Vector2Int _referenceSize_k__BackingField; // 0xAC
	
		// Properties
		public Vector2 scaleFactor { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181E96690-0x0000000181E966B0 0x0000000181E96790-0x0000000181E967A0
		public bool useScaling { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181773D00-0x0000000181773D10 0x0000000181773D30-0x0000000181773D40
		public Vector2Int referenceSize { [CompilerGenerated] get; [CompilerGenerated] internal set; } // 0x0000000181709190-0x00000001817091A0 0x0000000181709230-0x0000000181709240
		public RTHandleProperties rtHandleProperties { get; } // 0x0000000181E96630-0x0000000181E96690 
		public RenderTexture rt { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public Texture externalTexture { get; } // 0x00000001802F8630-0x00000001802F8640 
		public RenderTargetIdentifier nameID { get; } // 0x0000000181E96610-0x0000000181E96630 
		public string name { get; } // 0x00000001802F4000-0x00000001802F4010 
		public bool isMSAAEnabled { get; } // 0x0000000180377920-0x0000000180377930 
	
		// Constructors
		internal RTHandle(RTHandleSystem owner); // 0x0000000181E965D0-0x0000000181E96610
	
		// Methods
		public void SetCustomHandleProperties([IsReadOnly] in RTHandleProperties properties); // 0x0000000181E96330-0x0000000181E96350
		public void ClearCustomHandleProperties(); // 0x0000000180496BB0-0x0000000180496BC0
		public static implicit operator RenderTargetIdentifier(RTHandle handle); // 0x0000000181E966B0-0x0000000181E96700
		public static implicit operator Texture(RTHandle handle); // 0x0000000181E96710-0x0000000181E96790
		public static implicit operator RenderTexture(RTHandle handle); // 0x0000000181E96700-0x0000000181E96710
		internal void SetRenderTexture(RenderTexture rt, bool transferOwnership = true /* Metadata: 0x006617E3 */); // 0x0000000181E96350-0x0000000181E963E0
		internal void SetTexture(Texture tex); // 0x0000000181E96440-0x0000000181E964C0
		internal void SetTexture(RenderTargetIdentifier tex); // 0x0000000181E963E0-0x0000000181E96440
		public ulong GetUniqueID(); // 0x0000000181E96180-0x0000000181E96230
		[Obsolete("GetInstanceID() is obsolete, use GetUniqueID() instead.", true)]
		public int GetInstanceID(); // 0x0000000181E95FA0-0x0000000181E96040
		public void Release(); // 0x0000000181E96230-0x0000000181E96330
		public Vector2Int GetScaledSize(Vector2Int refSize); // 0x0000000181E960F0-0x0000000181E96180
		public Vector2Int GetScaledSize(); // 0x0000000181E96040-0x0000000181E960F0
		public void SwitchToFastMemory(CommandBuffer cmd, float residencyFraction = 1f /* Metadata: 0x006617E4 */, FastMemoryFlags flags = FastMemoryFlags.None | FastMemoryFlags.SpillTop /* Metadata: 0x006617E8 */, bool copyContents = false /* Metadata: 0x006617E9 */); // 0x0000000181E96530-0x0000000181E965D0
		public void CopyToFastMemory(CommandBuffer cmd, float residencyFraction = 1f /* Metadata: 0x006617EA */, FastMemoryFlags flags = FastMemoryFlags.None | FastMemoryFlags.SpillTop /* Metadata: 0x006617EE */); // 0x0000000181E95F00-0x0000000181E95FA0
		public void SwitchOutFastMemory(CommandBuffer cmd, bool copyContents = true /* Metadata: 0x006617EF */); // 0x0000000181E964C0-0x0000000181E96530
	}
}
