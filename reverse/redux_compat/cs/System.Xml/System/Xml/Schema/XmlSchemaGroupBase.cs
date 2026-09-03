/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public abstract class XmlSchemaGroupBase : XmlSchemaParticle // TypeDefIndex: 7220
	{
		// Properties
		[XmlIgnore]
		public abstract XmlSchemaObjectCollection Items { get; }
	
		// Constructors
		protected XmlSchemaGroupBase(); // 0x00000001819DE3D0-0x00000001819DE420
	
		// Methods
		internal abstract void SetItems(XmlSchemaObjectCollection newItems);
	}
}
