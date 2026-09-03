/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 3: Unity.RenderPipelines.Core.Runtime.dll - Assembly: Unity.RenderPipelines.Core.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 5299-6022

namespace UnityEngine.Rendering
{
	[Serializable]
	public class VrsLut // TypeDefIndex: 5860
	{
		// Fields
		[SerializeField]
		private Color[] m_Data; // 0x10
		private const uint Rate1x = 0; // Metadata: 0x00661B76
		private const uint Rate2x = 1; // Metadata: 0x00661B77
		private const uint Rate4x = 2; // Metadata: 0x00661B78
	
		// Properties
		public Color this[ShadingRateFragmentSize fragmentSize] { get => default; set {} } // 0x0000000181ED21A0-0x0000000181ED21E0 0x0000000181ED21E0-0x0000000181ED2220
	
		// Constructors
		public VrsLut(); // 0x0000000181ED2110-0x0000000181ED21A0
	
		// Methods
		public static VrsLut CreateDefault(); // 0x0000000181ED1EA0-0x0000000181ED2080
		public GraphicsBuffer CreateBuffer(bool forVisualization = false /* Metadata: 0x00661B75 */); // 0x0000000181ED1AF0-0x0000000181ED1EA0
		private uint MapFragmentShadingRateToBinary(ShadingRateFragmentSize fs); // 0x0000000181ED2090-0x0000000181ED2110
		private uint EncodeShadingRate(uint x, uint y); // 0x0000000181ED2080-0x0000000181ED2090
	}
}
