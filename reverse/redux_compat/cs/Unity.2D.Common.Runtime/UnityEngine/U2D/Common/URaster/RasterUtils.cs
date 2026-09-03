/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

// Image 36: Unity.2D.Common.Runtime.dll - Assembly: Unity.2D.Common.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14954-14996

namespace UnityEngine.U2D.Common.URaster
{
	internal struct RasterUtils // TypeDefIndex: 14993
	{
		// Methods
		internal static unsafe Color32* GetPixelOffsetBuffer(int offset, Color32* pixels); // 0x0000000181C388A0-0x0000000181C388B0
		internal static unsafe Color32 GetPixel(Color32* pixels, ref int2 textureCfg, int x, int y); // 0x0000000181C388B0-0x0000000181C388C0
		internal static byte Color32ToByte(Color32 rgba); // 0x0000000181C38800-0x0000000181C388A0
		internal static Color32 ByteToColor32(byte rgba); // 0x0000000181C387C0-0x0000000181C38800
		internal static float Min3(float a, float b, float c); // 0x0000000181C38900-0x0000000181C38930
		internal static float Max3(float a, float b, float c); // 0x0000000181C388D0-0x0000000181C38900
		internal static int Orient2d(float2 a, float2 b, float2 c); // 0x0000000181C38930-0x0000000181C38990
		internal static bool IsValidColorByte(byte c); // 0x0000000181C388C0-0x0000000181C388D0
		internal static unsafe byte Pixelate(ref Pixels pixelMask, ref int2 textureCfg, Color32* pixels, byte fillColorByte, int sx, int sy, int x, int y); // 0x0000000181C38AF0-0x0000000181C38C30
		internal static void Pad(ref Pixels pixelMask, byte srcColorByte, byte tgtColorByte, int dx, int dy, int padx, int pady); // 0x0000000181C38990-0x0000000181C38AF0
		internal static unsafe void RasterizeTriangle(ref Pixels pixelMask, Color32* pixels, ref int2 textureCfg, byte fillColorByte, ref float2 v0, ref float2 v1, ref float2 v2, int padx, int pady); // 0x0000000181C38C30-0x0000000181C39130
		internal static unsafe bool Rasterize(Color32* pixels, ref int2 textureCfg, Vector2* vertices, int vertexCount, int* indices, int indexCount, ref Pixels pixelMask, int padx, int pady); // 0x0000000181C39130-0x0000000181C39390
		internal static void SaveImage(NativeArray<byte> image, int w, int h, string path); // 0x0000000181C39390-0x0000000181C394F0
	}
}
