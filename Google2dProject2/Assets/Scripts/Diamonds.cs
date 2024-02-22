using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamonds : MonoBehaviour
{
    [SerializeField] private AudioClip diamondSound;

    private int count = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            //Debug.Log(count);
            count++;
            AudioSource.PlayClipAtPoint(diamondSound, collision.gameObject.transform.position);
            Destroy(collision.gameObject);
        }
    }
}
