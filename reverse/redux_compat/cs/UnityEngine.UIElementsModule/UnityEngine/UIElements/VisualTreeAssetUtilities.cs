/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Unity.Properties;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.UIElements;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	[VisibleToOtherModules(new string[2] {"UnityEditor.UIBuilderModule", "UnityEditor.UIToolkitAuthoringModule" })]
	internal static class VisualTreeAssetUtilities // TypeDefIndex: 4926
	{
		// Nested types
		[CompilerGenerated]
		private sealed class _EnumerateEnclosingNamespaces_d__0 : IEnumerable<string>, IEnumerator<string> // TypeDefIndex: 4927
		{
			// Fields
			private int __1__state; // 0x10
			private string __2__current; // 0x18
			private int __l__initialThreadId; // 0x20
			private string fullTypeName; // 0x28
			public string __3__fullTypeName; // 0x30
			private int _lastDot_5__2; // 0x38
	
			// Properties
			string IEnumerator<System.String>.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
			object IEnumerator.Current { [DebuggerHidden] get; } // 0x00000001802F8EC0-0x00000001802F8ED0 
	
			// Constructors
			[DebuggerHidden]
			public _EnumerateEnclosingNamespaces_d__0(int __1__state); // 0x0000000180A5D530-0x0000000180A5D560
	
			// Methods
			[DebuggerHidden]
			void IDisposable.Dispose(); // 0x00000001802F9320-0x00000001802F9330
			private bool MoveNext(); // 0x00000001823D1510-0x00000001823D15E0
			[DebuggerHidden]
			void IEnumerator.Reset(); // 0x00000001823D1680-0x00000001823D16C0
			[DebuggerHidden]
			IEnumerator<string> IEnumerable<string>.GetEnumerator(); // 0x00000001823D15E0-0x00000001823D1680
			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator(); // 0x00000001823D15E0-0x00000001823D1680
		}
	
		// Methods
		[IteratorStateMachine(typeof(_EnumerateEnclosingNamespaces_d__0))]
		public static IEnumerable<string> EnumerateEnclosingNamespaces(string fullTypeName); // 0x00000001823E5AD0-0x00000001823E5B50
	
		// Extension methods
		public static UxmlNamespaceDefinition FindUxmlNamespaceDefinitionForTypeName(this VisualTreeAsset vta, UxmlAsset asset, string fullTypeName); // 0x00000001823E5B50-0x00000001823E60D0
	}
}
