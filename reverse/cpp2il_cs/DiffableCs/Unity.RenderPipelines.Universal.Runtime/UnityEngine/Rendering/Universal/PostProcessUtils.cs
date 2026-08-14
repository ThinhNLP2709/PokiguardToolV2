namespace UnityEngine.Rendering.Universal;

public static class PostProcessUtils
{
	private static class ShaderConstants
	{
		public static readonly int _Grain_Texture; //Field offset: 0x0
		public static readonly int _Grain_Params; //Field offset: 0x4
		public static readonly int _Grain_TilingParams; //Field offset: 0x8
		public static readonly int _BlueNoise_Texture; //Field offset: 0xC
		public static readonly int _Dithering_Params; //Field offset: 0x10
		public static readonly int _SourceSize; //Field offset: 0x14

		private static ShaderConstants() { }

	}


	[Obsolete("This method is obsolete. Use ConfigureDithering override that takes camera pixel width and height instead.")]
	public static int ConfigureDithering(PostProcessData data, int index, Camera camera, Material material) { }

	public static int ConfigureDithering(PostProcessData data, int index, int cameraPixelWidth, int cameraPixelHeight, Material material) { }

	[Obsolete("This method is obsolete. Use ConfigureFilmGrain override that takes camera pixel width and height instead.")]
	public static void ConfigureFilmGrain(PostProcessData data, FilmGrain settings, Camera camera, Material material) { }

	public static void ConfigureFilmGrain(PostProcessData data, FilmGrain settings, int cameraPixelWidth, int cameraPixelHeight, Material material) { }

	internal static void SetSourceSize(RasterCommandBuffer cmd, RTHandle source) { }

	internal static void SetSourceSize(CommandBuffer cmd, RTHandle source) { }

}

