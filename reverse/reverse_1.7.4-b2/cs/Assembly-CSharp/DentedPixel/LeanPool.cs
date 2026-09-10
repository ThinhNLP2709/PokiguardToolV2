/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2490

namespace DentedPixel
{
	public class LeanPool // TypeDefIndex: 2469
	{
		// Fields
		private GameObject[] array; // 0x10
		private Queue<GameObject> oldestItems; // 0x18
		private int retrieveIndex; // 0x20
	
		// Constructors
		public LeanPool(); // 0x000000018080F920-0x000000018080F930
	
		// Methods
		public GameObject[] init(GameObject prefab, int count, Transform parent = null, bool retrieveOldestItems = true /* Metadata: 0x0068F5F9 */); // 0x000000018080F9A0-0x000000018080FB30
		public void init(GameObject[] array, bool retrieveOldestItems = true /* Metadata: 0x0068F5FA */); // 0x000000018080FB30-0x000000018080FBD0
		public void giveup(GameObject go); // 0x000000018080F930-0x000000018080F9A0
		public GameObject retrieve(); // 0x000000018080FBD0-0x000000018080FD30
	}
}
