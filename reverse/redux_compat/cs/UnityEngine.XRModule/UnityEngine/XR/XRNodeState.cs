/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 46: UnityEngine.XRModule.dll - Assembly: UnityEngine.XRModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 15337-15374

namespace UnityEngine.XR
{
	[UsedByNativeCode]
	public struct XRNodeState // TypeDefIndex: 15344
	{
		// Fields
		private XRNode m_Type; // 0x00
		private AvailableTrackingData m_AvailableFields; // 0x04
		private Vector3 m_Position; // 0x08
		private Quaternion m_Rotation; // 0x14
		private Vector3 m_Velocity; // 0x24
		private Vector3 m_AngularVelocity; // 0x30
		private Vector3 m_Acceleration; // 0x3C
		private Vector3 m_AngularAcceleration; // 0x48
		private int m_Tracked; // 0x54
		private ulong m_UniqueID; // 0x58
	
		// Properties
		public ulong uniqueID { set; } // 0x000000018044C5A0-0x000000018044C5B0
		public XRNode nodeType { set; } // 0x0000000180732D50-0x0000000180732D60
		public bool tracked { set; } // 0x00000001825D7F40-0x00000001825D7F50
	}
}
