/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

// Image 1: mscorlib.dll - Assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089 - Types 2027-3782

namespace System.Threading.Tasks
{
	internal class TaskExceptionHolder // TypeDefIndex: 2673
	{
		// Fields
		private static readonly bool s_failFastOnUnobservedException; // 0x00
		private readonly Task m_task; // 0x10
		private LowLevelListWithIList<ExceptionDispatchInfo> m_faultExceptions; // 0x18
		private ExceptionDispatchInfo m_cancellationException; // 0x20
		private bool m_isHandled; // 0x28
	
		// Properties
		internal bool ContainsFaultList { get; } // 0x00000001816857A0-0x00000001816857C0 
	
		// Constructors
		internal TaskExceptionHolder(Task task); // 0x00000001803855F0-0x0000000180385630
		static TaskExceptionHolder(); // 0x0000000181685760-0x00000001816857A0
	
		// Methods
		private static bool ShouldFailFastOnUnobservedException(); // 0x00000001802E7840-0x00000001802E7850
		~TaskExceptionHolder(); // 0x00000001816852A0-0x00000001816854B0
		internal void Add(object exceptionObject, bool representsCancellation); // 0x0000000181684FB0-0x00000001816850C0
		private void SetCancellationException(object exceptionObject); // 0x0000000181685660-0x0000000181685760
		private void AddFaultException(object exceptionObject); // 0x0000000181684B80-0x0000000181684FB0
		private void MarkAsUnhandled(); // 0x00000001816855F0-0x0000000181685660
		internal void MarkAsHandled(bool calledFromFinalizer); // 0x0000000181685570-0x00000001816855F0
		internal AggregateException CreateExceptionObject(bool calledFromFinalizer, Exception includeThisException); // 0x00000001816850C0-0x00000001816852A0
		internal ReadOnlyCollection<ExceptionDispatchInfo> GetExceptionDispatchInfos(); // 0x00000001816854B0-0x0000000181685570
		internal ExceptionDispatchInfo GetCancellationExceptionDispatchInfo(); // 0x00000001802F8630-0x00000001802F8640
	}
}
