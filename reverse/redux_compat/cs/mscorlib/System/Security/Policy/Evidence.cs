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

namespace System.Security.Policy
{
	[Serializable]
	[ComVisible(true)]
	[MonoTODO("Serialization format not compatible with .NET")]
	public sealed class Evidence : ICollection // TypeDefIndex: 2765
	{
		// Fields
		private bool _locked; // 0x10
		private ArrayList hostEvidenceList; // 0x18
		private ArrayList assemblyEvidenceList; // 0x20
	
		// Properties
		[Obsolete]
		public int Count { get; } // 0x000000018147C150-0x000000018147C1C0 
		public bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public object SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
	
		// Nested types
		private class EvidenceEnumerator : IEnumerator // TypeDefIndex: 2766
		{
			// Fields
			private IEnumerator currentEnum; // 0x10
			private IEnumerator hostEnum; // 0x18
			private IEnumerator assemblyEnum; // 0x20
	
			// Properties
			public object Current { get; } // 0x000000018147BF60-0x000000018147BFB0 
	
			// Constructors
			public EvidenceEnumerator(IEnumerator hostenum, IEnumerator assemblyenum); // 0x000000018147BF00-0x000000018147BF60
	
			// Methods
			public bool MoveNext(); // 0x000000018147BDE0-0x000000018147BE70
			public void Reset(); // 0x000000018147BE70-0x000000018147BF00
		}
	
		// Constructors
		public Evidence(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		[Obsolete]
		public void CopyTo(Array array, int index); // 0x000000018147BFB0-0x000000018147C080
		[Obsolete]
		public IEnumerator GetEnumerator(); // 0x000000018147C080-0x000000018147C150
	}
}
