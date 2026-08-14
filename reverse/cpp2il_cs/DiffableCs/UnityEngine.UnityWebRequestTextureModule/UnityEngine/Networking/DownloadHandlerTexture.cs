namespace UnityEngine.Networking;

[NativeHeader("Modules/UnityWebRequestTexture/Public/DownloadHandlerTexture.h")]
public sealed class DownloadHandlerTexture : DownloadHandler
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(DownloadHandlerTexture handler) { }

	}

	private NativeArray<Byte> m_NativeData; //Field offset: 0x18

	public Texture2D texture
	{
		 get { } //Length: 297
	}

	public DownloadHandlerTexture(bool readable) { }

	private static IntPtr Create(DownloadHandlerTexture obj, DownloadedTextureParams parameters) { }

	private static IntPtr Create_Injected(DownloadHandlerTexture obj, in DownloadedTextureParams parameters) { }

	public virtual void Dispose() { }

	public Texture2D get_texture() { }

	public static Texture2D GetContent(UnityWebRequest www) { }

	protected virtual NativeArray<Byte> GetNativeData() { }

	private void InternalCreateTexture(DownloadedTextureParams parameters) { }

	[NativeThrows]
	private Texture2D InternalGetTextureNative() { }

	private static IntPtr InternalGetTextureNative_Injected(IntPtr _unity_self) { }

}

