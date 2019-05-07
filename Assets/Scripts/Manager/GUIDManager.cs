using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIDManager : MonoBehaviour {

	public static string GUID { get { return Guid.NewGuid().ToString(); } }

}
