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
	public class HableCurve // TypeDefIndex: 5774
	{
		// Fields
		[CompilerGenerated]
		private float _whitePoint_k__BackingField; // 0x10
		[CompilerGenerated]
		private float _inverseWhitePoint_k__BackingField; // 0x14
		[CompilerGenerated]
		private float _x0_k__BackingField; // 0x18
		[CompilerGenerated]
		private float _x1_k__BackingField; // 0x1C
		public readonly Segment[] segments; // 0x20
		public readonly Uniforms uniforms; // 0x28
	
		// Properties
		public float whitePoint { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001807187E0-0x00000001807187F0 0x00000001807187F0-0x0000000180718800
		public float inverseWhitePoint { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181120AA0-0x0000000181120AB0 0x0000000181C40AB0-0x0000000181C40AC0
		public float x0 { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x00000001806CB0A0-0x00000001806CB0B0 0x0000000180FB0A90-0x0000000180FB0AA0
		public float x1 { [CompilerGenerated] get; [CompilerGenerated] private set; } // 0x0000000181CE2A30-0x0000000181CE2A40 0x0000000181EB7970-0x0000000181EB7980
	
		// Nested types
		public class Segment // TypeDefIndex: 5775
		{
			// Fields
			public float offsetX; // 0x10
			public float offsetY; // 0x14
			public float scaleX; // 0x18
			public float scaleY; // 0x1C
			public float lnA; // 0x20
			public float B; // 0x24
	
			// Constructors
			public Segment(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public float Eval(float x); // 0x0000000181EB92F0-0x0000000181EB9340
		}
	
		private struct DirectParams // TypeDefIndex: 5776
		{
			// Fields
			internal float x0; // 0x00
			internal float y0; // 0x04
			internal float x1; // 0x08
			internal float y1; // 0x0C
			internal float W; // 0x10
			internal float overshootX; // 0x14
			internal float overshootY; // 0x18
			internal float gamma; // 0x1C
		}
	
		public class Uniforms // TypeDefIndex: 5777
		{
			// Fields
			private HableCurve parent; // 0x10
	
			// Properties
			public Vector4 curve { get; } // 0x0000000181EBC4F0-0x0000000181EBC530 
			public Vector4 toeSegmentA { get; } // 0x0000000181EBC750-0x0000000181EBC7F0 
			public Vector4 toeSegmentB { get; } // 0x0000000181EBC7F0-0x0000000181EBC860 
			public Vector4 midSegmentA { get; } // 0x0000000181EBC530-0x0000000181EBC5D0 
			public Vector4 midSegmentB { get; } // 0x0000000181EBC5D0-0x0000000181EBC640 
			public Vector4 shoSegmentA { get; } // 0x0000000181EBC640-0x0000000181EBC6E0 
			public Vector4 shoSegmentB { get; } // 0x0000000181EBC6E0-0x0000000181EBC750 
	
			// Constructors
			internal Uniforms(HableCurve parent); // 0x00000001803855F0-0x0000000180385630
		}
	
		// Constructors
		public HableCurve(); // 0x0000000181EB7800-0x0000000181EB7970
	
		// Methods
		public float Eval(float x); // 0x0000000181EB6FB0-0x0000000181EB7050
		public void Init(float toeStrength, float toeLength, float shoulderStrength, float shoulderLength, float shoulderAngle, float gamma); // 0x0000000181EB7590-0x0000000181EB7790
		private void InitSegments(DirectParams srcParams); // 0x0000000181EB7050-0x0000000181EB7590
		private void SolveAB(out float lnA, out float B, float x0, float y0, float m); // 0x0000000181EB7790-0x0000000181EB7800
		private void AsSlopeIntercept(out float m, out float b, float x0, float x1, float y0, float y1); // 0x0000000181EB6F00-0x0000000181EB6F60
		private float EvalDerivativeLinearGamma(float m, float b, float g, float x); // 0x0000000181EB6F60-0x0000000181EB6FB0
	}
}
