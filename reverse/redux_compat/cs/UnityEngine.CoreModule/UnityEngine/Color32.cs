/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Scripting;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[Serializable]
	[DefaultMember("Item")]
	[UsedByNativeCode]
	public struct Color32 : IEquatable<UnityEngine.Color32>, IFormattable // TypeDefIndex: 7656
	{
		// Fields
		[Ignore(DoesNotContributeToSize = true)]
		private int rgba; // 0x00
		public byte r; // 0x00
		public byte g; // 0x01
		public byte b; // 0x02
		public byte a; // 0x03
	
		// Constructors
		public Color32(byte r, byte g, byte b, byte a); // 0x0000000180F4CB10-0x0000000180F4CB30
	
		// Methods
		public static implicit operator Color32(Color c); // 0x00000001805E9E20-0x00000001805E9F10
		public static implicit operator Color(Color32 c); // 0x00000001821C7A60-0x00000001821C7AD0
		[IsReadOnly]
		public override int GetHashCode(); // 0x00000001814330E0-0x00000001814330F0
		[IsReadOnly]
		public override bool Equals(object other); // 0x00000001821C7780-0x00000001821C7800
		[IsReadOnly]
		public bool Equals(Color32 other); // 0x00000001815FCAB0-0x00000001815FCAC0
		[IsReadOnly]
		public bool Equals([IsReadOnly] in Color32 other); // 0x000000018216CF90-0x000000018216CFA0
		[IsReadOnly]
		public override string ToString(); // 0x00000001821C7A50-0x00000001821C7A60
		[IsReadOnly]
		public string ToString(string format, IFormatProvider formatProvider); // 0x00000001821C7800-0x00000001821C7A50
	}
}
