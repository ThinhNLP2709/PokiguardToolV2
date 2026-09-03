/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	[Serializable]
	public class CookieCollection : ICollection<WebSocketSharp.Net.Cookie> // TypeDefIndex: 13270
	{
		// Fields
		private List<Cookie> _list; // 0x10
		private bool _readOnly; // 0x18
		private object _sync; // 0x20
	
		// Properties
		internal IList<Cookie> List { get; } // 0x00000001825D8700-0x00000001825D8710 
		internal IEnumerable<Cookie> Sorted { get; } // 0x00000001825EFBD0-0x00000001825EFCB0 
		public int Count { get; } // 0x0000000180B5F570-0x0000000180B5F590 
		public bool IsReadOnly { get; internal set; } // 0x00000001825EF930-0x00000001825EF940 0x00000001804C2E10-0x00000001804C2E20
		public bool IsSynchronized { get; } // 0x00000001825EF940-0x00000001825EF950 
		public Cookie this[int index] { get => default; } // 0x00000001825EFB50-0x00000001825EFBD0 
		public Cookie this[string name] { get => default; } // 0x00000001825EF950-0x00000001825EFB50 
		public object SyncRoot { get; } // 0x00000001825DE400-0x00000001825DE410 
	
		// Constructors
		public CookieCollection(); // 0x00000001825EF6D0-0x00000001825EF790
	
		// Methods
		private void add(Cookie cookie); // 0x00000001825EF790-0x00000001825EF870
		private static int compareForSort(Cookie x, Cookie y); // 0x00000001825EF870-0x00000001825EF8C0
		private static int compareForSorted(Cookie x, Cookie y); // 0x00000001825EF8C0-0x00000001825EF930
		private static CookieCollection parseRequest(string value); // 0x00000001825EFCB0-0x00000001825F0220
		private static CookieCollection parseResponse(string value); // 0x00000001825F0220-0x00000001825F0D60
		private int search(Cookie cookie); // 0x00000001825F0D60-0x00000001825F0E60
		private static string urlDecode(string s, Encoding encoding); // 0x00000001825F0E60-0x00000001825F0F30
		internal static CookieCollection Parse(string value, bool response); // 0x00000001825EF1B0-0x00000001825EF240
		internal void SetOrRemove(Cookie cookie); // 0x00000001825EF330-0x00000001825EF400
		internal void SetOrRemove(CookieCollection cookies); // 0x00000001825EF400-0x00000001825EF5C0
		internal void Sort(); // 0x00000001825EF5C0-0x00000001825EF660
		public void Add(Cookie cookie); // 0x00000001825EEE20-0x00000001825EEEE0
		public void Add(CookieCollection cookies); // 0x00000001825EECA0-0x00000001825EEE20
		public void Clear(); // 0x00000001825EEEE0-0x00000001825EEF90
		public bool Contains(Cookie cookie); // 0x00000001825EEF90-0x00000001825EF000
		public void CopyTo(Cookie[] array, int index); // 0x00000001825EF000-0x00000001825EF140
		public IEnumerator<Cookie> GetEnumerator(); // 0x00000001825EF140-0x00000001825EF1B0
		public bool Remove(Cookie cookie); // 0x00000001825EF240-0x00000001825EF330
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001825EF660-0x00000001825EF6D0
	}
}
