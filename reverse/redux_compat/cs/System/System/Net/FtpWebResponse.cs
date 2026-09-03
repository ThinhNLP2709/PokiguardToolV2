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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	public class FtpWebResponse : WebResponse, IDisposable // TypeDefIndex: 9026
	{
		// Fields
		internal Stream _responseStream; // 0x20
		private long _contentLength; // 0x28
		private Uri _responseUri; // 0x30
		private FtpStatusCode _statusCode; // 0x38
		private string _statusLine; // 0x40
		private WebHeaderCollection _ftpRequestHeaders; // 0x48
		private DateTime _lastModified; // 0x50
		private string _bannerMessage; // 0x58
		private string _welcomeMessage; // 0x60
		private string _exitMessage; // 0x68
	
		// Properties
		public override WebHeaderCollection Headers { get; } // 0x0000000181BED470-0x0000000181BED5A0 
		public override Uri ResponseUri { get; } // 0x000000018031E110-0x000000018031E120 
		public FtpStatusCode StatusCode { get; } // 0x000000018047EDE0-0x000000018047EDF0 
	
		// Nested types
		internal sealed class EmptyStream : MemoryStream // TypeDefIndex: 9027
		{
			// Constructors
			internal EmptyStream(); // 0x0000000181BE0FB0-0x0000000181BE1030
		}
	
		// Constructors
		internal FtpWebResponse(Stream responseStream, long contentLength, Uri responseUri, FtpStatusCode statusCode, string statusLine, DateTime lastModified, string bannerMessage, string welcomeMessage, string exitMessage); // 0x0000000181BED330-0x0000000181BED470
	
		// Methods
		internal void UpdateStatus(FtpStatusCode statusCode, string statusLine, string exitMessage); // 0x0000000181BED2F0-0x0000000181BED330
		public override Stream GetResponseStream(); // 0x0000000181BED180-0x0000000181BED260
		internal void SetResponseStream(Stream stream); // 0x0000000181BED260-0x0000000181BED2F0
		public override void Close(); // 0x0000000181BED0D0-0x0000000181BED180
	}
}
