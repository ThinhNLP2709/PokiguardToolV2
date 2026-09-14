/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2936

namespace DentedPixel
{
	public class LeanPool // TypeDefIndex: 2915
	{
		// Fields
		private GameObject[] array; // 0x10
		private Queue<GameObject> oldestItems; // 0x18
		private int retrieveIndex; // 0x20
	
		// Constructors
		public LeanPool(); // 0x0000000180D44ED0-0x0000000180D44EE0
	
		// Methods
		public GameObject[] init(GameObject prefab, int count, Transform parent = null, bool retrieveOldestItems = true /* Metadata: 0x005F2273 */); // 0x0000000180D449B0-0x0000000180D44CA0
		public void giveup(GameObject go); // 0x0000000180D44CA0-0x0000000180D44D60
		public GameObject retrieve(); // 0x0000000180D44D60-0x0000000180D44ED0
	}
}
