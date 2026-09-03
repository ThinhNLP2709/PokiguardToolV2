/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.ResourceProviders
{
	public struct InstantiationParameters // TypeDefIndex: 13750
	{
		// Fields
		private Vector3 m_Position; // 0x00
		private Quaternion m_Rotation; // 0x0C
		private Transform m_Parent; // 0x20
		private bool m_InstantiateInWorldPosition; // 0x28
		private bool m_SetPositionRotation; // 0x29
	
		// Properties
		public Vector3 Position { get; } // 0x0000000181D8BE70-0x0000000181D8BE90 
		public Quaternion Rotation { get; } // 0x0000000181D8BE90-0x0000000181D8BEA0 
		public Transform Parent { get; } // 0x00000001802F8630-0x00000001802F8640 
		public bool InstantiateInWorldPosition { get; } // 0x0000000180327270-0x0000000180327280 
		public bool SetPositionRotation { get; } // 0x000000018052D500-0x000000018052D510 
	
		// Constructors
		public InstantiationParameters(Transform parent, bool instantiateInWorldSpace); // 0x000000018204B7D0-0x000000018204B840
		public InstantiationParameters(Vector3 position, Quaternion rotation, Transform parent); // 0x000000018204B840-0x000000018204B880
	
		// Methods
		public TObject Instantiate<TObject>(TObject source)
			where TObject : UnityEngine.Object;
	}
}
