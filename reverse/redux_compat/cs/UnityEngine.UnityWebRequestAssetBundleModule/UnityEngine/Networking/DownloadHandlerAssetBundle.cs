/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;

// Image 68: UnityEngine.UnityWebRequestAssetBundleModule.dll - Assembly: UnityEngine.UnityWebRequestAssetBundleModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15839-15844

namespace UnityEngine.Networking
{
	[NativeHeader("Modules/UnityWebRequestAssetBundle/Public/DownloadHandlerAssetBundle.h")]
	public sealed class DownloadHandlerAssetBundle : DownloadHandler // TypeDefIndex: 15843
	{
		// Properties
		public AssetBundle assetBundle { get; } // 0x00000001825CA980-0x00000001825CAA80 
		public bool autoLoadAssetBundle { get; [NativeMethod(ThrowsException = true)] set; } // 0x00000001825CAAC0-0x00000001825CAB20 0x00000001825CAC10-0x00000001825CAC70
		public bool isDownloadComplete { get; } // 0x00000001825CAB60-0x00000001825CABC0 
	
		// Nested types
		internal static class BindingsMarshaller // TypeDefIndex: 15844
		{
			// Methods
			public static IntPtr ConvertToNative(DownloadHandlerAssetBundle handler); // 0x00000001808586A0-0x00000001808586C0
		}
	
		// Constructors
		public DownloadHandlerAssetBundle(string url, uint crc); // 0x00000001825CA880-0x00000001825CA8D0
		public DownloadHandlerAssetBundle(string url, CachedAssetBundle cachedBundle, uint crc); // 0x00000001825CA8D0-0x00000001825CA940
	
		// Methods
		private static IntPtr Create([UnityMarshalAs(NativeType.ScriptingObjectPtr)] DownloadHandlerAssetBundle obj, string url, uint crc); // 0x00000001825CA610-0x00000001825CA780
		private static IntPtr CreateCached([UnityMarshalAs(NativeType.ScriptingObjectPtr)] DownloadHandlerAssetBundle obj, string url, string name, Hash128 hash, uint crc); // 0x00000001825CA350-0x00000001825CA5B0
		private void InternalCreateAssetBundle(string url, uint crc); // 0x00000001825CA860-0x00000001825CA880
		private void InternalCreateAssetBundleCached(string url, string name, Hash128 hash, uint crc); // 0x00000001825CA820-0x00000001825CA860
		protected override byte[] GetData(); // 0x00000001825CA780-0x00000001825CA7D0
		protected override string GetText(); // 0x00000001825CA7D0-0x00000001825CA820
		private static IntPtr Create_Injected(DownloadHandlerAssetBundle obj, ref ManagedSpanWrapper url, uint crc); // 0x00000001825CA5B0-0x00000001825CA610
		private static IntPtr CreateCached_Injected(DownloadHandlerAssetBundle obj, ref ManagedSpanWrapper url, ref ManagedSpanWrapper name, in Hash128 hash, uint crc); // 0x00000001825CA2E0-0x00000001825CA350
		private static IntPtr get_assetBundle_Injected(IntPtr _unity_self); // 0x00000001825CA940-0x00000001825CA980
		private static bool get_autoLoadAssetBundle_Injected(IntPtr _unity_self); // 0x00000001825CAA80-0x00000001825CAAC0
		private static void set_autoLoadAssetBundle_Injected(IntPtr _unity_self, bool value); // 0x00000001825CABC0-0x00000001825CAC10
		private static bool get_isDownloadComplete_Injected(IntPtr _unity_self); // 0x00000001825CAB20-0x00000001825CAB60
	}
}
