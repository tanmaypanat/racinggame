using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

    public GameObject BulletShooter;
    public GameObject Bullet;
    public float BulletForce;

    private Vector3 targetPosition;
    private float turnSpeed;
	// Use this for initialization
	void Start () {
     turnSpeed = 1f;
	}
	
	// Update is called once per frame
	void Update () {
       SetTargetPosition();
        Vector3 towards = targetPosition - transform.position;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(towards), Time.deltaTime * turnSpeed);
		 if (Input.GetMouseButton(0))
        {
            GameObject TempBullet;
            TempBullet = Instantiate(Bullet, BulletShooter.transform.position, BulletShooter.transform.rotation);

            TempBullet.transform.Rotate(Vector3.left * 90);

            TempBullet.transform.position = Vector3.MoveTowards(transform.position, targetPosition, BulletForce * Time.deltaTime);

            /* Rigidbody tempRigidBody;
             tempRigidBody = TempBullet.GetComponent<Rigidbody>();

             tempRigidBody.AddForce(transform.forward * BulletForce);*/

            Destroy(TempBullet, 5.0f);
        }
	}

    void SetTargetPosition()
    {
        //creates a plane for the user to click on
        Plane plane = new Plane(Vector3.up, transform.position);
        //creates a ray from the camera to the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //float used to store the target point
        float point = 0f;

        //sets the target position as the point where the ray and the plane meet
        if (plane.Raycast(ray, out point))
           targetPosition = ray.GetPoint(point);
        
    }

}
