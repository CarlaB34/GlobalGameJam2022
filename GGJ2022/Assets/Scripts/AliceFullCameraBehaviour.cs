using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AliceFullCameraBehaviour : MonoBehaviour
{

    [SerializeField]
    private GameObject alice;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(alice.transform.position.x, alice.transform.position.y, alice.transform.position.z);
    }
}
