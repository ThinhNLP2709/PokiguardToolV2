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

// Image 5: System.Xml.dll - Assembly: System.Xml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 6672-7340

namespace System.Xml.Schema
{
	public class XmlSchemaObjectCollection : CollectionBase // TypeDefIndex: 7232
	{
		// Fields
		private XmlSchemaObject parent; // 0x18
	
		// Properties
		public virtual XmlSchemaObject this[int index] { get => default; set {} } // 0x00000001819DF250-0x00000001819DF300 0x00000001819DF300-0x00000001819DF380
	
		// Constructors
		public XmlSchemaObjectCollection(); // 0x0000000181412020-0x0000000181412030
	
		// Methods
		public new XmlSchemaObjectEnumerator GetEnumerator(); // 0x00000001819DEF80-0x00000001819DF000
		public int Add(XmlSchemaObject item); // 0x00000001819DEE90-0x00000001819DEF00
		public void Insert(int index, XmlSchemaObject item); // 0x00000001819DF000-0x00000001819DF080
		public void Remove(XmlSchemaObject item); // 0x00000001819DF180-0x00000001819DF250
		protected override void OnInsert(int index, object item); // 0x00000001819DF0B0-0x00000001819DF0E0
		protected override void OnSet(int index, object oldValue, object newValue); // 0x00000001819DF110-0x00000001819DF180
		protected override void OnClear(); // 0x00000001819DF080-0x00000001819DF0B0
		protected override void OnRemove(int index, object item); // 0x00000001819DF0E0-0x00000001819DF110
		internal XmlSchemaObjectCollection Clone(); // 0x00000001819DEF00-0x00000001819DEF80
		private void Add(XmlSchemaObjectCollection collToAdd); // 0x00000001819DEE60-0x00000001819DEE90
	}
}
