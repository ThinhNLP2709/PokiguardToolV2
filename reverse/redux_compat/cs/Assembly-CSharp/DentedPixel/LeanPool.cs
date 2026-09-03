/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

namespace DentedPixel
{
	public class LeanPool // TypeDefIndex: 2013
	{
		// Fields
		private GameObject[] array; // 0x10
		private Queue<GameObject> oldestItems; // 0x18
		private int retrieveIndex; // 0x20
	
		// Constructors
		public LeanPool(); // 0x0000000180670F30-0x0000000180670F40
	
		// Methods
		public GameObject[] init(GameObject prefab, int count, Transform parent = null, bool retrieveOldestItems = true /* Metadata: 0x0064E12F */); // 0x0000000180670FB0-0x0000000180671140
		public void init(GameObject[] array, bool retrieveOldestItems = true /* Metadata: 0x0064E130 */); // 0x0000000180671140-0x00000001806711E0
		public void giveup(GameObject go); // 0x0000000180670F40-0x0000000180670FB0
		public GameObject retrieve(); // 0x00000001806711E0-0x0000000180671340
	}
}
