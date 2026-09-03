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
	public static class FSRUtils // TypeDefIndex: 5752
	{
		// Fields
		internal const float kMaxSharpnessStops = 2.5f; // Metadata: 0x00661A8C
		public const float kDefaultSharpnessStops = 0.2f; // Metadata: 0x00661A90
		public const float kDefaultSharpnessLinear = 0.92f; // Metadata: 0x00661A94
	
		// Nested types
		private static class ShaderConstants // TypeDefIndex: 5753
		{
			// Fields
			public static readonly int _FsrEasuConstants0; // 0x00
			public static readonly int _FsrEasuConstants1; // 0x04
			public static readonly int _FsrEasuConstants2; // 0x08
			public static readonly int _FsrEasuConstants3; // 0x0C
			public static readonly int _FsrRcasConstants; // 0x10
	
			// Constructors
			static ShaderConstants(); // 0x0000000181EB9340-0x0000000181EB9440
		}
	
		// Methods
		public static void SetEasuConstants(CommandBuffer cmd, Vector2 inputViewportSizeInPixels, Vector2 inputImageSizeInPixels, Vector2 outputImageSizeInPixels); // 0x0000000181EB43D0-0x0000000181EB46D0
		public static void SetEasuConstants(BaseCommandBuffer cmd, Vector2 inputViewportSizeInPixels, Vector2 inputImageSizeInPixels, Vector2 outputImageSizeInPixels); // 0x0000000181EB46D0-0x0000000181EB4700
		public static void SetRcasConstants(CommandBuffer cmd, float sharpnessStops = 0.2f /* Metadata: 0x00661A7C */); // 0x0000000181EB4760-0x0000000181EB4830
		public static void SetRcasConstants(BaseCommandBuffer cmd, float sharpnessStops = 0.2f /* Metadata: 0x00661A80 */); // 0x0000000181EB4830-0x0000000181EB4850
		public static void SetRcasConstantsLinear(CommandBuffer cmd, float sharpnessLinear = 0.92f /* Metadata: 0x00661A84 */); // 0x0000000181EB4700-0x0000000181EB4720
		public static void SetRcasConstantsLinear(RasterCommandBuffer cmd, float sharpnessLinear = 0.92f /* Metadata: 0x00661A88 */); // 0x0000000181EB4720-0x0000000181EB4760
		public static bool IsSupported(); // 0x0000000181EB43B0-0x0000000181EB43D0
	}
}
