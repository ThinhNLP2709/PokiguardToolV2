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
using System.Threading;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	[Serializable]
	public class FileWebRequest : WebRequest, ISerializable // TypeDefIndex: 9096
	{
		// Fields
		private static WaitCallback s_GetRequestStreamCallback; // 0x00
		private static WaitCallback s_GetResponseCallback; // 0x08
		private string m_connectionGroupName; // 0x38
		private long m_contentLength; // 0x40
		private ICredentials m_credentials; // 0x48
		private FileAccess m_fileAccess; // 0x50
		private WebHeaderCollection m_headers; // 0x58
		private string m_method; // 0x60
		private IWebProxy m_proxy; // 0x68
		private ManualResetEvent m_readerEvent; // 0x70
		private bool m_readPending; // 0x78
		private WebResponse m_response; // 0x80
		private Stream m_stream; // 0x88
		private bool m_syncHint; // 0x90
		private int m_timeout; // 0x94
		private Uri m_uri; // 0x98
		private bool m_writePending; // 0xA0
		private bool m_writing; // 0xA1
		private LazyAsyncResult m_WriteAResult; // 0xA8
		private LazyAsyncResult m_ReadAResult; // 0xB0
		private int m_Aborted; // 0xB8
	
		// Properties
		internal bool Aborted { get; } // 0x0000000181C0A2D0-0x0000000181C0A2E0 
		public override long ContentLength { get; } // 0x0000000180377940-0x0000000180377950 
		public override ICredentials Credentials { get; set; } // 0x00000001803272B0-0x00000001803272C0 0x00000001803780C0-0x00000001803780D0
		public override WebHeaderCollection Headers { get; } // 0x00000001802F4000-0x00000001802F4010 
		public override string Method { get; set; } // 0x0000000180333260-0x0000000180333490 0x0000000181C0A310-0x0000000181C0A3E0
		public override IWebProxy Proxy { get; set; } // 0x0000000180316960-0x0000000180316970 0x0000000180316A40-0x0000000180316A50
		public override int Timeout { get; } // 0x000000018033D1E0-0x000000018033D1F0 
		public override Uri RequestUri { get; } // 0x00000001806CCBC0-0x00000001806CCBD0 
		public override bool UseDefaultCredentials { get; } // 0x0000000181C0A2E0-0x0000000181C0A310 
	
		// Constructors
		internal FileWebRequest(Uri uri); // 0x0000000181C09D30-0x0000000181C09EC0
		[Obsolete("Serialization is obsoleted for this type. http://go.microsoft.com/fwlink/?linkid=14202")]
		protected FileWebRequest(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181C09EC0-0x0000000181C0A2D0
		static FileWebRequest(); // 0x0000000181C09C40-0x0000000181C09D30
	
		// Methods
		new void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181BF9D50-0x0000000181BF9D80
		protected override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181C09170-0x0000000181C093A0
		public override IAsyncResult BeginGetResponse(AsyncCallback callback, object state); // 0x0000000181C08C90-0x0000000181C08F50
		public override WebResponse EndGetResponse(IAsyncResult asyncResult); // 0x0000000181C08F50-0x0000000181C09170
		public override WebResponse GetResponse(); // 0x0000000181C09900-0x0000000181C09B90
		private static void GetRequestStreamCallback(object state); // 0x0000000181C093A0-0x0000000181C095D0
		private static void GetResponseCallback(object state); // 0x0000000181C095D0-0x0000000181C09900
		internal void UnblockReader(); // 0x0000000181C09B90-0x0000000181C09C40
		public override void Abort(); // 0x0000000181C08A10-0x0000000181C08C90
	}
}
