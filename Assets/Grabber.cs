using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grabber : MonoBehaviour
{
	private GameObject selectedObject;

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (selectedObject == null)
			{
				RaycastHit[] hits = CastRay();
				RaycastHit trueHit = hits.Where(c => c.collider.gameObject.tag == "drag").FirstOrDefault();


                if (trueHit.collider != null)
				{
					if (!trueHit.collider.CompareTag("drag"))
						return;

					selectedObject = trueHit.collider.gameObject;
					Cursor.visible = false;
				}
			}
			else
			{
				Vector3 position = new Vector3(
				Input.mousePosition.x,
				Input.mousePosition.y,
				Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
				Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

				selectedObject.transform.position = new Vector3(worldPosition.x, 2.0f, worldPosition.z);

                selectedObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

                selectedObject = null;
				Cursor.visible = true;
            }
		}

		if (selectedObject != null)
		{
			Vector3 position = new Vector3(
				Input.mousePosition.x,
				Input.mousePosition.y,
				Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);
			Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

			selectedObject.transform.position = new Vector3(worldPosition.x, 2.0f, worldPosition.z);
			selectedObject.GetComponent<Rigidbody>().freezeRotation = true;
		}
	}

	private RaycastHit[] CastRay()
	{
		Vector3 screenMousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
		Vector3 screenMousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

		Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
		Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

		RaycastHit[] hit = new RaycastHit[5];
		hit = Physics.RaycastAll(worldMousePosNear, worldMousePosFar - worldMousePosNear);

		return hit;
	}
}