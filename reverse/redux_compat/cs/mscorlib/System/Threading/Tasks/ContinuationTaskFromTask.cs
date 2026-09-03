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

namespace System.Threading.Tasks
{
	internal sealed class ContinuationTaskFromTask : Task // TypeDefIndex: 2663
	{
		// Fields
		private Task m_antecedent; // 0x50
	
		// Constructors
		public ContinuationTaskFromTask(Task antecedent, Delegate action, object state, TaskCreationOptions creationOptions, InternalTaskOptions internalOptions); // 0x000000018167DD30-0x000000018167DE60
	
		// Methods
		internal override void InnerInvoke(); // 0x000000018167DC20-0x000000018167DD30
	}
}
