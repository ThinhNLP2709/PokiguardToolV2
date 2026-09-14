/*
 * Generated code file by Il2CppInspector - http://www.djkaty.com - https://github.com/djkaty
 */

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

// Image 0: Assembly-CSharp.dll - Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null - Types 0-2943

public class LeanSmooth // TypeDefIndex: 312
{
	// Methods
	public static float damp(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EED9F */, float deltaTime = -1f /* Metadata: 0x005EEDA3 */); // 0x00000001802DB630-0x00000001802DB800
	public static Vector3 damp(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EEDA7 */, float deltaTime = -1f /* Metadata: 0x005EEDAB */); // 0x00000001802DB800-0x00000001802DB930
	public static Color damp(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EEDAF */, float deltaTime = -1f /* Metadata: 0x005EEDB3 */); // 0x00000001802DB930-0x00000001802DBAA0
	public static float spring(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EEDB7 */, float deltaTime = -1f /* Metadata: 0x005EEDBB */, float friction = 2f /* Metadata: 0x005EEDBF */, float accelRate = 0.5f /* Metadata: 0x005EEDC3 */); // 0x00000001802DBAA0-0x00000001802DBBC0
	public static Vector3 spring(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EEDC7 */, float deltaTime = -1f /* Metadata: 0x005EEDCB */, float friction = 2f /* Metadata: 0x005EEDCF */, float accelRate = 0.5f /* Metadata: 0x005EEDD3 */); // 0x00000001802DBBC0-0x00000001802DBD40
	public static Color spring(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EEDD7 */, float deltaTime = -1f /* Metadata: 0x005EEDDB */, float friction = 2f /* Metadata: 0x005EEDDF */, float accelRate = 0.5f /* Metadata: 0x005EEDE3 */); // 0x00000001802DBD40-0x00000001802DBF10
	public static float linear(float current, float target, float moveSpeed, float deltaTime = -1f /* Metadata: 0x005EEDE7 */); // 0x00000001802DBF10-0x00000001802DBFE0
	public static Vector3 linear(Vector3 current, Vector3 target, float moveSpeed, float deltaTime = -1f /* Metadata: 0x005EEDEB */); // 0x00000001802DBFE0-0x00000001802DC0C0
	public static Color linear(Color current, Color target, float moveSpeed); // 0x00000001802DC0C0-0x00000001802DC1D0
	public static float bounceOut(float current, float target, ref float currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EEDEF */, float deltaTime = -1f /* Metadata: 0x005EEDF3 */, float friction = 2f /* Metadata: 0x005EEDF7 */, float accelRate = 0.5f /* Metadata: 0x005EEDFB */, float hitDamping = 0.9f /* Metadata: 0x005EEDFF */); // 0x00000001802DC1D0-0x00000001802DC320
	public static Vector3 bounceOut(Vector3 current, Vector3 target, ref Vector3 currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EEE03 */, float deltaTime = -1f /* Metadata: 0x005EEE07 */, float friction = 2f /* Metadata: 0x005EEE0B */, float accelRate = 0.5f /* Metadata: 0x005EEE0F */, float hitDamping = 0.9f /* Metadata: 0x005EEE13 */); // 0x00000001802DC320-0x00000001802DC4C0
	public static Color bounceOut(Color current, Color target, ref Color currentVelocity, float smoothTime, float maxSpeed = -1f /* Metadata: 0x005EEE17 */, float deltaTime = -1f /* Metadata: 0x005EEE1B */, float friction = 2f /* Metadata: 0x005EEE1F */, float accelRate = 0.5f /* Metadata: 0x005EEE23 */, float hitDamping = 0.9f /* Metadata: 0x005EEE27 */); // 0x00000001802DC4C0-0x00000001802DC6C0
}

