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
	[NativeClass("RenderSettings", PersistentTypeId = 104)]
	[NativeHeader("Runtime/Graphics/QualitySettingsTypes.h")]
	[NativeHeader("Runtime/Camera/RenderSettings.h")]
	[StaticAccessor("GetRenderSettings()", StaticAccessorType.Dot)]
	public sealed class RenderSettings : Object // TypeDefIndex: 7571
	{
		// Properties
		[Obsolete("Use RenderSettings.ambientIntensity instead (UnityUpgradable) -> ambientIntensity", false)]
		public static float ambientSkyboxAmount { get; set; } // 0x00000001821BD0B0-0x00000001821BD0E0 0x00000001821BDB30-0x00000001821BDB70
		[NativeProperty("UseFog")]
		public static bool fog { get; set; } // 0x00000001821BD6B0-0x00000001821BD6E0 0x00000001821BE030-0x00000001821BE070
		[NativeProperty("LinearFogStart")]
		public static float fogStartDistance { get; set; } // 0x00000001821BD680-0x00000001821BD6B0 0x00000001821BDFF0-0x00000001821BE030
		[NativeProperty("LinearFogEnd")]
		public static float fogEndDistance { get; set; } // 0x00000001821BD620-0x00000001821BD650 0x00000001821BDF70-0x00000001821BDFB0
		public static FogMode fogMode { get; set; } // 0x00000001821BD650-0x00000001821BD680 0x00000001821BDFB0-0x00000001821BDFF0
		public static Color fogColor { get; set; } // 0x00000001821BD5B0-0x00000001821BD5F0 0x00000001821BDEF0-0x00000001821BDF30
		public static float fogDensity { get; set; } // 0x00000001821BD5F0-0x00000001821BD620 0x00000001821BDF30-0x00000001821BDF70
		public static AmbientMode ambientMode { get; set; } // 0x00000001821BD160-0x00000001821BD190 0x00000001821BDBF0-0x00000001821BDC30
		public static Color ambientSkyColor { get; set; } // 0x00000001821BD270-0x00000001821BD2B0 0x00000001821BDCF0-0x00000001821BDD30
		public static Color ambientEquatorColor { get; set; } // 0x00000001821BCFF0-0x00000001821BD030 0x00000001821BDA70-0x00000001821BDAB0
		public static Color ambientGroundColor { get; set; } // 0x00000001821BD070-0x00000001821BD0B0 0x00000001821BDAF0-0x00000001821BDB30
		public static float ambientIntensity { get; set; } // 0x00000001821BD0B0-0x00000001821BD0E0 0x00000001821BDB30-0x00000001821BDB70
		[NativeProperty("AmbientSkyColor")]
		public static Color ambientLight { get; set; } // 0x00000001821BD120-0x00000001821BD160 0x00000001821BDBB0-0x00000001821BDBF0
		public static Color subtractiveShadowColor { get; set; } // 0x00000001821BD960-0x00000001821BD9A0 0x00000001821BE2F0-0x00000001821BE330
		[NativeProperty("SkyboxMaterial")]
		public static Material skybox { get; set; } // 0x00000001821BD830-0x00000001821BD890 0x00000001821BE1F0-0x00000001821BE230
		public static Light sun { get; set; } // 0x00000001821BD9D0-0x00000001821BDA30 0x00000001821BE370-0x00000001821BE3B0
		public static SphericalHarmonicsL2 ambientProbe { [NativeMethod("GetFinalAmbientProbe")] get; set; } // 0x00000001821BD1D0-0x00000001821BD230 0x00000001821BDC70-0x00000001821BDCB0
		[Obsolete("RenderSettings.customReflection has been deprecated in favor of RenderSettings.customReflectionTexture.", false)]
		public static Cubemap customReflection { get; set; } // 0x00000001821BD340-0x00000001821BD420 0x00000001821BDD70-0x00000001821BDDB0
		[NativeProperty("CustomReflection")]
		public static Texture customReflectionTexture { get; [NativeMethod(ThrowsException = true)] set; } // 0x00000001821BD2E0-0x00000001821BD340 0x00000001821BDD70-0x00000001821BDDB0
		public static float reflectionIntensity { get; set; } // 0x00000001821BD7D0-0x00000001821BD800 0x00000001821BE170-0x00000001821BE1B0
		public static int reflectionBounces { get; set; } // 0x00000001821BD7A0-0x00000001821BD7D0 0x00000001821BE130-0x00000001821BE170
		[NativeProperty("GeneratedSkyboxReflection")]
		internal static Cubemap defaultReflection { get; } // 0x00000001821BD4B0-0x00000001821BD510 
		public static DefaultReflectionMode defaultReflectionMode { get; set; } // 0x00000001821BD420-0x00000001821BD450 0x00000001821BDDB0-0x00000001821BDDF0
		public static int defaultReflectionResolution { get; set; } // 0x00000001821BD450-0x00000001821BD480 0x00000001821BDDF0-0x00000001821BDE30
		public static float haloStrength { get; set; } // 0x00000001821BD6E0-0x00000001821BD710 0x00000001821BE070-0x00000001821BE0B0
		public static float flareStrength { get; set; } // 0x00000001821BD540-0x00000001821BD570 0x00000001821BDE70-0x00000001821BDEB0
		public static float flareFadeSpeed { get; set; } // 0x00000001821BD510-0x00000001821BD540 0x00000001821BDE30-0x00000001821BDE70
		[NativeProperty("DefaultSpotCookie")]
		internal static Texture2D spotCookieTexture { get; set; } // 0x00000001821BD8C0-0x00000001821BD920 0x00000001821BE270-0x00000001821BE2B0
		internal static Texture2D haloTexture { get; set; } // 0x00000001821BD740-0x00000001821BD7A0 0x00000001821BE0F0-0x00000001821BE130
	
		// Constructors
		private RenderSettings(); // 0x00000001821BCF60-0x00000001821BCFB0
	
		// Methods
		[FreeFunction("GetRenderSettings")]
		internal static Object GetRenderSettings(); // 0x00000001821BCED0-0x00000001821BCF30
		[StaticAccessor("RenderSettingsScripting", StaticAccessorType.DoubleColon)]
		internal static void Reset(); // 0x00000001821BCF30-0x00000001821BCF60
		private static void get_fogColor_Injected(); // 0x00000001821BD570-0x00000001821BD5B0
		private static void set_fogColor_Injected(in Color value); // 0x00000001821BDEB0-0x00000001821BDEF0
		private static void get_ambientSkyColor_Injected(); // 0x00000001821BD230-0x00000001821BD270
		private static void set_ambientSkyColor_Injected(in Color value); // 0x00000001821BDCB0-0x00000001821BDCF0
		private static void get_ambientEquatorColor_Injected(); // 0x00000001821BCFB0-0x00000001821BCFF0
		private static void set_ambientEquatorColor_Injected(in Color value); // 0x00000001821BDA30-0x00000001821BDA70
		private static void get_ambientGroundColor_Injected(); // 0x00000001821BD030-0x00000001821BD070
		private static void set_ambientGroundColor_Injected(in Color value); // 0x00000001821BDAB0-0x00000001821BDAF0
		private static void get_ambientLight_Injected(); // 0x00000001821BD0E0-0x00000001821BD120
		private static void set_ambientLight_Injected(in Color value); // 0x00000001821BDB70-0x00000001821BDBB0
		private static void get_subtractiveShadowColor_Injected(); // 0x00000001821BD920-0x00000001821BD960
		private static void set_subtractiveShadowColor_Injected(in Color value); // 0x00000001821BE2B0-0x00000001821BE2F0
		private static IntPtr get_skybox_Injected(); // 0x00000001821BD800-0x00000001821BD830
		private static void set_skybox_Injected(IntPtr value); // 0x00000001821BE1B0-0x00000001821BE1F0
		private static IntPtr get_sun_Injected(); // 0x00000001821BD9A0-0x00000001821BD9D0
		private static void set_sun_Injected(IntPtr value); // 0x00000001821BE330-0x00000001821BE370
		private static void get_ambientProbe_Injected(); // 0x00000001821BD190-0x00000001821BD1D0
		private static void set_ambientProbe_Injected(in SphericalHarmonicsL2 value); // 0x00000001821BDC30-0x00000001821BDC70
		private static IntPtr get_customReflectionTexture_Injected(); // 0x00000001821BD2B0-0x00000001821BD2E0
		private static void set_customReflectionTexture_Injected(IntPtr value); // 0x00000001821BDD30-0x00000001821BDD70
		private static IntPtr get_defaultReflection_Injected(); // 0x00000001821BD480-0x00000001821BD4B0
		private static IntPtr GetRenderSettings_Injected(); // 0x00000001821BCEA0-0x00000001821BCED0
		private static IntPtr get_spotCookieTexture_Injected(); // 0x00000001821BD890-0x00000001821BD8C0
		private static void set_spotCookieTexture_Injected(IntPtr value); // 0x00000001821BE230-0x00000001821BE270
		private static IntPtr get_haloTexture_Injected(); // 0x00000001821BD710-0x00000001821BD740
		private static void set_haloTexture_Injected(IntPtr value); // 0x00000001821BE0B0-0x00000001821BE0F0
	}
}
