/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Security.X509;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace System.Security.Cryptography.X509Certificates
{
	public sealed class X509Store : IDisposable // TypeDefIndex: 8799
	{
		// Fields
		private string _name; // 0x10
		private StoreLocation _location; // 0x18
		private X509Certificate2Collection list; // 0x20
		private OpenFlags _flags; // 0x28
		private Mono.Security.X509.X509Store store; // 0x30
	
		// Properties
		public X509Certificate2Collection Certificates { get; } // 0x0000000181BA2300-0x0000000181BA2390 
		private X509Stores Factory { get; } // 0x0000000181BA2390-0x0000000181BA23B0 
		internal Mono.Security.X509.X509Store Store { get; } // 0x000000018031E110-0x000000018031E120 
	
		// Constructors
		public X509Store(StoreName storeName, StoreLocation storeLocation); // 0x0000000181BA21A0-0x0000000181BA2300
	
		// Methods
		public void Close(); // 0x0000000181BA1D80-0x0000000181BA1DC0
		public void Dispose(); // 0x0000000181BA1D80-0x0000000181BA1DC0
		public void Open(OpenFlags flags); // 0x0000000181BA1DC0-0x0000000181BA21A0
	}
}
