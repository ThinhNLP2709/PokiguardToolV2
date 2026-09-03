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

namespace UnityEngine.UIElements
{
	[EventCategory(EventCategory.Default)]
	public abstract class EventBase<T> : EventBase // TypeDefIndex: 3973
		where T : EventBase<T>, new()
	{
		// Fields
		private static readonly long s_TypeId;
		private static readonly ObjectPool<T> s_Pool;
		private int m_RefCount;
		internal static readonly EventCategory EventCategory;
		internal static readonly TypeData k_TypeData;
	
		// Properties
		public override long eventTypeId { get; }
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 3974
		{
			// Fields
			public static readonly __c<T> __9;
	
			// Constructors
			static __c();
			public __c();
	
			// Methods
			internal T _.cctor_b__18_0();
		}
	
		// Constructors
		protected EventBase();
		static EventBase();
	
		// Methods
		protected internal static void SetCreateFunction(Func<T> createMethod);
		public static long TypeId();
		protected override void Init();
		public static T GetPooled();
		internal static T GetPooled(EventBase e);
		private static void ReleasePooled(T evt);
		internal override void Acquire();
		public sealed override void Dispose();
		internal override void InvokeCallback(Delegate userCallback);
		internal override void InvokeCallback<TArg>(Delegate userCallback, [IsReadOnly] in ref TArg arg);
	}
}
