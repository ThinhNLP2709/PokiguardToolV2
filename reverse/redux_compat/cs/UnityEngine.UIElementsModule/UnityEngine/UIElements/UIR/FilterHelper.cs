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
	internal static class FilterHelper // TypeDefIndex: 5048
	{
		// Fields
		private static readonly int s_MainTexId; // 0x00
	
		// Constructors
		static FilterHelper(); // 0x0000000182410840-0x0000000182410890
	
		// Methods
		public static void ApplyFilterPass(RenderTexture source, RenderTexture target, PostProcessingPass pass, FilterFunction filterFunc, int filterPassIndex, MaterialPropertyBlock propertyBlock, bool readsGamma, bool writesGamma, bool outputLinear, float pixelsPerPoint, Rect? sourceUVRect = default, RectInt? drawBounds = default, Rect? viewport = default, bool usePixelMatrix = true /* Metadata: 0x00660A20 */); // 0x0000000182410000-0x0000000182410840
		public static RenderTexture ApplyFilterChain(RenderTexture source, ReadOnlySpan<UnmanagedFilterFunction> filters, float pixelsPerPoint, RenderTextureReadWrite colorSpace, bool readsGamma, bool writesGamma, MaterialPropertyBlock propertyBlock, bool usePixelMatrix = true /* Metadata: 0x00660A21 */, bool skipCustomFilters = false /* Metadata: 0x00660A22 */); // 0x000000018240F9F0-0x0000000182410000
	}
}
