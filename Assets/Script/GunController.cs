using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    
    
    //Follow pointeur Souris
    public Vector3 mousePosition;
    public Camera sceneCamera;
    public Transform aimTransform;

   

    // Update is called once per frame
    void Update()
    {
        mousePosition = GetMouseWorldPosition();
        
    }

    void FixedUpdate()
    {
        AimingAtMouse();
    }

    void AimingAtMouse()
    {
        

        //Follow pointeur souris
        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        aimTransform.eulerAngles = new Vector3(0,0,aimAngle);

        
    }











    //Mouse PositionZ to 0
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        
        return vec;
    }

    public static Vector3 GetMouseWorldPositionWithZ()
    {       
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
   public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {       
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }

    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera wordlCamera)
    {       
        Vector3 worldPositon = wordlCamera.ScreenToWorldPoint(screenPosition);
        return worldPositon;
    }
}
