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

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public abstract class MulticastDelegate : Delegate // TypeDefIndex: 2476
	{
		// Fields
		private Delegate[] delegates; // 0x78
	
		// Methods
		public override void GetObjectData(SerializationInfo info, StreamingContext context); // 0x0000000181650370-0x00000001816505A0
		protected sealed override object DynamicInvokeImpl(object[] args); // 0x0000000181656B00-0x0000000181656BC0
		public sealed override bool Equals(object obj); // 0x0000000181656BC0-0x0000000181656D10
		public sealed override int GetHashCode(); // 0x0000000181650130-0x00000001816501D0
		protected override MethodInfo GetMethodImpl(); // 0x0000000181656E00-0x0000000181656F60
		public sealed override Delegate[] GetInvocationList(); // 0x0000000181656D10-0x0000000181656E00
		protected sealed override Delegate CombineImpl(Delegate follow); // 0x0000000181656760-0x0000000181656B00
		private int LastIndexOf(Delegate[] haystack, Delegate[] needle); // 0x0000000181656F60-0x00000001816570F0
		protected sealed override Delegate RemoveImpl(Delegate value); // 0x00000001816570F0-0x0000000181657460
	}
}
