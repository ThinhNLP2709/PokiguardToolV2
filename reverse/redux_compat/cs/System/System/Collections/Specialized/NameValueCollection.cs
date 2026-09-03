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
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Collections.Specialized
{
	[Serializable]
	public class NameValueCollection : NameObjectCollectionBase // TypeDefIndex: 8950
	{
		// Fields
		private string[] _all; // 0x58
		private string[] _allKeys; // 0x60
	
		// Properties
		public string this[string name] { get => default; set {} } // 0x00000001818FDF50-0x00000001818FDF70 0x00000001818FEA70-0x00000001818FEA90
		public virtual string[] AllKeys { get; } // 0x0000000181BCF5D0-0x0000000181BCF750 
	
		// Constructors
		public NameValueCollection(); // 0x0000000181BCF470-0x0000000181BCF580
		public NameValueCollection(NameValueCollection col); // 0x0000000181BCF0C0-0x0000000181BCF310
		public NameValueCollection(int capacity); // 0x0000000181BCF310-0x0000000181BCF400
		public NameValueCollection(int capacity, IEqualityComparer equalityComparer); // 0x0000000181BCEFE0-0x0000000181BCF0C0
		protected NameValueCollection(SerializationInfo info, StreamingContext context); // 0x0000000181BCF400-0x0000000181BCF470
		internal NameValueCollection(DBNull dummy); // 0x0000000181BCF580-0x0000000181BCF5D0
	
		// Methods
		protected void InvalidateCachedArrays(); // 0x0000000181BCEDA0-0x0000000181BCEDE0
		private static string GetAsOneString(ArrayList list); // 0x0000000181BCE8B0-0x0000000181BCEA60
		private static string[] GetAsStringArray(ArrayList list); // 0x0000000181BCEA60-0x0000000181BCEB10
		public void Add(NameValueCollection c); // 0x0000000181BCE630-0x0000000181BCE7C0
		public virtual void Clear(); // 0x0000000181BCE7C0-0x0000000181BCE8B0
		public virtual void Add(string name, string value); // 0x0000000181BCE4A0-0x0000000181BCE630
		public virtual string Get(string name); // 0x0000000181BCED00-0x0000000181BCEDA0
		public virtual string[] GetValues(string name); // 0x0000000181BCEB20-0x0000000181BCEBC0
		public virtual void Set(string name, string value); // 0x0000000181BCEE30-0x0000000181BCEFE0
		public virtual void Remove(string name); // 0x0000000181BCEDE0-0x0000000181BCEE30
		public virtual string Get(int index); // 0x0000000181BCEC60-0x0000000181BCED00
		public virtual string[] GetValues(int index); // 0x0000000181BCEBC0-0x0000000181BCEC60
		public virtual string GetKey(int index); // 0x0000000181BCEB10-0x0000000181BCEB20
	}
}
