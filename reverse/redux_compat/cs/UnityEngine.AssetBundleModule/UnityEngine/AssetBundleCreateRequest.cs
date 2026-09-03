/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 61: UnityEngine.AssetBundleModule.dll - Assembly: UnityEngine.AssetBundleModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15752-15762

namespace UnityEngine
{
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadFromAsyncOperation.h")]
	[RequiredByNativeCode]
	public class AssetBundleCreateRequest : AsyncOperation // TypeDefIndex: 15756
	{
		// Properties
		public AssetBundle assetBundle { [NativeMethod("GetAssetBundleBlocking")] get; } // 0x0000000182163780-0x0000000182163810 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15757
		{
			// Methods
			public static AssetBundleCreateRequest ConvertToManaged(IntPtr ptr); // 0x0000000182164B60-0x0000000182164BC0
			public static IntPtr ConvertToNative(AssetBundleCreateRequest assetBundleCreateRequest); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		private AssetBundleCreateRequest(IntPtr ptr); // 0x0000000182163730-0x0000000182163740
	
		// Methods
		private static IntPtr get_assetBundle_Injected(IntPtr _unity_self); // 0x0000000182163740-0x0000000182163780
	}
}
