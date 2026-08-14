namespace UnityEngine.Rendering;

public class BaseCommandBuffer
{
	protected private CommandBuffer m_WrappedCommandBuffer; //Field offset: 0x10
	internal RenderGraphPass m_ExecutingPass; //Field offset: 0x18

	public string name
	{
		 get { } //Length: 29
	}

	public int sizeInBytes
	{
		 get { } //Length: 29
	}

	internal BaseCommandBuffer(CommandBuffer wrapped, RenderGraphPass executingPass, bool isAsync) { }

	public string get_name() { }

	public int get_sizeInBytes() { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	protected private void ThrowIfGlobalStateNotAllowed() { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	protected private void ThrowIfRasterNotAllowed() { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	protected private void ValidateTextureHandle(TextureHandle h) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	protected private void ValidateTextureHandleRead(TextureHandle h) { }

	[Conditional("DEVELOPMENT_BUILD")]
	[Conditional("UNITY_EDITOR")]
	protected private void ValidateTextureHandleWrite(TextureHandle h) { }

}

