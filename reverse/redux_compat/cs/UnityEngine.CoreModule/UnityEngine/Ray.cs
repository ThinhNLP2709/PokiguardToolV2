/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	public struct Ray : IFormattable // TypeDefIndex: 7527
	{
		// Fields
		private Vector3 m_Origin; // 0x00
		private Vector3 m_Direction; // 0x0C
	
		// Properties
		public Vector3 origin { [IsReadOnly] get; set; } // 0x0000000181D8BE70-0x0000000181D8BE90 0x0000000181D8BED0-0x0000000181D8BEE0
		public Vector3 direction { [IsReadOnly] get; } // 0x0000000181EB8370-0x0000000181EB8390 
	
		// Constructors
		public Ray(Vector3 origin, Vector3 direction); // 0x0000000182192630-0x0000000182192660
	
		// Methods
		[IsReadOnly]
		public Vector3 GetPoint(float distance); // 0x00000001821924F0-0x0000000182192530
		[IsReadOnly]
		public override string ToString(); // 0x0000000182192530-0x0000000182192540
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x0000000182192540-0x0000000182192630
	}
}
