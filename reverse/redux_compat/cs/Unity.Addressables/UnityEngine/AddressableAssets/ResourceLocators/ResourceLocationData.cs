/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.ResourceManagement.Util;
using UnityEngine.Serialization;

// Image 25: Unity.Addressables.dll - Assembly: Unity.Addressables, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14023-14125

namespace UnityEngine.AddressableAssets.ResourceLocators
{
	[Serializable]
	public class ResourceLocationData // TypeDefIndex: 14111
	{
		// Fields
		[FormerlySerializedAs("m_keys")]
		[SerializeField]
		private string[] m_Keys; // 0x10
		[FormerlySerializedAs("m_internalId")]
		[SerializeField]
		private string m_InternalId; // 0x18
		[FormerlySerializedAs("m_provider")]
		[SerializeField]
		private string m_Provider; // 0x20
		[FormerlySerializedAs("m_dependencies")]
		[SerializeField]
		private string[] m_Dependencies; // 0x28
		[SerializeField]
		private SerializedType m_ResourceType; // 0x30
		[SerializeField]
		private byte[] SerializedData; // 0x50
		private object _Data; // 0x58
	
		// Properties
		public string[] Keys { get; } // 0x0000000180377550-0x0000000180377560 
		public string InternalId { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public string Provider { get; } // 0x00000001802F8630-0x00000001802F8640 
		public string[] Dependencies { get; } // 0x000000018033D240-0x000000018033D250 
		public Type ResourceType { get; } // 0x0000000181C7EAA0-0x0000000181C7EAB0 
		public object Data { get; set; } // 0x0000000181C7EA40-0x0000000181C7EAA0 0x0000000181C7EAB0-0x0000000181C7EB60
	
		// Constructors
		public ResourceLocationData(string[] keys, string id, Type provider, Type t, string[] dependencies = null); // 0x0000000181C7E8E0-0x0000000181C7EA40
	}
}
