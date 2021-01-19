using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rage : MonoBehaviour
{
  public CapsuleCollider collider;
  GameObject elephant_main;
  GameObject elephant_material;
  public float scale;
  Material m;
  // Start is called before the first frame update
  void Start()
  {
    collider = GetComponent<CapsuleCollider>();
    elephant_material = GameObject.Find("Elephant");

  }

  // Update is called once per frame
  void setElephantNormalState()
  {
    elephant_main.transform.localScale = new Vector3(1, 1, 1);
    m.color = new Color(102f / 255f, 102f / 255f, 102f / 255f);
    Destroy(gameObject);
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      elephant_main = other.gameObject;
      other.gameObject.transform.localScale = new Vector3(scale, scale, scale);
      m = elephant_material.GetComponent<SkinnedMeshRenderer>().material;
      m.color = Color.red;
      gameObject.SetActive(false);
      Invoke("setElephantNormalState", 10);
    }
  }
  void Update()
  {

  }
}
