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

namespace UnityEngine
{
	[NativeClass("Light", PersistentTypeId = 108)]
	[NativeHeader("Runtime/Export/Graphics/Light.bindings.h")]
	[RequireComponent(typeof(Transform))]
	public sealed class Light : Behaviour // TypeDefIndex: 7621
	{
		// Properties
		public LightShadows shadows { [NativeMethod("GetShadowType")] get; } // 0x00000001821A5120-0x00000001821A5180 
		public float shadowStrength { get; [FreeFunction("Light_Bindings::SetShadowStrength", HasExplicitThis = true)] set; } // 0x00000001821A5080-0x00000001821A50E0 0x00000001821A5720-0x00000001821A5790
		public LightShadowResolution shadowResolution { get; } // 0x00000001821A4490-0x00000001821A44F0 
		private LightShadowResolution ShadowResolution { get; } // 0x00000001821A4490-0x00000001821A44F0 
		public Vector2 cookieSize2D { get; } // 0x00000001821A48C0-0x00000001821A4930 
		public Texture cookie { get; } // 0x00000001821A4970-0x00000001821A4A00 
		public Vector2 areaSize { get; } // 0x00000001821A4540-0x00000001821A45B0 
		[NativeProperty("LightType")]
		public LightType type { get; } // 0x00000001821A5300-0x00000001821A5360 
		public float spotAngle { get; } // 0x00000001821A5260-0x00000001821A52C0 
		public float innerSpotAngle { get; } // 0x00000001821A4C20-0x00000001821A4C80 
		public Color color { get; set; } // 0x00000001821A4800-0x00000001821A4870 0x00000001821A5450-0x00000001821A54B0
		public float colorTemperature { get; } // 0x00000001821A4750-0x00000001821A47B0 
		public bool useColorTemperature { get; } // 0x00000001821A53A0-0x00000001821A5400 
		public float intensity { get; set; } // 0x00000001821A4CC0-0x00000001821A4D20 0x00000001821A5500-0x00000001821A5570
		public float bounceIntensity { get; } // 0x00000001821A46B0-0x00000001821A4710 
		public float luxAtDistance { get; } // 0x00000001821A4D60-0x00000001821A4DC0 
		public bool enableSpotReflector { get; } // 0x00000001821A4B80-0x00000001821A4BE0 
		public float shadowBias { get; } // 0x00000001821A4EA0-0x00000001821A4F00 
		public float shadowNormalBias { get; } // 0x00000001821A4FE0-0x00000001821A5040 
		public float shadowNearPlane { get; } // 0x00000001821A4F40-0x00000001821A4FA0 
		public float range { get; set; } // 0x00000001821A4E00-0x00000001821A4E60 0x00000001821A55C0-0x00000001821A5630
		public float dilatedRange { get; } // 0x00000001821A4AE0-0x00000001821A4B40 
		public LightBakingOutput bakingOutput { get; } // 0x00000001821A4600-0x00000001821A4670 
		public int cullingMask { get; } // 0x00000001821A4A40-0x00000001821A4AA0 
		public int renderingLayerMask { set; } // 0x00000001821A5670-0x00000001821A56D0
		public float shapeRadius { get; } // 0x00000001821A51C0-0x00000001821A5220 
	
		// Constructors
		public Light(); // 0x00000001802E7A70-0x00000001802E7BC0
	
		// Methods
		private static LightShadows get_shadows_Injected(IntPtr _unity_self); // 0x00000001821A50E0-0x00000001821A5120
		private static float get_shadowStrength_Injected(IntPtr _unity_self); // 0x00000001821A5040-0x00000001821A5080
		private static void set_shadowStrength_Injected(IntPtr _unity_self, float value); // 0x00000001821A56D0-0x00000001821A5720
		private static LightShadowResolution get_ShadowResolution_Injected(IntPtr _unity_self); // 0x00000001821A4450-0x00000001821A4490
		private static void get_cookieSize2D_Injected(IntPtr _unity_self, ); // 0x00000001821A4870-0x00000001821A48C0
		private static IntPtr get_cookie_Injected(IntPtr _unity_self); // 0x00000001821A4930-0x00000001821A4970
		private static void get_areaSize_Injected(IntPtr _unity_self, ); // 0x00000001821A44F0-0x00000001821A4540
		private static LightType get_type_Injected(IntPtr _unity_self); // 0x00000001821A52C0-0x00000001821A5300
		private static float get_spotAngle_Injected(IntPtr _unity_self); // 0x00000001821A5220-0x00000001821A5260
		private static float get_innerSpotAngle_Injected(IntPtr _unity_self); // 0x00000001821A4BE0-0x00000001821A4C20
		private static void get_color_Injected(IntPtr _unity_self, ); // 0x00000001821A47B0-0x00000001821A4800
		private static void set_color_Injected(IntPtr _unity_self, in Color value); // 0x00000001821A5400-0x00000001821A5450
		private static float get_colorTemperature_Injected(IntPtr _unity_self); // 0x00000001821A4710-0x00000001821A4750
		private static bool get_useColorTemperature_Injected(IntPtr _unity_self); // 0x00000001821A5360-0x00000001821A53A0
		private static float get_intensity_Injected(IntPtr _unity_self); // 0x00000001821A4C80-0x00000001821A4CC0
		private static void set_intensity_Injected(IntPtr _unity_self, float value); // 0x00000001821A54B0-0x00000001821A5500
		private static float get_bounceIntensity_Injected(IntPtr _unity_self); // 0x00000001821A4670-0x00000001821A46B0
		private static float get_luxAtDistance_Injected(IntPtr _unity_self); // 0x00000001821A4D20-0x00000001821A4D60
		private static bool get_enableSpotReflector_Injected(IntPtr _unity_self); // 0x00000001821A4B40-0x00000001821A4B80
		private static float get_shadowBias_Injected(IntPtr _unity_self); // 0x00000001821A4E60-0x00000001821A4EA0
		private static float get_shadowNormalBias_Injected(IntPtr _unity_self); // 0x00000001821A4FA0-0x00000001821A4FE0
		private static float get_shadowNearPlane_Injected(IntPtr _unity_self); // 0x00000001821A4F00-0x00000001821A4F40
		private static float get_range_Injected(IntPtr _unity_self); // 0x00000001821A4DC0-0x00000001821A4E00
		private static void set_range_Injected(IntPtr _unity_self, float value); // 0x00000001821A5570-0x00000001821A55C0
		private static float get_dilatedRange_Injected(IntPtr _unity_self); // 0x00000001821A4AA0-0x00000001821A4AE0
		private static void get_bakingOutput_Injected(IntPtr _unity_self, ); // 0x00000001821A45B0-0x00000001821A4600
		private static int get_cullingMask_Injected(IntPtr _unity_self); // 0x00000001821A4A00-0x00000001821A4A40
		private static void set_renderingLayerMask_Injected(IntPtr _unity_self, int value); // 0x00000001821A5630-0x00000001821A5670
		private static float get_shapeRadius_Injected(IntPtr _unity_self); // 0x00000001821A5180-0x00000001821A51C0
	}
}
