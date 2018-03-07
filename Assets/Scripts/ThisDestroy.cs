using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisDestroy : MonoBehaviour {

	public void DestroyThis()
    {
        Destroy(this.gameObject);
    }
}
