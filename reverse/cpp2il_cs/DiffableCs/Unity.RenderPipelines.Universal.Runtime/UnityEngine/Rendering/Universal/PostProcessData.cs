namespace UnityEngine.Rendering.Universal;

public class PostProcessData : ScriptableObject
{
	[ReloadGroup]
	internal sealed class ShaderResources
	{
		[Reload("Shaders/PostProcessing/StopNaN.shader", Package::Root (1))]
		public Shader stopNanPS; //Field offset: 0x10
		[Reload("Shaders/PostProcessing/SubpixelMorphologicalAntialiasing.shader", Package::Root (1))]
		public Shader subpixelMorphologicalAntialiasingPS; //Field offset: 0x18
		[Reload("Shaders/PostProcessing/GaussianDepthOfField.shader", Package::Root (1))]
		public Shader gaussianDepthOfFieldPS; //Field offset: 0x20
		[Reload("Shaders/PostProcessing/BokehDepthOfField.shader", Package::Root (1))]
		public Shader bokehDepthOfFieldPS; //Field offset: 0x28
		[Reload("Shaders/PostProcessing/CameraMotionBlur.shader", Package::Root (1))]
		public Shader cameraMotionBlurPS; //Field offset: 0x30
		[Reload("Shaders/PostProcessing/PaniniProjection.shader", Package::Root (1))]
		public Shader paniniProjectionPS; //Field offset: 0x38
		[Reload("Shaders/PostProcessing/LutBuilderLdr.shader", Package::Root (1))]
		public Shader lutBuilderLdrPS; //Field offset: 0x40
		[Reload("Shaders/PostProcessing/LutBuilderHdr.shader", Package::Root (1))]
		public Shader lutBuilderHdrPS; //Field offset: 0x48
		[Reload("Shaders/PostProcessing/Bloom.shader", Package::Root (1))]
		public Shader bloomPS; //Field offset: 0x50
		[Reload("Shaders/PostProcessing/TemporalAA.shader", Package::Root (1))]
		public Shader temporalAntialiasingPS; //Field offset: 0x58
		[Reload("Shaders/PostProcessing/LensFlareDataDriven.shader", Package::Root (1))]
		public Shader LensFlareDataDrivenPS; //Field offset: 0x60
		[Reload("Shaders/PostProcessing/LensFlareScreenSpace.shader", Package::Root (1))]
		public Shader LensFlareScreenSpacePS; //Field offset: 0x68
		[Reload("Shaders/PostProcessing/ScalingSetup.shader", Package::Root (1))]
		public Shader scalingSetupPS; //Field offset: 0x70
		[Reload("Shaders/PostProcessing/EdgeAdaptiveSpatialUpsampling.shader", Package::Root (1))]
		public Shader easuPS; //Field offset: 0x78
		[Reload("Shaders/PostProcessing/UberPost.shader", Package::Root (1))]
		public Shader uberPostPS; //Field offset: 0x80
		[Reload("Shaders/PostProcessing/FinalPost.shader", Package::Root (1))]
		public Shader finalPostPassPS; //Field offset: 0x88

		public ShaderResources() { }

	}

	[ReloadGroup]
	internal sealed class TextureResources
	{
		[Reload("Textures/BlueNoise16/L/LDR_LLL1_{0}.png", 0, 32, Package::Root (1))]
		public Texture2D[] blueNoise16LTex; //Field offset: 0x10
		[Reload(new IL2CPP_TYPE_STRING[] {"Textures/FilmGrain/Thin01.png", "Textures/FilmGrain/Thin02.png", "Textures/FilmGrain/Medium01.png", "Textures/FilmGrain/Medium02.png", "Textures/FilmGrain/Medium03.png", "Textures/FilmGrain/Medium04.png", "Textures/FilmGrain/Medium05.png", "Textures/FilmGrain/Medium06.png", "Textures/FilmGrain/Large01.png", "Textures/FilmGrain/Large02.png"}, Package::Root (1))]
		public Texture2D[] filmGrainTex; //Field offset: 0x18
		[Reload("Textures/SMAA/AreaTex.tga", Package::Root (1))]
		public Texture2D smaaAreaTex; //Field offset: 0x20
		[Reload("Textures/SMAA/SearchTex.tga", Package::Root (1))]
		public Texture2D smaaSearchTex; //Field offset: 0x28

		public TextureResources() { }

	}

	public ShaderResources shaders; //Field offset: 0x18
	public TextureResources textures; //Field offset: 0x20

	public PostProcessData() { }

}

