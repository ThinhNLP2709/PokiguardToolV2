namespace UnityEngine;

[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetOperation.h")]
[RequiredByNativeCode]
public class AssetBundleRequest : ResourceRequest
{
	public static class BindingsMarshaller
	{

		public static AssetBundleRequest ConvertToManaged(IntPtr ptr) { }

		public static IntPtr ConvertToNative(AssetBundleRequest request) { }

	}


	public Object[] allAssets
	{
		[NativeMethod("GetAllLoadedAssets")]
		 get { } //Length: 81
	}

	public object asset
	{
		 get { } //Length: 20
	}

	private AssetBundleRequest(IntPtr ptr) { }

	[NativeMethod("GetAllLoadedAssets")]
	public Object[] get_allAssets() { }

	private static Object[] get_allAssets_Injected(IntPtr _unity_self) { }

	public object get_asset() { }

	[NativeMethod("GetLoadedAsset")]
	protected virtual object GetResult() { }

	private static IntPtr GetResult_Injected(IntPtr _unity_self) { }

}

