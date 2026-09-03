/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 22: Mono.Security.dll - Assembly: Mono.Security, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756 - Types 13806-13909

namespace Mono.Security.Protocol.Ntlm
{
	public abstract class MessageBase // TypeDefIndex: 13854
	{
		// Fields
		private static byte[] header; // 0x00
		private int _type; // 0x10
		private NtlmFlags _flags; // 0x14
	
		// Properties
		public NtlmFlags Flags { get; set; } // 0x0000000180A5E110-0x0000000180A5E120 0x0000000180E02550-0x0000000180E02560
		public int Type { get; } // 0x00000001802E64B0-0x00000001802E64C0 
	
		// Constructors
		protected MessageBase(int messageType); // 0x00000001802F9040-0x00000001802F9070
		static MessageBase(); // 0x0000000181423400-0x0000000181423490
	
		// Methods
		protected byte[] PrepareMessage(int messageSize); // 0x0000000181423310-0x0000000181423400
		protected virtual void Decode(byte[] message); // 0x0000000181423080-0x0000000181423310
		protected bool CheckHeader(byte[] message); // 0x0000000181422F50-0x0000000181423080
		public abstract byte[] GetBytes();
	}
}
