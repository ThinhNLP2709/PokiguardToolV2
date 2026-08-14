namespace UnityEngine.Rendering.Universal;

internal class ShaderData : IDisposable
{
	private static ShaderData m_Instance; //Field offset: 0x0
	private ComputeBuffer m_LightDataBuffer; //Field offset: 0x10
	private ComputeBuffer m_LightIndicesBuffer; //Field offset: 0x18
	private ComputeBuffer m_AdditionalLightShadowParamsStructuredBuffer; //Field offset: 0x20
	private ComputeBuffer m_AdditionalLightShadowSliceMatricesStructuredBuffer; //Field offset: 0x28

	internal static ShaderData instance
	{
		internal get { } //Length: 141
	}

	private ShaderData() { }

	public override void Dispose() { }

	private void DisposeBuffer(ref ComputeBuffer buffer) { }

	internal static ShaderData get_instance() { }

	internal ComputeBuffer GetAdditionalLightShadowParamsStructuredBuffer(int size) { }

	internal ComputeBuffer GetAdditionalLightShadowSliceMatricesStructuredBuffer(int size) { }

	internal ComputeBuffer GetLightDataBuffer(int size) { }

	internal ComputeBuffer GetLightIndicesBuffer(int size) { }

	private ComputeBuffer GetOrUpdateBuffer(ref ComputeBuffer buffer, int size) { }

}

