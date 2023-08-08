using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    public EquippableItem item;
    Inventory inventory;

    private void Start()
    {
        inventory = Object.FindObjectOfType<Inventory>();
        Collect();
    }

    public void Collect()
    {
        Debug.Log("topladı");
        inventory.AddItem(item);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("değdi");
            Collect();

        }
    }
}
