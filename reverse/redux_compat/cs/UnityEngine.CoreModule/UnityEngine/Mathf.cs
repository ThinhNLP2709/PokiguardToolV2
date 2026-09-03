/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;
using UnityEngine.Bindings;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Il2CppEagerStaticClassConstruction]
	[NativeHeader("Runtime/Math/ColorSpaceConversion.h")]
	[NativeHeader("NativeKernel/Math/FloatConversion.h")]
	[NativeHeader("Runtime/Math/PerlinNoise.h")]
	public struct Mathf // TypeDefIndex: 7667
	{
		// Fields
		public static readonly float Epsilon; // 0x00
		private static readonly float ApproxEpsilon; // 0x04
	
		// Constructors
		static Mathf(); // 0x00000001821ED3A0-0x00000001821ED420
	
		// Methods
		[FreeFunction(IsThreadSafe = true)]
		public static float GammaToLinearSpace(float value); // 0x00000001821ECB60-0x00000001821ECBA0
		[FreeFunction(IsThreadSafe = true)]
		public static float LinearToGammaSpace(float value); // 0x00000001821ECC20-0x00000001821ECC60
		[FreeFunction(IsThreadSafe = true)]
		public static Color CorrelatedColorTemperatureToRGB(float kelvin); // 0x00000001821EC8F0-0x00000001821EC940
		[FreeFunction(IsThreadSafe = true)]
		public static ushort FloatToHalf(float val); // 0x00000001821ECA60-0x00000001821ECAA0
		[FreeFunction(IsThreadSafe = true)]
		public static float HalfToFloat(ushort val); // 0x00000001821ECBA0-0x00000001821ECBE0
		[FreeFunction("PerlinNoise::NoiseNormalized", IsThreadSafe = true)]
		public static float PerlinNoise(float x, float y); // 0x00000001821ECE40-0x00000001821ECE90
		public static float Sin(float f); // 0x00000001821ED0A0-0x00000001821ED100
		public static float Cos(float f); // 0x00000001821EC940-0x00000001821EC9A0
		public static float Tan(float f); // 0x00000001821ED340-0x00000001821ED3A0
		public static float Asin(float f); // 0x00000001821EC5A0-0x00000001821EC600
		public static float Acos(float f); // 0x00000001821EC500-0x00000001821EC560
		public static float Atan(float f); // 0x00000001821EC670-0x00000001821EC6D0
		public static float Atan2(float y, float x); // 0x00000001821EC600-0x00000001821EC670
		public static float Sqrt(float f); // 0x00000001821ED2C0-0x00000001821ED340
		public static float Abs(float f); // 0x00000001821EC450-0x00000001821EC4B0
		public static int Abs(int value); // 0x00000001821EC4B0-0x00000001821EC500
		public static float Min(float a, float b); // 0x00000001821ECDB0-0x00000001821ECDC0
		public static int Min(int a, int b); // 0x0000000180313B00-0x0000000180313B10
		public static float Max(float a, float b); // 0x00000001821ECDA0-0x00000001821ECDB0
		public static int Max(int a, int b); // 0x00000001821ECD90-0x00000001821ECDA0
		public static float Pow(float f, float p); // 0x00000001821ECF00-0x00000001821ECF70
		public static float Exp(float power); // 0x00000001821ECA00-0x00000001821ECA60
		public static float Log(float f, float p); // 0x00000001821ECCC0-0x00000001821ECD30
		public static float Log(float f); // 0x00000001821ECD30-0x00000001821ECD90
		public static float Log10(float f); // 0x00000001821ECC60-0x00000001821ECCC0
		public static float Ceil(float f); // 0x00000001821EC730-0x00000001821EC790
		public static float Floor(float f); // 0x00000001821ECB00-0x00000001821ECB60
		public static float Round(float f); // 0x00000001821ED020-0x00000001821ED080
		public static int CeilToInt(float f); // 0x00000001821EC6D0-0x00000001821EC730
		public static int FloorToInt(float f); // 0x00000001821ECAA0-0x00000001821ECB00
		public static int RoundToInt(float f); // 0x00000001821ECFC0-0x00000001821ED020
		public static float Sign(float f); // 0x00000001821ED080-0x00000001821ED0A0
		public static float Clamp(float value, float min, float max); // 0x00000001821EC830-0x00000001821EC850
		public static int Clamp(int value, int min, int max); // 0x00000001821EC810-0x00000001821EC830
		public static float Clamp01(float value); // 0x00000001821EC790-0x00000001821EC7B0
		public static float Lerp(float a, float b, float t); // 0x00000001806D9B50-0x00000001806D9B80
		public static float LerpUnclamped(float a, float b, float t); // 0x00000001821ECC10-0x00000001821ECC20
		public static float MoveTowards(float current, float target, float maxDelta); // 0x00000001821ECDC0-0x00000001821ECE10
		public static float SmoothStep(float from, float to, float t); // 0x00000001821ED260-0x00000001821ED2C0
		public static bool Approximately(float a, float b); // 0x00000001821EC560-0x00000001821EC5A0
		public static float SmoothDamp(float current, float target, ref float currentVelocity, float smoothTime, [DefaultValue("Mathf.Infinity")] float maxSpeed, [DefaultValue("Time.deltaTime")] float deltaTime); // 0x00000001821ED100-0x00000001821ED260
		public static float Repeat(float t, float length); // 0x00000001821ECF70-0x00000001821ECFC0
		public static float PingPong(float t, float length); // 0x00000001821ECE90-0x00000001821ECF00
		public static float InverseLerp(float a, float b, float value); // 0x00000001821ECBE0-0x00000001821ECC10
		public static float DeltaAngle(float current, float target); // 0x00000001821EC9A0-0x00000001821ECA00
		[VisibleToOtherModules(new string[1] {"UnityEngine.UIElementsModule" })]
		internal static float ClampToFloat(double value); // 0x00000001821EC7B0-0x00000001821EC810
		public static int NextPowerOfTwo(int value); // 0x00000001821ECE10-0x00000001821ECE40
		public static int ClosestPowerOfTwo(int value); // 0x00000001821EC850-0x00000001821EC8A0
		public static bool IsPowerOfTwo(int value); // 0x0000000181C8CBF0-0x0000000181C8CC00
		private static void CorrelatedColorTemperatureToRGB_Injected(float kelvin, ); // 0x00000001821EC8A0-0x00000001821EC8F0
	}
}
