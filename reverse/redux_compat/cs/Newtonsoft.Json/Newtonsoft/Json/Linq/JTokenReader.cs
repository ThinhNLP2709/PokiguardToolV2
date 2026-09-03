/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq
{
	[Nullable(0)]
	[NullableContext(1)]
	public class JTokenReader : JsonReader, IJsonLineInfo // TypeDefIndex: 10337
	{
		// Fields
		private readonly JToken _root; // 0x78
		[Nullable(2)]
		private string _initialPath; // 0x80
		[Nullable(2)]
		private JToken _parent; // 0x88
		[Nullable(2)]
		private JToken _current; // 0x90
	
		// Properties
		[Nullable(2)]
		public JToken CurrentToken { [NullableContext(2)] get; } // 0x00000001806CCBA0-0x00000001806CCBB0 
		int IJsonLineInfo.LineNumber { get; } // 0x00000001817607A0-0x0000000181760800 
		int IJsonLineInfo.LinePosition { get; } // 0x0000000181760800-0x0000000181760860 
		public override string Path { get; } // 0x0000000181761D10-0x0000000181761E10 
	
		// Constructors
		public JTokenReader(JToken token); // 0x0000000181761C10-0x0000000181761C80
		public JTokenReader(JToken token, string initialPath); // 0x0000000181761C80-0x0000000181761D10
	
		// Methods
		public override bool Read(); // 0x0000000181761150-0x00000001817612C0
		private bool ReadOver(JToken t); // 0x0000000181760910-0x0000000181761110
		private bool ReadToEnd(); // 0x0000000181761110-0x0000000181761150
		private JsonToken? GetEndToken(JContainer c); // 0x00000001817605F0-0x0000000181760740
		private bool ReadInto(JContainer c); // 0x0000000181760860-0x0000000181760910
		private bool SetEnd(JContainer c); // 0x00000001817612F0-0x0000000181761450
		private void SetToken(JToken token); // 0x0000000181761450-0x0000000181761C10
		[NullableContext(2)]
		private string SafeToString(object value); // 0x00000001817612C0-0x00000001817612F0
		bool IJsonLineInfo.HasLineInfo(); // 0x0000000181760740-0x00000001817607A0
	}
}
