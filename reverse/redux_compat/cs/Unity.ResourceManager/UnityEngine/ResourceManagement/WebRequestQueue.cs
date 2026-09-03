/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement
{
	public static class WebRequestQueue // TypeDefIndex: 13679
	{
		// Fields
		internal static int s_MaxRequest; // 0x00
		internal static Queue<WebRequestQueueOperation> s_QueuedOperations; // 0x08
		internal static List<UnityWebRequestAsyncOperation> s_ActiveRequests; // 0x10
	
		// Constructors
		static WebRequestQueue(); // 0x000000018205C450-0x000000018205C550
	
		// Methods
		public static void SetMaxConcurrentRequests(int maxRequests); // 0x000000018205BFB0-0x000000018205C070
		public static WebRequestQueueOperation QueueRequest(UnityWebRequest request); // 0x000000018205BEC0-0x000000018205BFB0
		public static void WaitForRequestToBeActive(WebRequestQueueOperation request, int millisecondsTimeout); // 0x000000018205C070-0x000000018205C450
		internal static void DequeueRequest(UnityWebRequestAsyncOperation operation); // 0x000000018205BCA0-0x000000018205BD50
		private static void OnWebAsyncOpComplete(AsyncOperation operation); // 0x000000018205BD50-0x000000018205BDF0
		private static void OnWebAsyncOpComplete(UnityWebRequestAsyncOperation operation); // 0x000000018205BDF0-0x000000018205BEC0
		private static void BeginWebRequest(WebRequestQueueOperation queueOperation); // 0x000000018205BA70-0x000000018205BCA0
	}
}
