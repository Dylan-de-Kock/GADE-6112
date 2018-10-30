
using UnityEngine;

public class CameraControl : MonoBehaviour {
    
    public float panSpeed = 20f;
    public float panBorder = 10f;
    public Vector2 panLimit;
    public float ScrollSpeed = 20f;
    public float zoomSize = 5;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(10f, -9f, -10f);
        Camera.main.orthographicSize = 5;		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            zoomSize -= 1;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            zoomSize += 1;
        }

        GetComponent<Camera>().orthographicSize = zoomSize;

        Vector3 pos = transform.position;
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorder)
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= - panBorder)
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorder)
        {
            pos.x += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorder)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, -panLimit.y, panLimit.y);

        transform.position = pos;


		
	}
}
