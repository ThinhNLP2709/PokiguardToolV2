/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Net.WebSockets;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Server
{
	public abstract class WebSocketBehavior : IWebSocketSession // TypeDefIndex: 13332
	{
		// Fields
		private WebSocketContext _context; // 0x10
		private Func<CookieCollection, CookieCollection, bool> _cookiesValidator; // 0x18
		private bool _emitOnPing; // 0x20
		private string _id; // 0x28
		private bool _ignoreExtensions; // 0x30
		private Func<string, bool> _originValidator; // 0x38
		private string _protocol; // 0x40
		private WebSocketSessionManager _sessions; // 0x48
		private DateTime _startTime; // 0x50
		private WebSocket _websocket; // 0x58
	
		// Properties
		protected NameValueCollection Headers { get; } // 0x00000001826210A0-0x00000001826210D0 
		protected NameValueCollection QueryString { get; } // 0x0000000182621110-0x0000000182621140 
		protected WebSocketSessionManager Sessions { get; } // 0x00000001825E8B00-0x00000001825E8B10 
		public WebSocketState ConnectionState { get; } // 0x0000000182621040-0x0000000182621070 
		public WebSocketContext Context { get; } // 0x00000001825D8700-0x00000001825D8710 
		public Func<CookieCollection, CookieCollection, bool> CookiesValidator { get; set; } // 0x00000001825D8710-0x00000001825D8720 0x00000001802FAF70-0x00000001802FAF80
		public bool EmitOnPing { get; set; } // 0x0000000182621070-0x00000001826210A0 0x0000000182621290-0x00000001826212C0
		public string ID { get; } // 0x00000001825EE1C0-0x00000001825EE1D0 
		public bool IgnoreExtensions { get; set; } // 0x00000001825E8A50-0x00000001825E8A60 0x00000001802E8960-0x00000001802E8970
		public Func<string, bool> OriginValidator { get; set; } // 0x00000001825EE1D0-0x00000001825EE1E0 0x000000018033E850-0x000000018033E860
		public string Protocol { get; set; } // 0x00000001826210D0-0x0000000182621110 0x00000001826212C0-0x0000000182621410
		public DateTime StartTime { get; } // 0x00000001825F1E80-0x00000001825F1E90 
	
		// Constructors
		protected WebSocketBehavior(); // 0x0000000182620E90-0x0000000182620F00
	
		// Methods
		private string checkHandshakeRequest(WebSocketContext context); // 0x0000000182620F00-0x0000000182621040
		private void onClose(object sender, CloseEventArgs e); // 0x0000000182621140-0x00000001826211A0
		private void onError(object sender, ErrorEventArgs e); // 0x00000001826211A0-0x00000001826211C0
		private void onMessage(object sender, MessageEventArgs e); // 0x00000001826211C0-0x00000001826211E0
		private void onOpen(object sender, EventArgs e); // 0x00000001826211E0-0x0000000182621290
		internal void Start(WebSocketContext context, WebSocketSessionManager sessions); // 0x0000000182620B80-0x0000000182620E90
		protected void Close(); // 0x0000000182620500-0x0000000182620580
		protected void Close(ushort code, string reason); // 0x0000000182620580-0x0000000182620600
		protected void Close(CloseStatusCode code, string reason); // 0x0000000182620600-0x0000000182620680
		protected void CloseAsync(); // 0x0000000182620480-0x0000000182620500
		protected void CloseAsync(ushort code, string reason); // 0x0000000182620400-0x0000000182620480
		protected void CloseAsync(CloseStatusCode code, string reason); // 0x0000000182620380-0x0000000182620400
		protected virtual void OnClose(CloseEventArgs e); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnError(ErrorEventArgs e); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnMessage(MessageEventArgs e); // 0x00000001802E76C0-0x00000001802E76D0
		protected virtual void OnOpen(); // 0x00000001802E76C0-0x00000001802E76D0
		protected bool Ping(); // 0x0000000182620680-0x0000000182620700
		protected bool Ping(string message); // 0x0000000182620700-0x0000000182620780
		protected void Send(byte[] data); // 0x0000000182620980-0x0000000182620A00
		protected void Send(FileInfo fileInfo); // 0x0000000182620A00-0x0000000182620A80
		protected void Send(string data); // 0x0000000182620B00-0x0000000182620B80
		protected void Send(Stream stream, int length); // 0x0000000182620A80-0x0000000182620B00
		protected void SendAsync(byte[] data, Action<bool> completed); // 0x0000000182620880-0x0000000182620900
		protected void SendAsync(FileInfo fileInfo, Action<bool> completed); // 0x0000000182620800-0x0000000182620880
		protected void SendAsync(string data, Action<bool> completed); // 0x0000000182620900-0x0000000182620980
		protected void SendAsync(Stream stream, int length, Action<bool> completed); // 0x0000000182620780-0x0000000182620800
	}
}
