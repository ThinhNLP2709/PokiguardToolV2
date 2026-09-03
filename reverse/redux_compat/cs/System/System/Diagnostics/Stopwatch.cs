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

namespace System.Diagnostics
{
	public class Stopwatch // TypeDefIndex: 8748
	{
		// Fields
		public static readonly long Frequency; // 0x00
		public static readonly bool IsHighResolution; // 0x08
		private long elapsed; // 0x10
		private long started; // 0x18
		private bool is_running; // 0x20
	
		// Properties
		public TimeSpan Elapsed { get; } // 0x0000000181B853E0-0x0000000181B85570 
		public long ElapsedMilliseconds { get; } // 0x0000000181B850A0-0x0000000181B85370 
		public long ElapsedTicks { get; } // 0x0000000181B85370-0x0000000181B853E0 
	
		// Constructors
		public Stopwatch(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static Stopwatch(); // 0x0000000181B85050-0x0000000181B850A0
	
		// Methods
		public static long GetTimestamp(); // 0x00000001816929E0-0x00000001816929F0
		public static Stopwatch StartNew(); // 0x0000000181B84ED0-0x0000000181B84F70
		public void Start(); // 0x0000000181B84F70-0x0000000181B84FD0
		public void Stop(); // 0x0000000181B84FD0-0x0000000181B85050
		public void Restart(); // 0x0000000181B84E70-0x0000000181B84ED0
	}
}
