using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour
{
	[SerializeField]
	private Vector3 moveAxis;
	[SerializeField]
	private float moveSpeed;
	[SerializeField]
	private float positionOffset;

	private Transform rootTransform;
	private Transform gfxTransform;

	private Vector3 startPosition;
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
		transform.position += (gfxTransform.localScale.x * 0.5f + positionOffset) * moveAxis.x * gfxTransform.right;
		transform.position += (gfxTransform.localScale.y * 0.5f + positionOffset) * moveAxis.y * gfxTransform.up;
		transform.position += (gfxTransform.localScale.z * 0.5f + positionOffset) * moveAxis.z * gfxTransform.forward;
	}

	private void OnMouseDown()
	{
		startPosition = rootTransform.position;
		startScreen = Input.mousePosition;

		xDot = Vector3.Dot(transform.right, Camera.main.transform.right);
		yDot = Vector3.Dot(transform.right, Camera.main.transform.up);
	}

	private void OnMouseDrag()
	{
		Vector3 drag = Input.mousePosition - startScreen;
		rootTransform.position = startPosition;

		rootTransform.position += Mathf.Abs( moveAxis.x) * xDot * drag.x * moveSpeed * rootTransform.right;
		rootTransform.position += Mathf.Abs( moveAxis.x) * yDot * drag.y * moveSpeed * rootTransform.right;
		rootTransform.position += Mathf.Abs( moveAxis.y) * xDot * drag.x * moveSpeed * rootTransform.up;
		rootTransform.position += Mathf.Abs( moveAxis.y) * yDot * drag.y * moveSpeed * rootTransform.up;
		rootTransform.position += Mathf.Abs( moveAxis.z) * xDot * drag.x * moveSpeed * rootTransform.forward;
		rootTransform.position += Mathf.Abs( moveAxis.z) * yDot * drag.y * moveSpeed * rootTransform.forward;
	}
}
