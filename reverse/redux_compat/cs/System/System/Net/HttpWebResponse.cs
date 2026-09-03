/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	public class HttpWebResponse : WebResponse, ISerializable, IDisposable // TypeDefIndex: 9135
	{
		// Fields
		private Uri uri; // 0x20
		private WebHeaderCollection webHeaders; // 0x28
		private CookieCollection cookieCollection; // 0x30
		private string method; // 0x38
		private Version version; // 0x40
		private HttpStatusCode statusCode; // 0x48
		private string statusDescription; // 0x50
		private long contentLength; // 0x58
		private string contentType; // 0x60
		private CookieContainer cookie_container; // 0x68
		private bool disposed; // 0x70
		private Stream stream; // 0x78
	
		// Properties
		public override WebHeaderCollection Headers { get; } // 0x000000018033D240-0x000000018033D250 
		public override Uri ResponseUri { get; } // 0x0000000181B10260-0x0000000181B10280 
		public virtual HttpStatusCode StatusCode { get; } // 0x000000018033D1C0-0x000000018033D1D0 
		public virtual string StatusDescription { get; } // 0x0000000181B10280-0x0000000181B102A0 
	
		// Constructors
		public HttpWebResponse(); // 0x00000001802F4070-0x00000001802F4080
		internal HttpWebResponse(Uri uri, string method, HttpStatusCode status, WebHeaderCollection headers); // 0x0000000181B0FB00-0x0000000181B0FBF0
		internal HttpWebResponse(Uri uri, string method, WebResponseStream stream, CookieContainer container); // 0x0000000181B0FFA0-0x0000000181B10260
		[Obsolete("Serialization is obsoleted for this type", false)]
		protected HttpWebResponse(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B0FBF0-0x0000000181B0FFA0
	
		// Methods
		public override Stream GetResponseStream(); // 0x0000000181B0FA20-0x0000000181B0FAB0
		new void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B0FAD0-0x0000000181B0FB00
		protected override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B0F8B0-0x0000000181B0FA20
		public override void Close(); // 0x0000000181B0F6D0-0x0000000181B0F710
		void IDisposable.Dispose(); // 0x0000000181B0FAB0-0x0000000181B0FAD0
		protected override void Dispose(bool disposing); // 0x0000000181B0F710-0x0000000181B0F720
		private void CheckDisposed(); // 0x0000000181B0F650-0x0000000181B0F6D0
		private void FillCookies(); // 0x0000000181B0F720-0x0000000181B0F8B0
	}
}
