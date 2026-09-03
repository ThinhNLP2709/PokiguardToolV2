/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Serialization
{
	[Serializable]
	public abstract class SerializationBinder // TypeDefIndex: 3024
	{
		// Constructors
		protected SerializationBinder(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public virtual void BindToName(Type serializedType, out string assemblyName, out string typeName); // 0x00000001814EA860-0x00000001814EA890
		public abstract Type BindToType(string assemblyName, string typeName);
	}
}
