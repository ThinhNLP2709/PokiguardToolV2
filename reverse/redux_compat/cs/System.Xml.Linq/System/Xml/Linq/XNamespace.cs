/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 47: System.Xml.Linq.dll - Assembly: System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 - Types 15375-15412

namespace System.Xml.Linq
{
	public sealed class XNamespace // TypeDefIndex: 15403
	{
		// Fields
		private static XHashtable<WeakReference> s_namespaces; // 0x00
		private static WeakReference s_refNone; // 0x08
		private static WeakReference s_refXml; // 0x10
		private static WeakReference s_refXmlns; // 0x18
		private string _namespaceName; // 0x10
		private int _hashCode; // 0x18
		private XHashtable<XName> _names; // 0x20
	
		// Properties
		public string NamespaceName { get; } // 0x0000000180377550-0x0000000180377560 
		public static XNamespace None { get; } // 0x000000018195DA90-0x000000018195DAE0 
		public static XNamespace Xml { get; } // 0x000000018195DAE0-0x000000018195DB40 
		public static XNamespace Xmlns { get; } // 0x000000018195DB40-0x000000018195DBA0 
	
		// Constructors
		internal XNamespace(string namespaceName); // 0x000000018195D990-0x000000018195DA90
	
		// Methods
		public XName GetName(string localName); // 0x000000018195D4D0-0x000000018195D550
		public override string ToString(); // 0x0000000180377550-0x0000000180377560
		public static XNamespace Get(string namespaceName); // 0x000000018195D920-0x000000018195D990
		[CLSCompliant(false)]
		public static implicit operator XNamespace(string namespaceName); // 0x000000018195DBA0-0x000000018195DBC0
		public override bool Equals(object obj); // 0x0000000180A29AB0-0x0000000180A29AC0
		public override int GetHashCode(); // 0x0000000180B23260-0x0000000180B23270
		public static bool operator ==(XNamespace left, XNamespace right); // 0x0000000180A29AB0-0x0000000180A29AC0
		public static bool operator !=(XNamespace left, XNamespace right); // 0x000000018126B560-0x000000018126B570
		internal XName GetName(string localName, int index, int count); // 0x000000018195D340-0x000000018195D4D0
		internal static XNamespace Get(string namespaceName, int index, int count); // 0x000000018195D550-0x000000018195D920
		private static string ExtractLocalName(XName n); // 0x0000000180FB0360-0x0000000180FB0380
		private static string ExtractNamespace(WeakReference r); // 0x000000018195D2C0-0x000000018195D340
		private static XNamespace EnsureNamespace(ref WeakReference refNmsp, string namespaceName); // 0x000000018195D1B0-0x000000018195D2C0
	}
}
