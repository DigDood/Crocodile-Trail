using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    void Start()
    {
    }

    void Update()
    {
        GetInput();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += -transform.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += -transform.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.childCount > 0)
        {
            if (collision.gameObject.tag != "Road")
            {
                GameObject child = collision.transform.GetChild(0).gameObject;
                TextMeshPro textX = child.GetComponent<TextMeshPro>();
                textX.gameObject.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "Bomb")
        {
            collision.transform.GetComponent<Rigidbody>().useGravity = true;
            collision.transform.GetComponent<Rigidbody>().isKinematic = false;
            speed = 0;
            transform.position = 70c12ollision.transform.position + Vector3.up;
            collision.transform.tag = "Untagged";
        }
    }
}
