using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleArrow : MonoBehaviour
{
	[SerializeField]
	private Vector3 scaleAxis;
	[SerializeField]
	private float scaleSpeed;
	[SerializeField]
	private float positionOffset;

	private Transform rootTransform;
	private Transform gfxTransform;

	private Vector3 startScale;
	private Vector3 startScreen;
	private float xDot;
	private float yDot;

	private void Awake()
	{
		rootTransform = transform.parent.parent;
		gfxTransform = rootTransform.GetChild(0);
		gameObject.SetActive(false);
	}


	private void Update()
	{
		transform.position = gfxTransform.position;
		transform.position += (gfxTransform.localScale.x * 0.5f + positionOffset) * scaleAxis.x * gfxTransform.right;
		transform.position += (gfxTransform.localScale.y * 0.5f + positionOffset) * scaleAxis.y * gfxTransform.up;
		transform.position += (gfxTransform.localScale.z * 0.5f + positionOffset) * scaleAxis.z * gfxTransform.forward;
	}

	private void OnMouseDown()
	{
		startScale = gfxTransform.localScale;
		startScreen = Input.mousePosition;

		/*xDot = Vector3.Dot(transform.right, Camera.main.transform.right);
		yDot = Vector3.Dot(transform.right, Camera.main.transform.up);*/

		xDot = Vector3.Dot(scaleAxis, Camera.main.transform.right);
		yDot = Vector3.Dot(scaleAxis, Camera.main.transform.up);
	}

	private void OnMouseDrag()
	{
		Vector3 drag = Input.mousePosition - startScreen;
		gfxTransform.localScale = startScale;

		gfxTransform.localScale += Mathf.Abs(scaleAxis.x) * xDot * drag.x * scaleSpeed * Vector3.right;
		gfxTransform.localScale += Mathf.Abs(scaleAxis.x) * yDot * drag.y * scaleSpeed * Vector3.right;
		gfxTransform.localScale += Mathf.Abs(scaleAxis.y) * xDot * drag.x * scaleSpeed * Vector3.up;
		gfxTransform.localScale += Mathf.Abs(scaleAxis.y) * yDot * drag.y * scaleSpeed * Vector3.up;
		gfxTransform.localScale += Mathf.Abs(scaleAxis.z) * xDot * drag.x * scaleSpeed * Vector3.forward;
		gfxTransform.localScale += Mathf.Abs(scaleAxis.z) * yDot * drag.y * scaleSpeed * Vector3.forward;
	}
}
