/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	[ComVisible(true)]
	public abstract class MarshalByRefObject // TypeDefIndex: 2470
	{
		// Fields
		[NonSerialized]
		private object _identity; // 0x10
	
		// Properties
		internal ServerIdentity ObjectIdentity { get; set; } // 0x0000000181652D40-0x0000000181652D80 0x0000000181652D80-0x0000000181652DC0
	
		// Constructors
		protected MarshalByRefObject(); // 0x00000001802E76C0-0x00000001802E76D0
	
		// Methods
		public virtual ObjRef CreateObjRef(Type requestedType); // 0x0000000181652CC0-0x0000000181652D00
		public virtual object InitializeLifetimeService(); // 0x0000000181652D00-0x0000000181652D40
	}
}
