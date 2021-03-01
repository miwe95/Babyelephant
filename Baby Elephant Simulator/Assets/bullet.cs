using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
  public Transform bulletSpawn;
  public Rigidbody rb;
  // Start is called before the first frame update
  void Start()
  {
    rb.AddForce(rb.transform.forward * 100f);
  }

}
