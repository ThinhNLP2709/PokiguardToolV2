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

namespace System.Xml
{
	public abstract class XmlNodeList : IEnumerable, IDisposable // TypeDefIndex: 6838
	{
		// Properties
		public abstract int Count { get; }
		public virtual XmlNode this[int i] { get => default; } // 0x000000018164FA90-0x000000018164FAB0 
	
		// Constructors
		protected XmlNodeList(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		public abstract XmlNode Item(int index);
		public abstract IEnumerator GetEnumerator();
		void IDisposable.Dispose(); // 0x000000018152D8E0-0x000000018152D900
		protected virtual void PrivateDisposeNodeList(); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
