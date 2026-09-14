/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

public static class UISortingLift // TypeDefIndex: 1412
{
	// Fields
	private static readonly Dictionary<Canvas, Origin> _origins; // 0x00

	// Nested types
	private class Origin // TypeDefIndex: 1413
	{
		// Fields
		public bool overrideSorting; // 0x10
		public int order; // 0x14
		public bool raycasterAdded; // 0x18

		// Constructors
		public Origin(); // 0x000000018028A320-0x000000018028A330
	}

	// Constructors
	static UISortingLift(); // 0x000000018079ADD0-0x000000018079AEB0

	// Methods
	public static void Apply(GameObject panel); // 0x0000000180799C90-0x000000018079A310
	public static void Restore(GameObject panel); // 0x000000018079A310-0x000000018079A600
	private static int BlockingOrder(Canvas root, Transform panel); // 0x000000018079A600-0x000000018079A900
	private static Origin Remember(Canvas c); // 0x000000018079A900-0x000000018079AA50
	private static void Prune(); // 0x000000018079AA50-0x000000018079ADD0
}

