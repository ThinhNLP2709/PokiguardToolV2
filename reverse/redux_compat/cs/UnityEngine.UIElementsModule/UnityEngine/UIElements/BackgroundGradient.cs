/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[Serializable]
	public struct BackgroundGradient : IEquatable<BackgroundGradient> // TypeDefIndex: 4364
	{
		// Fields
		[SerializeField]
		private GradientType m_Type; // 0x00
		[SerializeField]
		private float m_Angle; // 0x04
		[SerializeField]
		private BackgroundGradientStop[] m_Stops; // 0x08
		[SerializeField]
		private BackgroundGradientShape m_Shape; // 0x10
		[SerializeField]
		private BackgroundGradientSize m_Size; // 0x14
		[SerializeField]
		private Vector2 m_Position; // 0x18
	
		// Properties
		public GradientType type { get; set; } // 0x0000000180732D10-0x0000000180732D20 0x0000000180732D50-0x0000000180732D60
		public float angle { get; set; } // 0x000000018035C790-0x000000018035C7A0 0x0000000181CE28C0-0x0000000181CE28D0
		public BackgroundGradientStop[] stops { get; set; } // 0x0000000180C5CF90-0x0000000180C5CFA0 0x0000000181B9F360-0x0000000181B9F370
		public BackgroundGradientShape shape { get; set; } // 0x00000001802E64B0-0x00000001802E64C0 0x00000001805D5560-0x00000001805D5570
		public BackgroundGradientSize size { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public Vector2 position { get; set; } // 0x0000000180FAFC30-0x0000000180FAFC50 0x00000001804C2E30-0x00000001804C2E40
	
		// Methods
		public bool IsEmpty(); // 0x00000001824CFCF0-0x00000001824CFD10
		public bool Equals(BackgroundGradient other); // 0x00000001824CF940-0x00000001824CFB40
		public override bool Equals(object obj); // 0x00000001824CFB40-0x00000001824CFBE0
		public override int GetHashCode(); // 0x00000001824CFBE0-0x00000001824CFCF0
		public override string ToString(); // 0x00000001824CFE80-0x00000001824D01D0
		private string StopsToString(); // 0x00000001824CFD10-0x00000001824CFE80
	}
}
