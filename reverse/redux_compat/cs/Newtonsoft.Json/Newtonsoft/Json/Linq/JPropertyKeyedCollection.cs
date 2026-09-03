/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq
{
	[Nullable(new byte[2] {0, 1 })]
	[NullableContext(1)]
	internal class JPropertyKeyedCollection : Collection<Newtonsoft.Json.Linq.JToken> // TypeDefIndex: 10321
	{
		// Fields
		private static readonly IEqualityComparer<string> Comparer; // 0x00
		[Nullable(new byte[3] {2, 1, 1 })]
		private Dictionary<string, JToken> _dictionary; // 0x18
	
		// Properties
		public JToken this[string key] { get => default; } // 0x0000000181743590-0x0000000181743680 
		public ICollection<string> Keys { get; } // 0x0000000181743680-0x00000001817436D0 
		public ICollection<JToken> Values { get; } // 0x00000001817436D0-0x0000000181743720 
	
		// Constructors
		public JPropertyKeyedCollection(); // 0x0000000181743520-0x0000000181743590
		static JPropertyKeyedCollection(); // 0x0000000181743460-0x0000000181743520
	
		// Methods
		private void AddKey(string key, JToken item); // 0x00000001817424A0-0x0000000181742510
		protected void ChangeItemKey(JToken item, string newKey); // 0x0000000181742510-0x0000000181742750
		protected override void ClearItems(); // 0x0000000181742750-0x00000001817427A0
		public bool Contains(string key); // 0x0000000181742BA0-0x0000000181742C50
		private bool ContainsItem(JToken item); // 0x0000000181742AD0-0x0000000181742BA0
		private void EnsureDictionary(); // 0x0000000181742C50-0x0000000181742D10
		private string GetKeyForItem(JToken item); // 0x0000000181742D10-0x0000000181742D80
		protected override void InsertItem(int index, JToken item); // 0x0000000181742E00-0x0000000181742F10
		public bool Remove(string key); // 0x0000000181743070-0x0000000181743150
		protected override void RemoveItem(int index); // 0x0000000181742F10-0x0000000181743020
		private void RemoveKey(string key); // 0x0000000181743020-0x0000000181743070
		protected override void SetItem(int index, JToken item); // 0x0000000181743150-0x00000001817433D0
		public bool TryGetValue(string key, [Nullable(2)] [NotNullWhen(true)] out JToken value); // 0x00000001817433D0-0x0000000181743460
		public int IndexOfReference(JToken t); // 0x0000000181742D80-0x0000000181742E00
		public bool Compare(JPropertyKeyedCollection other); // 0x00000001817427A0-0x0000000181742AD0
	}
}
