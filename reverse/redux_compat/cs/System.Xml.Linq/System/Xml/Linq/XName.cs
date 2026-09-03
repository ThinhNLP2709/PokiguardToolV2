/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 47: System.Xml.Linq.dll - Assembly: System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 - Types 15375-15412

namespace System.Xml.Linq
{
	[Serializable]
	public sealed class XName : IEquatable<XName>, ISerializable // TypeDefIndex: 15402
	{
		// Fields
		private XNamespace _ns; // 0x10
		private string _localName; // 0x18
		private int _hashCode; // 0x20
	
		// Properties
		public string LocalName { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public XNamespace Namespace { get; } // 0x0000000180377550-0x0000000180377560 
		public string NamespaceName { get; } // 0x0000000180FB1BE0-0x0000000180FB1C00 
	
		// Constructors
		internal XName(XNamespace ns, string localName); // 0x000000018195D090-0x000000018195D170
		internal XName(); // 0x000000018195D170-0x000000018195D1A0
	
		// Methods
		public override string ToString(); // 0x000000018195D000-0x000000018195D090
		public static XName Get(string expandedName); // 0x000000018195CD00-0x000000018195CED0
		public static XName Get(string localName, string namespaceName); // 0x000000018195CED0-0x000000018195CFC0
		[CLSCompliant(false)]
		public static implicit operator XName(string expandedName); // 0x000000018195D1A0-0x000000018195D1B0
		public override bool Equals(object obj); // 0x0000000180A29AB0-0x0000000180A29AC0
		public override int GetHashCode(); // 0x0000000180C4F680-0x0000000180C4F690
		public static bool operator ==(XName left, XName right); // 0x0000000180A29AB0-0x0000000180A29AC0
		bool IEquatable<XName>.Equals(XName other); // 0x0000000180A29AB0-0x0000000180A29AC0
		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context); // 0x000000018195CFC0-0x000000018195D000
	}
}
