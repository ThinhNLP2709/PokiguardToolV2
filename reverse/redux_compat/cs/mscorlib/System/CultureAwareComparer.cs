/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public sealed class CultureAwareComparer : StringComparer, ISerializable // TypeDefIndex: 2339
	{
		// Fields
		private readonly CompareInfo _compareInfo; // 0x10
		private CompareOptions _options; // 0x18
	
		// Constructors
		internal CultureAwareComparer(CultureInfo culture, CompareOptions options); // 0x0000000181615A50-0x0000000181615B60
		internal CultureAwareComparer(CompareInfo compareInfo, CompareOptions options); // 0x0000000181615DA0-0x0000000181615E80
		private CultureAwareComparer(SerializationInfo info, StreamingContext context); // 0x0000000181615B60-0x0000000181615DA0
	
		// Methods
		public override int Compare(string x, string y); // 0x0000000181615760-0x00000001816157D0
		public override bool Equals(string x, string y); // 0x00000001816157D0-0x0000000181615830
		public override int GetHashCode(string obj); // 0x0000000181615900-0x0000000181615980
		public override bool Equals(object obj); // 0x0000000181615830-0x00000001816158C0
		public override int GetHashCode(); // 0x00000001816158C0-0x0000000181615900
		public void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181615980-0x0000000181615A50
	}
}
