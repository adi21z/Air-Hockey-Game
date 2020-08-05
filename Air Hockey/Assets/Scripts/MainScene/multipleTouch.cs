using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class multipleTouch : MonoBehaviour
{
    public GameObject circle1;
    


    public List<touchLocation> touches = new List<touchLocation>();
    public LayerMask mask;

    public Transform BoundaryHolder1;
    public Transform BoundaryHolder2;

    Boundary playerBoundary1;
    Boundary playerBoundary2;

    public Rigidbody rb1;
    public Rigidbody rb2;
    private void Awake()
    {
        
    }
    void Start()
    {
       
        playerBoundary1 = new Boundary(BoundaryHolder1.GetChild(0).position.z,
        BoundaryHolder1.GetChild(1).position.z, BoundaryHolder1.GetChild(2).position.x, BoundaryHolder1.GetChild(3).position.x);
        playerBoundary2 = new Boundary(BoundaryHolder2.GetChild(0).position.z,
       BoundaryHolder2.GetChild(1).position.z, BoundaryHolder2.GetChild(2).position.x, BoundaryHolder2.GetChild(3).position.x);
    
       
    }
    
   
    void Update()
    {
       
        int i = 0;
        while (i < Input.touchCount)
        {
            Touch t = Input.GetTouch(i);
            if (t.phase == TouchPhase.Began)
            {
                Debug.Log("touch began");
               
                touches.Add(new touchLocation(t.fingerId,circle1));
            }
            else if (t.phase == TouchPhase.Ended)
            {
                Debug.Log("touch ended");
                touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                //Destroy(thisTouch.circle);
                touches.RemoveAt(touches.IndexOf(thisTouch));
            }
            else if (t.phase == TouchPhase.Moved)
            {
                Debug.Log("touch is moving");
                touchLocation thisTouch = touches.Find(touchLocation => touchLocation.touchId == t.fingerId);
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
            
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit, mask))
                {
                    
                    if (hit.point.z <playerBoundary1.Up)
                    {
                        Vector3 clampedMousePos1 = new Vector3(Mathf.Clamp(hit.point.x, playerBoundary1.Left, playerBoundary1.Right), hit.point.y,
                                                            Mathf.Clamp(hit.point.z, playerBoundary1.Down, playerBoundary1.Up));
                        
                        rb1.MovePosition(clampedMousePos1);
                    }
                    if (hit.point.z > playerBoundary2.Down)
                    {
                        Vector3 clampedMousePos2 = new Vector3(Mathf.Clamp(hit.point.x, playerBoundary2.Left, playerBoundary2.Right), hit.point.y,
                                                           Mathf.Clamp(hit.point.z, playerBoundary2.Down, playerBoundary2.Up));

                        rb2.MovePosition(clampedMousePos2);
                    }
                }
            }
            ++i;
        }
    }
    
   
    
}


