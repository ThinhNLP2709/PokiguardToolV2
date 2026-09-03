/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	internal class CompiledIdentityConstraint // TypeDefIndex: 7011
	{
		// Fields
		internal XmlQualifiedName name; // 0x10
		private ConstraintRole role; // 0x18
		private Asttree selector; // 0x20
		private Asttree[] fields; // 0x28
		internal XmlQualifiedName refer; // 0x30
		public static readonly CompiledIdentityConstraint Empty; // 0x00
	
		// Properties
		public ConstraintRole Role { get; } // 0x0000000180B23260-0x0000000180B23270 
		public Asttree Selector { get; } // 0x00000001802F8630-0x00000001802F8640 
		public Asttree[] Fields { get; } // 0x000000018033D240-0x000000018033D250 
	
		// Nested types
		public enum ConstraintRole // TypeDefIndex: 7012
		{
			Unique = 0,
			Key = 1,
			Keyref = 2
		}
	
		// Constructors
		private CompiledIdentityConstraint(); // 0x0000000181ACA810-0x0000000181ACA8A0
		public CompiledIdentityConstraint(XmlSchemaIdentityConstraint constraint, XmlNamespaceManager nsmgr); // 0x0000000181ACA8A0-0x0000000181ACAD50
		static CompiledIdentityConstraint(); // 0x0000000181ACA730-0x0000000181ACA810
	}
}
