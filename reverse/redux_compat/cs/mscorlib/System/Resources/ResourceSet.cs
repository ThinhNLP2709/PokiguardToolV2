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

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Resources
{
	[Serializable]
	[ComVisible(true)]
	public class ResourceSet : IDisposable, IEnumerable // TypeDefIndex: 3268
	{
		// Fields
		[NonSerialized]
		protected IResourceReader Reader; // 0x10
		protected Hashtable Table; // 0x18
		private Hashtable _caseInsensitiveTable; // 0x20
	
		// Constructors
		protected ResourceSet(); // 0x0000000181518C40-0x0000000181518CB0
		internal ResourceSet(bool junk); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private void CommonInit(); // 0x00000001815180C0-0x0000000181518120
		protected virtual void Dispose(bool disposing); // 0x0000000181518120-0x00000001815181C0
		public void Dispose(); // 0x00000001815181C0-0x00000001815181E0
		[ComVisible(false)]
		public virtual IDictionaryEnumerator GetEnumerator(); // 0x00000001815185E0-0x00000001815185F0
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001815185E0-0x00000001815185F0
		private IDictionaryEnumerator GetEnumeratorHelper(); // 0x0000000181518550-0x00000001815185E0
		public virtual string GetString(string name); // 0x00000001815187E0-0x0000000181518990
		public virtual string GetString(string name, bool ignoreCase); // 0x0000000181518990-0x0000000181518C40
		public virtual object GetObject(string name); // 0x00000001815185F0-0x00000001815186D0
		public virtual object GetObject(string name, bool ignoreCase); // 0x00000001815186D0-0x00000001815187E0
		private object GetObjectInternal(string name); // 0x00000001815185F0-0x00000001815186D0
		private object GetCaseInsensitiveObjectInternal(string name); // 0x00000001815181E0-0x0000000181518550
	}
}
