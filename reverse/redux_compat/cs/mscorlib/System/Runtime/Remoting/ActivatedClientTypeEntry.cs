/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.Remoting
{
	[ComVisible(true)]
	public class ActivatedClientTypeEntry : TypeEntry // TypeDefIndex: 2870
	{
		// Fields
		private string applicationUrl; // 0x20
		private Type obj_type; // 0x28
	
		// Properties
		public string ApplicationUrl { get; } // 0x00000001802F8630-0x00000001802F8640 
		public IContextAttribute[] ContextAttributes { get; } // 0x00000001802E7860-0x00000001802E7870 
		public Type ObjectType { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Constructors
		public ActivatedClientTypeEntry(string typeName, string assemblyName, string appUrl); // 0x00000001814ADBF0-0x00000001814ADD40
	
		// Methods
		public override string ToString(); // 0x00000001814ADBD0-0x00000001814ADBF0
	}
}
