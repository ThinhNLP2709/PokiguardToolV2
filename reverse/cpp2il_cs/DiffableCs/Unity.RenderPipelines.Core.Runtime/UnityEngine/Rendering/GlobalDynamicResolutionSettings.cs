namespace UnityEngine.Rendering;

public struct GlobalDynamicResolutionSettings
{
	public bool enabled; //Field offset: 0x0
	public bool useMipBias; //Field offset: 0x1
	public List<AdvancedUpscalers> advancedUpscalersByPriority; //Field offset: 0x8
	public uint DLSSPerfQualitySetting; //Field offset: 0x10
	public UpsamplerScheduleType DLSSInjectionPoint; //Field offset: 0x14
	public UpsamplerScheduleType TAAUInjectionPoint; //Field offset: 0x18
	public UpsamplerScheduleType STPInjectionPoint; //Field offset: 0x1C
	public UpsamplerScheduleType defaultInjectionPoint; //Field offset: 0x20
	public bool DLSSUseOptimalSettings; //Field offset: 0x24
	[Range(0, 1)]
	public float DLSSSharpness; //Field offset: 0x28
	public bool FSR2EnableSharpness; //Field offset: 0x2C
	[Range(0, 1)]
	public float FSR2Sharpness; //Field offset: 0x30
	public bool FSR2UseOptimalSettings; //Field offset: 0x34
	public uint FSR2QualitySetting; //Field offset: 0x38
	public UpsamplerScheduleType FSR2InjectionPoint; //Field offset: 0x3C
	public bool fsrOverrideSharpness; //Field offset: 0x40
	[Range(0, 1)]
	public float fsrSharpness; //Field offset: 0x44
	public float maxPercentage; //Field offset: 0x48
	public float minPercentage; //Field offset: 0x4C
	public DynamicResolutionType dynResType; //Field offset: 0x50
	public DynamicResUpscaleFilter upsampleFilter; //Field offset: 0x51
	public bool forceResolution; //Field offset: 0x52
	public float forcedPercentage; //Field offset: 0x54
	public float lowResTransparencyMinimumThreshold; //Field offset: 0x58
	public float rayTracingHalfResThreshold; //Field offset: 0x5C
	public float lowResSSGIMinimumThreshold; //Field offset: 0x60
	public float lowResVolumetricCloudsMinimumThreshold; //Field offset: 0x64
	[Obsolete("Obsolete, used only for data migration. Use the advancedUpscalersByPriority list instead to add the proper supported advanced upscaler by priority.")]
	public bool enableDLSS; //Field offset: 0x68

	public static GlobalDynamicResolutionSettings NewDefault() { }

}

