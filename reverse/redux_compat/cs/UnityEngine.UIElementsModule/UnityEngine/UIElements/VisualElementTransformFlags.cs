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
	[Flags]
	internal enum VisualElementTransformFlags // TypeDefIndex: 4963
	{
		WorldTransformDirty = 1,
		WorldTransformInverseDirty = 2,
		BoundingBoxDirty = 4,
		WorldBoundingBoxDirty = 8,
		BoundingBoxWithoutNestedDirty = 16,
		Needs3DBounds = 32,
		LocalBounds3DDirty = 64,
		LocalBoundsWithoutNested3DDirty = 128,
		Init = 223,
		BoundingBoxDirtiedSinceLastLayoutPass = 256,
		DisableClipping = 512,
		HierarchyDisplayed = 1024,
		LayoutManual = 2048,
		PickingIgnore = 4096,
		UsesContainsPoint = 8192
	}
}
