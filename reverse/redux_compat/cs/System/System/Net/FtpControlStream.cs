/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class FtpControlStream : CommandStream // TypeDefIndex: 9014
	{
		// Fields
		private Socket _dataSocket; // 0x88
		private IPEndPoint _passiveEndPoint; // 0x90
		private TlsStream _tlsStream; // 0x98
		private StringBuilder _bannerMessage; // 0xA0
		private StringBuilder _welcomeMessage; // 0xA8
		private StringBuilder _exitMessage; // 0xB0
		private WeakReference _credentials; // 0xB8
		private string _currentTypeSetting; // 0xC0
		private long _contentLength; // 0xC8
		private DateTime _lastModified; // 0xD0
		private bool _dataHandshakeStarted; // 0xD8
		private string _loginDirectory; // 0xE0
		private string _establishedServerDirectory; // 0xE8
		private string _requestedServerDirectory; // 0xF0
		private Uri _responseUri; // 0xF8
		private FtpLoginState _loginState; // 0x100
		internal FtpStatusCode StatusCode; // 0x104
		internal string StatusLine; // 0x108
		private static readonly AsyncCallback s_acceptCallbackDelegate; // 0x00
		private static readonly AsyncCallback s_connectCallbackDelegate; // 0x08
		private static readonly AsyncCallback s_SSLHandshakeCallback; // 0x10
	
		// Properties
		internal NetworkCredential Credentials { get; set; } // 0x0000000181BE61B0-0x0000000181BE6270 0x0000000181BE62D0-0x0000000181BE6380
		internal long ContentLength { get; } // 0x00000001806CCB50-0x00000001806CCB60 
		internal DateTime LastModified { get; } // 0x00000001806CCB60-0x00000001806CCB70 
		internal Uri ResponseUri { get; } // 0x0000000180CDCEE0-0x0000000180CDCEF0 
		internal string BannerMessage { get; } // 0x0000000181BE6180-0x0000000181BE61B0 
		internal string WelcomeMessage { get; } // 0x0000000181BE62A0-0x0000000181BE62D0 
		internal string ExitMessage { get; } // 0x0000000181BE6270-0x0000000181BE62A0 
	
		// Nested types
		private enum GetPathOption // TypeDefIndex: 9015
		{
			Normal = 0,
			AssumeFilename = 1,
			AssumeNoFilename = 2
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass31_0 // TypeDefIndex: 9016
		{
			// Fields
			public FtpControlStream __4__this; // 0x10
			public TlsStream tlsStream; // 0x18
	
			// Constructors
			public __c__DisplayClass31_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _PipelineCallback_b__0(IAsyncResult ar); // 0x0000000181BF5720-0x0000000181BF57E0
		}
	
		// Constructors
		internal FtpControlStream(TcpClient client); // 0x0000000181BE6040-0x0000000181BE6180
		static FtpControlStream(); // 0x0000000181BE5F00-0x0000000181BE6040
	
		// Methods
		internal void AbortConnect(); // 0x0000000181BE1310-0x0000000181BE1330
		private static void AcceptCallback(IAsyncResult asyncResult); // 0x0000000181BE1330-0x0000000181BE1600
		private static void ConnectCallback(IAsyncResult asyncResult); // 0x0000000181BE2C50-0x0000000181BE2D60
		private static void SSLHandshakeCallback(IAsyncResult asyncResult); // 0x0000000181BE5940-0x0000000181BE5A60
		private PipelineInstruction QueueOrCreateFtpDataStream(ref Stream stream); // 0x0000000181BE55F0-0x0000000181BE5940
		protected override void ClearState(); // 0x0000000181BE2B50-0x0000000181BE2C50
		protected override PipelineInstruction PipelineCallback(PipelineEntry entry, ResponseDescription response, bool timeout, ref Stream stream); // 0x0000000181BE41B0-0x0000000181BE4E10
		protected override PipelineEntry[] BuildCommandsList(WebRequest req); // 0x0000000181BE1600-0x0000000181BE27F0
		private PipelineInstruction QueueOrCreateDataConection(PipelineEntry entry, ResponseDescription response, bool timeout, ref Stream stream, out bool isSocketReady); // 0x0000000181BE4E10-0x0000000181BE55F0
		private static void GetPathInfo(GetPathOption pathOption, Uri uri, out string path, out string directory, out string filename); // 0x0000000181BE3820-0x0000000181BE39E0
		private string FormatAddress(IPAddress address, int Port); // 0x0000000181BE3130-0x0000000181BE3260
		private string FormatAddressV6(IPAddress address, int port); // 0x0000000181BE3020-0x0000000181BE3130
		private long GetContentLengthFrom213Response(string responseString); // 0x0000000181BE3360-0x0000000181BE3490
		private DateTime GetLastModifiedFrom213Response(string str); // 0x0000000181BE3490-0x0000000181BE3790
		private void TryUpdateResponseUri(string str, FtpWebRequest request); // 0x0000000181BE5B50-0x0000000181BE5F00
		private void TryUpdateContentLength(string str); // 0x0000000181BE5A60-0x0000000181BE5B50
		private string GetLoginDirectory(string str); // 0x0000000181BE3790-0x0000000181BE3820
		private int GetPortV4(string responseString); // 0x0000000181BE3D80-0x0000000181BE3F40
		private int GetPortV6(string responseString); // 0x0000000181BE3F40-0x0000000181BE4130
		private void CreateFtpListenerSocket(FtpWebRequest request); // 0x0000000181BE2DF0-0x0000000181BE3020
		private string GetPortCommandLine(FtpWebRequest request); // 0x0000000181BE39E0-0x0000000181BE3D80
		private string FormatFtpCommand(string command, string parameter); // 0x0000000181BE3260-0x0000000181BE3360
		protected Socket CreateFtpDataSocket(FtpWebRequest request, Socket templateSocket); // 0x0000000181BE2D60-0x0000000181BE2DF0
		protected override bool CheckValid(ResponseDescription response, ref int validThrough, ref int completeLength); // 0x0000000181BE27F0-0x0000000181BE2B50
		private TriState IsFtpDataStreamWriteable(); // 0x0000000181BE4130-0x0000000181BE41B0
	}
}
