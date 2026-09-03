/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	public static class ResourceManagerConfig // TypeDefIndex: 13725
	{
		// Methods
		public static bool ExtractKeyAndSubKey(object keyObj, out string mainKey, out string subKey); // 0x0000000182053410-0x0000000182053500
		public static bool IsPathRemote(string path); // 0x0000000182053500-0x0000000182053550
		public static string StripQueryParameters(string path); // 0x00000001820537B0-0x00000001820537F0
		public static bool ShouldPathUseWebRequest(string path); // 0x0000000182053650-0x00000001820537B0
		private static bool PlatformCanLoadLocallyFromUrlPath(); // 0x0000000182053550-0x0000000182053650
		public static Array CreateArrayResult(Type type, UnityEngine.Object[] allAssets); // 0x0000000182053100-0x0000000182053290
		public static TObject CreateArrayResult<TObject>(UnityEngine.Object[] allAssets)
			where TObject : class;
		public static IList CreateListResult(Type type, UnityEngine.Object[] allAssets); // 0x0000000182053290-0x0000000182053410
		public static TObject CreateListResult<TObject>(UnityEngine.Object[] allAssets);
		public static bool IsInstance<T1, T2>();
	}
}
