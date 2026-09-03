/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	[ComVisible(true)]
	[DefaultMember("Item")]
	public class WebHeaderCollection : NameValueCollection, ISerializable // TypeDefIndex: 9056
	{
		// Fields
		private static readonly HeaderInfoTable HInfo; // 0x00
		private string[] m_CommonHeaders; // 0x68
		private int m_NumCommonHeaders; // 0x70
		private static readonly string[] s_CommonHeaderNames; // 0x08
		private static readonly sbyte[] s_CommonHeaderHints; // 0x10
		private NameValueCollection m_InnerCollection; // 0x78
		private WebHeaderCollectionType m_Type; // 0x80
		private static readonly char[] HttpTrimCharacters; // 0x18
		private static RfcChar[] RfcCharMap; // 0x20
	
		// Properties
		private NameValueCollection InnerCollection { get; } // 0x0000000181BF8F00-0x0000000181BF8FC0 
		private bool AllowHttpRequestHeader { get; } // 0x0000000181BF8E80-0x0000000181BF8EC0 
		public override int Count { get; } // 0x0000000181BF8EC0-0x0000000181BF8F00 
		public override KeysCollection Keys { get; } // 0x0000000181BF8FC0-0x0000000181BF9010 
		public override string[] AllKeys { get; } // 0x0000000181BF8E30-0x0000000181BF8E80 
	
		// Nested types
		private enum RfcChar : byte // TypeDefIndex: 9057
		{
			High = 0,
			Reg = 1,
			Ctl = 2,
			CR = 3,
			LF = 4,
			WS = 5,
			Colon = 6,
			Delim = 7
		}
	
		// Constructors
		public WebHeaderCollection(); // 0x0000000181BF8D00-0x0000000181BF8D50
		internal WebHeaderCollection(WebHeaderCollectionType type); // 0x0000000181BF8D50-0x0000000181BF8E30
		protected WebHeaderCollection(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181BF8B30-0x0000000181BF8D00
		static WebHeaderCollection(); // 0x0000000181BF8590-0x0000000181BF8B30
	
		// Methods
		private void NormalizeCommonHeaders(); // 0x0000000181BF7AB0-0x0000000181BF7C10
		internal static bool AllowMultiValues(string name); // 0x0000000181BF67F0-0x0000000181BF6890
		public void Remove(HttpRequestHeader header); // 0x0000000181BF7C70-0x0000000181BF7D70
		internal void AddInternal(string name, string value); // 0x0000000181BF62E0-0x0000000181BF6350
		internal void ChangeInternal(string name, string value); // 0x0000000181BF6890-0x0000000181BF6900
		internal void RemoveInternal(string name); // 0x0000000181BF7C10-0x0000000181BF7C70
		internal static string CheckBadChars(string name, bool isHeaderValue); // 0x0000000181BF6900-0x0000000181BF6E80
		internal static bool ContainsNonAsciiChars(string token); // 0x0000000181BF6EE0-0x0000000181BF6F50
		internal void ThrowOnRestrictedHeader(string headerName); // 0x0000000181BF8300-0x0000000181BF8540
		public override void Add(string name, string value); // 0x0000000181BF6350-0x0000000181BF6510
		public void Add(string header); // 0x0000000181BF6510-0x0000000181BF67F0
		public override void Set(string name, string value); // 0x0000000181BF80C0-0x0000000181BF8300
		internal void SetInternal(string name, string value); // 0x0000000181BF7E90-0x0000000181BF80C0
		public override void Remove(string name); // 0x0000000181BF7D70-0x0000000181BF7E90
		public override string[] GetValues(string header); // 0x0000000181BF7440-0x0000000181BF7690
		public override string ToString(); // 0x0000000181BF8540-0x0000000181BF8590
		internal static string GetAsString(NameValueCollection cc, bool winInetCompat, bool forTrace); // 0x0000000181BF6F50-0x0000000181BF71F0
		public override void OnDeserialization(object sender); // 0x00000001802E76C0-0x00000001802E76D0
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181BF72B0-0x0000000181BF7440
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181BF5DF0-0x0000000181BF5E20
		public override string Get(string name); // 0x0000000181BF76E0-0x0000000181BF7A60
		public override IEnumerator GetEnumerator(); // 0x0000000181BF71F0-0x0000000181BF7260
		public override string Get(int index); // 0x0000000181BF7A60-0x0000000181BF7AB0
		public override string[] GetValues(int index); // 0x0000000181BF7690-0x0000000181BF76E0
		public override string GetKey(int index); // 0x0000000181BF7260-0x0000000181BF72B0
		public override void Clear(); // 0x0000000181BF6E80-0x0000000181BF6EE0
	}
}
