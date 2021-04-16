using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadController : MonoBehaviour
{
    Transform head_tr;
    Transform doooor;
    float xRotate;
    float yRotate;
    float sens = 3f;
    public GameObject GGkey;
    public GameObject pressE;
    public GameObject keyGG;
    public GameObject ClosedDoor;
    public GameObject dooor;
    public GameObject makeKey;
    public GameObject makeKey2;
    int key = 0;
    int door = 0;
    int keykeepertext = 0;
   
    void Start()
    {
        doooor = dooor.GetComponent<Transform>();
    }

    void Update()
    {
        GGkey.SetActive(false);
        keyGG.SetActive(false);
        ClosedDoor.SetActive(false);
        makeKey.SetActive(false);
        makeKey2.SetActive(false);
        pressE.SetActive(false);
        xRotate = xRotate - Input.GetAxis("Mouse Y") * sens;
        yRotate = yRotate + Input.GetAxis("Mouse X") * sens;
        xRotate = Mathf.Clamp(xRotate, -90, 90);
        transform.rotation = Quaternion.Euler(xRotate, yRotate, 0);
        FindObjectOfType<BodyController>().SomeMethod(yRotate);

        Debug.DrawRay(transform.position, transform.forward * 4f, Color.red);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 4f))
        {
            if(hit.collider.gameObject.tag == "keykeeper")
            { 
                if(door==0)
                {
                    GGkey.SetActive(true);
                    keykeepertext = 1;
                }
                if(door==1)
                {
                    makeKey.SetActive(true);
                    key = 1;
                }
            }
            if(hit.collider.gameObject.tag == "door")
            { 
                if(key==0)
                {
                    ClosedDoor.SetActive(true);
                    door = 1;
                }
                if(key==1)
                {  
                    pressE.SetActive(true);
                    if(Input.GetKeyDown("e"))
                    {
                        Destroy(doooor.gameObject);
                    }
                }
            }
        }
    }
}