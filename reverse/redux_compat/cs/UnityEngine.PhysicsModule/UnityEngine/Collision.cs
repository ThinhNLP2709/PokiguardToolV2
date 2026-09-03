/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 48: UnityEngine.PhysicsModule.dll - Assembly: UnityEngine.PhysicsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15413-15444

namespace UnityEngine
{
	public class Collision // TypeDefIndex: 15417
	{
		// Fields
		private ContactPairHeader m_Header; // 0x10
		private ContactPair m_Pair; // 0x60
		private bool m_Flipped; // 0x90
		private ContactPoint[] m_LegacyContacts; // 0x98
	
		// Properties
		public Component body { get; } // 0x00000001822D48E0-0x00000001822D4960 
		public Collider collider { get; } // 0x00000001822D4960-0x00000001822D4980 
		public GameObject gameObject { get; } // 0x00000001822D4980-0x00000001822D4A40 
		internal bool Flipped { set; } // 0x000000018033EC10-0x000000018033EC20
	
		// Constructors
		public Collision(); // 0x00000001822D4880-0x00000001822D48E0
		internal Collision([IsReadOnly] in ContactPairHeader header, [IsReadOnly] in ContactPair pair, bool flipped); // 0x00000001822D47A0-0x00000001822D4880
	
		// Methods
		internal void Clear(); // 0x00000001822D46D0-0x00000001822D4720
		internal void Reuse([IsReadOnly] in ContactPairHeader header, [IsReadOnly] in ContactPair pair); // 0x00000001822D4720-0x00000001822D47A0
	}
}
