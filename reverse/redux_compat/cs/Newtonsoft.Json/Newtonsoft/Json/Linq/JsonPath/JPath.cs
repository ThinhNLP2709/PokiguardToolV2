/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Linq.JsonPath
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class JPath // TypeDefIndex: 10356
	{
		// Fields
		private static readonly char[] FloatCharacters; // 0x00
		private readonly string _expression; // 0x10
		[CompilerGenerated]
		private readonly List<PathFilter> _Filters_k__BackingField; // 0x18
		private int _currentIndex; // 0x20
	
		// Properties
		public List<PathFilter> Filters { [CompilerGenerated] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
		// Constructors
		public JPath(string expression); // 0x00000001817604A0-0x0000000181760560
		static JPath(); // 0x0000000181760410-0x00000001817604A0
	
		// Methods
		private void ParseMain(); // 0x000000018175E490-0x000000018175E680
		private bool ParsePath(List<PathFilter> filters, int currentPartStartIndex, bool query); // 0x000000018175EC30-0x000000018175F190
		private static PathFilter CreatePathFilter([Nullable(2)] string member, bool scan); // 0x000000018175D0D0-0x000000018175D150
		private PathFilter ParseIndexer(char indexerOpenChar, bool scan); // 0x000000018175E320-0x000000018175E490
		private PathFilter ParseArrayIndexer(char indexerCloseChar); // 0x000000018175D5D0-0x000000018175DF60
		private void EatWhitespace(); // 0x000000018175D210-0x000000018175D270
		private PathFilter ParseQuery(char indexerCloseChar, bool scan); // 0x000000018175F190-0x000000018175F490
		private bool TryParseExpression([Nullable(new byte[2] {2, 1 })] out List<PathFilter> expressionPath); // 0x000000018175FEA0-0x00000001817600C0
		private JsonException CreateUnexpectedCharacterException(); // 0x000000018175D150-0x000000018175D210
		private object ParseSide(); // 0x000000018175F820-0x000000018175FA90
		private QueryExpression ParseExpression(); // 0x000000018175DF60-0x000000018175E320
		[NullableContext(2)]
		private bool TryParseValue(out object value); // 0x00000001817600C0-0x0000000181760410
		private string ReadQuotedString(); // 0x000000018175FA90-0x000000018175FD20
		private string ReadRegexString(); // 0x000000018175FD20-0x000000018175FEA0
		private bool Match(string s); // 0x000000018175D530-0x000000018175D5D0
		private QueryOperator ParseOperator(); // 0x000000018175E680-0x000000018175EC30
		private PathFilter ParseQuotedField(char indexerCloseChar, bool scan); // 0x000000018175F490-0x000000018175F820
		private void EnsureLength(string message); // 0x000000018175D270-0x000000018175D2E0
		internal IEnumerable<JToken> Evaluate(JToken root, JToken t, [Nullable(2)] JsonSelectSettings settings); // 0x000000018175D4A0-0x000000018175D530
		internal static IEnumerable<JToken> Evaluate(List<PathFilter> filters, JToken root, JToken t, [Nullable(2)] JsonSelectSettings settings); // 0x000000018175D2E0-0x000000018175D4A0
	}
}
