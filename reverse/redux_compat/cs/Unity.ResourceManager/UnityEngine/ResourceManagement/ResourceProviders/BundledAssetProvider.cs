/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	[DisplayName("Assets from Bundles Provider")]
	public class BundledAssetProvider : ResourceProviderBase // TypeDefIndex: 13746
	{
		// Nested types
		internal class InternalOp // TypeDefIndex: 13747
		{
			// Fields
			private AssetBundle m_AssetBundle; // 0x10
			private AssetBundleRequest m_PreloadRequest; // 0x18
			private AssetBundleRequest m_RequestOperation; // 0x20
			private object m_Result; // 0x28
			private ProvideHandle m_ProvideHandle; // 0x30
			private string subObjectName; // 0x48
	
			// Constructors
			public InternalOp(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal static T LoadBundleFromDependecies<T>(IList<object> results)
				where T : class, IAssetBundleResource;
			internal static bool IsDownloadOnly(IList<object> results); // 0x000000018204CB10-0x000000018204CCC0
			public void Start(ProvideHandle provideHandle); // 0x000000018204E600-0x000000018204EB00
			private void BeginAssetLoad(); // 0x000000018204BD60-0x000000018204C340
			private bool WaitForCompletionHandler(); // 0x000000018204F170-0x000000018204F260
			private void ActionComplete(AsyncOperation obj); // 0x000000018204B880-0x000000018204BD60
			private void GetArrayResult(UnityEngine.Object[] allAssets); // 0x000000018204C6B0-0x000000018204C730
			private void GetListResult(UnityEngine.Object[] allAssets); // 0x000000018204C920-0x000000018204CB10
			private void GetAssetResult(UnityEngine.Object asset); // 0x000000018204C730-0x000000018204C830
			private void GetAssetSubObjectResult(UnityEngine.Object[] allAssets); // 0x000000018204C830-0x000000018204C920
			private void CompleteOperation(); // 0x000000018204C340-0x000000018204C490
			public float ProgressCallback(); // 0x000000018204CCC0-0x000000018204CCE0
			[CompilerGenerated]
			private void _Start_b__8_0(AsyncOperation operation); // 0x000000018204F0F0-0x000000018204F100
		}
	
		// Constructors
		public BundledAssetProvider(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public override void Provide(ProvideHandle provideHandle); // 0x0000000182049300-0x0000000182049380
	}
}
