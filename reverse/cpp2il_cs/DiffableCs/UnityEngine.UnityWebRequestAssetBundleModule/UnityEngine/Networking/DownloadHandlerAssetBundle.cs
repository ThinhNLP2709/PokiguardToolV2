namespace UnityEngine.Networking;

[NativeHeader("Modules/UnityWebRequestAssetBundle/Public/DownloadHandlerAssetBundle.h")]
public sealed class DownloadHandlerAssetBundle : DownloadHandler
{
	public static class BindingsMarshaller
	{

		public static IntPtr ConvertToNative(DownloadHandlerAssetBundle handler) { }

	}


	public AssetBundle assetBundle
	{
		 get { } //Length: 297
	}

	public bool autoLoadAssetBundle
	{
		 get { } //Length: 81
		[NativeThrows]
		 set { } //Length: 91
	}

	public bool isDownloadComplete
	{
		 get { } //Length: 81
	}

	public DownloadHandlerAssetBundle(string url, uint crc) { }

	public DownloadHandlerAssetBundle(string url, CachedAssetBundle cachedBundle, uint crc) { }

	private static IntPtr Create(DownloadHandlerAssetBundle obj, string url, uint crc) { }

	private static IntPtr Create_Injected(DownloadHandlerAssetBundle obj, ref ManagedSpanWrapper url, uint crc) { }

	private static IntPtr CreateCached(DownloadHandlerAssetBundle obj, string url, string name, Hash128 hash, uint crc) { }

	private static IntPtr CreateCached_Injected(DownloadHandlerAssetBundle obj, ref ManagedSpanWrapper url, ref ManagedSpanWrapper name, in Hash128 hash, uint crc) { }

	public AssetBundle get_assetBundle() { }

	private static IntPtr get_assetBundle_Injected(IntPtr _unity_self) { }

	public bool get_autoLoadAssetBundle() { }

	private static bool get_autoLoadAssetBundle_Injected(IntPtr _unity_self) { }

	public bool get_isDownloadComplete() { }

	private static bool get_isDownloadComplete_Injected(IntPtr _unity_self) { }

	protected virtual Byte[] GetData() { }

	protected virtual string GetText() { }

	private void InternalCreateAssetBundle(string url, uint crc) { }

	private void InternalCreateAssetBundleCached(string url, string name, Hash128 hash, uint crc) { }

	[NativeThrows]
	public void set_autoLoadAssetBundle(bool value) { }

	private static void set_autoLoadAssetBundle_Injected(IntPtr _unity_self, bool value) { }

}

