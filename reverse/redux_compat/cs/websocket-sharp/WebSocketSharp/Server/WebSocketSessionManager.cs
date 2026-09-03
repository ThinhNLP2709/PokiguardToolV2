/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Timers;
using WebSocketSharp;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Server
{
	public class WebSocketSessionManager // TypeDefIndex: 13325
	{
		// Fields
		private static readonly byte[] _emptyPingFrameAsBytes; // 0x00
		private object _forSweep; // 0x10
		private bool _keepClean; // 0x18
		private Logger _log; // 0x20
		private Dictionary<string, IWebSocketSession> _sessions; // 0x28
		private ServerState _state; // 0x30
		private bool _sweeping; // 0x34
		private Timer _sweepTimer; // 0x38
		private object _sync; // 0x40
		private TimeSpan _waitTime; // 0x48
	
		// Properties
		internal ServerState State { get; } // 0x0000000182629690-0x00000001826296B0 
		public IEnumerable<string> ActiveIDs { get; } // 0x0000000182629030-0x00000001826290C0 
		public int Count { get; } // 0x00000001826290C0-0x0000000182629160 
		public IEnumerable<string> IDs { get; } // 0x0000000182629160-0x0000000182629340 
		public IEnumerable<string> InactiveIDs { get; } // 0x0000000182629340-0x00000001826293D0 
		public IWebSocketSession this[string id] { get => default; } // 0x00000001826293D0-0x00000001826294B0 
		public bool KeepClean { get; set; } // 0x0000000182624EB0-0x0000000182624ED0 0x0000000182629780-0x0000000182629850
		public IEnumerable<IWebSocketSession> Sessions { get; } // 0x00000001826294B0-0x0000000182629690 
		public TimeSpan WaitTime { get; set; } // 0x00000001825E8B00-0x00000001825E8B10 0x0000000182629850-0x00000001826299D0
	
		// Nested types
		[CompilerGenerated]
		private sealed class _get_ActiveIDs_d__15 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 13326
		{
			// Fields
			private int __1__state; // 0x10
			private string __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			public WebSocketSessionManager __4__this; // 0x28
			private Dictionary<string, bool> __s__1; // 0x30
			private KeyValuePair<string, bool> _res_5__2; // 0x58
	
			// Properties
			string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _get_ActiveIDs_d__15(int __1__state); // 0x00000001825DE850-0x00000001825DE8A0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018261F9E0-0x000000018261FA60
			private bool MoveNext(); // 0x000000018261F6B0-0x000000018261F8E0
			private void __m__Finally1(); // 0x000000018206C8D0-0x000000018206C8F0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018261F9A0-0x000000018261F9E0
			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x000000018261F8E0-0x000000018261F9A0
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x000000018261F8E0-0x000000018261F9A0
		}
	
		[CompilerGenerated]
		private sealed class _get_InactiveIDs_d__21 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 13327
		{
			// Fields
			private int __1__state; // 0x10
			private string __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			public WebSocketSessionManager __4__this; // 0x28
			private Dictionary<string, bool> __s__1; // 0x30
			private KeyValuePair<string, bool> _res_5__2; // 0x58
	
			// Properties
			string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _get_InactiveIDs_d__21(int __1__state); // 0x00000001825DE850-0x00000001825DE8A0
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x000000018261F9E0-0x000000018261FA60
			private bool MoveNext(); // 0x000000018261FA60-0x000000018261FC90
			private void __m__Finally1(); // 0x000000018206C8D0-0x000000018206C8F0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x000000018261FD50-0x000000018261FD90
			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x000000018261FC90-0x000000018261FD50
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x000000018261FC90-0x000000018261FD50
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass34_0 // TypeDefIndex: 13328
		{
			// Fields
			public WebSocketSessionManager __4__this; // 0x10
			public Opcode opcode; // 0x18
			public byte[] data; // 0x20
			public Action completed; // 0x28
	
			// Constructors
			public __c__DisplayClass34_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _broadcastAsync_b__0(object state); // 0x000000018261F0D0-0x000000018261F110
		}
	
		[CompilerGenerated]
		private sealed class __c__DisplayClass35_0 // TypeDefIndex: 13329
		{
			// Fields
			public WebSocketSessionManager __4__this; // 0x10
			public Opcode opcode; // 0x18
			public Stream stream; // 0x20
			public Action completed; // 0x28
	
			// Constructors
			public __c__DisplayClass35_0(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal void _broadcastAsync_b__0(object state); // 0x000000018261F110-0x000000018261F150
		}
	
		// Constructors
		static WebSocketSessionManager(); // 0x00000001826280E0-0x0000000182628150
		internal WebSocketSessionManager(Logger log); // 0x0000000182628150-0x0000000182628340
	
		// Methods
		private void broadcast(Opcode opcode, byte[] data, Action completed); // 0x0000000182628910-0x0000000182628CC0
		private void broadcast(Opcode opcode, Stream stream, Action completed); // 0x0000000182628540-0x0000000182628910
		private void broadcastAsync(Opcode opcode, byte[] data, Action completed); // 0x0000000182628340-0x0000000182628440
		private void broadcastAsync(Opcode opcode, Stream stream, Action completed); // 0x0000000182628440-0x0000000182628540
		private Dictionary<string, bool> broadping(byte[] frameAsBytes); // 0x0000000182628CC0-0x0000000182628F80
		private bool canSet(); // 0x0000000182628F80-0x0000000182628FD0
		private static string createID(); // 0x0000000182628FD0-0x0000000182629030
		private void setSweepTimer(double interval); // 0x00000001826296B0-0x0000000182629780
		private void stop(PayloadData payloadData, bool send); // 0x00000001826299D0-0x0000000182629D00
		private bool tryGetSession(string id, out IWebSocketSession session); // 0x0000000182629D00-0x0000000182629E40
		internal string Add(IWebSocketSession session); // 0x0000000182625490-0x0000000182625620
		internal bool Remove(string id); // 0x0000000182626DA0-0x0000000182626E70
		internal void Start(); // 0x0000000182627990-0x0000000182627A50
		internal void Stop(ushort code, string reason); // 0x0000000182627A50-0x0000000182627B40
		public void Broadcast(byte[] data); // 0x0000000182625D70-0x0000000182625F00
		public void Broadcast(string data); // 0x0000000182625F00-0x0000000182626150
		public void Broadcast(Stream stream, int length); // 0x0000000182626150-0x00000001826264B0
		public void BroadcastAsync(byte[] data, Action completed); // 0x0000000182625870-0x0000000182625A00
		public void BroadcastAsync(string data, Action completed); // 0x0000000182625620-0x0000000182625870
		public void BroadcastAsync(Stream stream, int length, Action completed); // 0x0000000182625A00-0x0000000182625D70
		public void CloseSession(string id); // 0x0000000182626690-0x0000000182626840
		public void CloseSession(string id, ushort code, string reason); // 0x00000001826264B0-0x0000000182626690
		public void CloseSession(string id, CloseStatusCode code, string reason); // 0x0000000182626840-0x0000000182626A20
		public bool PingTo(string id); // 0x0000000182626A20-0x0000000182626BD0
		public bool PingTo(string message, string id); // 0x0000000182626BD0-0x0000000182626DA0
		public void SendTo(byte[] data, string id); // 0x00000001826277C0-0x0000000182627990
		public void SendTo(string data, string id); // 0x0000000182627410-0x00000001826275E0
		public void SendTo(Stream stream, int length, string id); // 0x00000001826275E0-0x00000001826277C0
		public void SendToAsync(byte[] data, string id, Action<bool> completed); // 0x0000000182627050-0x0000000182627230
		public void SendToAsync(string data, string id, Action<bool> completed); // 0x0000000182627230-0x0000000182627410
		public void SendToAsync(Stream stream, int length, string id, Action<bool> completed); // 0x0000000182626E70-0x0000000182627050
		public void Sweep(); // 0x0000000182627B40-0x0000000182628000
		public bool TryGetSession(string id, out IWebSocketSession session); // 0x0000000182628000-0x00000001826280D0
		[CompilerGenerated]
		private void _setSweepTimer_b__39_0(object sender, ElapsedEventArgs e); // 0x00000001826280D0-0x00000001826280E0
	}
}
