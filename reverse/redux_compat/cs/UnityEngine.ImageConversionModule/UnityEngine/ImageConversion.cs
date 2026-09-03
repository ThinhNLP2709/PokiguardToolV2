/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 73: UnityEngine.ImageConversionModule.dll - Assembly: UnityEngine.ImageConversionModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15871-15874

namespace UnityEngine
{
	[NativeHeader("Modules/ImageConversion/ScriptBindings/ImageConversion.bindings.h")]
	public static class ImageConversion // TypeDefIndex: 15874
	{
		// Methods
		private static void EncodeToPNG_Injected(IntPtr tex, ); // 0x00000001822769B0-0x0000000182276A00
		private static void EncodeToR2DInternal_Injected(IntPtr tex, ); // 0x0000000182276B30-0x0000000182276B80
		private static bool LoadImage_Injected(IntPtr tex, ref ManagedSpanWrapper data, bool markNonReadable); // 0x0000000182276CB0-0x0000000182276D10
	
		// Extension methods
		[NativeMethod(Name = "ImageConversionBindings::EncodeToPNG", IsFreeFunction = true, ThrowsException = true)]
		public static byte[] EncodeToPNG(this Texture2D tex); // 0x0000000182276A00-0x0000000182276B30
		[NativeMethod(Name = "ImageConversionBindings::EncodeToR2D", IsFreeFunction = true, ThrowsException = true)]
		internal static byte[] EncodeToR2DInternal(this Texture2D tex); // 0x0000000182276B80-0x0000000182276CB0
		[NativeMethod(Name = "ImageConversionBindings::LoadImage", IsFreeFunction = true)]
		public static bool LoadImage([NotNull] this Texture2D tex, ReadOnlySpan<byte> data, bool markNonReadable); // 0x0000000182276E20-0x0000000182277030
		public static bool LoadImage(this Texture2D tex, byte[] data); // 0x0000000182276D10-0x0000000182276E20
	}
}
