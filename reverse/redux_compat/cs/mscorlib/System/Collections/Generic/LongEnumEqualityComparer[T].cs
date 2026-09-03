/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Collections.Generic
{
	[Serializable]
	internal sealed class LongEnumEqualityComparer<T> : EqualityComparer<T>, ISerializable // TypeDefIndex: 3620
		where T : struct
	{
		// Constructors
		public LongEnumEqualityComparer();
		public LongEnumEqualityComparer(SerializationInfo information, StreamingContext context);
	
		// Methods
		public override bool Equals(T x, T y);
		public override int GetHashCode(T obj);
		public override bool Equals(object obj);
		public override int GetHashCode();
		public void GetObjectData(SerializationInfo info, StreamingContext context);
	}
}
