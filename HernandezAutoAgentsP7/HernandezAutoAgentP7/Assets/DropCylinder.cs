using UnityEngine;

public class DropCylinder : MonoBehaviour {

    public GameObject obstacle;
    GameObject[] agents;
    private Camera cam;

    void Start() {

        agents = GameObject.FindGameObjectsWithTag("Agent");
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0)) {

            RaycastHit hitInfo;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hitInfo)) {

                Instantiate(obstacle, hitInfo.point, obstacle.transform.rotation);
                foreach (GameObject a in agents) {

                    a.GetComponent<AgentesControl>().DetectNewObstacle(hitInfo.point);
                }
            }
        }
    }
}
