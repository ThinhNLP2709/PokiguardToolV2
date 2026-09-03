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
using System.Threading;
using System.Threading.Tasks;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net
{
	internal class ContentDecodeStream : WebReadStream // TypeDefIndex: 9115
	{
		// Fields
		[CompilerGenerated]
		private readonly Stream _OriginalInnerStream_k__BackingField; // 0x40
	
		// Properties
		private Stream OriginalInnerStream { [CompilerGenerated] get; } // 0x0000000180377940-0x0000000180377950 
	
		// Nested types
		internal enum Mode // TypeDefIndex: 9116
		{
			GZip = 0,
			Deflate = 1
		}
	
		// Constructors
		private ContentDecodeStream(WebOperation operation, Stream decodeStream, Stream originalInnerStream); // 0x0000000181BFBBC0-0x0000000181BFBC00
	
		// Methods
		public static ContentDecodeStream Create(WebOperation operation, Stream innerStream, Mode mode); // 0x0000000181BFBEB0-0x0000000181BFBF90
		protected override Task<int> ProcessReadAsync(byte[] buffer, int offset, int size, CancellationToken cancellationToken); // 0x0000000181BF3990-0x0000000181BF39C0
		internal override Task FinishReading(CancellationToken cancellationToken); // 0x0000000181BFBF90-0x0000000181BFC090
	}
}
