/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	[IsReadOnly]
	public struct CancellationTokenRegistration : IEquatable<CancellationTokenRegistration>, IDisposable // TypeDefIndex: 2549
	{
		// Fields
		private readonly CancellationCallbackInfo m_callbackInfo; // 0x00
		private readonly SparselyPopulatedArrayAddInfo<CancellationCallbackInfo> m_registrationInfo; // 0x08
	
		// Constructors
		internal CancellationTokenRegistration(CancellationCallbackInfo callbackInfo, SparselyPopulatedArrayAddInfo<CancellationCallbackInfo> registrationInfo); // 0x0000000180F378E0-0x0000000180F37920
	
		// Methods
		public bool Unregister(); // 0x00000001816645F0-0x0000000181664670
		public void Dispose(); // 0x0000000181664310-0x0000000181664460
		public override bool Equals(object obj); // 0x00000001816644B0-0x0000000181664560
		public bool Equals(CancellationTokenRegistration other); // 0x0000000181664460-0x00000001816644B0
		public override int GetHashCode(); // 0x0000000181664560-0x00000001816645F0
	}
}
