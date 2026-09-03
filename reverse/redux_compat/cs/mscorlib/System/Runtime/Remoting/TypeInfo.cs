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

namespace System.Runtime.Remoting
{
	[Serializable]
	internal class TypeInfo : IRemotingTypeInfo // TypeDefIndex: 2897
	{
		// Fields
		private string serverType; // 0x10
		private string[] serverHierarchy; // 0x18
		private string[] interfacesImplemented; // 0x20
	
		// Properties
		public string TypeName { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Constructors
		public TypeInfo(Type type); // 0x00000001814CA160-0x00000001814CA5C0
	
		// Methods
		public bool CanCastTo(Type fromType, object o); // 0x00000001814C9F40-0x00000001814CA160
	}
}
