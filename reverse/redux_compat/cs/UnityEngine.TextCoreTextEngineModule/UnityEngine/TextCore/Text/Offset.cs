/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 15: UnityEngine.TextCoreTextEngineModule.dll - Assembly: UnityEngine.TextCoreTextEngineModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 12610-12729

namespace UnityEngine.TextCore.Text
{
	internal struct Offset // TypeDefIndex: 12698
	{
		// Fields
		private float m_Left; // 0x00
		private float m_Right; // 0x04
		private float m_Top; // 0x08
		private float m_Bottom; // 0x0C
		private static readonly Offset k_ZeroOffset; // 0x00
	
		// Properties
		public float left { get; } // 0x000000018035C780-0x000000018035C790 
		public float right { get; } // 0x000000018035C790-0x000000018035C7A0 
		public float top { get; } // 0x00000001802DB050-0x00000001802DB060 
		public float bottom { get; } // 0x00000001802DB040-0x00000001802DB050 
		public static Offset zero { get; } // 0x00000001823335B0-0x0000000182333610 
	
		// Constructors
		public Offset(float left, float right, float top, float bottom); // 0x0000000182082140-0x0000000182082160
		static Offset(); // 0x0000000182333570-0x00000001823335B0
	
		// Methods
		public static bool operator ==(Offset lhs, Offset rhs); // 0x000000018192E0B0-0x000000018192E0F0
		public static Offset operator *(Offset a, float b); // 0x0000000182082270-0x0000000182082290
		public override int GetHashCode(); // 0x0000000182333520-0x0000000182333570
		public override bool Equals(object obj); // 0x00000001823334C0-0x0000000182333520
	}
}
