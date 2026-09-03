/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Buffers
{
	[EventSource(Guid = "0866B2B8-5CEF-5DB9-2612-0C0FFD814A44", Name = "System.Buffers.ArrayPoolEventSource")]
	internal sealed class ArrayPoolEventSource : EventSource // TypeDefIndex: 3624
	{
		// Fields
		internal static readonly ArrayPoolEventSource Log; // 0x00
	
		// Nested types
		internal enum BufferAllocatedReason // TypeDefIndex: 3625
		{
			Pooled = 0,
			OverMaximumSize = 1,
			PoolExhausted = 2
		}
	
		// Constructors
		private ArrayPoolEventSource(); // 0x00000001815A6E70-0x00000001815A6F20
		static ArrayPoolEventSource(); // 0x00000001815A6D70-0x00000001815A6E70
	
		// Methods
		[Event(1, Level = EventLevel.Verbose)]
		internal void BufferRented(int bufferId, int bufferSize, int poolId, int bucketId); // 0x00000001815A6BF0-0x00000001815A6CE0
		[Event(2, Level = EventLevel.Informational)]
		internal void BufferAllocated(int bufferId, int bufferSize, int poolId, int bucketId, BufferAllocatedReason reason); // 0x00000001815A6AE0-0x00000001815A6BF0
		[Event(3, Level = EventLevel.Verbose)]
		internal void BufferReturned(int bufferId, int bufferSize, int poolId); // 0x00000001815A6CE0-0x00000001815A6D10
		[Event(4, Level = EventLevel.Informational)]
		internal void BufferTrimmed(int bufferId, int bufferSize, int poolId); // 0x00000001815A6D40-0x00000001815A6D70
		[Event(5, Level = EventLevel.Informational)]
		internal void BufferTrimPoll(int milliseconds, int pressure); // 0x00000001815A6D10-0x00000001815A6D40
	}
}
