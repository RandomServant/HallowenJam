using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactPlayer : MonoBehaviour
{
    bool active = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (active) return;
        else
        {
            if (other.gameObject.GetComponent<Player>())
            {
                active = true;
                other.gameObject.GetComponent<Player>().Death();
            }
        }
    }

}
