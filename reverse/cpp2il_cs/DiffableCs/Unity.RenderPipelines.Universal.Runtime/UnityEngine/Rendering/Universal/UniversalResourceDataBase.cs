namespace UnityEngine.Rendering.Universal;

public abstract class UniversalResourceDataBase : ContextItem
{
	public enum ActiveID
	{
		Camera = 0,
		BackBuffer = 1,
	}

	[CompilerGenerated]
	private bool <isAccessible>k__BackingField; //Field offset: 0x10

	internal bool isAccessible
	{
		[CompilerGenerated]
		internal get { } //Length: 5
		[CompilerGenerated]
		internal set { } //Length: 4
	}

	protected UniversalResourceDataBase() { }

	protected TextureHandle CheckAndGetTextureHandle(ref TextureHandle handle) { }

	protected TextureHandle[] CheckAndGetTextureHandle(ref TextureHandle[] handle) { }

	protected void CheckAndSetTextureHandle(ref TextureHandle handle, TextureHandle newHandle) { }

	protected void CheckAndSetTextureHandle(ref TextureHandle[] handle, TextureHandle[] newHandle) { }

	protected bool CheckAndWarnAboutAccessibility() { }

	internal void EndFrame() { }

	[CompilerGenerated]
	internal bool get_isAccessible() { }

	internal void InitFrame() { }

	[CompilerGenerated]
	internal void set_isAccessible(bool value) { }

}

