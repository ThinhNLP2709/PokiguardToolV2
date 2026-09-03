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
	[Serializable]
	[Obsolete("BatchRendererGroupGlobals and associated cbuffer are now set automatically by Unity. Setting it manually is no longer necessary or supported. #from(2023.1)")]
	public struct BatchRendererGroupGlobals : IEquatable<BatchRendererGroupGlobals> // TypeDefIndex: 5730
	{
		// Fields
		public const string kGlobalsPropertyName = "unity_DOTSInstanceGlobalValues"; // Metadata: 0x00661966
		public static readonly int kGlobalsPropertyId; // 0x00
		public Vector4 ProbesOcclusion; // 0x00
		public Vector4 SpecCube0_HDR; // 0x10
		public Vector4 SpecCube1_HDR; // 0x20
		public SHCoefficients SHCoefficients; // 0x30
	
		// Properties
		public static BatchRendererGroupGlobals Default { get; } // 0x0000000181EA2760-0x0000000181EA2940 
	
		// Constructors
		static BatchRendererGroupGlobals(); // 0x0000000181EA2710-0x0000000181EA2760
	
		// Methods
		public bool Equals(BatchRendererGroupGlobals other); // 0x0000000181EA22A0-0x0000000181EA2580
		public override bool Equals(object obj); // 0x0000000181EA2100-0x0000000181EA22A0
		public override int GetHashCode(); // 0x0000000181EA2580-0x0000000181EA2710
		public static bool operator ==(BatchRendererGroupGlobals left, BatchRendererGroupGlobals right); // 0x0000000181EA2940-0x0000000181EA2A20
		public static bool operator !=(BatchRendererGroupGlobals left, BatchRendererGroupGlobals right); // 0x0000000181EA2A20-0x0000000181EA2B00
	}
}
