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
	internal class CubicBezierDecoder : ABSPathDecoder // TypeDefIndex: 13490
	{
		// Fields
		private static readonly ControlPoint[] _PartialControlPs; // 0x00
		private static readonly Vector3[] _PartialWps; // 0x08
	
		// Properties
		internal override int minInputWaypoints { get; } // 0x000000018071E4A0-0x000000018071E4B0 
	
		// Constructors
		public CubicBezierDecoder(); // 0x00000001802E5CB0-0x00000001802E5CC0
		static CubicBezierDecoder(); // 0x000000018071E3E0-0x000000018071E4A0
	
		// Methods
		internal override void FinalizePath(Path p, Vector3[] wps, bool isClosedPath); // 0x000000018071D3E0-0x000000018071DA30
		internal override Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints); // 0x000000018071DA30-0x000000018071DC90
		internal void SetTimeToLengthTables(Path p, int subdivisions); // 0x000000018071DC90-0x000000018071DF90
		internal void SetWaypointsLengths(Path p, int subdivisions); // 0x000000018071DF90-0x000000018071E3E0
	}
}
