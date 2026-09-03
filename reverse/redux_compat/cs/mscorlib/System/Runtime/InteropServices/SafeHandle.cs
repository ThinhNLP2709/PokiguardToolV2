/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.InteropServices
{
	public abstract class SafeHandle : CriticalFinalizerObject, IDisposable // TypeDefIndex: 3152
	{
		// Fields
		protected IntPtr handle; // 0x10
		private int _state; // 0x18
		private bool _ownsHandle; // 0x1C
		private bool _fullyInitialized; // 0x1D
		private const int RefCount_Mask = 2147483644; // Metadata: 0x0064EC05
		private const int RefCount_One = 4; // Metadata: 0x0064EC0A
	
		// Properties
		public bool IsClosed { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] get; } // 0x000000018151AA60-0x000000018151AA70 
		public abstract bool IsInvalid { [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)] get; }
	
		// Constructors
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected SafeHandle(IntPtr invalidHandleValue, bool ownsHandle); // 0x000000018151A9D0-0x000000018151AA60
	
		// Methods
		~SafeHandle(); // 0x000000018151A7E0-0x000000018151A860
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		protected void SetHandle(IntPtr handle); // 0x0000000180719060-0x0000000180719070
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public IntPtr DangerousGetHandle(); // 0x0000000180377550-0x0000000180377560
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void Close(); // 0x00000001815181C0-0x00000001815181E0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void Dispose(); // 0x00000001815181C0-0x00000001815181E0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		protected virtual void Dispose(bool disposing); // 0x000000018151A720-0x000000018151A7E0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		protected abstract bool ReleaseHandle();
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void SetHandleAsInvalid(); // 0x000000018151A920-0x000000018151A9D0
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public void DangerousAddRef(ref bool success); // 0x000000018151A5E0-0x000000018151A660
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void DangerousRelease(); // 0x000000018151A710-0x000000018151A720
		private void InternalDispose(); // 0x000000018151A860-0x000000018151A900
		private void InternalFinalize(); // 0x000000018151A900-0x000000018151A920
		private void DangerousReleaseInternal(bool dispose); // 0x000000018151A660-0x000000018151A710
	}
}
