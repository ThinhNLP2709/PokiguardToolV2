/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[UsedByNativeCode]
	public struct BoneWeight : IEquatable<UnityEngine.BoneWeight> // TypeDefIndex: 7629
	{
		// Fields
		[SerializeField]
		private float m_Weight0; // 0x00
		[SerializeField]
		private float m_Weight1; // 0x04
		[SerializeField]
		private float m_Weight2; // 0x08
		[SerializeField]
		private float m_Weight3; // 0x0C
		[SerializeField]
		private int m_BoneIndex0; // 0x10
		[SerializeField]
		private int m_BoneIndex1; // 0x14
		[SerializeField]
		private int m_BoneIndex2; // 0x18
		[SerializeField]
		private int m_BoneIndex3; // 0x1C
	
		// Properties
		public float weight0 { get; } // 0x000000018035C780-0x000000018035C790 
		public float weight1 { get; } // 0x000000018035C790-0x000000018035C7A0 
		public float weight2 { get; } // 0x00000001802DB050-0x00000001802DB060 
		public float weight3 { get; } // 0x00000001802DB040-0x00000001802DB050 
		public int boneIndex0 { get; } // 0x00000001802E64B0-0x00000001802E64C0 
		public int boneIndex1 { get; } // 0x0000000180A5E110-0x0000000180A5E120 
		public int boneIndex2 { get; } // 0x0000000180B23260-0x0000000180B23270 
		public int boneIndex3 { get; } // 0x0000000180B232F0-0x0000000180B23300 
	
		// Methods
		public override int GetHashCode(); // 0x000000018219CFC0-0x000000018219D0E0
		public override bool Equals(object other); // 0x000000018219CF20-0x000000018219CFC0
		public bool Equals(BoneWeight other); // 0x000000018219CE50-0x000000018219CF20
	}
}
