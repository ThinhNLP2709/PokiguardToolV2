namespace UnityEngine;

[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromAsyncOperation.h")]
[RequiredByNativeCode]
public class AssetBundleCreateRequest : AsyncOperation
{
	public static class BindingsMarshaller
	{

		public static AssetBundleCreateRequest ConvertToManaged(IntPtr ptr) { }

		public static IntPtr ConvertToNative(AssetBundleCreateRequest assetBundleCreateRequest) { }

	}


	public AssetBundle assetBundle
	{
		[NativeMethod("GetAssetBundleBlocking")]
		 get { } //Length: 132
	}

	private AssetBundleCreateRequest(IntPtr ptr) { }

	[NativeMethod("GetAssetBundleBlocking")]
	public AssetBundle get_assetBundle() { }

	private static IntPtr get_assetBundle_Injected(IntPtr _unity_self) { }

}

