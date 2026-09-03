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
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface)]
	[ComVisible(true)]
	public sealed class SoapTypeAttribute : SoapAttribute // TypeDefIndex: 2959
	{
		// Fields
		private bool _useAttribute; // 0x28
		private string _xmlElementName; // 0x30
		private string _xmlNamespace; // 0x38
		private string _xmlTypeName; // 0x40
		private string _xmlTypeNamespace; // 0x48
		private bool _isType; // 0x50
		private bool _isElement; // 0x51
	
		// Properties
		public override bool UseAttribute { get; } // 0x0000000180327270-0x0000000180327280 
		public string XmlElementName { get; } // 0x000000018031E110-0x000000018031E120 
		public override string XmlNamespace { get; } // 0x00000001803272A0-0x00000001803272B0 
		public string XmlTypeName { get; } // 0x0000000180377940-0x0000000180377950 
		public string XmlTypeNamespace { get; } // 0x00000001803272B0-0x00000001803272C0 
		internal bool IsInteropXmlElement { get; } // 0x00000001802F4040-0x00000001802F4050 
		internal bool IsInteropXmlType { get; } // 0x0000000180377920-0x0000000180377930 
	
		// Constructors
		public SoapTypeAttribute(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		internal override void SetReflectionObject(object reflectionObject); // 0x00000001814EC1A0-0x00000001814EC3E0
	}
}
