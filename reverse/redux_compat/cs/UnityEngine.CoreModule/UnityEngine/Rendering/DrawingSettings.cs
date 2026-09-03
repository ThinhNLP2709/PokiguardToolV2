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
	public struct DrawingSettings : IEquatable<DrawingSettings> // TypeDefIndex: 8409
	{
		// Fields
		public static readonly int maxShaderPasses; // 0x00
		private SortingSettings m_SortingSettings; // 0x00
		internal unsafe fixed /* 0x00000000-0x00000000 */ int shaderPassNames[0]; // 0x60
		private PerObjectData m_PerObjectData; // 0xA0
		private DrawRendererFlags m_Flags; // 0xA4
		private EntityId m_OverrideShaderID; // 0xA8
		private int m_OverrideShaderPassIndex; // 0xB0
		private EntityId m_OverrideMaterialEntityId; // 0xB8
		private int m_OverrideMaterialPassIndex; // 0xC0
		private EntityId m_fallbackMaterialEntityId; // 0xC8
		private int m_MainLightIndex; // 0xD0
		private int m_UseSrpBatcher; // 0xD4
		private int m_LodCrossFadeStencilMask; // 0xD8
		private CullingSplitMask m_SplitMask; // 0xDC
	
		// Properties
		public PerObjectData perObjectData { set; } // 0x000000018033E7D0-0x000000018033E7E0
		public bool enableInstancing { set; } // 0x000000018225A820-0x000000018225A840
		public Material overrideMaterial { set; } // 0x000000018225A840-0x000000018225A880
		public Shader overrideShader { set; } // 0x000000018225A880-0x000000018225A8C0
		public int overrideMaterialPassIndex { set; } // 0x000000018170C650-0x000000018170C660
		public int overrideShaderPassIndex { set; } // 0x0000000181727410-0x0000000181727420
		public int mainLightIndex { set; } // 0x0000000181DB5420-0x0000000181DB5430
		public int lodCrossFadeStencilMask { set; } // 0x00000001819DD210-0x00000001819DD220
		public CullingSplitMask splitMask { set; } // 0x000000018225A8C0-0x000000018225A8D0
	
		// Nested types
		[CompilerGenerated]
		[UnsafeValueType]
		public struct _shaderPassNames_e__FixedBuffer // TypeDefIndex: 8410
		{
			// Fields
			public int FixedElementField; // 0x00
		}
	
		// Constructors
		public unsafe DrawingSettings(ShaderTagId shaderPassName, SortingSettings sortingSettings); // 0x000000018225A5F0-0x000000018225A730
		static DrawingSettings(); // 0x000000018225A5B0-0x000000018225A5F0
	
		// Methods
		public ShaderTagId GetShaderPassName(int index); // 0x000000018225A340-0x000000018225A470
		public void SetShaderPassName(int index, ShaderTagId shaderPassName); // 0x000000018225A470-0x000000018225A5B0
		public bool Equals(DrawingSettings other); // 0x0000000182259BE0-0x000000018225A270
		public override bool Equals(object obj); // 0x0000000182259AA0-0x0000000182259BE0
		public override int GetHashCode(); // 0x000000018225A270-0x000000018225A340
		public static bool operator ==(DrawingSettings left, DrawingSettings right); // 0x000000018225A730-0x000000018225A820
	}
}
