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
	public class XmlSchemaObjectEnumerator : IEnumerator // TypeDefIndex: 7233
	{
		// Fields
		private IEnumerator enumerator; // 0x10
	
		// Properties
		public XmlSchemaObject Current { get; } // 0x00000001819E7A10-0x00000001819E7AB0 
		object IEnumerator.Current { get; } // 0x00000001819E79C0-0x00000001819E7A10 
	
		// Constructors
		internal XmlSchemaObjectEnumerator(IEnumerator enumerator); // 0x00000001803855F0-0x0000000180385630
	
		// Methods
		public bool MoveNext(); // 0x00000001819E78D0-0x00000001819E7920
		void IEnumerator.Reset(); // 0x00000001819E7970-0x00000001819E79C0
		bool IEnumerator.MoveNext(); // 0x00000001819E7920-0x00000001819E7970
	}
}
