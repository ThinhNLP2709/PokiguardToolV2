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
	public static class LightUnitUtils // TypeDefIndex: 5782
	{
		// Fields
		public const float SphereSolidAngle = 12.566371f; // Metadata: 0x00661B0A
	
		// Properties
		private static float k_LuminanceToEvFactor { get; } // 0x0000000181EC1650-0x0000000181EC1700 
		private static float k_EvToLuminanceFactor { get; } // 0x0000000181EC1630-0x0000000181EC1650 
	
		// Methods
		public static LightUnit GetNativeLightUnit(LightType lightType); // 0x0000000181EC1090-0x0000000181EC1130
		public static bool IsLightUnitSupported(LightType lightType, LightUnit lightUnit); // 0x0000000181EC1530-0x0000000181EC15A0
		public static float GetSolidAngleFromPointLight(); // 0x0000000181EC1130-0x0000000181EC1140
		public static float GetSolidAngleFromSpotLight(float spotAngle); // 0x0000000181EC1240-0x0000000181EC12D0
		public static float GetSolidAngleFromPyramidLight(float spotAngle, float aspectRatio); // 0x0000000181EC1140-0x0000000181EC1240
		internal static float GetSolidAngle(LightType lightType, bool spotReflector, float spotAngle, float aspectRatio); // 0x0000000181EC12D0-0x0000000181EC1530
		public static float GetAreaFromRectangleLight(float rectSizeX, float rectSizeY); // 0x0000000181EC1020-0x0000000181EC1040
		public static float GetAreaFromRectangleLight(Vector2 rectSize); // 0x0000000181EC1040-0x0000000181EC1070
		public static float GetAreaFromDiscLight(float discRadius); // 0x0000000181EC1000-0x0000000181EC1020
		public static float GetAreaFromTubeLight(float tubeLength); // 0x0000000181EC1070-0x0000000181EC1090
		public static float LumenToCandela(float lumen, float solidAngle); // 0x0000000181EC15A0-0x0000000181EC15B0
		public static float CandelaToLumen(float candela, float solidAngle); // 0x0000000181EC05A0-0x0000000181EC05B0
		public static float LumenToNits(float lumen, float area); // 0x0000000181EC15A0-0x0000000181EC15B0
		public static float NitsToLumen(float nits, float area); // 0x0000000181EC05A0-0x0000000181EC05B0
		public static float LuxToCandela(float lux, float distance); // 0x0000000181EC15B0-0x0000000181EC15C0
		public static float CandelaToLux(float candela, float distance); // 0x0000000181EC05B0-0x0000000181EC05C0
		public static float Ev100ToNits(float ev100); // 0x0000000181EC0FC0-0x0000000181EC1000
		public static float NitsToEv100(float nits); // 0x0000000181EC15C0-0x0000000181EC1630
		public static float Ev100ToCandela(float ev100); // 0x0000000181EC0FC0-0x0000000181EC1000
		public static float CandelaToEv100(float candela); // 0x0000000181EC0590-0x0000000181EC05A0
		internal static float ConvertIntensityInternal(float intensity, LightUnit fromUnit, LightUnit toUnit, LightType lightType, float area, float luxAtDistance, float solidAngle); // 0x0000000181EC05C0-0x0000000181EC0DC0
		public static float ConvertIntensity(Light light, float intensity, LightUnit fromUnit, LightUnit toUnit); // 0x0000000181EC0DC0-0x0000000181EC0FC0
	}
}
