/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System
{
	[Serializable]
	public class OperationCanceledException : SystemException // TypeDefIndex: 2319
	{
		// Fields
		[NonSerialized]
		private CancellationToken _cancellationToken; // 0x90
	
		// Properties
		public CancellationToken CancellationToken { get; private set; } // 0x00000001806CCBA0-0x00000001806CCBB0 0x0000000181617040-0x0000000181617060
	
		// Constructors
		public OperationCanceledException(); // 0x0000000181616F10-0x0000000181616F80
		public OperationCanceledException(string message); // 0x0000000181616F80-0x0000000181616FD0
		public OperationCanceledException(string message, CancellationToken token); // 0x0000000181616FD0-0x0000000181617040
		protected OperationCanceledException(SerializationInfo info, StreamingContext context); // 0x00000001814ADEF0-0x00000001814ADF50
	}
}
