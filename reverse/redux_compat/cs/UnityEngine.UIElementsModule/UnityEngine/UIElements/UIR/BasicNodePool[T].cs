/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements.UIR
{
	internal class BasicNodePool<T> : LinkedPool<UnityEngine.UIElements.UIR.BasicNode<T>> // TypeDefIndex: 5086
	{
		// Nested types
		[CompilerGenerated]
		private static class __O // TypeDefIndex: 5087
		{
			// Fields
			public static Func<BasicNode<T>> _0___Create;
			public static Action<BasicNode<T>> _1___Reset;
		}
	
		// Constructors
		public BasicNodePool();
	
		// Methods
		private static void Reset(BasicNode<T> node);
		private static BasicNode<T> Create();
	}
}
