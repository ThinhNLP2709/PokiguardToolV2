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
using System.Runtime.Versioning;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Bson
{
	internal class BsonArray : BsonToken, IEnumerable<Newtonsoft.Json.Bson.BsonToken> // TypeDefIndex: 10420
	{
		// Fields
		private readonly List<BsonToken> _children; // 0x20
	
		// Properties
		public override BsonType Type { get; } // 0x000000018176FA50-0x000000018176FA60 
	
		// Constructors
		public BsonArray(); // 0x000000018176F9D0-0x000000018176FA50
	
		// Methods
		public void Add(BsonToken token); // 0x000000018176F8B0-0x000000018176F960
		public IEnumerator<BsonToken> GetEnumerator(); // 0x000000018176F960-0x000000018176F9D0
		IEnumerator IEnumerable.GetEnumerator(); // 0x000000018176F960-0x000000018176F9D0
	}
}
