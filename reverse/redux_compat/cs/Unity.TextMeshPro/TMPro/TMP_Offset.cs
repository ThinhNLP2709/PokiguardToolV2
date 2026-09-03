/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

// Image 13: Unity.TextMeshPro.dll - Assembly: Unity.TextMeshPro, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 11765-11954

namespace TMPro
{
	public struct TMP_Offset // TypeDefIndex: 11786
	{
		// Fields
		private float m_Left; // 0x00
		private float m_Right; // 0x04
		private float m_Top; // 0x08
		private float m_Bottom; // 0x0C
		private static readonly TMP_Offset k_ZeroOffset; // 0x00
	
		// Properties
		public float left { get; set; } // 0x000000018035C780-0x000000018035C790 0x0000000181DBFEC0-0x0000000181DBFED0
		public float right { get; set; } // 0x000000018035C790-0x000000018035C7A0 0x0000000181CE28C0-0x0000000181CE28D0
		public float top { get; set; } // 0x00000001802DB050-0x00000001802DB060 0x0000000181DA9A50-0x0000000181DA9A60
		public float bottom { get; set; } // 0x00000001802DB040-0x00000001802DB050 0x0000000181DD0800-0x0000000181DD0810
		public float horizontal { get; set; } // 0x000000018035C780-0x000000018035C790 0x0000000181237540-0x0000000181237550
		public float vertical { get; set; } // 0x00000001802DB050-0x00000001802DB060 0x0000000182082290-0x00000001820822A0
		public static TMP_Offset zero { get; } // 0x0000000182082160-0x00000001820821C0 
	
		// Constructors
		public TMP_Offset(float left, float right, float top, float bottom); // 0x0000000182082140-0x0000000182082160
		public TMP_Offset(float horizontal, float vertical); // 0x0000000182082120-0x0000000182082140
		static TMP_Offset(); // 0x00000001820820E0-0x0000000182082120
	
		// Methods
		public static bool operator ==(TMP_Offset lhs, TMP_Offset rhs); // 0x000000018192E0B0-0x000000018192E0F0
		public static bool operator !=(TMP_Offset lhs, TMP_Offset rhs); // 0x00000001820821C0-0x0000000182082270
		public static TMP_Offset operator *(TMP_Offset a, float b); // 0x0000000182082270-0x0000000182082290
		public override int GetHashCode(); // 0x0000000182082090-0x00000001820820E0
		public override bool Equals(object obj); // 0x0000000182082030-0x0000000182082090
		public bool Equals(TMP_Offset other); // 0x0000000182081FB0-0x0000000182082030
	}
}
