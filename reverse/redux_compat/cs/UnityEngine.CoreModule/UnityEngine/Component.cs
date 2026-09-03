/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;
using UnityEngine.Scripting;
using UnityEngineInternal;

// Image 6: UnityEngine.CoreModule.dll - Assembly: UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 7341-8473

namespace UnityEngine
{
	[NativeClass("Unity::Component", PersistentTypeId = 2)]
	[NativeHeader("Runtime/Export/Scripting/Component.bindings.h")]
	[RequiredByNativeCode]
	public class Component : Object // TypeDefIndex: 7737
	{
		// Properties
		public Transform transform { [FreeFunction("GetTransform", HasExplicitThis = true, ThrowsException = true)] get; } // 0x00000001821E54A0-0x00000001821E5530 
		public GameObject gameObject { [FreeFunction("GetGameObject", HasExplicitThis = true)] get; } // 0x00000001821E53D0-0x00000001821E5460 
	
		// Constructors
		public Component(); // 0x00000001821E4560-0x00000001821E45B0
	
		// Methods
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponent(Type type); // 0x00000001821E4DD0-0x00000001821E4EE0
		[FreeFunction(HasExplicitThis = true, ThrowsException = true)]
		internal Component GetComponentFastPath(Type type); // 0x00000001821E4AF0-0x00000001821E4B90
		public T GetComponent<T>();
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public bool TryGetComponent(Type type, out Component component); // 0x00000001821E51A0-0x00000001821E5390
		public bool TryGetComponent<T>(out ref T component);
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInChildren(Type t, bool includeInactive); // 0x00000001821E4B90-0x00000001821E4CB0
		public T GetComponentInChildren<T>([DefaultValue("false")] bool includeInactive);
		[ExcludeFromDocs]
		public T GetComponentInChildren<T>();
		public T[] GetComponentsInChildren<T>(bool includeInactive);
		public void GetComponentsInChildren<T>(bool includeInactive, List<T> result);
		public T[] GetComponentsInChildren<T>();
		public void GetComponentsInChildren<T>(List<T> results);
		[TypeInferenceRule(TypeInferenceRules.TypeReferencedByFirstArgument)]
		public Component GetComponentInParent(Type t, bool includeInactive); // 0x00000001821E4CB0-0x00000001821E4DD0
		public T GetComponentInParent<T>([DefaultValue("false")] bool includeInactive);
		public T GetComponentInParent<T>();
		public T[] GetComponentsInParent<T>(bool includeInactive);
		public void GetComponentsInParent<T>(bool includeInactive, List<T> results);
		public T[] GetComponentsInParent<T>();
		[FreeFunction(HasExplicitThis = true, ThrowsException = true)]
		private void GetComponentsForListInternal(Type searchType, object resultList); // 0x00000001821E4F40-0x00000001821E4FB0
		public void GetComponents(Type type, List<Component> results); // 0x00000001821E4F40-0x00000001821E4FB0
		public void GetComponents<T>(List<T> results);
		public T[] GetComponents<T>();
		[FreeFunction("SendMessage", HasExplicitThis = true)]
		public void SendMessage(string methodName, object value, SendMessageOptions options); // 0x00000001821E5020-0x00000001821E51A0
		[FreeFunction("BroadcastMessage", HasExplicitThis = true)]
		public void BroadcastMessage(string methodName, [DefaultValue("null")] object parameter, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options); // 0x00000001821E4920-0x00000001821E4AA0
		private static IntPtr get_transform_Injected(IntPtr _unity_self); // 0x00000001821E5460-0x00000001821E54A0
		private static IntPtr get_gameObject_Injected(IntPtr _unity_self); // 0x00000001821E5390-0x00000001821E53D0
		private static IntPtr GetComponentFastPath_Injected(IntPtr _unity_self, Type type); // 0x00000001821E4AA0-0x00000001821E4AF0
		private static void GetComponentsForListInternal_Injected(IntPtr _unity_self, Type searchType, object resultList); // 0x00000001821E4EE0-0x00000001821E4F40
		private static void SendMessage_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName, object value, SendMessageOptions options); // 0x00000001821E4FB0-0x00000001821E5020
		private static void BroadcastMessage_Injected(IntPtr _unity_self, ref ManagedSpanWrapper methodName, [DefaultValue("null")] object parameter, [DefaultValue("SendMessageOptions.RequireReceiver")] SendMessageOptions options); // 0x00000001821E48B0-0x00000001821E4920
	}
}
