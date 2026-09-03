/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Serialization;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Events
{
	[Serializable]
	internal class ArgumentCache : ISerializationCallbackReceiver // TypeDefIndex: 7921
	{
		// Fields
		[FormerlySerializedAs("objectArgument")]
		[SerializeField]
		private UnityEngine.Object m_ObjectArgument; // 0x10
		[FormerlySerializedAs("objectArgumentAssemblyTypeName")]
		[SerializeField]
		private string m_ObjectArgumentAssemblyTypeName; // 0x18
		[FormerlySerializedAs("intArgument")]
		[SerializeField]
		private int m_IntArgument; // 0x20
		[FormerlySerializedAs("floatArgument")]
		[SerializeField]
		private float m_FloatArgument; // 0x24
		[FormerlySerializedAs("stringArgument")]
		[SerializeField]
		private string m_StringArgument; // 0x28
		[SerializeField]
		private bool m_BoolArgument; // 0x30
	
		// Properties
		public UnityEngine.Object unityObjectArgument { get; } // 0x0000000180377550-0x0000000180377560 
		public string unityObjectArgumentAssemblyTypeName { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public int intArgument { get; } // 0x0000000180C4F680-0x0000000180C4F690 
		public float floatArgument { get; } // 0x0000000181CE2830-0x0000000181CE2840 
		public string stringArgument { get; } // 0x000000018033D240-0x000000018033D250 
		public bool boolArgument { get; } // 0x00000001802E8950-0x00000001802E8960 
	
		// Constructors
		public ArgumentCache(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void OnBeforeSerialize(); // 0x00000001822005D0-0x0000000182200600
		public void OnAfterDeserialize(); // 0x00000001822005D0-0x0000000182200600
	}
}
