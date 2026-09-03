/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;
using UnityEngine.Scripting.APIUpdating;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.U2D
{
	[Serializable]
	[MovedFrom("UnityEngine.Experimental.U2D")]
	[NativeHeader("Runtime/2D/Common/SpriteDataAccess.h")]
	[NativeHeader("Runtime/2D/Common/SpriteTypes.h")]
	[RequiredByNativeCode]
	public struct SpriteBone // TypeDefIndex: 8463
	{
		// Fields
		[NativeName("name")]
		[SerializeField]
		private string m_Name; // 0x00
		[NativeName("guid")]
		[SerializeField]
		private string m_Guid; // 0x08
		[NativeName("position")]
		[SerializeField]
		private Vector3 m_Position; // 0x10
		[NativeName("rotation")]
		[SerializeField]
		private Quaternion m_Rotation; // 0x1C
		[NativeName("length")]
		[SerializeField]
		private float m_Length; // 0x2C
		[NativeName("parentId")]
		[SerializeField]
		private int m_ParentId; // 0x30
		[NativeName("color")]
		[SerializeField]
		private Color32 m_Color; // 0x34
	
		// Properties
		public string name { get; } // 0x00000001808BADD0-0x00000001808BADE0 
		public string guid { get; } // 0x0000000180C5CF90-0x0000000180C5CFA0 
		public Vector3 position { get; } // 0x0000000180719290-0x00000001807192B0 
		public Quaternion rotation { get; } // 0x000000018226C980-0x000000018226C990 
		public int parentId { get; } // 0x000000018033D100-0x000000018033D110 
	}
}
