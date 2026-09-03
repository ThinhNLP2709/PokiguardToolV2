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
	[ComVisible(true)]
	public class WellKnownServiceTypeEntry : TypeEntry // TypeDefIndex: 2900
	{
		// Fields
		private Type obj_type; // 0x20
		private string obj_uri; // 0x28
		private WellKnownObjectMode obj_mode; // 0x30
	
		// Properties
		public WellKnownObjectMode Mode { get; } // 0x000000018033D100-0x000000018033D110 
		public Type ObjectType { get; } // 0x00000001802F8630-0x00000001802F8640 
		public string ObjectUri { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Constructors
		public WellKnownServiceTypeEntry(string typeName, string assemblyName, string objectUri, WellKnownObjectMode mode); // 0x00000001814CAD60-0x00000001814CAEC0
	
		// Methods
		public override string ToString(); // 0x00000001814CAC60-0x00000001814CAD60
	}
}
