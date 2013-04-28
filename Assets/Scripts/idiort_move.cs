using UnityEngine;
using System.Collections;

public class idiort_move : MonoBehaviour {
	private GameObject[] idiorts;
	private GameObject[] navs;
	public bool idling;
	// Use this for initialization
	void Start () {
		idiorts = GameObject.FindGameObjectsWithTag("idiort");
		navs = GameObject.FindGameObjectsWithTag("bridge");
		idling = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.B)){
			if(idling){
				idling = !idling;
				int i = 0;
				foreach(GameObject idiort in idiorts){
					NavMeshAgent n = idiort.GetComponent<NavMeshAgent>();
					Transform dest;
					if(idiort.name == "captain"){
						dest = GameObject.Find("captains_chair").GetComponent<Transform>();
					} else {
						dest = navs[i].GetComponent<Transform>();
						i++;
					}
					n.SetDestination(dest.position);
				}
			} else {
				idling = !idling;	
			}
		}
	}
}
