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
	internal class LinearDecoder : ABSPathDecoder // TypeDefIndex: 13494
	{
		// Properties
		internal override int minInputWaypoints { get; } // 0x0000000180472790-0x00000001804727A0 
	
		// Constructors
		public LinearDecoder(); // 0x00000001802E5CB0-0x00000001802E5CC0
	
		// Methods
		internal override void FinalizePath(Path p, Vector3[] wps, bool isClosedPath); // 0x0000000180721050-0x00000001807210C0
		internal override Vector3 GetPoint(float perc, Vector3[] wps, Path p, ControlPoint[] controlPoints); // 0x00000001807210C0-0x00000001807212B0
		internal void SetTimeToLengthTables(Path p, int subdivisions); // 0x00000001807212B0-0x00000001807215A0
		internal void SetWaypointsLengths(Path p, int subdivisions); // 0x00000001802E76C0-0x00000001802E76D0
	}
}
