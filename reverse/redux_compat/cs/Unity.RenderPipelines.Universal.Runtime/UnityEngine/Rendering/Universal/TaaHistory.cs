/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

// Image 8: Unity.RenderPipelines.Universal.Runtime.dll - Assembly: Unity.RenderPipelines.Universal.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 9287-9944

namespace UnityEngine.Rendering.Universal
{
	public sealed class TaaHistory : CameraHistoryItem // TypeDefIndex: 9492
	{
		// Fields
		private int[] m_TaaAccumulationTextureIds; // 0x20
		private int[] m_TaaAccumulationVersions; // 0x28
		private static readonly string[] m_TaaAccumulationNames; // 0x00
		private RenderTextureDescriptor m_Descriptor; // 0x30
		private Hash128 m_DescKey; // 0x68
	
		// Constructors
		public TaaHistory(); // 0x0000000181F996A0-0x0000000181F99720
		static TaaHistory(); // 0x0000000181F995D0-0x0000000181F996A0
	
		// Methods
		public override void OnCreate(BufferedRTHandleSystem owner, uint typeId); // 0x0000000181F99170-0x0000000181F991E0
		public override void Reset(); // 0x0000000181F991E0-0x0000000181F992A0
		public RTHandle GetAccumulationTexture(int eyeIndex = 0 /* Metadata: 0x0069EBCF */); // 0x0000000181F990C0-0x0000000181F99100
		public int GetAccumulationVersion(int eyeIndex = 0 /* Metadata: 0x0069EBD0 */); // 0x0000000181F99100-0x0000000181F99130
		internal void SetAccumulationVersion(int eyeIndex, int version); // 0x0000000181F992A0-0x0000000181F992D0
		private bool IsValid(); // 0x0000000181F99130-0x0000000181F99170
		private bool IsDirty(ref RenderTextureDescriptor desc); // 0x0000000181F8B330-0x0000000181F8B380
		private void Alloc(ref RenderTextureDescriptor desc, bool xrMultipassEnabled); // 0x0000000181F98F50-0x0000000181F990C0
		internal bool Update(UniversalCameraData cameraData, bool xrMultipassEnabled = false /* Metadata: 0x0069EBD1 */); // 0x0000000181F992D0-0x0000000181F995D0
	}
}
