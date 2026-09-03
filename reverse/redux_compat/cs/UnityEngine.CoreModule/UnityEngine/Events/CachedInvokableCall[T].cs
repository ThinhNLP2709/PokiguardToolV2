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
	internal class CachedInvokableCall<T> : InvokableCall<T> // TypeDefIndex: 7928
	{
		// Fields
		private readonly T m_Arg1;
	
		// Constructors
		public CachedInvokableCall(UnityEngine.Object target, MethodInfo theFunction, T argument);
	
		// Methods
		public override void Invoke(object[] args);
		public override void Invoke(T arg0);
	}
}
