/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	[Serializable]
	[ComVisible(true)]
	public class WebHeaderCollection : NameValueCollection, ISerializable // TypeDefIndex: 13287
	{
		// Fields
		private static readonly Dictionary<string, HttpHeaderInfo> _headers; // 0x00
		private bool _internallyUsed; // 0x68
		private HttpHeaderType _state; // 0x6C
	
		// Properties
		internal HttpHeaderType State { get; } // 0x0000000182609AD0-0x0000000182609AE0 
		public override string[] AllKeys { get; } // 0x0000000182618C20-0x0000000182618C30 
		public override int Count { get; } // 0x0000000182618C30-0x0000000182618C40 
		public string this[HttpRequestHeader header] { get => default; set {} } // 0x0000000182618C40-0x0000000182618CF0 0x00000001826158E0-0x0000000182615A30
		public string this[HttpResponseHeader header] { get => default; set {} } // 0x0000000182618CF0-0x0000000182618DA0 0x0000000182615440-0x0000000182615590
		public override KeysCollection Keys { get; } // 0x0000000182618DA0-0x0000000182618DB0 
	
		// Constructors
		static WebHeaderCollection(); // 0x0000000182616A30-0x00000001826182A0
		internal WebHeaderCollection(HttpHeaderType state, bool internallyUsed); // 0x00000001826182A0-0x00000001826182E0
		protected WebHeaderCollection(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x00000001826182E0-0x00000001826184D0
		public WebHeaderCollection(); // 0x0000000182612C60-0x0000000182612C70
	
		// Methods
		private void add(string name, string value, HttpHeaderType headerType); // 0x00000001826184D0-0x0000000182618500
		private void checkAllowed(HttpHeaderType headerType); // 0x0000000182618500-0x0000000182618580
		private static string checkName(string name, string paramName); // 0x0000000182618580-0x0000000182618760
		private void checkRestricted(string name, HttpHeaderType headerType); // 0x0000000182618760-0x0000000182618830
		private static string checkValue(string value, string paramName); // 0x0000000182618830-0x0000000182618980
		private static HttpHeaderInfo getHeaderInfo(string name); // 0x0000000182618980-0x0000000182618AF0
		private static string getHeaderName(string key); // 0x0000000182618AF0-0x0000000182618BA0
		private static HttpHeaderType getHeaderType(string name); // 0x0000000182618BA0-0x0000000182618C20
		private static bool isMultiValue(string name, bool response); // 0x0000000182618DB0-0x0000000182618E50
		private static bool isRestricted(string name, bool response); // 0x0000000182618E50-0x0000000182618ED0
		private void set(string name, string value, HttpHeaderType headerType); // 0x0000000182618ED0-0x0000000182619020
		internal void InternalRemove(string name); // 0x0000000182615C90-0x0000000182615CA0
		internal void InternalSet(string header, bool response); // 0x0000000182615D60-0x0000000182615F00
		internal void InternalSet(string name, string value, bool response); // 0x0000000182615CA0-0x0000000182615D60
		internal string ToStringMultiValue(bool response); // 0x00000001826166D0-0x00000001826168E0
		protected void AddWithoutValidate(string headerName, string headerValue); // 0x0000000182615360-0x0000000182615440
		public void Add(string header); // 0x0000000182615590-0x00000001826157F0
		public void Add(HttpRequestHeader header, string value); // 0x00000001826158E0-0x0000000182615A30
		public void Add(HttpResponseHeader header, string value); // 0x0000000182615440-0x0000000182615590
		public override void Add(string name, string value); // 0x00000001826157F0-0x00000001826158E0
		public override void Clear(); // 0x0000000182615A30-0x0000000182615A50
		public override string Get(int index); // 0x0000000182615C80-0x0000000182615C90
		public override string Get(string name); // 0x0000000182615C70-0x0000000182615C80
		public override IEnumerator GetEnumerator(); // 0x0000000182615A50-0x0000000182615A60
		public override string GetKey(int index); // 0x0000000182615A60-0x0000000182615A70
		public override string[] GetValues(int index); // 0x0000000182615C30-0x0000000182615C50
		public override string[] GetValues(string name); // 0x0000000182615C50-0x0000000182615C70
		public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000182615A70-0x0000000182615C30
		public static bool IsRestricted(string headerName); // 0x0000000182615F00-0x0000000182615FF0
		public static bool IsRestricted(string headerName, bool response); // 0x0000000182615FF0-0x0000000182616070
		public override void OnDeserialization(object sender); // 0x00000001802E76C0-0x00000001802E76D0
		public void Remove(HttpRequestHeader header); // 0x0000000182616120-0x0000000182616230
		public void Remove(HttpResponseHeader header); // 0x0000000182616230-0x0000000182616340
		public override void Remove(string name); // 0x0000000182616070-0x0000000182616120
		public void Set(HttpRequestHeader header, string value); // 0x0000000182616490-0x00000001826165E0
		public void Set(HttpResponseHeader header, string value); // 0x0000000182616340-0x0000000182616490
		public override void Set(string name, string value); // 0x00000001826165E0-0x00000001826166D0
		public byte[] ToByteArray(); // 0x00000001825F6150-0x00000001825F61B0
		public override string ToString(); // 0x00000001826168E0-0x0000000182616A30
		void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181BF5DF0-0x0000000181BF5E20
	}
}
