/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement.Util;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	[Serializable]
	public class ProviderLoadRequestOptions // TypeDefIndex: 13765
	{
		// Fields
		[SerializeField]
		private bool m_IgnoreFailures; // 0x10
		[SerializeField]
		private int m_WebRequestTimeout; // 0x14
		[SerializeField]
		private string m_LocalCachePath; // 0x18
	
		// Properties
		public bool IgnoreFailures { get; set; } // 0x00000001805625D0-0x00000001805625E0 0x00000001804C2E20-0x00000001804C2E30
		public int WebRequestTimeout { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public string LocalCachePath { get; set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
	
		// Nested types
		public class SerializationAdatapter : BinaryStorageBuffer.ISerializationAdapter<ProviderLoadRequestOptions> // TypeDefIndex: 13766
		{
			// Properties
			IEnumerable<BinaryStorageBuffer.ISerializationAdapter> ISerializationAdapter.Dependencies { get; } // 0x00000001802E7860-0x00000001802E7870 
	
			// Nested types
			private struct Data // TypeDefIndex: 13767
			{
				// Fields
				public bool ignoreFailures; // 0x00
				public int requestTimeout; // 0x04
				public uint localCachePathOffset; // 0x08
			}
	
			// Constructors
			public SerializationAdatapter(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			object UnityEngine.ResourceManagement.Util.BinaryStorageBuffer.ISerializationAdapter.Deserialize(BinaryStorageBuffer.Reader reader, Type t, uint offset, out uint size); // 0x0000000182059BE0-0x0000000182059D40
			uint UnityEngine.ResourceManagement.Util.BinaryStorageBuffer.ISerializationAdapter.Serialize(BinaryStorageBuffer.Writer writer, object val); // 0x0000000182059D40-0x0000000182059E30
		}
	
		// Constructors
		public ProviderLoadRequestOptions(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public ProviderLoadRequestOptions Copy(); // 0x0000000182050EF0-0x0000000182050F70
	}
}
