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

namespace System.Threading
{
	internal sealed class InternalThread : CriticalFinalizerObject // TypeDefIndex: 2613
	{
		// Fields
		private int lock_thread_id; // 0x10
		private IntPtr handle; // 0x18
		private IntPtr native_handle; // 0x20
		private IntPtr name_chars; // 0x28
		private int name_free; // 0x30
		private int name_length; // 0x34
		private ThreadState state; // 0x38
		private object abort_exc; // 0x40
		private int abort_state_handle; // 0x48
		internal long thread_id; // 0x50
		private IntPtr debugger_thread; // 0x58
		private UIntPtr static_data; // 0x60
		private IntPtr runtime_thread_info; // 0x68
		private object current_appcontext; // 0x70
		private object root_domain_thread; // 0x78
		internal byte[] _serialized_principal; // 0x80
		internal int _serialized_principal_version; // 0x88
		private IntPtr appdomain_refs; // 0x90
		private int interruption_requested; // 0x98
		private IntPtr longlived; // 0xA0
		internal bool threadpool_thread; // 0xA8
		private bool thread_interrupt_requested; // 0xA9
		internal int stack_size; // 0xAC
		internal byte apartment_state; // 0xB0
		internal int critical_region_level; // 0xB4
		internal int managed_id; // 0xB8
		private int small_id; // 0xBC
		private IntPtr manage_callback; // 0xC0
		private IntPtr flags; // 0xC8
		private IntPtr thread_pinning_ref; // 0xD0
		private IntPtr abort_protected_block_count; // 0xD8
		private int priority; // 0xE0
		private IntPtr owned_mutex; // 0xE8
		private IntPtr suspended_event; // 0xF0
		private int self_suspended; // 0xF8
		private IntPtr thread_state; // 0x100
		private IntPtr netcore0; // 0x108
		private IntPtr netcore1; // 0x110
		private IntPtr netcore2; // 0x118
		private IntPtr last; // 0x120
	
		// Constructors
		public InternalThread(); // 0x0000000181681930-0x0000000181681950
	
		// Methods
		private void Thread_free_internal(); // 0x0000000181681920-0x0000000181681930
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		~InternalThread(); // 0x00000001816818B0-0x0000000181681920
	}
}
