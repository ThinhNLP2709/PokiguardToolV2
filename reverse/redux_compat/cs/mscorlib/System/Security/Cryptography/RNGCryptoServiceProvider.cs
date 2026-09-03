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

namespace System.Security.Cryptography
{
	public sealed class RNGCryptoServiceProvider : RandomNumberGenerator // TypeDefIndex: 2843
	{
		// Fields
		private static object _lock; // 0x00
		private IntPtr _handle; // 0x10
	
		// Constructors
		static RNGCryptoServiceProvider(); // 0x00000001814A3D80-0x00000001814A3E10
		public RNGCryptoServiceProvider(); // 0x00000001814A3E10-0x00000001814A3E70
	
		// Methods
		private void Check(); // 0x00000001814A3A10-0x00000001814A3A90
		private static bool RngOpen(); // 0x00000001814A3D70-0x00000001814A3D80
		private static unsafe IntPtr RngInitialize(byte* seed, IntPtr seed_length); // 0x00000001814A3D60-0x00000001814A3D70
		private static unsafe IntPtr RngGetBytes(IntPtr handle, byte* data, IntPtr data_length); // 0x00000001814A3D50-0x00000001814A3D60
		private static void RngClose(IntPtr handle); // 0x00000001814A3D40-0x00000001814A3D50
		public override void GetBytes(byte[] data); // 0x00000001814A3B60-0x00000001814A3D40
		~RNGCryptoServiceProvider(); // 0x00000001814A3AA0-0x00000001814A3B60
		protected override void Dispose(bool disposing); // 0x00000001814A3A90-0x00000001814A3AA0
	}
}
