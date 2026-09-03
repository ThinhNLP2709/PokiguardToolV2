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
	public static class ColorUtils // TypeDefIndex: 5746
	{
		// Fields
		private const float k_LightMeterCalibrationConstant = 12.5f; // Metadata: 0x006619B7
		private const float k_LensAttenuation = 0.65f; // Metadata: 0x006619BB
		public static float s_LightMeterCalibrationConstant; // 0x00
		public static float s_LensAttenuation; // 0x04
	
		// Properties
		public static float lensImperfectionExposureScale { get; } // 0x0000000181EAC930-0x0000000181EAC9A0 
	
		// Constructors
		static ColorUtils(); // 0x0000000181EAC8E0-0x0000000181EAC930
	
		// Methods
		public static float StandardIlluminantY(float x); // 0x0000000181EAC7D0-0x0000000181EAC800
		public static Vector3 CIExyToLMS(float x, float y); // 0x0000000181EABBB0-0x0000000181EABC40
		public static Vector3 ColorBalanceToLMSCoeffs(float temperature, float tint); // 0x0000000181EABC40-0x0000000181EABDC0
		public static ValueTuple<Vector4, Vector4, Vector4> PrepareShadowsMidtonesHighlights([IsReadOnly] in Vector4 inShadows, [IsReadOnly] in Vector4 inMidtones, [IsReadOnly] in Vector4 inHighlights); // 0x0000000181EAC4B0-0x0000000181EAC740
		public static ValueTuple<Vector4, Vector4, Vector4> PrepareLiftGammaGain([IsReadOnly] in Vector4 inLift, [IsReadOnly] in Vector4 inGamma, [IsReadOnly] in Vector4 inGain); // 0x0000000181EAC160-0x0000000181EAC4B0
		public static ValueTuple<Vector4, Vector4> PrepareSplitToning([IsReadOnly] in Vector4 inShadows, [IsReadOnly] in Vector4 inHighlights, float balance); // 0x0000000181EAC740-0x0000000181EAC7D0
		public static float Luminance([IsReadOnly] in Color color); // 0x0000000181EAC130-0x0000000181EAC160
		public static float ComputeEV100(float aperture, float shutterSpeed, float ISO); // 0x0000000181EABE70-0x0000000181EABEF0
		public static float ConvertEV100ToExposure(float EV100); // 0x0000000181EABF40-0x0000000181EAC020
		public static float ConvertExposureToEV100(float exposure); // 0x0000000181EAC020-0x0000000181EAC130
		public static float ComputeEV100FromAvgLuminance(float avgLuminance); // 0x0000000181EABDC0-0x0000000181EABE70
		public static float ComputeISO(float aperture, float shutterSpeed, float targetEV100); // 0x0000000181EABEF0-0x0000000181EABF40
		public static uint ToHex(Color c); // 0x0000000181EAC800-0x0000000181EAC860
		public static Color ToRGBA(uint hex); // 0x0000000181EAC860-0x0000000181EAC8E0
	}
}
