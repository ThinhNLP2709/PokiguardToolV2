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

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Net.Security
{
	public abstract class AuthenticatedStream : Stream // TypeDefIndex: 9246
	{
		// Fields
		private Stream _InnerStream; // 0x28
		private bool _LeaveStreamOpen; // 0x30
	
		// Properties
		protected Stream InnerStream { get; } // 0x000000018033D240-0x000000018033D250 
		public abstract bool IsAuthenticated { get; }
	
		// Constructors
		protected AuthenticatedStream(Stream innerStream, bool leaveInnerStreamOpen); // 0x0000000181B256A0-0x0000000181B25800
	
		// Methods
		protected override void Dispose(bool disposing); // 0x0000000181B255B0-0x0000000181B256A0
	}
}
