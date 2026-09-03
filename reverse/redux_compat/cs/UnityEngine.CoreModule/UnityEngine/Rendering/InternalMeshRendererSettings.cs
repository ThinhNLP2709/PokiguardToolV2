/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[UsedByNativeCode]
	internal struct InternalMeshRendererSettings // TypeDefIndex: 8366
	{
		// Fields
		public static readonly InternalMeshRendererSettings Default; // 0x00
		private uint m_RenderingLayerMask; // 0x00
		private ushort m_Data; // 0x04
		private byte m_ObjectLayer; // 0x06
	
		// Properties
		public uint RenderingLayerMask { get; } // 0x0000000180732D10-0x0000000180732D20 
		public byte ObjectLayer { get; } // 0x000000018225CCA0-0x000000018225CCB0 
		public bool StaticShadowCaster { get; } // 0x000000018225B830-0x000000018225B840 
		public ShadowCastingMode ShadowCastingMode { get; } // 0x000000018225CCB0-0x000000018225CCC0 
		public LightProbeUsage LightProbeUsage { get; } // 0x000000018225CC80-0x000000018225CC90 
		public MotionVectorGenerationMode MotionVectorGenerationMode { get; } // 0x000000018225CC90-0x000000018225CCA0 
		public bool SmallMeshCulling { get; } // 0x000000018225CCC0-0x000000018225CCD0 
		public bool IsPartOfStaticBatch { get; } // 0x000000018225CC70-0x000000018225CC80 
		internal bool HasTree { get; } // 0x000000018225CC60-0x000000018225CC70 
	
		// Constructors
		public InternalMeshRendererSettings(uint renderingLayerMask, byte objectLayer, bool receiveShadows, bool staticShadowCaster, ShadowCastingMode shadowCastingMode, LightProbeUsage lightProbeUsage, MotionVectorGenerationMode motionMode, bool smallMeshCulling, bool isPartOfStaticBatch); // 0x000000018225CB60-0x000000018225CC60
		static InternalMeshRendererSettings(); // 0x000000018225CAB0-0x000000018225CB60
	}
}
