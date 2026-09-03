/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	public struct BatchFilterSettings // TypeDefIndex: 8353
	{
		// Fields
		public uint renderingLayerMask; // 0x00
		public int rendererPriority; // 0x04
		private ulong m_sceneCullingMask; // 0x08
		public byte layer; // 0x10
		private byte m_batchLayer; // 0x11
		private byte m_motionMode; // 0x12
		private byte m_shadowMode; // 0x13
		private byte m_receiveShadows; // 0x14
		private byte m_staticShadowCaster; // 0x15
		private byte m_allDepthSorted; // 0x16
		private byte m_isSceneCullingMaskSet; // 0x17
	
		// Properties
		public byte batchLayer { set; } // 0x00000001815C0340-0x00000001815C0350
		public MotionVectorGenerationMode motionMode { set; } // 0x0000000181734F30-0x0000000181734F40
		public ShadowCastingMode shadowCastingMode { set; } // 0x0000000181F33560-0x0000000181F33570
		public bool receiveShadows { set; } // 0x0000000181541B70-0x0000000181541B80
		public bool staticShadowCaster { set; } // 0x000000018155D210-0x000000018155D220
		public bool allDepthSorted { set; } // 0x0000000181F97910-0x0000000181F97920
	}
}
