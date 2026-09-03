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

namespace Mono.Security.X509
{
	public class X509Stores // TypeDefIndex: 13831
	{
		// Fields
		private string _storePath; // 0x10
		private bool _newFormat; // 0x18
		private X509Store _trusted; // 0x20
	
		// Properties
		public X509Store TrustedRoot { get; } // 0x0000000181418DC0-0x0000000181418EB0 
	
		// Constructors
		internal X509Stores(string path, bool newFormat); // 0x0000000181237140-0x0000000181237190
	
		// Methods
		public X509Store Open(string storeName, bool create); // 0x0000000181418C90-0x0000000181418DC0
	}
}
