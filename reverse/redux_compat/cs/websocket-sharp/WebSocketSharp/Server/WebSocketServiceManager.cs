/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using WebSocketSharp;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Server
{
	public class WebSocketServiceManager // TypeDefIndex: 13331
	{
		// Fields
		private Dictionary<string, WebSocketServiceHost> _hosts; // 0x10
		private bool _keepClean; // 0x18
		private Logger _log; // 0x20
		private ServerState _state; // 0x28
		private object _sync; // 0x30
		private TimeSpan _waitTime; // 0x38
	
		// Properties
		public int Count { get; } // 0x0000000182624AD0-0x0000000182624B70 
		public IEnumerable<WebSocketServiceHost> Hosts { get; } // 0x0000000182624B70-0x0000000182624C70 
		public WebSocketServiceHost this[string path] { get => default; } // 0x0000000182624C70-0x0000000182624EB0 
		public bool KeepClean { get; set; } // 0x0000000182624EB0-0x0000000182624ED0 0x0000000182624FD0-0x00000001826251E0
		public IEnumerable<string> Paths { get; } // 0x0000000182624ED0-0x0000000182624FD0 
		public TimeSpan WaitTime { get; set; } // 0x00000001825EE1D0-0x00000001825EE1E0 0x00000001826251E0-0x0000000182625490
	
		// Constructors
		internal WebSocketServiceManager(Logger log); // 0x0000000182624970-0x0000000182624A80
	
		// Methods
		private bool canSet(); // 0x0000000182624A80-0x0000000182624AD0
		internal bool InternalTryGetServiceHost(string path, out WebSocketServiceHost host); // 0x0000000182623F00-0x0000000182624010
		internal void Start(); // 0x00000001826243A0-0x0000000182624560
		internal void Stop(ushort code, string reason); // 0x0000000182624560-0x0000000182624730
		public void AddService<TBehavior>(string path, Action<TBehavior> initializer)
			where TBehavior : WebSocketBehavior, new();
		public void Clear(); // 0x0000000182623CD0-0x0000000182623F00
		public bool RemoveService(string path); // 0x0000000182624010-0x00000001826243A0
		public bool TryGetServiceHost(string path, out WebSocketServiceHost host); // 0x0000000182624730-0x0000000182624970
	}
}
