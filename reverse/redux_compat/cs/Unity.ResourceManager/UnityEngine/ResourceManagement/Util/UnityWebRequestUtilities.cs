/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	public class UnityWebRequestUtilities // TypeDefIndex: 13727
	{
		// Fields
		private const string k_AddressablesLogConditional = "ADDRESSABLES_LOG_ALL"; // Metadata: 0x006A7E57
	
		// Constructors
		public UnityWebRequestUtilities(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public static bool RequestHasErrors(UnityWebRequest webReq, out UnityWebRequestResult result); // 0x000000018205B340-0x000000018205B490
		public static bool IsAssetBundleDownloaded(UnityWebRequestAsyncOperation op); // 0x000000018205B0F0-0x000000018205B190
		internal static void LogOperationResult(AsyncOperation op); // 0x000000018205B1E0-0x000000018205B2F0
		[Conditional("ADDRESSABLES_LOG_ALL")]
		internal static void Log(string msg); // 0x000000018205B2F0-0x000000018205B340
		internal static void LogError(string msg); // 0x000000018205B190-0x000000018205B1E0
	}
}
