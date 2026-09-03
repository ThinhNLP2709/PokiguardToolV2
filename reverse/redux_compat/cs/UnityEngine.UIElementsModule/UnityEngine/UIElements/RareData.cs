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
using UnityEngine.UIElements.Unmanaged;

// Image 2: UnityEngine.UIElementsModule.dll - Assembly: UnityEngine.UIElementsModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 3783-5298

namespace UnityEngine.UIElements
{
	internal struct RareData : IStyleDataGroup<RareData>, IEquatable<RareData> // TypeDefIndex: 4624
	{
		// Fields
		public Color unityBackgroundImageTintColor; // 0x00
		public UnmanagedRefCountedList<UnmanagedFilterFunction> backdropFilter; // 0x10
		public Cursor cursor; // 0x18
		public UnmanagedRefCountedList<UnmanagedFilterFunction> filter; // 0x30
		public EntityId unityAnimationClip; // 0x38
		public AnimationPlayState animationPlayState; // 0x40
		public TextOverflow textOverflow; // 0x44
		public OverflowClipBox unityOverflowClipBox; // 0x48
		public int unitySliceBottom; // 0x4C
		public int unitySliceLeft; // 0x50
		public int unitySliceRight; // 0x54
		public float unitySliceScale; // 0x58
		public int unitySliceTop; // 0x5C
		public SliceType unitySliceType; // 0x60
		public TextOverflowPosition unityTextOverflowPosition; // 0x64
	
		// Methods
		public RareData GetDefault(); // 0x0000000182545F10-0x0000000182545F40
		public RareData Copy(); // 0x0000000182545C60-0x0000000182545D40
		public void CopyFrom(ref RareData other); // 0x0000000182545BA0-0x0000000182545C60
		public void Dispose(); // 0x0000000182545D40-0x0000000182545D90
		public static bool operator ==(RareData lhs, RareData rhs); // 0x00000001825460E0-0x00000001825464E0
		public bool Equals(RareData other); // 0x0000000182545E70-0x0000000182545F10
		public override bool Equals(object obj); // 0x0000000182545D90-0x0000000182545E70
		public override int GetHashCode(); // 0x0000000182545F40-0x00000001825460E0
	}
}
