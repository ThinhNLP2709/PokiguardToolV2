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

namespace System.Security.Cryptography.X509Certificates
{
	public class X509Chain : IDisposable // TypeDefIndex: 8785
	{
		// Fields
		private X509ChainImpl impl; // 0x10
	
		// Properties
		internal X509ChainImpl Impl { get; } // 0x0000000181B9F8E0-0x0000000181B9F940 
		public X509ChainElementCollection ChainElements { get; } // 0x0000000181B9F7E0-0x0000000181B9F860 
		public X509ChainPolicy ChainPolicy { get; } // 0x0000000181B9F860-0x0000000181B9F8E0 
	
		// Constructors
		public X509Chain(); // 0x0000000181B9F6F0-0x0000000181B9F760
		public X509Chain(bool useMachineContext); // 0x0000000181B9F760-0x0000000181B9F7E0
		internal X509Chain(X509ChainImpl impl); // 0x0000000181B9F670-0x0000000181B9F6F0
		[MonoTODO("Mono\'s X509Chain is fully managed. All handles are invalid.")]
		public X509Chain(IntPtr chainContext); // 0x0000000181B9F620-0x0000000181B9F670
	
		// Methods
		[MonoTODO("Not totally RFC3280 compliant, but neither is MS implementation...")]
		public bool Build(X509Certificate2 certificate); // 0x0000000181B9F370-0x0000000181B9F400
		public void Reset(); // 0x0000000181B9F5A0-0x0000000181B9F620
		public static X509Chain Create(); // 0x0000000181B9F400-0x0000000181B9F4A0
		public void Dispose(); // 0x0000000181B9F530-0x0000000181B9F5A0
		protected virtual void Dispose(bool disposing); // 0x0000000181B9F4A0-0x0000000181B9F530
		~X509Chain(); // 0x0000000181428550-0x00000001814285D0
	}
}
