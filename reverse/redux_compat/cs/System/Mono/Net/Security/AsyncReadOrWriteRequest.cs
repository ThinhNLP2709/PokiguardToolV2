/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Net.Security
{
	internal abstract class AsyncReadOrWriteRequest : AsyncProtocolRequest // TypeDefIndex: 8552
	{
		// Fields
		[CompilerGenerated]
		private readonly BufferOffsetSize _UserBuffer_k__BackingField; // 0x38
		[CompilerGenerated]
		private int _CurrentSize_k__BackingField; // 0x40
	
		// Properties
		protected BufferOffsetSize UserBuffer { [CompilerGenerated] get; } // 0x00000001803272A0-0x00000001803272B0 
		protected int CurrentSize { [CompilerGenerated] get; [CompilerGenerated] set; } // 0x000000018033D790-0x000000018033D7A0 0x000000018033ED10-0x000000018033ED20
	
		// Constructors
		public AsyncReadOrWriteRequest(MobileAuthenticatedStream parent, bool sync, byte[] buffer, int offset, int size); // 0x000000018180F6F0-0x000000018180F790
	
		// Methods
		public override string ToString(); // 0x000000018180F680-0x000000018180F6F0
	}
}
