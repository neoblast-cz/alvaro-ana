using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossumMovement : MonoBehaviour
{
    private float speed = 1f;

    
	public float direction = 1;
	private bool followPlayer;

	[SerializeField] private LayerMask layerMask;
	[SerializeField] private Vector2 rayCastOffset;

	private RaycastHit2D rightWall;
	private RaycastHit2D leftWall;
	private RaycastHit2D rightLedge;
	private RaycastHit2D leftLedge;

	void Update() {
        
        //Check for walls
		rightWall = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.right, 1f, layerMask);
		Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + rayCastOffset.y), Vector2.right, Color.yellow);

		if (rightWall.collider != null) {
			if (!followPlayer) {
				direction = -1;
			}
			else {
				Jump();
			}
		}

		leftWall = Physics2D.Raycast(new Vector2(transform.position.x - rayCastOffset.x, transform.position.y + rayCastOffset.y), Vector2.left, 1f, layerMask);
		Debug.DrawRay(new Vector2(transform.position.x, transform.position.y + rayCastOffset.y), Vector2.left, Color.blue);

		if (leftWall.collider != null) {
			if (!followPlayer) {
				direction = 1;
			} else {
				Jump();
			}
		}

		//Check for ledges
		if (!followPlayer) {
			rightLedge = Physics2D.Raycast(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y), Vector2.down, .5f);
			Debug.DrawRay(new Vector2(transform.position.x + rayCastOffset.x, transform.position.y), Vector2.down, Color.blue);
			if (rightLedge.collider == null)
			{
				direction = -1;
			}

			leftLedge = Physics2D.Raycast(new Vector2(transform.position.x - rayCastOffset.x, transform.position.y), Vector2.down, .5f);
			Debug.DrawRay(new Vector2(transform.position.x - rayCastOffset.x, transform.position.y), Vector2.down, Color.blue);

			if (leftLedge.collider == null)
			{
				direction = 1;
			}
		}
	} // update

	public void Jump()
	{
		
	}
}