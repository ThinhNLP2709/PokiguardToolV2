namespace UnityEngine;

[NativeHeader("Modules/AssetBundle/Public/AssetBundleUnloadOperation.h")]
[RequiredByNativeCode]
public class AssetBundleUnloadOperation : AsyncOperation
{
	public static class BindingsMarshaller
	{

		public static AssetBundleUnloadOperation ConvertToManaged(IntPtr ptr) { }

		public static IntPtr ConvertToNative(AssetBundleUnloadOperation assetBundleUnloadOperation) { }

	}


	private AssetBundleUnloadOperation(IntPtr ptr) { }

	[NativeMethod("WaitForCompletion")]
	public void WaitForCompletion() { }

	private static void WaitForCompletion_Injected(IntPtr _unity_self) { }

}

