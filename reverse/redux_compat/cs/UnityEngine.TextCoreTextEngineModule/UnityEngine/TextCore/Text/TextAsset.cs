/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Serialization;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	[Serializable]
	[ExcludeFromObjectFactory]
	public abstract class TextAsset : ScriptableObject // TypeDefIndex: 12667
	{
		// Fields
		[SerializeField]
		internal string m_Version; // 0x18
		[NonSerialized]
		internal EntityId m_EntityId; // 0x20
		internal int m_HashCode; // 0x28
		[FormerlySerializedAs("material")]
		[SerializeField]
		internal Material m_Material; // 0x30
		internal int m_MaterialHashCode; // 0x38
	
		// Properties
		public string version { get; internal set; } // 0x00000001802F8EC0-0x00000001802F8ED0 0x00000001802FAF70-0x00000001802FAF80
		public EntityId entityId { get; } // 0x000000018206F200-0x000000018206F250 
		[Obsolete("Use entityId instead.")]
		public int instanceID { get; } // 0x0000000182335870-0x00000001823358C0 
		public int hashCode { get; set; } // 0x0000000182335830-0x0000000182335870 0x0000000180378100-0x0000000180378110
		public Material material { get; set; } // 0x000000018031E110-0x000000018031E120 0x0000000180378110-0x0000000180378120
		public int materialHashCode { get; set; } // 0x00000001823358C0-0x0000000182335960 0x00000001805D5570-0x00000001805D5580
	
		// Constructors
		protected TextAsset(); // 0x00000001805F5FD0-0x00000001805F5FE0
	
		// Methods
		internal virtual void OnDestroy(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
