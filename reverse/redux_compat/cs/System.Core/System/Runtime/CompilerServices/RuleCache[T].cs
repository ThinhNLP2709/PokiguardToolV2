/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// Image 14: System.Core.dll - Assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e - Types 11955-12609

namespace System.Runtime.CompilerServices
{
	[DebuggerStepThrough]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class RuleCache<T> // TypeDefIndex: 12545
		where T : class
	{
		// Fields
		private T[] _rules;
		private readonly object _cacheLock;
	
		// Constructors
		internal RuleCache();
	
		// Methods
		internal T[] GetRules();
		internal void MoveRule(T rule, int i);
		internal void AddRule(T newRule);
		private static T[] AddOrInsert(T[] rules, T item);
	}
}
