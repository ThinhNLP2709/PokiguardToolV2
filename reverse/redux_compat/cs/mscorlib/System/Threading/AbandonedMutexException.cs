/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading
{
	[Serializable]
	public class AbandonedMutexException : SystemException // TypeDefIndex: 2523
	{
		// Fields
		private int _mutexIndex; // 0x90
		private Mutex _mutex; // 0x98
	
		// Constructors
		public AbandonedMutexException(); // 0x0000000181663A50-0x0000000181663AA0
		public AbandonedMutexException(int location, WaitHandle handle); // 0x0000000181663AA0-0x0000000181663B60
		protected AbandonedMutexException(SerializationInfo info, StreamingContext context); // 0x0000000181663B60-0x0000000181663B90
	
		// Methods
		private void SetupException(int location, WaitHandle handle); // 0x00000001816639C0-0x0000000181663A50
	}
}
