using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMintNFTs : MonoBehaviour
{
    Transform player;
    Collider treeCollider;
    GameObject world;
    GameObject callButton;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        treeCollider = GameObject.FindGameObjectWithTag("Tree").GetComponent<Collider>();
        world = GameObject.FindGameObjectWithTag("Planet");
        callButton = GameObject.FindGameObjectWithTag("CallButton");
        callButton.SetActive(false);
    }


    private void OnCollisionEnter(Collision collision)
    {
        print("any collision uce");
        if (collision.gameObject.tag == "Tree")
        {
            callButton.SetActive(true);
            print("Collided with tree");
            /**if (Input.GetKeyDown(KeyCode.N)) {
                //world.GetComponent<CustomCallExample>().PrintHi();
            }*/
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            callButton.SetActive(false);
        }
    }
}
