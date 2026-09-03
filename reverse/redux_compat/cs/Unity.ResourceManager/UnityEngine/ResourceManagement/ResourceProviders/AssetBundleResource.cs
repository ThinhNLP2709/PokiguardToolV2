/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.ResourceManagement.Util;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	public class AssetBundleResource : IAssetBundleResource, IUpdateReceiver // TypeDefIndex: 13733
	{
		// Fields
		private AssetBundle m_AssetBundle; // 0x10
		private AsyncOperation m_RequestOperation; // 0x18
		internal WebRequestQueueOperation m_WebRequestQueueOperation; // 0x20
		internal ProvideHandle m_ProvideHandle; // 0x28
		internal AssetBundleRequestOptions m_Options; // 0x40
		internal CacheStatus m_CacheStatus; // 0x48
		[NonSerialized]
		private bool m_RequestCompletedCallbackCalled; // 0x4C
		private int m_Retries; // 0x50
		private BundleSource m_Source; // 0x54
		private long m_BytesToDownload; // 0x58
		private long m_DownloadedBytes; // 0x60
		internal bool m_Completed; // 0x68
		private AssetBundleUnloadOperation m_UnloadOperation; // 0x70
		private const int k_WaitForWebRequestMainThreadSleep = 1; // Metadata: 0x006A7E6E
		internal string m_TransformedInternalId; // 0x78
		private AssetBundleRequest m_PreloadRequest; // 0x80
		private bool m_PreloadCompleted; // 0x88
		private ulong m_LastDownloadedByteCount; // 0x90
		private float m_TimeoutTimer; // 0x98
		private int m_TimeoutOverFrames; // 0x9C
		internal bool m_DownloadOnly; // 0xA0
		private int m_LastFrameCount; // 0xA4
		private float m_TimeSecSinceLastUpdate; // 0xA8
		internal Func<UnityWebRequestResult, bool> m_RequestRetryCallback; // 0xB0
		internal AssetBundleProvider m_AssetBundleProvider; // 0xB8
		internal string m_InternalId; // 0xC0
		internal LoadType m_LoadType; // 0xC8
		internal bool m_CanSkipWebDownload; // 0xCC
		private Action<AssetBundleResource> m_CompletionCallbacks; // 0xD0
	
		// Properties
		private bool HasTimedOut { get; } // 0x0000000182046530-0x0000000182046560 
		internal long BytesToDownload { get; } // 0x0000000182046490-0x0000000182046530 
	
		// Nested types
		public enum LoadType // TypeDefIndex: 13734
		{
			None = 0,
			Local = 1,
			Web = 2
		}
	
		internal enum CacheStatus // TypeDefIndex: 13735
		{
			Unknown = 0,
			Cached = 1,
			NotCached = 2
		}
	
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13736
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Func<UnityWebRequestResult, bool> __9__65_0; // 0x08
	
			// Constructors
			static __c(); // 0x000000018205AB70-0x000000018205ABE0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal bool _.ctor_b__65_0(UnityWebRequestResult x); // 0x0000000182042760-0x0000000182042780
		}
	
		// Constructors
		public AssetBundleResource(); // 0x0000000182046390-0x0000000182046490
	
		// Methods
		internal void AddCompletionCallback(Action<AssetBundleResource> callback); // 0x0000000182043120-0x0000000182043210
		private void InvokeCompletionCallbacks(); // 0x00000001820449D0-0x0000000182044A50
		private void CompleteOperation(AssetBundleResource result, bool success, Exception exception); // 0x0000000182043AD0-0x0000000182043BD0
		internal bool IsCached(); // 0x0000000182044A50-0x0000000182044A90
		internal static CacheStatus GetCacheStatus(AssetBundleRequestOptions options); // 0x0000000182044220-0x00000001820442E0
		internal bool IsWebDownload(); // 0x0000000182044A90-0x0000000182044AB0
		internal void InitializeForProvide(IResourceLocation location, ResourceManager resourceManager); // 0x0000000182044840-0x00000001820449D0
		internal UnityWebRequest CreateWebRequest(IResourceLocation loc); // 0x0000000182043E50-0x0000000182043EF0
		internal UnityWebRequest CreateWebRequest(string url); // 0x0000000182043BD0-0x0000000182043E50
		public AssetBundleRequest GetAssetPreloadRequest(); // 0x00000001820440C0-0x0000000182044220
		private float PercentComplete(); // 0x0000000182044EC0-0x0000000182044EE0
		private DownloadStatus GetDownloadStatus(); // 0x00000001820442E0-0x0000000182044480
		public AssetBundle GetAssetBundle(); // 0x0000000182044070-0x00000001820440C0
		private void OnUnloadOperationComplete(AsyncOperation op); // 0x0000000182044E90-0x0000000182044EC0
		public void Start(ProvideHandle provideHandle, AssetBundleUnloadOperation unloadOp, Func<UnityWebRequestResult, bool> requestRetryCallback); // 0x0000000182045480-0x0000000182045540
		internal void Start(ProvideHandle provideHandle, AssetBundleUnloadOperation unloadOp, Func<UnityWebRequestResult, bool> requestRetryCallback, AssetBundleProvider assetBundleProvider); // 0x0000000182044EE0-0x0000000182045480
		private bool WaitForCompletionHandler(); // 0x00000001820457B0-0x0000000182045C10
		private void AddCallbackInvokeIfDone(AsyncOperation operation, Action<AsyncOperation> callback); // 0x00000001820430B0-0x0000000182043120
		public static void GetLoadInfo(ProvideHandle handle, out LoadType loadType, out string path); // 0x0000000182044480-0x0000000182044510
		internal static void GetLoadInfo(IResourceLocation location, ResourceManager resourceManager, out LoadType loadType, out string path); // 0x0000000182044510-0x0000000182044840
		private void BeginOperation(); // 0x0000000182043210-0x0000000182043810
		private void LoadLocalBundle(); // 0x0000000182044AB0-0x0000000182044BB0
		internal WebRequestQueueOperation EnqueueWebRequest(string internalId); // 0x0000000182043EF0-0x0000000182044070
		internal void AddBeginWebRequestHandler(WebRequestQueueOperation webRequestQueueOperation); // 0x0000000182042F80-0x00000001820430B0
		private void BeginWebRequestOperation(AsyncOperation asyncOp); // 0x0000000182043810-0x0000000182043950
		public void Update(float unscaledDeltaTime); // 0x0000000182045620-0x00000001820457B0
		private void LocalRequestOperationCompleted(AsyncOperation op); // 0x0000000182044BB0-0x0000000182044E90
		private void CompleteBundleLoad(AssetBundle bundle); // 0x0000000182043950-0x0000000182043AD0
		private void WebRequestOperationCompleted(AsyncOperation op); // 0x0000000182045C10-0x0000000182046390
		public bool Unload(out AssetBundleUnloadOperation unloadOp); // 0x0000000182045550-0x0000000182045620
		[CompilerGenerated]
		private void _GetAssetPreloadRequest_b__44_0(AsyncOperation operation); // 0x0000000181E426E0-0x0000000181E426F0
		[CompilerGenerated]
		private void _AddBeginWebRequestHandler_b__58_0(UnityWebRequestAsyncOperation asyncOp); // 0x0000000182045540-0x0000000182045550
	}
}
