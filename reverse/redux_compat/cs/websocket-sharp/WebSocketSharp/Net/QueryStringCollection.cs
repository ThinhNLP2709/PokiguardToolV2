/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	internal sealed class QueryStringCollection : NameValueCollection // TypeDefIndex: 13301
	{
		// Constructors
		public QueryStringCollection(); // 0x0000000182612C60-0x0000000182612C70
		public QueryStringCollection(int capacity); // 0x0000000182612C50-0x0000000182612C60
	
		// Methods
		private static string urlDecode(string s, Encoding encoding); // 0x0000000182612C70-0x0000000182612D30
		public static QueryStringCollection Parse(string query); // 0x0000000182612800-0x0000000182612830
		public static QueryStringCollection Parse(string query, Encoding encoding); // 0x0000000182612830-0x0000000182612B10
		public override string ToString(); // 0x0000000182612B10-0x0000000182612C50
	}
}
