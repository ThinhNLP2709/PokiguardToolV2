/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Rendering;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Experimental.Rendering
{
	[NativeHeader("Runtime/Graphics/GraphicsFormatUtility.bindings.h")]
	[NativeHeader("Runtime/Graphics/Format.h")]
	[NativeHeader("Runtime/Graphics/TextureFormat.h")]
	public class GraphicsFormatUtility // TypeDefIndex: 8238
	{
		// Fields
		private static readonly GraphicsFormat[] tableNoStencil; // 0x00
		private static readonly GraphicsFormat[] tableStencil; // 0x08
	
		// Constructors
		static GraphicsFormatUtility(); // 0x0000000182247470-0x0000000182247560
	
		// Methods
		[FreeFunction("GetGraphicsFormat_Native_Texture")]
		internal static GraphicsFormat GetFormat([NotNull] Texture texture); // 0x0000000182246CB0-0x0000000182246D70
		public static GraphicsFormat GetGraphicsFormat(TextureFormat format, bool isSRGB); // 0x0000000182246F40-0x0000000182246FC0
		[FreeFunction(IsThreadSafe = true)]
		private static GraphicsFormat GetGraphicsFormat_Native_TextureFormat(TextureFormat format, bool isSRGB); // 0x0000000182246DB0-0x0000000182246DF0
		public static GraphicsFormat GetGraphicsFormat(RenderTextureFormat format, bool isSRGB); // 0x0000000182246EC0-0x0000000182246F40
		[FreeFunction(IsThreadSafe = false)]
		private static GraphicsFormat GetGraphicsFormat_Native_RenderTextureFormat(RenderTextureFormat format, bool isSRGB); // 0x0000000182246D70-0x0000000182246DB0
		public static GraphicsFormat GetGraphicsFormat(RenderTextureFormat format, RenderTextureReadWrite readWrite); // 0x0000000182246DF0-0x0000000182246EC0
		[FreeFunction(IsThreadSafe = true)]
		private static GraphicsFormat GetDepthStencilFormatFromBitsLegacy_Native(int minimumDepthBits); // 0x0000000182246820-0x0000000182246860
		public static GraphicsFormat GetDepthStencilFormat(int depthBits); // 0x0000000182246860-0x00000001822468D0
		[FreeFunction(IsThreadSafe = true)]
		public static int GetDepthBits(GraphicsFormat format); // 0x00000001822467E0-0x0000000182246820
		public static GraphicsFormat GetDepthStencilFormat(int minimumDepthBits, int minimumStencilBits); // 0x00000001822468D0-0x0000000182246B30
		[FreeFunction(IsThreadSafe = true)]
		public static bool IsSRGBFormat(GraphicsFormat format); // 0x00000001822473F0-0x0000000182247430
		[FreeFunction(IsThreadSafe = true)]
		public static GraphicsFormat GetSRGBFormat(GraphicsFormat format); // 0x0000000182247040-0x0000000182247080
		[FreeFunction(IsThreadSafe = true)]
		public static GraphicsFormat GetLinearFormat(GraphicsFormat format); // 0x0000000182246FC0-0x0000000182247000
		[FreeFunction(IsThreadSafe = true)]
		public static RenderTextureFormat GetRenderTextureFormat(GraphicsFormat format); // 0x0000000182247000-0x0000000182247040
		[FreeFunction(IsThreadSafe = true)]
		public static uint GetAlphaComponentCount(GraphicsFormat format); // 0x0000000182246720-0x0000000182246760
		[FreeFunction(IsThreadSafe = true)]
		public static uint GetComponentCount(GraphicsFormat format); // 0x00000001822467A0-0x00000001822467E0
		[FreeFunction(IsThreadSafe = true)]
		public static string GetFormatString(GraphicsFormat format); // 0x0000000182246B70-0x0000000182246C70
		[FreeFunction(IsThreadSafe = true)]
		private static bool IsCompressedFormat_Native_TextureFormat(TextureFormat format); // 0x0000000182247200-0x0000000182247240
		public static bool IsCompressedFormat(TextureFormat format); // 0x0000000182247240-0x00000001822472B0
		[FreeFunction(IsThreadSafe = true)]
		private static bool CanDecompressFormat(GraphicsFormat format, bool wholeImage); // 0x00000001822466E0-0x0000000182246720
		internal static bool CanDecompressFormat(GraphicsFormat format); // 0x0000000182246670-0x00000001822466E0
		[FreeFunction(IsThreadSafe = true)]
		public static bool IsAlphaOnlyFormat(GraphicsFormat format); // 0x00000001822471C0-0x0000000182247200
		[FreeFunction(IsThreadSafe = true)]
		public static bool HasAlphaChannel(GraphicsFormat format); // 0x0000000182247180-0x00000001822471C0
		[FreeFunction(IsThreadSafe = true)]
		public static bool IsDepthFormat(GraphicsFormat format); // 0x00000001822472F0-0x0000000182247330
		[FreeFunction(IsThreadSafe = true)]
		public static bool IsStencilFormat(GraphicsFormat format); // 0x0000000182247430-0x0000000182247470
		[FreeFunction(IsThreadSafe = true)]
		public static bool IsDepthStencilFormat(GraphicsFormat format); // 0x0000000182247330-0x0000000182247370
		[FreeFunction(IsThreadSafe = true)]
		[Obsolete("Texture compression format PVRTC has been deprecated and will be removed in a future release", false)]
		public static bool IsPVRTCFormat(GraphicsFormat format); // 0x00000001822473B0-0x00000001822473F0
		[FreeFunction(IsThreadSafe = true)]
		public static bool IsHDRFormat(GraphicsFormat format); // 0x0000000182247370-0x00000001822473B0
		[FreeFunction("IsCompressedCrunchTextureFormat", IsThreadSafe = true)]
		public static bool IsCrunchFormat(TextureFormat format); // 0x00000001822472B0-0x00000001822472F0
		[FreeFunction(IsThreadSafe = true)]
		public static FormatSwizzle GetSwizzleR(GraphicsFormat format); // 0x0000000182247140-0x0000000182247180
		[FreeFunction(IsThreadSafe = true)]
		public static FormatSwizzle GetSwizzleG(GraphicsFormat format); // 0x0000000182247100-0x0000000182247140
		[FreeFunction(IsThreadSafe = true)]
		public static FormatSwizzle GetSwizzleB(GraphicsFormat format); // 0x00000001822470C0-0x0000000182247100
		[FreeFunction(IsThreadSafe = true)]
		public static FormatSwizzle GetSwizzleA(GraphicsFormat format); // 0x0000000182247080-0x00000001822470C0
		[FreeFunction(IsThreadSafe = true)]
		public static uint GetBlockSize(GraphicsFormat format); // 0x0000000182246760-0x00000001822467A0
		private static GraphicsFormat GetFormat_Injected(IntPtr texture); // 0x0000000182246C70-0x0000000182246CB0
		private static void GetFormatString_Injected(GraphicsFormat format, ); // 0x0000000182246B30-0x0000000182246B70
	}
}
