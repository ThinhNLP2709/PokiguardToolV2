/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

// Image 29: Unity.2D.Animation.Runtime.dll - Assembly: Unity.2D.Animation.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 14331-14427

namespace UnityEngine.U2D.Animation
{
	[Serializable]
	[MovedFrom("UnityEngine.Experimental.U2D.Animation")]
	internal class SpriteCategoryEntry : INameHash, ISpriteLibraryLabel // TypeDefIndex: 14386
	{
		// Fields
		[SerializeField]
		private string m_Name; // 0x10
		[HideInInspector]
		[SerializeField]
		private int m_Hash; // 0x18
		[SerializeField]
		private Sprite m_Sprite; // 0x20
	
		// Properties
		public string name { get; set; } // 0x0000000180377550-0x0000000180377560 0x0000000181C1FD70-0x0000000181C1FE00
		public int hash { get; } // 0x0000000180B23260-0x0000000180B23270 
		public Sprite sprite { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
		// Constructors
		public SpriteCategoryEntry(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public void UpdateHash(); // 0x0000000181C1FCF0-0x0000000181C1FD70
	}
}
