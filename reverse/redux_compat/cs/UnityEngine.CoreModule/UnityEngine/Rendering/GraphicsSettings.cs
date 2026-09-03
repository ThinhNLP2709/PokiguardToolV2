/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Scripting.LifecycleManagement;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Rendering
{
	[NativeClass("GraphicsSettings", PersistentTypeId = 30)]
	[NativeHeader("Runtime/Camera/GraphicsSettings.h")]
	[StaticAccessor("GetGraphicsSettings()", StaticAccessorType.Dot)]
	public sealed class GraphicsSettings : UnityEngine.Object // TypeDefIndex: 8308
	{
		// Fields
		[AutoStaticsCleanupOnCodeReload]
		private static Lazy<RenderPipelineGlobalSettings> s_CurrentRenderPipelineGlobalSettings; // 0x00
	
		// Properties
		public static bool lightsUseLinearIntensity { get; set; } // 0x00000001822483E0-0x0000000182248410 0x0000000182248450-0x0000000182248490
		public static bool lightsUseColorTemperature { set; } // 0x0000000182248410-0x0000000182248450
		public static bool useScriptableRenderPipelineBatching { set; } // 0x0000000182248490-0x00000001822484D0
		[NativeName("CurrentRenderPipeline")]
		private static ScriptableObject INTERNAL_currentRenderPipeline { get; } // 0x0000000182248160-0x00000001822481E0 
		public static RenderPipelineAsset currentRenderPipeline { get; } // 0x00000001822482C0-0x0000000182248360 
		public static bool isScriptableRenderPipelineEnabled { get; } // 0x0000000182248360-0x00000001822483E0 
		public static Type currentRenderPipelineAssetType { get; } // 0x00000001822481E0-0x00000001822482C0 
	
		// Constructors
		static GraphicsSettings(); // 0x0000000182248060-0x0000000182248130
	
		// Methods
		public static bool HasShaderDefine(GraphicsTier tier, BuiltinShaderDefine defineHash); // 0x0000000182247BA0-0x0000000182247BE0
		public static bool HasShaderDefine(BuiltinShaderDefine defineHash); // 0x0000000182247BE0-0x0000000182247C80
		[RequiredByNativeCode]
		[VisibleToOtherModules]
		internal static Shader GetDefaultShader(DefaultShaderType type); // 0x0000000182247860-0x0000000182247BA0
		[RequiredByNativeCode]
		[VisibleToOtherModules]
		internal static Material GetDefaultMaterial(DefaultMaterialType type); // 0x0000000182247560-0x0000000182247860
		[NativeName("GetSettingsForRenderPipeline")]
		private static UnityEngine.Object Internal_GetSettingsForRenderPipeline(string renderpipelineName); // 0x0000000182247DC0-0x0000000182247FA0
		public static RenderPipelineGlobalSettings GetSettingsForRenderPipeline<T>()
			where T : RenderPipeline;
		private static RenderPipelineGlobalSettings Internal_GetCurrentRenderPipelineGlobalSettings(); // 0x0000000182247C80-0x0000000182247D80
		public static bool TryGetCurrentRenderPipelineGlobalSettings(out RenderPipelineGlobalSettings asset); // 0x0000000182247FA0-0x0000000182248060
		public static T GetRenderPipelineSettings<T>()
			where T : class, IRenderPipelineGraphicsSettings;
		public static bool TryGetRenderPipelineSettings<T>(out ref T settings)
			where T : class, IRenderPipelineGraphicsSettings;
		private static IntPtr get_INTERNAL_currentRenderPipeline_Injected(); // 0x0000000182248130-0x0000000182248160
		private static IntPtr Internal_GetSettingsForRenderPipeline_Injected(ref ManagedSpanWrapper renderpipelineName); // 0x0000000182247D80-0x0000000182247DC0
	}
}
