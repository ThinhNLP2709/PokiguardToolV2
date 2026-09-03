/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnityEngine;

// Image 19: DOTween.dll - Assembly: DOTween, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null - Types 13338-13539

namespace DG.Tweening.Plugins.Core.PathCore
{
	internal class CatmullRomDecoder : ABSPathDecoder // TypeDefIndex: 13493
	{
		// Fields
		private static readonly ControlPoint[] _PartialControlPs; // 0x00
		private static readonly Vector3[] _PartialWps; // 0x08
	
		// Properties
		internal override int minInputWaypoints { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		public CatmullRomDecoder(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static CatmullRomDecoder(); // 0x000000018071C0C0-0x000000018071C180
	
		// Methods
		internal override void FinalizePath(Path p, Vector3[] wps, bool isClosedPath); // 0x000000018071B170-0x000000018071B420
		internal override Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints); // 0x000000018071B420-0x000000018071B890
		internal void SetTimeToLengthTables(Path p, int subdivisions); // 0x000000018071B890-0x000000018071BB90
		internal void SetWaypointsLengths(Path p, int subdivisions); // 0x000000018071BB90-0x000000018071C0C0
	}
}
