/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine.Events
{
	internal abstract class BaseInvokableCall // TypeDefIndex: 7922
	{
		// Constructors
		protected BaseInvokableCall(); // 0x00000001802E5CB0-0x00000001802E5CC0
		protected BaseInvokableCall(object target, MethodInfo function); // 0x0000000182200690-0x00000001822007D0
	
		// Methods
		public abstract void Invoke(object[] args);
		protected static void ThrowOnInvalidArg<T>(object arg);
		protected static bool AllowInvoke(Delegate @delegate); // 0x0000000182200600-0x0000000182200690
		public abstract bool Find(object targetObj, MethodInfo method);
	}
}
