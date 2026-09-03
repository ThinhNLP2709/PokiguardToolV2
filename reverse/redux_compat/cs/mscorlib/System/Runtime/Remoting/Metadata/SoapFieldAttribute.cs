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

namespace System.Runtime.Remoting.Metadata
{
	[AttributeUsage(AttributeTargets.Field)]
	[ComVisible(true)]
	public sealed class SoapFieldAttribute : SoapAttribute // TypeDefIndex: 2956
	{
		// Fields
		private string _elementName; // 0x28
		private bool _isElement; // 0x30
	
		// Properties
		public string XmlElementName { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Constructors
		public SoapFieldAttribute(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		public bool IsInteropXmlElement(); // 0x00000001802E8950-0x00000001802E8960
		internal override void SetReflectionObject(object reflectionObject); // 0x00000001814EBEF0-0x00000001814EBF80
	}
}
