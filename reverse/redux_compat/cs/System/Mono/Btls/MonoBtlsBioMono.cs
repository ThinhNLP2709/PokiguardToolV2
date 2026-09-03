/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Mono.Util;

// Image 7: System.dll - Assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 8474-9286

namespace Mono.Btls
{
	internal class MonoBtlsBioMono : MonoBtlsBio // TypeDefIndex: 8585
	{
		// Fields
		private GCHandle handle; // 0x20
		private IntPtr instance; // 0x28
		private BioReadFunc readFunc; // 0x30
		private BioWriteFunc writeFunc; // 0x38
		private BioControlFunc controlFunc; // 0x40
		private IntPtr readFuncPtr; // 0x48
		private IntPtr writeFuncPtr; // 0x50
		private IntPtr controlFuncPtr; // 0x58
		private IMonoBtlsBioMono backend; // 0x60
	
		// Nested types
		private enum ControlCommand // TypeDefIndex: 8586
		{
			Flush = 1
		}
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int BioReadFunc(IntPtr bio, IntPtr data, int dataLength, out int wantMore); // TypeDefIndex: 8587; 0x000000018043A200-0x000000018043A220
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate int BioWriteFunc(IntPtr bio, IntPtr data, int dataLength); // TypeDefIndex: 8588; 0x0000000180A72B30-0x0000000180A72B50
	
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate long BioControlFunc(IntPtr bio, ControlCommand command, long arg); // TypeDefIndex: 8589; 0x0000000180A72B30-0x0000000180A72B50
	
		// Constructors
		public MonoBtlsBioMono(IMonoBtlsBioMono backend); // 0x0000000181815CD0-0x0000000181816120
	
		// Methods
		private static extern IntPtr mono_btls_bio_mono_new(); // 0x00000001818161E0-0x0000000181816250
		private static extern void mono_btls_bio_mono_initialize(IntPtr handle, IntPtr instance, IntPtr readFunc, IntPtr writeFunc, IntPtr controlFunc); // 0x0000000181816120-0x00000001818161E0
		private long Control(ControlCommand command, long arg); // 0x0000000181815480-0x0000000181815520
		private int OnRead(IntPtr data, int dataLength, out int wantMore); // 0x00000001818157C0-0x0000000181815930
		[MonoPInvokeCallback(typeof(BioReadFunc))]
		private static int OnRead(IntPtr instance, IntPtr data, int dataLength, out int wantMore); // 0x0000000181815520-0x00000001818157C0
		private int OnWrite(IntPtr data, int dataLength); // 0x0000000181815930-0x0000000181815A70
		[MonoPInvokeCallback(typeof(BioWriteFunc))]
		private static int OnWrite(IntPtr instance, IntPtr data, int dataLength); // 0x0000000181815A70-0x0000000181815CD0
		[MonoPInvokeCallback(typeof(BioControlFunc))]
		private static long Control(IntPtr instance, ControlCommand command, long arg); // 0x00000001818152C0-0x0000000181815480
		protected override void Close(); // 0x0000000181815200-0x00000001818152C0
	}
}
