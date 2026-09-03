/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 21: Unity.ResourceManager.dll - Assembly: Unity.ResourceManager, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13663-13805

namespace UnityEngine.ResourceManagement.Util
{
	[ExecuteInEditMode]
	public abstract class ComponentSingleton<T> : MonoBehaviour // TypeDefIndex: 13703
		where T : ComponentSingleton<T>
	{
		// Fields
		private static T s_Instance;
	
		// Properties
		public static bool Exists { get; }
		public static T Instance { get; }
	
		// Constructors
		protected ComponentSingleton();
	
		// Methods
		private static T FindInstance();
		protected virtual string GetGameObjectName();
		private static T CreateNewSingleton();
		private void Awake();
		public static void DestroySingleton();
	}
}
