/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	public class HttpListenerPrefixCollection : ICollection<string> // TypeDefIndex: 13278
	{
		// Fields
		private HttpListener _listener; // 0x10
		private List<string> _prefixes; // 0x18
	
		// Properties
		public int Count { get; } // 0x00000001814EA450-0x00000001814EA470 
		public bool IsReadOnly { get; } // 0x00000001825EF940-0x00000001825EF950 
		public bool IsSynchronized { get; } // 0x00000001825EF940-0x00000001825EF950 
	
		// Constructors
		internal HttpListenerPrefixCollection(HttpListener listener); // 0x00000001825F95C0-0x00000001825F9650
	
		// Methods
		public void Add(string uriPrefix); // 0x00000001825F8F50-0x00000001825F90E0
		public void Clear(); // 0x00000001825F90E0-0x00000001825F91D0
		public bool Contains(string uriPrefix); // 0x00000001825F91D0-0x00000001825F92D0
		public void CopyTo(string[] array, int offset); // 0x00000001825F92D0-0x00000001825F9350
		public IEnumerator<string> GetEnumerator(); // 0x00000001825F9350-0x00000001825F93C0
		public bool Remove(string uriPrefix); // 0x00000001825F93C0-0x00000001825F9550
		IEnumerator IEnumerable.GetEnumerator(); // 0x00000001825F9550-0x00000001825F95C0
	}
}
