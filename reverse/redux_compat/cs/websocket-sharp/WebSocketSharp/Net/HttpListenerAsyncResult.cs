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
	internal class HttpListenerAsyncResult : IAsyncResult // TypeDefIndex: 13309
	{
		// Fields
		private AsyncCallback _callback; // 0x10
		private bool _completed; // 0x18
		private bool _completedSynchronously; // 0x19
		private HttpListenerContext _context; // 0x20
		private bool _endCalled; // 0x28
		private Exception _exception; // 0x30
		private object _state; // 0x38
		private object _sync; // 0x40
		private ManualResetEvent _waitHandle; // 0x48
	
		// Properties
		internal HttpListenerContext Context { get; } // 0x00000001826196A0-0x00000001826196E0 
		internal bool EndCalled { get; set; } // 0x0000000182602ED0-0x0000000182602EE0 0x00000001804AE490-0x00000001804AE4A0
		internal object SyncRoot { get; } // 0x00000001825E8A60-0x00000001825E8A70 
		public object AsyncState { get; } // 0x00000001825EE1D0-0x00000001825EE1E0 
		public WaitHandle AsyncWaitHandle { get; } // 0x00000001826195D0-0x00000001826196A0 
		public bool CompletedSynchronously { get; } // 0x00000001825DDB80-0x00000001825DDB90 
		public bool IsCompleted { get; } // 0x00000001826196E0-0x0000000182619760 
	
		// Constructors
		internal HttpListenerAsyncResult(AsyncCallback callback, object state); // 0x0000000182619450-0x00000001826194D0
	
		// Methods
		private void complete(); // 0x00000001826194D0-0x00000001826195D0
		internal void Complete(Exception exception); // 0x00000001826193B0-0x00000001826193E0
		internal void Complete(HttpListenerContext context, bool completedSynchronously); // 0x00000001826193E0-0x0000000182619420
		[CompilerGenerated]
		private void _complete_b__25_0(object state); // 0x0000000182619420-0x0000000182619450
	}
}
