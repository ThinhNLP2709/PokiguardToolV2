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
	public class FileWebResponse : WebResponse, ISerializable, ICloseEx // TypeDefIndex: 9099
	{
		// Fields
		private bool m_closed; // 0x20
		private long m_contentLength; // 0x28
		private FileAccess m_fileAccess; // 0x30
		private WebHeaderCollection m_headers; // 0x38
		private Stream m_stream; // 0x40
		private Uri m_uri; // 0x48
	
		// Properties
		public override WebHeaderCollection Headers { get; } // 0x0000000181C0ACD0-0x0000000181C0ACF0 
		public override Uri ResponseUri { get; } // 0x0000000181C0ACF0-0x0000000181C0AD10 
	
		// Constructors
		internal FileWebResponse(FileWebRequest request, Uri uri, FileAccess access, bool asyncHint); // 0x0000000181C0A9F0-0x0000000181C0ACD0
		[Obsolete("Serialization is obsoleted for this type. http://go.microsoft.com/fwlink/?linkid=14202")]
		protected FileWebResponse(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181C0A790-0x0000000181C0A9F0
	
		// Methods
		new void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181B0FAD0-0x0000000181B0FB00
		protected override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext); // 0x0000000181C0A4A0-0x0000000181C0A600
		private void CheckDisposed(); // 0x0000000181C0A3E0-0x0000000181C0A460
		public override void Close(); // 0x0000000181C0A460-0x0000000181C0A4A0
		void ICloseEx.CloseEx(CloseExState closeState); // 0x0000000181C0A660-0x0000000181C0A790
		public override Stream GetResponseStream(); // 0x0000000181C0A600-0x0000000181C0A660
	}
}
