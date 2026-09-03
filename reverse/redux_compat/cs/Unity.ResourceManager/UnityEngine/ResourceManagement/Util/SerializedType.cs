/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	[Serializable]
	public struct SerializedType // TypeDefIndex: 13721
	{
		// Fields
		[FormerlySerializedAs("m_assemblyName")]
		[SerializeField]
		private string m_AssemblyName; // 0x00
		[FormerlySerializedAs("m_className")]
		[SerializeField]
		private string m_ClassName; // 0x08
		private Type m_CachedType; // 0x10
		[CompilerGenerated]
		private bool _ValueChanged_k__BackingField; // 0x18
	
		// Properties
		public string AssemblyName { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public string ClassName { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
		public Type Value { get; set; } // 0x0000000182059EE0-0x000000018205A050 0x000000018205A050-0x000000018205A130
		public bool ValueChanged { [IsReadOnly] [CompilerGenerated] get; [CompilerGenerated] set; } // 0x0000000180F9E350-0x0000000180F9E360 0x00000001804C2E10-0x00000001804C2E20
	
		// Methods
		public override string ToString(); // 0x0000000182059E30-0x0000000182059EE0
	}
}
