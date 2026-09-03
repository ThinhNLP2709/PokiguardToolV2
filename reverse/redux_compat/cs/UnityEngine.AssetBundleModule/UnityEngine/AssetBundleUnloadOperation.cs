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
	[NativeHeader("Modules/AssetBundle/Public/AssetBundleUnloadOperation.h")]
	[RequiredByNativeCode]
	public class AssetBundleUnloadOperation : AsyncOperation // TypeDefIndex: 15761
	{
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15762
		{
			// Methods
			public static AssetBundleUnloadOperation ConvertToManaged(IntPtr ptr); // 0x0000000182164BC0-0x0000000182164C20
			public static IntPtr ConvertToNative(AssetBundleUnloadOperation assetBundleUnloadOperation); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		private AssetBundleUnloadOperation(IntPtr ptr); // 0x0000000182163730-0x0000000182163740
	
		// Methods
		[NativeMethod("WaitForCompletion")]
		public void WaitForCompletion(); // 0x00000001821639C0-0x0000000182163A20
		private static void WaitForCompletion_Injected(IntPtr _unity_self); // 0x0000000182163980-0x00000001821639C0
	}
}
