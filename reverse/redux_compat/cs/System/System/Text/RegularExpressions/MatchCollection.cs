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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Text.RegularExpressions
{
	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(CollectionDebuggerProxy<Match>))]
	public class MatchCollection : IList<Match>, IReadOnlyList<Match>, IList // TypeDefIndex: 8698
	{
		// Fields
		private readonly Regex _regex; // 0x10
		private readonly List<Match> _matches; // 0x18
		private bool _done; // 0x20
		private readonly string _input; // 0x28
		private readonly int _beginning; // 0x30
		private readonly int _length; // 0x34
		private int _startat; // 0x38
		private int _prevlen; // 0x3C
	
		// Properties
		public bool IsReadOnly { get; } // 0x00000001802E7990-0x00000001802E79A0 
		public int Count { get; } // 0x0000000181B603E0-0x0000000181B60420 
		public virtual Match this[int i] { get => default; } // 0x0000000181B60420-0x0000000181B604D0 
		public bool IsSynchronized { get; } // 0x00000001802E7840-0x00000001802E7850 
		public object SyncRoot { get; } // 0x0000000180370C60-0x0000000180370C70 
		Match IList<System.Text.RegularExpressions.Match>.this[int index] { get => default; set {} } // 0x0000000181B5FD90-0x0000000181B5FDB0 0x0000000181B5FDB0-0x0000000181B5FE00
		bool IList.IsFixedSize { get; } // 0x00000001802E7990-0x00000001802E79A0 
		object IList.this[int index] { get => default; set {} } // 0x0000000181B5FD90-0x0000000181B5FDB0 0x0000000181B60200-0x0000000181B60250
	
		// Nested types
		[Serializable]
		private sealed class Enumerator : IEnumerator<Match> // TypeDefIndex: 8699
		{
			// Fields
			private readonly MatchCollection _collection; // 0x10
			private int _index; // 0x18
	
			// Properties
			public Match Current { get; } // 0x0000000181B5DB10-0x0000000181B5DB90 
			object IEnumerator.Current { get; } // 0x0000000181B5DB10-0x0000000181B5DB90 
	
			// Constructors
			internal Enumerator(MatchCollection collection); // 0x0000000181560590-0x00000001815605D0
	
			// Methods
			public bool MoveNext(); // 0x0000000181B5DA20-0x0000000181B5DA70
			void IEnumerator.Reset(); // 0x00000001810FCE00-0x00000001810FCE10
			void IDisposable.Dispose(); // 0x00000001802E76C0-0x00000001802E76D0
		}
	
		// Constructors
		internal MatchCollection(Regex regex, string input, int beginning, int length, int startat); // 0x0000000181B60280-0x0000000181B603E0
		internal MatchCollection(); // 0x0000000181B60250-0x0000000181B60280
	
		// Methods
		public IEnumerator GetEnumerator(); // 0x0000000181B5F8D0-0x0000000181B5F940
		IEnumerator<Match> IEnumerable<Match>.GetEnumerator(); // 0x0000000181B5FC10-0x0000000181B5FC80
		private Match GetMatch(int i); // 0x0000000181B5F940-0x0000000181B5FAB0
		private void EnsureInitialized(); // 0x0000000181B5F8B0-0x0000000181B5F8D0
		public void CopyTo(Array array, int arrayIndex); // 0x0000000181B5F7D0-0x0000000181B5F8B0
		public void CopyTo(Match[] array, int arrayIndex); // 0x0000000181B5F770-0x0000000181B5F7D0
		int IList<Match>.IndexOf(Match item); // 0x0000000181B5FC80-0x0000000181B5FCF0
		void IList<Match>.Insert(int index, Match item); // 0x0000000181B5FCF0-0x0000000181B5FD40
		void IList<Match>.RemoveAt(int index); // 0x0000000181B5FD40-0x0000000181B5FD90
		void ICollection<Match>.Add(Match item); // 0x0000000181B5FAB0-0x0000000181B5FB00
		void ICollection<Match>.Clear(); // 0x0000000181B5FB00-0x0000000181B5FB50
		bool ICollection<Match>.Contains(Match item); // 0x0000000181B5FB50-0x0000000181B5FBC0
		bool ICollection<Match>.Remove(Match item); // 0x0000000181B5FBC0-0x0000000181B5FC10
		int IList.Add(object value); // 0x0000000181B5FE00-0x0000000181B5FE50
		void IList.Clear(); // 0x0000000181B5FE50-0x0000000181B5FEA0
		bool IList.Contains(object value); // 0x0000000181B5FEA0-0x0000000181B5FFD0
		int IList.IndexOf(object value); // 0x0000000181B5FFD0-0x0000000181B60110
		void IList.Insert(int index, object value); // 0x0000000181B60110-0x0000000181B60160
		void IList.Remove(object value); // 0x0000000181B601B0-0x0000000181B60200
		void IList.RemoveAt(int index); // 0x0000000181B60160-0x0000000181B601B0
	}
}
