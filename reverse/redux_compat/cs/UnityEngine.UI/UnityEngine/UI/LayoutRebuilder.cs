/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Pool;

// Image 17: UnityEngine.UI.dll - Assembly: UnityEngine.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13008-13214

namespace UnityEngine.UI
{
	public class LayoutRebuilder : ICanvasElement // TypeDefIndex: 13084
	{
		// Fields
		private RectTransform m_ToRebuild; // 0x10
		private int m_CachedHashFromTransform; // 0x18
		private static readonly ObjectPool<LayoutRebuilder> s_Rebuilders; // 0x00
	
		// Properties
		public Transform transform { get; } // 0x0000000180377550-0x0000000180377560 
	
		// Nested types
		[Serializable]
		[CompilerGenerated]
		private sealed class __c // TypeDefIndex: 13085
		{
			// Fields
			public static readonly __c __9; // 0x00
			public static Predicate<Component> __9__10_0; // 0x08
			public static UnityAction<Component> __9__12_0; // 0x10
			public static UnityAction<Component> __9__12_1; // 0x18
			public static UnityAction<Component> __9__12_2; // 0x20
			public static UnityAction<Component> __9__12_3; // 0x28
	
			// Constructors
			static __c(); // 0x0000000182597570-0x00000001825975E0
			public __c(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
			// Methods
			internal LayoutRebuilder _.cctor_b__5_0(); // 0x0000000182597470-0x00000001825974C0
			internal void _.cctor_b__5_1(LayoutRebuilder x); // 0x00000001825974C0-0x0000000182597500
			internal bool _StripDisabledBehavioursFromList_b__10_0(Component e); // 0x0000000182597130-0x00000001825971D0
			internal void _Rebuild_b__12_0(Component e); // 0x0000000182596F70-0x0000000182596FE0
			internal void _Rebuild_b__12_1(Component e); // 0x0000000182596FE0-0x0000000182597050
			internal void _Rebuild_b__12_2(Component e); // 0x0000000182597050-0x00000001825970C0
			internal void _Rebuild_b__12_3(Component e); // 0x00000001825970C0-0x0000000182597130
		}
	
		// Constructors
		static LayoutRebuilder(); // 0x0000000182594510-0x0000000182594700
		public LayoutRebuilder(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		private void Initialize(RectTransform controller); // 0x00000001825931C0-0x0000000182593210
		private void Clear(); // 0x0000000182593040-0x0000000182593070
		private static void ReapplyDrivenProperties(RectTransform driven); // 0x0000000182593F30-0x0000000182593F80
		public bool IsDestroyed(); // 0x0000000182593210-0x0000000182593260
		private static void StripDisabledBehavioursFromList(List<Component> components); // 0x0000000182594220-0x0000000182594310
		public static void ForceRebuildLayoutImmediate(RectTransform layoutRoot); // 0x00000001825930D0-0x00000001825931C0
		public void Rebuild(CanvasUpdate executing); // 0x0000000182593F80-0x0000000182594220
		private void PerformLayoutControl(RectTransform rect, UnityAction<Component> action); // 0x0000000182593C00-0x0000000182593F30
		private void PerformLayoutCalculation(RectTransform rect, UnityAction<Component> action); // 0x00000001825939E0-0x0000000182593C00
		public static void MarkLayoutForRebuild(RectTransform rect); // 0x00000001825932E0-0x0000000182593890
		private static bool ValidController(RectTransform layoutRoot, List<Component> comps); // 0x0000000182594370-0x0000000182594510
		private static void MarkLayoutRootForRebuild(RectTransform controller); // 0x0000000182593890-0x00000001825939E0
		public void LayoutComplete(); // 0x0000000182593260-0x00000001825932E0
		public void GraphicUpdateComplete(); // 0x00000001802E76C0-0x00000001802E76D0
		public override int GetHashCode(); // 0x0000000180B23260-0x0000000180B23270
		public override bool Equals(object obj); // 0x0000000182593070-0x00000001825930D0
		public override string ToString(); // 0x0000000182594310-0x0000000182594370
	}
}
