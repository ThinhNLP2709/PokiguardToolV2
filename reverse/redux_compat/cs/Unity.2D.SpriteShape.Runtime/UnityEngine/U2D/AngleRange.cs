/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 24: Unity.2D.SpriteShape.Runtime.dll - Assembly: Unity.2D.SpriteShape.Runtime, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13957-14022

namespace UnityEngine.U2D
{
	[Serializable]
	public class AngleRange : ICloneable // TypeDefIndex: 13995
	{
		// Fields
		[SerializeField]
		private float m_Start; // 0x10
		[SerializeField]
		private float m_End; // 0x14
		[SerializeField]
		private int m_Order; // 0x18
		[SerializeField]
		private List<Sprite> m_Sprites; // 0x20
	
		// Properties
		public float start { get; set; } // 0x00000001807187E0-0x00000001807187F0 0x00000001807187F0-0x0000000180718800
		public float end { get; set; } // 0x0000000181120AA0-0x0000000181120AB0 0x0000000181C40AB0-0x0000000181C40AC0
		public int order { get; set; } // 0x0000000180B23260-0x0000000180B23270 0x0000000180F9EB90-0x0000000180F9EBA0
		public List<Sprite> sprites { get; set; } // 0x00000001802F8630-0x00000001802F8640 0x000000018033E830-0x000000018033E840
	
		// Constructors
		public AngleRange(); // 0x0000000181C40A30-0x0000000181C40AB0
	
		// Methods
		public object Clone(); // 0x0000000181C40650-0x0000000181C40730
		public override bool Equals(object obj); // 0x0000000181C40730-0x0000000181C408F0
		public override int GetHashCode(); // 0x0000000181C408F0-0x0000000181C40A30
	}
}
