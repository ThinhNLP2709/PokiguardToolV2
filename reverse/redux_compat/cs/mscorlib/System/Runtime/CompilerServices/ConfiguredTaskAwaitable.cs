/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Runtime.CompilerServices
{
	[IsReadOnly]
	public struct ConfiguredTaskAwaitable // TypeDefIndex: 3220
	{
		// Fields
		private readonly ConfiguredTaskAwaiter m_configuredTaskAwaiter; // 0x00
	
		// Nested types
		[IsReadOnly]
		public struct ConfiguredTaskAwaiter : ICriticalNotifyCompletion // TypeDefIndex: 3221
		{
			// Fields
			internal readonly Task m_task; // 0x00
			internal readonly bool m_continueOnCapturedContext; // 0x08
	
			// Properties
			public bool IsCompleted { get; } // 0x0000000180DE29E0-0x0000000180DE2A00 
	
			// Constructors
			internal ConfiguredTaskAwaiter(Task task, bool continueOnCapturedContext); // 0x0000000180DE29B0-0x0000000180DE29E0
	
			// Methods
			public void OnCompleted(Action continuation); // 0x000000018150AF50-0x000000018150B010
			public void UnsafeOnCompleted(Action continuation); // 0x000000018150B010-0x000000018150B0D0
			[StackTraceHidden]
			public void GetResult(); // 0x000000018150AF00-0x000000018150AF50
		}
	
		// Constructors
		internal ConfiguredTaskAwaitable(Task task, bool continueOnCapturedContext); // 0x0000000180DE26A0-0x0000000180DE26F0
	
		// Methods
		public ConfiguredTaskAwaiter GetAwaiter(); // 0x000000018092E600-0x000000018092E610
	}
}
