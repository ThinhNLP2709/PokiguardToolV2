/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	internal sealed class HttpConnection // TypeDefIndex: 13274
	{
		// Fields
		private int _attempts; // 0x10
		private byte[] _buffer; // 0x18
		private static readonly int _bufferLength; // 0x00
		private HttpListenerContext _context; // 0x20
		private StringBuilder _currentLine; // 0x28
		private InputState _inputState; // 0x30
		private RequestStream _inputStream; // 0x38
		private LineState _lineState; // 0x40
		private EndPointListener _listener; // 0x48
		private EndPoint _localEndPoint; // 0x50
		private static readonly int _maxInputLength; // 0x04
		private ResponseStream _outputStream; // 0x58
		private int _position; // 0x60
		private EndPoint _remoteEndPoint; // 0x68
		private MemoryStream _requestBuffer; // 0x70
		private int _reuses; // 0x78
		private bool _secure; // 0x7C
		private Socket _socket; // 0x80
		private Stream _stream; // 0x88
		private object _sync; // 0x90
		private int _timeout; // 0x98
		private Dictionary<int, bool> _timeoutCanceled; // 0xA0
		private Timer _timer; // 0xA8
	
		// Properties
		public bool IsClosed { get; } // 0x00000001825F77F0-0x00000001825F7800 
		public bool IsLocal { get; } // 0x00000001825F7800-0x00000001825F78A0 
		public bool IsSecure { get; } // 0x00000001825F78A0-0x00000001825F78B0 
		public IPEndPoint LocalEndPoint { get; } // 0x00000001825F78B0-0x00000001825F7920 
		public IPEndPoint RemoteEndPoint { get; } // 0x00000001825F7920-0x00000001825F7990 
		public int Reuses { get; } // 0x00000001825F7990-0x00000001825F79A0 
		public Stream Stream { get; } // 0x00000001825F79A0-0x00000001825F79B0 
	
		// Constructors
		static HttpConnection(); // 0x00000001825F7000-0x00000001825F7050
		internal HttpConnection(Socket socket, EndPointListener listener); // 0x00000001825F7050-0x00000001825F73D0
	
		// Methods
		private void close(); // 0x00000001825F7440-0x00000001825F7580
		private void closeSocket(); // 0x00000001825F73D0-0x00000001825F7440
		private static MemoryStream createRequestBuffer(RequestStream inputStream); // 0x00000001825F7580-0x00000001825F76E0
		private void disposeRequestBuffer(); // 0x00000001825F76E0-0x00000001825F7720
		private void disposeStream(); // 0x00000001825F7720-0x00000001825F7770
		private void disposeTimer(); // 0x00000001825F7770-0x00000001825F77F0
		private void init(MemoryStream requestBuffer, int timeout); // 0x00000001825F79B0-0x00000001825F7BB0
		private static void onRead(IAsyncResult asyncResult); // 0x00000001825F7BB0-0x00000001825F7E10
		private static void onTimeout(object state); // 0x00000001825F7E10-0x00000001825F7F60
		private bool processInput(byte[] data, int length); // 0x00000001825F7F60-0x00000001825F8250
		private bool processRequestBuffer(); // 0x00000001825F8250-0x00000001825F83D0
		private string readLineFrom(byte[] buffer, int offset, int length, out int nread); // 0x00000001825F83D0-0x00000001825F84E0
		private MemoryStream takeOverRequestBuffer(); // 0x00000001825F84E0-0x00000001825F8750
		internal void BeginReadRequest(); // 0x00000001825F6800-0x00000001825F6970
		internal void Close(bool force); // 0x00000001825F6980-0x00000001825F6BD0
		public void Close(); // 0x00000001825F6970-0x00000001825F6980
		public RequestStream GetRequestStream(long contentLength, bool chunked); // 0x00000001825F6BD0-0x00000001825F6E10
		public ResponseStream GetResponseStream(); // 0x00000001825F6E10-0x00000001825F7000
	}
}
