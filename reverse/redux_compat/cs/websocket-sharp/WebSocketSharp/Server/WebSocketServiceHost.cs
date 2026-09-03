/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using WebSocketSharp;
using WebSocketSharp.Net.WebSockets;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Server
{
	public abstract class WebSocketServiceHost // TypeDefIndex: 13322
	{
		// Fields
		private Logger _log; // 0x10
		private string _path; // 0x18
		private WebSocketSessionManager _sessions; // 0x20
	
		// Properties
		internal ServerState State { get; } // 0x0000000182623C60-0x0000000182623C90 
		protected Logger Log { get; } // 0x00000001825D8700-0x00000001825D8710 
		public bool KeepClean { get; set; } // 0x0000000182623C30-0x0000000182623C60 0x0000000182623C90-0x0000000182623CB0
		public string Path { get; } // 0x00000001825D8710-0x00000001825D8720 
		public WebSocketSessionManager Sessions { get; } // 0x00000001825DE400-0x00000001825DE410 
		public abstract Type BehaviorType { get; }
		public TimeSpan WaitTime { get; set; } // 0x0000000181E1B6D0-0x0000000181E1B6F0 0x0000000182623CB0-0x0000000182623CD0
	
		// Constructors
		protected WebSocketServiceHost(string path, Logger log); // 0x0000000182623B90-0x0000000182623C30
	
		// Methods
		internal void Start(); // 0x0000000182623A60-0x0000000182623A80
		internal void StartSession(WebSocketContext context); // 0x0000000182623A10-0x0000000182623A60
		internal void Stop(ushort code, string reason); // 0x0000000182623A80-0x0000000182623B90
		protected abstract WebSocketBehavior CreateSession();
	}
}
