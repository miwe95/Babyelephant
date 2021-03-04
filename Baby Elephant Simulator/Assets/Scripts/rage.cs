using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rage : MonoBehaviour
{
  public CapsuleCollider collider;
  GameObject elephant_main;
  GameObject elephant_material;
  GameObject benjamin;
  public float scale;
  Material m;
  public MovementController benjamin_move;
  // Start is called before the first frame update
  void Start()
  {
    collider = GetComponent<CapsuleCollider>();
    elephant_material = GameObject.Find("Elephant");
    benjamin = GameObject.Find("Benjamin Blümchen");
    benjamin_move = benjamin.GetComponent<MovementController>();
  }

  // Update is called once per frame
  void setElephantNormalState()
  {
    elephant_main.transform.localScale = new Vector3(1, 1, 1);
    m.color = new Color(102f / 255f, 102f / 255f, 102f / 255f);
    benjamin_move.rage_mode = false;
    Destroy(gameObject);
  }

  void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      elephant_main = other.gameObject;
      benjamin_move.rageSound.Play();
      other.gameObject.transform.localScale = new Vector3(scale, scale, scale);
      m = elephant_material.GetComponent<SkinnedMeshRenderer>().material;
      m.color = Color.red;
      benjamin_move.rage_mode = true;
      gameObject.SetActive(false);
      Invoke("setElephantNormalState", 10);
    }
  }
  void Update()
  {

  }
}
