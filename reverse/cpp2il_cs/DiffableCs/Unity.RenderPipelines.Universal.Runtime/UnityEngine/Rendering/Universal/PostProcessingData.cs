namespace UnityEngine.Rendering.Universal;

public struct PostProcessingData
{
	private ContextContainer frameData; //Field offset: 0x0

	public ColorGradingMode gradingMode
	{
		 get { } //Length: 77
	}

	public int lutSize
	{
		 get { } //Length: 77
	}

	public bool supportDataDrivenLensFlare
	{
		 get { } //Length: 77
	}

	public bool supportScreenSpaceLensFlare
	{
		 get { } //Length: 77
	}

	internal UniversalPostProcessingData universalPostProcessingData
	{
		internal get { } //Length: 67
	}

	public bool useFastSRGBLinearConversion
	{
		 get { } //Length: 77
	}

	internal PostProcessingData(ContextContainer frameData) { }

	public ColorGradingMode get_gradingMode() { }

	public int get_lutSize() { }

	public bool get_supportDataDrivenLensFlare() { }

	public bool get_supportScreenSpaceLensFlare() { }

	internal UniversalPostProcessingData get_universalPostProcessingData() { }

	public bool get_useFastSRGBLinearConversion() { }

}

