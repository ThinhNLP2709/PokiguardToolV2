/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

// Image 9: Newtonsoft.Json.dll - Assembly: Newtonsoft.Json, Version=13.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed - Types 9945-10440

namespace Newtonsoft.Json.Utilities
{
	[Nullable(0)]
	[NullableContext(1)]
	internal class Base64Encoder // TypeDefIndex: 10094
	{
		// Fields
		private const int Base64LineSize = 76; // Metadata: 0x006A0683
		private const int LineSizeInBytes = 57; // Metadata: 0x006A0685
		private readonly char[] _charsLine; // 0x10
		private readonly TextWriter _writer; // 0x18
		[Nullable(2)]
		private byte[] _leftOverBytes; // 0x20
		private int _leftOverBytesCount; // 0x28
	
		// Nested types
		[CompilerGenerated]
		private struct _EncodeAsync_d__13 : IAsyncStateMachine // TypeDefIndex: 10095
		{
			// Fields
			public int __1__state; // 0x00
			public AsyncTaskMethodBuilder __t__builder; // 0x08
			[Nullable(0)]
			public Base64Encoder __4__this; // 0x20
			[Nullable(0)]
			public byte[] buffer; // 0x28
			public int index; // 0x30
			public int count; // 0x34
			public CancellationToken cancellationToken; // 0x38
			private int _num4_5__2; // 0x40
			private int _length_5__3; // 0x44
			private ConfiguredTaskAwaitable.ConfiguredTaskAwaiter __u__1; // 0x48
	
			// Methods
			private void MoveNext(); // 0x00000001816FAA50-0x00000001816FAEE0
			[DebuggerHidden]
			private void SetStateMachine([Nullable(0)] IAsyncStateMachine stateMachine); // 0x00000001816FAEE0-0x00000001816FAF40
		}
	
		// Constructors
		public Base64Encoder(TextWriter writer); // 0x00000001816E29F0-0x00000001816E2A80
	
		// Methods
		private void ValidateEncode(byte[] buffer, int index, int count); // 0x00000001816E27D0-0x00000001816E2930
		public void Encode(byte[] buffer, int index, int count); // 0x00000001816E21B0-0x00000001816E23E0
		private void StoreLeftOverBytes(byte[] buffer, int index, ref int count); // 0x00000001816E26D0-0x00000001816E27D0
		private bool FulfillFromLeftover(byte[] buffer, int index, ref int count); // 0x00000001816E2610-0x00000001816E26D0
		public void Flush(); // 0x00000001816E2540-0x00000001816E2610
		private void WriteChars(char[] chars, int index, int count); // 0x00000001816E29C0-0x00000001816E29F0
		public async Task EncodeAsync(byte[] buffer, int index, int count, CancellationToken cancellationToken); // 0x00000001816E2080-0x00000001816E21B0
		private Task WriteCharsAsync(char[] chars, int index, int count, CancellationToken cancellationToken); // 0x00000001816E2930-0x00000001816E29C0
		public Task FlushAsync(CancellationToken cancellationToken); // 0x00000001816E23E0-0x00000001816E2540
	}
}
