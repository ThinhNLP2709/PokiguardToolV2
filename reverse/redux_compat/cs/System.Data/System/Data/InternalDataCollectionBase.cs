/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 11: System.Data.dll - Assembly: System.Data, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 11180-11419

namespace System.Data
{
	public class InternalDataCollectionBase : ICollection // TypeDefIndex: 11216
	{
		// Fields
		internal static readonly CollectionChangeEventArgs s_refreshEventArgs; // 0x00
	
		// Properties
		[Browsable(false)]
		public virtual int Count { get; } // 0x000000018187A840-0x000000018187A880 
		[Browsable(false)]
		public bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		[Browsable(false)]
		public object SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
		protected virtual ArrayList List { get; } // 0x00000001802E7860-0x00000001802E7870 
	
		// Constructors
		public InternalDataCollectionBase(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static InternalDataCollectionBase(); // 0x000000018187A7C0-0x000000018187A840
	
		// Methods
		public virtual void CopyTo(Array ar, int index); // 0x000000018187A620-0x000000018187A680
		public virtual IEnumerator GetEnumerator(); // 0x000000018187A680-0x000000018187A6C0
		internal int NamesEqual(string s1, string s2, bool fCaseSensitive, CultureInfo locale); // 0x000000018187A6C0-0x000000018187A7C0
	}
}
