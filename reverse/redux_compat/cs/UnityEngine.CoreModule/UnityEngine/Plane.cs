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
	[UsedByNativeCode]
	public struct Plane : IEquatable<UnityEngine.Plane>, IFormattable // TypeDefIndex: 7526
	{
		// Fields
		private Vector3 m_Normal; // 0x00
		private float m_Distance; // 0x0C
	
		// Properties
		public Vector3 normal { [IsReadOnly] get; } // 0x0000000181D8BE70-0x0000000181D8BE90 
		public float distance { [IsReadOnly] get; } // 0x00000001802DB040-0x00000001802DB050 
	
		// Constructors
		public Plane(Vector3 inNormal, Vector3 inPoint); // 0x00000001821912F0-0x0000000182191360
		public Plane(Vector3 inNormal, float d); // 0x0000000182191360-0x00000001821913A0
		public Plane(Vector3 a, Vector3 b, Vector3 c); // 0x00000001821913A0-0x0000000182191490
	
		// Methods
		[IsReadOnly]
		public float GetDistanceToPoint(Vector3 point); // 0x0000000182191070-0x00000001821910A0
		[IsReadOnly]
		public bool Raycast(Ray ray, out float enter); // 0x0000000182191110-0x00000001821911F0
		public static bool operator ==(Plane lhs, Plane rhs); // 0x0000000182191490-0x0000000182191500
		[IsReadOnly]
		public override bool Equals(object other); // 0x0000000182190F20-0x0000000182191000
		[IsReadOnly]
		public bool Equals(Plane other); // 0x0000000182191000-0x0000000182191070
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Plane other); // 0x0000000182191000-0x0000000182191070
		[IsReadOnly]
		public override int GetHashCode(); // 0x00000001821910A0-0x0000000182191110
		[IsReadOnly]
		public override string ToString(); // 0x00000001821912E0-0x00000001821912F0
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821911F0-0x00000001821912E0
	}
}
