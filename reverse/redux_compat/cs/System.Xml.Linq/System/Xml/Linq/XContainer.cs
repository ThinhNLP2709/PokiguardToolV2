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
using System.Text;
using System.Xml;

// Image 47: System.Xml.Linq.dll - Assembly: System.Xml.Linq, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35 - Types 15375-15412

namespace System.Xml.Linq
{
	public abstract class XContainer : XNode // TypeDefIndex: 15383
	{
		// Fields
		internal object content; // 0x28
	
		// Properties
		public XNode LastNode { get; } // 0x000000018195A020-0x000000018195A190 
	
		// Nested types
		private sealed class ContentReader // TypeDefIndex: 15384
		{
			// Fields
			private readonly NamespaceCache _eCache; // 0x10
			private readonly NamespaceCache _aCache; // 0x20
			private readonly IXmlLineInfo _lineInfo; // 0x30
			private XContainer _currentContainer; // 0x38
			private string _baseUri; // 0x40
	
			// Constructors
			public ContentReader(XContainer rootContainer); // 0x00000001819551F0-0x0000000181955230
			public ContentReader(XContainer rootContainer, XmlReader r, LoadOptions o); // 0x0000000181955230-0x0000000181955300
	
			// Methods
			public bool ReadContentFrom(XContainer rootContainer, XmlReader r); // 0x0000000181954750-0x00000001819551F0
			public bool ReadContentFrom(XContainer rootContainer, XmlReader r, LoadOptions o); // 0x0000000181953860-0x0000000181954750
		}
	
		[CompilerGenerated]
		private sealed class _Nodes_d__18 : IEnumerable<XNode>, IEnumerator<XNode> // TypeDefIndex: 15385
		{
			// Fields
			private int __1__state; // 0x10
			private XNode __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			public XContainer __4__this; // 0x28
			private XNode _n_5__2; // 0x30
	
			// Properties
			XNode IEnumerator<System.Xml.Linq.XNode>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _Nodes_d__18(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
			private bool MoveNext(); // 0x0000000181956800-0x0000000181956A10
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x0000000181956AB0-0x0000000181956AF0
			[DebuggerHidden]
			IEnumerator<XNode> IEnumerable<XNode>.GetEnumerator(); // 0x0000000181956A10-0x0000000181956AB0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181956A10-0x0000000181956AB0
		}
	
		// Constructors
		internal XContainer(); // 0x00000001802E5CB0-0x00000001802E5CC0
		internal XContainer(XContainer other); // 0x0000000181959EC0-0x000000018195A020
	
		// Methods
		public void Add(object content); // 0x0000000181958620-0x00000001819589C0
		[IteratorStateMachine(typeof(_Nodes_d__18))]
		public IEnumerable<XNode> Nodes(); // 0x00000001819591E0-0x0000000181959260
		public void RemoveNodes(); // 0x0000000181959900-0x0000000181959D60
		internal virtual void AddAttribute(XAttribute a); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void AddAttributeSkipNotify(XAttribute a); // 0x00000001802E76C0-0x00000001802E76D0
		internal void AddContentSkipNotify(object content); // 0x0000000181957C50-0x0000000181957F70
		internal void AddNode(XNode n); // 0x0000000181958010-0x00000001819580B0
		internal void AddNodeSkipNotify(XNode n); // 0x0000000181957F70-0x0000000181958010
		internal void AddString(string s); // 0x0000000181958260-0x0000000181958620
		internal void AddStringSkipNotify(string s); // 0x00000001819580B0-0x0000000181958260
		internal void AppendNode(XNode n); // 0x0000000181958AB0-0x0000000181958BC0
		internal void AppendNodeSkipNotify(XNode n); // 0x00000001819589C0-0x0000000181958AB0
		internal override void AppendText(StringBuilder sb); // 0x0000000181958BC0-0x0000000181958CB0
		internal void ConvertTextToNode(); // 0x0000000181958CB0-0x0000000181958DC0
		internal static string GetStringValue(object value); // 0x0000000181958DC0-0x00000001819591E0
		internal void ReadContentFrom(XmlReader r); // 0x0000000181959260-0x0000000181959370
		internal void ReadContentFrom(XmlReader r, LoadOptions o); // 0x0000000181959370-0x0000000181959620
		internal void RemoveNode(XNode n); // 0x0000000181959620-0x0000000181959820
		private void RemoveNodesSkipNotify(); // 0x0000000181959820-0x0000000181959900
		internal virtual void ValidateNode(XNode node, XNode previous); // 0x00000001802E76C0-0x00000001802E76D0
		internal virtual void ValidateString(string s); // 0x00000001802E76C0-0x00000001802E76D0
		internal void WriteContentTo(XmlWriter writer); // 0x0000000181959D60-0x0000000181959EC0
	}
}
