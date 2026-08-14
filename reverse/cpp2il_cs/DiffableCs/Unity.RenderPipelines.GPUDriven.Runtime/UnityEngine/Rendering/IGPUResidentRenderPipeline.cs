namespace UnityEngine.Rendering;

public interface IGPUResidentRenderPipeline
{

	public GPUResidentDrawerMode gpuResidentDrawerMode
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public GPUResidentDrawerSettings gpuResidentDrawerSettings
	{
		 get { } //Length: 0
	}

	public GPUResidentDrawerMode get_gpuResidentDrawerMode() { }

	public GPUResidentDrawerSettings get_gpuResidentDrawerSettings() { }

	public static bool IsGPUResidentDrawerEnabled() { }

	public static bool IsGPUResidentDrawerSupportedByProjectConfiguration(bool logReason = false) { }

	public bool IsGPUResidentDrawerSupportedBySRP(bool logReason = false) { }

	public bool IsGPUResidentDrawerSupportedBySRP(out string message, out LogType severity) { }

	public static void ReinitializeGPUResidentDrawer() { }

	public void set_gpuResidentDrawerMode(GPUResidentDrawerMode value) { }

}

