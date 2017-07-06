using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePart : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bonus")
        {
            Bonus bonus = collision.gameObject.GetComponent<Bonus>();
            SendMessageUpwards(bonus.bonusAction);
            Destroy(collision.gameObject);
        }
    }
}
