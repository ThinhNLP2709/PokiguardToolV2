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
	[ComVisible(true)]
	public class SoapAttribute : Attribute // TypeDefIndex: 2955
	{
		// Fields
		private bool _useAttribute; // 0x10
		protected string ProtXmlNamespace; // 0x18
		protected object ReflectInfo; // 0x20
	
		// Properties
		public virtual bool UseAttribute { get; } // 0x00000001805625D0-0x00000001805625E0 
		public virtual string XmlNamespace { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		public SoapAttribute(); // 0x00000001802F4070-0x00000001802F4080
	
		// Methods
		internal virtual void SetReflectionObject(object reflectionObject); // 0x000000018033E830-0x000000018033E840
	}
}
