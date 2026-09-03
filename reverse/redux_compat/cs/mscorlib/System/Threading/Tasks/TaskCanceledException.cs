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

namespace System.Threading.Tasks
{
	[Serializable]
	public class TaskCanceledException : OperationCanceledException // TypeDefIndex: 2625
	{
		// Fields
		[NonSerialized]
		private readonly Task _canceledTask; // 0x98
	
		// Constructors
		public TaskCanceledException(); // 0x0000000181684A40-0x0000000181684A80
		public TaskCanceledException(Task task); // 0x00000001816849A0-0x0000000181684A40
		protected TaskCanceledException(SerializationInfo info, StreamingContext context); // 0x000000018148BDC0-0x000000018148BDE0
	}
}
