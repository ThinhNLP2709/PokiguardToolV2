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
	public struct BoundsInt : IEquatable<UnityEngine.BoundsInt>, IFormattable // TypeDefIndex: 7524
	{
		// Fields
		[SerializeField]
		private Vector3Int m_Position; // 0x00
		[SerializeField]
		private Vector3Int m_Size; // 0x0C
	
		// Properties
		public Vector3Int position { [IsReadOnly] get; set; } // 0x0000000181D8BE70-0x0000000181D8BE90 0x0000000181D8BED0-0x0000000181D8BEE0
		public Vector3Int size { [IsReadOnly] get; set; } // 0x0000000181EB8370-0x0000000181EB8390 0x000000018217AB50-0x000000018217AB60
	
		// Methods
		[IsReadOnly]
		public override string ToString(); // 0x000000018217AB40-0x000000018217AB50
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x000000018217A910-0x000000018217AB40
		[IsReadOnly]
		public override bool Equals(object other); // 0x000000018217A780-0x000000018217A860
		[IsReadOnly]
		public bool Equals(BoundsInt other); // 0x000000018217A740-0x000000018217A780
		[IsReadOnly]
		public bool Equals([IsReadOnly] in BoundsInt other); // 0x000000018217A740-0x000000018217A780
		[IsReadOnly]
		public override int GetHashCode(); // 0x000000018217A860-0x000000018217A910
	}
}
