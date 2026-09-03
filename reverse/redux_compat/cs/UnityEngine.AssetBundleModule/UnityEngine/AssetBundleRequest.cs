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
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleLoadAssetOperation.h")]
	[RequiredByNativeCode]
	public class AssetBundleRequest : ResourceRequest // TypeDefIndex: 15759
	{
		// Properties
		public new Object asset { get; } // 0x00000001816197C0-0x00000001816197E0 
		public Object[] allAssets { [NativeMethod("GetAllLoadedAssets")] get; } // 0x0000000182163920-0x0000000182163980 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15760
		{
			// Methods
			public static AssetBundleRequest ConvertToManaged(IntPtr ptr); // 0x0000000182164C20-0x0000000182164C80
			public static IntPtr ConvertToNative(AssetBundleRequest request); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		private AssetBundleRequest(IntPtr ptr); // 0x0000000182163730-0x0000000182163740
	
		// Methods
		[NativeMethod("GetLoadedAsset")]
		protected override Object GetResult(); // 0x0000000182163850-0x00000001821638E0
		private static IntPtr GetResult_Injected(IntPtr _unity_self); // 0x0000000182163810-0x0000000182163850
		private static Object[] get_allAssets_Injected(IntPtr _unity_self); // 0x00000001821638E0-0x0000000182163920
	}
}
