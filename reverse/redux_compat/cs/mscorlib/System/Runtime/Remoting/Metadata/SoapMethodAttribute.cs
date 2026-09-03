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
	[AttributeUsage(AttributeTargets.Method)]
	[ComVisible(true)]
	public sealed class SoapMethodAttribute : SoapAttribute // TypeDefIndex: 2957
	{
		// Fields
		private string _responseElement; // 0x28
		private string _responseNamespace; // 0x30
		private string _returnElement; // 0x38
		private string _soapAction; // 0x40
		private bool _useAttribute; // 0x48
		private string _namespace; // 0x50
	
		// Properties
		public override bool UseAttribute { get; } // 0x00000001804EFDA0-0x00000001804EFDB0 
		public override string XmlNamespace { get; } // 0x00000001806CCC00-0x00000001806CCC10 
	
		// Constructors
		public SoapMethodAttribute(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		internal override void SetReflectionObject(object reflectionObject); // 0x00000001814EBF80-0x00000001814EC1A0
	}
}
