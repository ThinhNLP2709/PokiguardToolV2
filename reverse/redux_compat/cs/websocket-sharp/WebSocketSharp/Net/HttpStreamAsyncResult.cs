/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

// Image 18: websocket-sharp.dll - Assembly: websocket-sharp, Version=1.0.2.0, Culture=neutral, PublicKeyToken=5660b08a1845a91e - Types 13215-13337

namespace WebSocketSharp.Net
{
	internal class HttpStreamAsyncResult : IAsyncResult // TypeDefIndex: 13283
	{
		// Fields
		private byte[] _buffer; // 0x10
		private AsyncCallback _callback; // 0x18
		private bool _completed; // 0x20
		private int _count; // 0x24
		private Exception _exception; // 0x28
		private int _offset; // 0x30
		private object _state; // 0x38
		private object _sync; // 0x40
		private int _syncRead; // 0x48
		private ManualResetEvent _waitHandle; // 0x50
	
		// Properties
		internal byte[] Buffer { get; set; } // 0x00000001825D8700-0x00000001825D8710 0x00000001803780D0-0x00000001803780E0
		internal int Count { get; set; } // 0x000000018260AC90-0x000000018260ACA0 0x0000000180E02560-0x0000000180E02570
		internal Exception Exception { get; } // 0x00000001825EE1C0-0x00000001825EE1D0 
		internal bool HasException { get; } // 0x000000018260ACA0-0x000000018260ACB0 
		internal int Offset { get; set; } // 0x000000018260AD30-0x000000018260AD40 0x000000018033E780-0x000000018033E790
		internal int SyncRead { get; set; } // 0x000000018260AD40-0x000000018260AD50 0x000000018033E7A0-0x000000018033E7B0
		public object AsyncState { get; } // 0x00000001825EE1D0-0x00000001825EE1E0 
		public WaitHandle AsyncWaitHandle { get; } // 0x000000018260ABB0-0x000000018260AC80 
		public bool CompletedSynchronously { get; } // 0x000000018260AC80-0x000000018260AC90 
		public bool IsCompleted { get; } // 0x000000018260ACB0-0x000000018260AD30 
	
		// Constructors
		internal HttpStreamAsyncResult(AsyncCallback callback, object state); // 0x000000018260AB30-0x000000018260ABB0
	
		// Methods
		internal void Complete(); // 0x000000018260A9F0-0x000000018260AB10
		internal void Complete(Exception exception); // 0x000000018260A8C0-0x000000018260A9F0
		[CompilerGenerated]
		private void _Complete_b__35_0(IAsyncResult ar); // 0x000000018260AB10-0x000000018260AB30
		[CompilerGenerated]
		private void _Complete_b__36_0(IAsyncResult ar); // 0x000000018260AB10-0x000000018260AB30
	}
}
