/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Serialization
{
	internal class ClassMap : ObjectMap // TypeDefIndex: 6994
	{
		// Fields
		private Hashtable _elements; // 0x10
		private ArrayList _elementMembers; // 0x18
		private Hashtable _attributeMembers; // 0x20
		private XmlTypeMapMemberAttribute[] _attributeMembersArray; // 0x28
		private ArrayList _flatLists; // 0x30
		private ArrayList _allMembers; // 0x38
		private ArrayList _membersWithDefault; // 0x40
		private ArrayList _listMembers; // 0x48
		private XmlTypeMapMemberAnyElement _defaultAnyElement; // 0x50
		private XmlTypeMapMemberAnyAttribute _defaultAnyAttribute; // 0x58
		private XmlTypeMapMemberNamespaces _namespaceDeclarations; // 0x60
		private XmlTypeMapMember _xmlTextCollector; // 0x68
		private XmlTypeMapMember _returnMember; // 0x70
		private bool _ignoreMemberNamespace; // 0x78
		private bool _canBeSimpleType; // 0x79
		private bool? _isOrderDependentMap; // 0x7A
	
		// Properties
		public bool IsOrderDependentMap { get; } // 0x0000000181ACA2B0-0x0000000181ACA510 
		public XmlTypeMapMemberAnyElement DefaultAnyElementMember { get; } // 0x00000001806CCC00-0x00000001806CCC10 
		public XmlTypeMapMemberAnyAttribute DefaultAnyAttributeMember { get; } // 0x00000001802F4000-0x00000001802F4010 
		public XmlTypeMapMemberNamespaces NamespaceDeclarations { get; } // 0x0000000180333260-0x0000000180333490 
		public ICollection AttributeMembers { get; } // 0x0000000181AC9F30-0x0000000181ACA250 
		public ICollection ElementMembers { get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
		public ArrayList AllMembers { get; } // 0x00000001803272A0-0x00000001803272B0 
		public ArrayList FlatLists { get; } // 0x000000018031E110-0x000000018031E120 
		public ArrayList ListMembers { get; } // 0x00000001803272B0-0x00000001803272C0 
		public XmlTypeMapMember XmlTextCollector { get; } // 0x0000000180316960-0x0000000180316970 
		public XmlTypeMapMember ReturnMember { get; } // 0x000000018033D4D0-0x000000018033D4E0 
		public XmlQualifiedName SimpleContentBaseType { get; } // 0x0000000181ACA510-0x0000000181ACA730 
		public bool HasSimpleContent { get; } // 0x0000000181ACA250-0x0000000181ACA2B0 
	
		// Constructors
		public ClassMap(); // 0x0000000181AC9E90-0x0000000181AC9F30
	
		// Methods
		public void AddMember(XmlTypeMapMember member); // 0x0000000181AC8A20-0x0000000181AC96B0
		private void RegisterFlatList(XmlTypeMapMemberExpandable member); // 0x0000000181AC9DD0-0x0000000181AC9E90
		public XmlTypeMapMemberAttribute GetAttribute(string name, string ns); // 0x0000000181AC9780-0x0000000181AC98E0
		public XmlTypeMapElementInfo GetElement(string name, string ns, int minimalOrder); // 0x0000000181AC98E0-0x0000000181AC9BB0
		public XmlTypeMapElementInfo GetElement(string name, string ns); // 0x0000000181AC9BB0-0x0000000181AC9DD0
		private string BuildKey(string name, string ns, int explicitOrder); // 0x0000000181AC96B0-0x0000000181AC9780
		public void SetCanBeSimpleType(bool can); // 0x00000001819E0730-0x00000001819E0740
	}
}
