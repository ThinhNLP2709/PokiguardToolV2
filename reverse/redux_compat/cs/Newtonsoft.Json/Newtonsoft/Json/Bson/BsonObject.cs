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
	internal class BsonObject : BsonToken, IEnumerable<Newtonsoft.Json.Bson.BsonProperty> // TypeDefIndex: 10419
	{
		// Fields
		private readonly List<BsonProperty> _children; // 0x20
	
		// Properties
		public override BsonType Type { get; } // 0x0000000181771970-0x0000000181771980 
	
		// Constructors
		public BsonObject(); // 0x00000001817718F0-0x0000000181771970
	
		// Methods
		public void Add(string name, BsonToken token); // 0x0000000181771720-0x0000000181771880
		public IEnumerator<BsonProperty> GetEnumerator(); // 0x0000000181771880-0x00000001817718F0
		IEnumerator IEnumerable.GetEnumerator(); // 0x0000000181771880-0x00000001817718F0
	}
}
