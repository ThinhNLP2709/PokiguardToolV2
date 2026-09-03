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
	public class WellKnownClientTypeEntry : TypeEntry // TypeDefIndex: 2898
	{
		// Fields
		private Type obj_type; // 0x20
		private string obj_url; // 0x28
		private string app_url; // 0x30
	
		// Properties
		public string ApplicationUrl { get; } // 0x000000018031E110-0x000000018031E120 
		public Type ObjectType { get; } // 0x00000001802F8630-0x00000001802F8640 
		public string ObjectUrl { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Constructors
		public WellKnownClientTypeEntry(string typeName, string assemblyName, string objectUrl); // 0x00000001814CAB10-0x00000001814CAC60
	
		// Methods
		public override string ToString(); // 0x00000001814CAAD0-0x00000001814CAB10
	}
}
