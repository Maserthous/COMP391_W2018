using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour {

    public GameObject explosionSkull;
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Boundary")
        {
            return;
            // Debug.Log("DestroyByContact");
        }

        Instantiate(explosionSkull, this.transform.position, this.transform.rotation);

        Destroy(other.gameObject); // Destroy other thing
        Destroy(this.gameObject); // Destroy this thing
	}
}
