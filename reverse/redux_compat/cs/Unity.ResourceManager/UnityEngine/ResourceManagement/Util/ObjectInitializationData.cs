/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.Serialization;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	[Serializable]
	public struct ObjectInitializationData // TypeDefIndex: 13722
	{
		// Fields
		[FormerlySerializedAs("m_id")]
		[SerializeField]
		private string m_Id; // 0x00
		[FormerlySerializedAs("m_objectType")]
		[SerializeField]
		private SerializedType m_ObjectType; // 0x08
		[FormerlySerializedAs("m_data")]
		[SerializeField]
		private string m_Data; // 0x28
	
		// Properties
		public string Id { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public SerializedType ObjectType { get; } // 0x0000000180C5D120-0x0000000180C5D140 
		public string Data { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Nested types
		internal class Serializer : BinaryStorageBuffer.ISerializationAdapter<ObjectInitializationData> // TypeDefIndex: 13723
		{
			// Properties
			public IEnumerable<BinaryStorageBuffer.ISerializationAdapter> Dependencies { get; } // 0x00000001802E7860-0x00000001802E7870 
	
			// Nested types
			private struct Data // TypeDefIndex: 13724
			{
				// Fields
				public uint id; // 0x00
				public uint type; // 0x04
				public uint data; // 0x08
			}
	
			// Constructors
			public Serializer(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			public object Deserialize(BinaryStorageBuffer.Reader reader, Type t, uint offset, out uint size); // 0x000000018205A130-0x000000018205A490
			public uint Serialize(BinaryStorageBuffer.Writer writer, object val); // 0x000000018205A490-0x000000018205A600
		}
	
		// Methods
		public override string ToString(); // 0x00000001820507D0-0x0000000182050850
		public TObject CreateInstance<TObject>(string idOverride = null);
		public AsyncOperationHandle GetAsyncInitHandle(ResourceManager rm, string idOverride = null); // 0x00000001820505B0-0x00000001820507D0
	}
}
