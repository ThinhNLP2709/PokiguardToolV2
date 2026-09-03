/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

// Image 47: System.Xml.Linq.dll - Assembly: System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 - Types 15375-15412

namespace System.Xml.Linq
{
	[XmlSchemaProvider(null, IsAny = true)]
	[XmlTypeConvertor("ConvertForAssignment")]
	public class XElement : XContainer, IXmlSerializable // TypeDefIndex: 15389
	{
		// Fields
		internal XName name; // 0x30
		internal XAttribute lastAttr; // 0x38
	
		// Properties
		public bool HasAttributes { get; } // 0x00000001805DFAC0-0x00000001805DFAD0 
		public bool IsEmpty { get; } // 0x000000018195CB60-0x000000018195CB70 
		public XName Name { get; } // 0x000000018031E110-0x000000018031E120 
		public override XmlNodeType NodeType { get; } // 0x0000000180472790-0x00000001804727A0 
		public string Value { get; set; } // 0x000000018195CB70-0x000000018195CC80 0x000000018195CC80-0x000000018195CD00
	
		// Nested types
		[CompilerGenerated]
		private sealed class _GetAttributes_d__116 : IEnumerable<XAttribute>, IEnumerator<XAttribute> // TypeDefIndex: 15390
		{
			// Fields
			private int __1__state; // 0x10
			private XAttribute __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			public XElement __4__this; // 0x28
			private XName name; // 0x30
			public XName __3__name; // 0x38
			private XAttribute _a_5__2; // 0x40
	
			// Properties
			XAttribute IEnumerator<System.Xml.Linq.XAttribute>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _GetAttributes_d__116(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x0000000181956630-0x0000000181956710
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001819567C0-0x0000000181956800
			[DebuggerHidden]
			IEnumerator<XAttribute> IEnumerable<XAttribute>.GetEnumerator(); // 0x0000000181956710-0x00000001819567C0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181956710-0x00000001819567C0
		}
	
		// Constructors
		public XElement(XName name); // 0x000000018195CAE0-0x000000018195CB60
		public XElement(XElement other); // 0x000000018195C8C0-0x000000018195CA50
		public XElement(XStreamingElement other); // 0x000000018195CA50-0x000000018195CAE0
	
		// Methods
		public XAttribute Attribute(XName name); // 0x000000018195B580-0x000000018195B5C0
		public IEnumerable<XAttribute> Attributes(); // 0x000000018195B5C0-0x000000018195B650
		public string GetPrefixOfNamespace(XNamespace ns); // 0x000000018195B9C0-0x000000018195BC90
		public override void WriteTo(XmlWriter writer); // 0x000000018195C800-0x000000018195C8C0
		XmlSchema IXmlSerializable.GetSchema(); // 0x00000001802E7860-0x00000001802E7870
		void IXmlSerializable.ReadXml(XmlReader reader); // 0x000000018195C420-0x000000018195C640
		void IXmlSerializable.WriteXml(XmlWriter writer); // 0x000000018195C640-0x000000018195C660
		internal override void AddAttribute(XAttribute a); // 0x000000018195B130-0x000000018195B380
		internal override void AddAttributeSkipNotify(XAttribute a); // 0x000000018195AFB0-0x000000018195B130
		internal void AppendAttribute(XAttribute a); // 0x000000018195B410-0x000000018195B580
		internal void AppendAttributeSkipNotify(XAttribute a); // 0x000000018195B380-0x000000018195B410
		internal override XNode CloneNode(); // 0x000000018195B650-0x000000018195B810
		[IteratorStateMachine(typeof(_GetAttributes_d__116))]
		private IEnumerable<XAttribute> GetAttributes(XName name); // 0x000000018195B810-0x000000018195B8A0
		private string GetNamespaceOfPrefixInScope(string prefix, XElement outOfScope); // 0x000000018195B8A0-0x000000018195B9C0
		private void ReadElementFrom(XmlReader r, LoadOptions o); // 0x000000018195C300-0x000000018195C3A0
		private void ReadElementFromImpl(XmlReader r, LoadOptions o); // 0x000000018195BC90-0x000000018195C300
		internal void SetEndElementLineInfo(int lineNumber, int linePosition); // 0x000000018195C3A0-0x000000018195C420
		internal override void ValidateNode(XNode node, XNode previous); // 0x000000018195C660-0x000000018195C800
	}
}
