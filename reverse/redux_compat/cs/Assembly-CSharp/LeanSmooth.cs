/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2026

public class LeanSmooth // TypeDefIndex: 289
{
	// Constructors
	public LeanSmooth(); // 0x00000001802E5CB0-0x00000001802E5CC0

	// Methods
	public static float damp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C097 */, float deltaTime = -1f /* Metadata: 0x0064C09B */); // 0x00000001806D1870-0x00000001806D1A00
	public static Vector3 damp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C09F */, float deltaTime = -1f /* Metadata: 0x0064C0A3 */); // 0x00000001806D15D0-0x00000001806D1700
	public static Color damp(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C0A7 */, float deltaTime = -1f /* Metadata: 0x0064C0AB */); // 0x00000001806D1700-0x00000001806D1870
	public static float spring(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C0AF */, float deltaTime = -1f /* Metadata: 0x0064C0B3 */, float friction = 2f /* Metadata: 0x0064C0B7 */, float accelRate = 0.5f /* Metadata: 0x0064C0BB */); // 0x00000001806D1C90-0x00000001806D1D70
	public static Vector3 spring(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C0BF */, float deltaTime = -1f /* Metadata: 0x0064C0C3 */, float friction = 2f /* Metadata: 0x0064C0C7 */, float accelRate = 0.5f /* Metadata: 0x0064C0CB */); // 0x00000001806D1D70-0x00000001806D1EF0
	public static Color spring(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C0CF */, float deltaTime = -1f /* Metadata: 0x0064C0D3 */, float friction = 2f /* Metadata: 0x0064C0D7 */, float accelRate = 0.5f /* Metadata: 0x0064C0DB */); // 0x00000001806D1EF0-0x00000001806D20C0
	public static float linear(float current, float target, float moveSpeed, float deltaTime = -1f /* Metadata: 0x0064C0DF */); // 0x00000001806D1AE0-0x00000001806D1B80
	public static Vector3 linear(Vector3 current, Vector3 target, float moveSpeed, float deltaTime = -1f /* Metadata: 0x0064C0E3 */); // 0x00000001806D1A00-0x00000001806D1AE0
	public static Color linear(Color current, Color target, float moveSpeed); // 0x00000001806D1B80-0x00000001806D1C90
	public static float bounceOut(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C0E7 */, float deltaTime = -1f /* Metadata: 0x0064C0EB */, float friction = 2f /* Metadata: 0x0064C0EF */, float accelRate = 0.5f /* Metadata: 0x0064C0F3 */, float hitDamping = 0.9f /* Metadata: 0x0064C0F7 */); // 0x00000001806D1310-0x00000001806D1430
	public static Vector3 bounceOut(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C0FB */, float deltaTime = -1f /* Metadata: 0x0064C0FF */, float friction = 2f /* Metadata: 0x0064C103 */, float accelRate = 0.5f /* Metadata: 0x0064C107 */, float hitDamping = 0.9f /* Metadata: 0x0064C10B */); // 0x00000001806D1430-0x00000001806D15D0
	public static Color bounceOut(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x0064C10F */, float deltaTime = -1f /* Metadata: 0x0064C113 */, float friction = 2f /* Metadata: 0x0064C117 */, float accelRate = 0.5f /* Metadata: 0x0064C11B */, float hitDamping = 0.9f /* Metadata: 0x0064C11F */); // 0x00000001806D1110-0x00000001806D1310
}

