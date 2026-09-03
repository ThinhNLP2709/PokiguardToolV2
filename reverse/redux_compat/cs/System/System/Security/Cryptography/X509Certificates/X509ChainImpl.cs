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
	internal abstract class X509ChainImpl : IDisposable // TypeDefIndex: 8789
	{
		// Properties
		public abstract bool IsValid { get; }
		public abstract X509ChainElementCollection ChainElements { get; }
		public abstract X509ChainPolicy ChainPolicy { get; }
	
		// Constructors
		protected X509ChainImpl(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		protected void ThrowIfContextInvalid(); // 0x0000000181B9EAD0-0x0000000181B9EB20
		public abstract bool Build(X509Certificate2 certificate);
		public abstract void AddStatus(X509ChainStatusFlags errorCode);
		public abstract void Reset();
		public void Dispose(); // 0x0000000181B9E9E0-0x0000000181B9EA50
		protected virtual void Dispose(bool disposing); // 0x00000001802E76C0-0x00000001802E76D0
		~X509ChainImpl(); // 0x0000000181B9EA50-0x0000000181B9EAD0
	}
}
