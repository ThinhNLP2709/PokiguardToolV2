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

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[NativeClass("AABB")]
	[NativeHeader("Runtime/Geometry/Intersection.h")]
	[NativeHeader("Runtime/Geometry/Ray.h")]
	[NativeHeader("Runtime/Geometry/AABB.h")]
	[NativeHeader("Runtime/Geometry/AABB.h")]
	[NativeHeader("Runtime/Math/MathScripting.h")]
	[RequiredByNativeCode(Optional = true, GenerateProxy = true)]
	public struct Bounds : IEquatable<UnityEngine.Bounds>, IFormattable // TypeDefIndex: 7523
	{
		// Fields
		private Vector3 m_Center; // 0x00
		[NativeName("m_Extent")]
		private Vector3 m_Extents; // 0x0C
	
		// Properties
		public Vector3 center { [IsReadOnly] get; set; } // 0x0000000181D8BE70-0x0000000181D8BE90 0x0000000181D8BED0-0x0000000181D8BEE0
		public Vector3 size { [IsReadOnly] get; set; } // 0x000000018217B250-0x000000018217B280 0x000000018217B420-0x000000018217B460
		public Vector3 extents { [IsReadOnly] get; set; } // 0x0000000181EB8370-0x0000000181EB8390 0x000000018217AB50-0x000000018217AB60
		public Vector3 min { [IsReadOnly] get; set; } // 0x000000018217B220-0x000000018217B250 0x000000018217B3B0-0x000000018217B420
		public Vector3 max { [IsReadOnly] get; set; } // 0x000000018217B1F0-0x000000018217B220 0x000000018217B330-0x000000018217B3B0
	
		// Constructors
		public Bounds(Vector3 center, Vector3 size); // 0x000000018217B1A0-0x000000018217B1F0
	
		// Methods
		[IsReadOnly]
		public override int GetHashCode(); // 0x0000000180C71E70-0x0000000180C71F10
		[IsReadOnly]
		public override bool Equals(object other); // 0x000000018217AD40-0x000000018217AE30
		[IsReadOnly]
		public bool Equals(Bounds other); // 0x000000018217ACE0-0x000000018217AD40
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Bounds other); // 0x000000018217ACE0-0x000000018217AD40
		public static bool operator !=(Bounds lhs, Bounds rhs); // 0x000000018217B280-0x000000018217B330
		public void SetMinMax(Vector3 min, Vector3 max); // 0x000000018217B030-0x000000018217B0A0
		public void SetMinMax([IsReadOnly] in Vector3 min, [IsReadOnly] in Vector3 max); // 0x000000018217AFD0-0x000000018217B030
		public void Encapsulate(Vector3 point); // 0x000000018217AB60-0x000000018217AC20
		public void Encapsulate([IsReadOnly] in Vector3 point); // 0x000000018217AC20-0x000000018217ACE0
		public void Encapsulate(Bounds bounds); // 0x0000000181C3FF90-0x0000000181C40150
		[IsReadOnly]
		public bool Intersects(Bounds bounds); // 0x000000018217AEE0-0x000000018217AFD0
		[IsReadOnly]
		public bool IntersectRay(Ray ray); // 0x000000018217AE90-0x000000018217AEE0
		[IsReadOnly]
		public override string ToString(); // 0x000000018217B190-0x000000018217B1A0
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x000000018217B0A0-0x000000018217B190
		[FreeFunction("IntersectRayAABB", IsThreadSafe = true)]
		private static bool IntersectRayAABB([IsReadOnly] in Ray ray, [IsReadOnly] in Bounds bounds, out float dist); // 0x000000018217AE30-0x000000018217AE90
	}
}
