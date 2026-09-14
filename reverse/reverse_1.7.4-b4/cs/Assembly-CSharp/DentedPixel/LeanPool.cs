/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

namespace DentedPixel
{
	public class LeanPool // TypeDefIndex: 2922
	{
		// Fields
		private GameObject[] array; // 0x10
		private Queue<GameObject> oldestItems; // 0x18
		private int retrieveIndex; // 0x20
	
		// Constructors
		public LeanPool(); // 0x0000000180D52C40-0x0000000180D52C50
	
		// Methods
		public GameObject[] init(GameObject prefab, int count, Transform parent = null, bool retrieveOldestItems = true /* Metadata: 0x005F368A */); // 0x0000000180D52720-0x0000000180D52A10
		public void giveup(GameObject go); // 0x0000000180D52A10-0x0000000180D52AD0
		public GameObject retrieve(); // 0x0000000180D52AD0-0x0000000180D52C40
	}
}
