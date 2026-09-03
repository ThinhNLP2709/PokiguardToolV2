/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.Util;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	[Serializable]
	public class BinaryCatalogInitialization : IInitializableObject // TypeDefIndex: 13742
	{
		// Fields
		public const int kDefaultBinaryStorageBufferCacheSize = 128; // Metadata: 0x006A7E75
		public const int kCatalogLocationCacheSize = 32; // Metadata: 0x006A7E77
		private static int s_BinaryStorageBufferCacheSize; // 0x00
		private static int s_CatalogLocationCacheSize; // 0x04
	
		// Properties
		public static int BinaryStorageBufferCacheSize { get; } // 0x00000001820482C0-0x0000000182048310 
		public static int CatalogLocationCacheSize { get; } // 0x0000000182048310-0x0000000182048360 
	
		// Constructors
		public BinaryCatalogInitialization(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static BinaryCatalogInitialization(); // 0x0000000182048270-0x00000001820482C0
	
		// Methods
		public static void ResetToDefaults(); // 0x0000000182048200-0x0000000182048270
		public bool Initialize(string id, string dataStr); // 0x0000000182048120-0x0000000182048200
		public AsyncOperationHandle<bool> InitializeAsync(ResourceManager resourceManager, string id, string dataStr); // 0x0000000182048070-0x0000000182048120
	}
}
