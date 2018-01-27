using UnityEngine;
using Variables.Definitions;
using System.Collections.Generic;
using System.Linq;
public class PlatformSpawner : MonoBehaviour
{

    public GameObject Platform;
    public FloatVariable MaxDoubleTapTime;
    public IntVariable DragModeV;
    public FloatVariable MaxDragRotateDistance;



    enum DragMode
    {
        Position,
        Rotation
    }


    const float _overlappingCircleSize = 0.2f;
    float _lastClickTime;
    List<GameObject> _platforms = new List<GameObject>();
    GameObject _draggedObject;
    Vector3 _grabMouseWorldPos;
    Vector3 _grabRotation;


    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Time" + (Time.time - _lastClickTime));
            if ((Time.time - _lastClickTime) < MaxDoubleTapTime.Value)
            {
                DoubleTap(Input.mousePosition);
            }
            else
            {
                SingleTap(Input.mousePosition);
            }

            _lastClickTime = Time.time;
        }

        if(Input.GetButtonUp("Fire1"))
        {
            //Debug.Log("Released button");
            _draggedObject = null;
        }


        HandleDragging(Input.mousePosition);
    }

    void HandleDragging(Vector3 mousePos)
    {
        if (_draggedObject == null)
            return;
        
        Vector3 targetPos = GetWorldMousePosition(mousePos);


        if (DragModeV.Value == (int)DragMode.Position)
        {
            _draggedObject.transform.position = targetPos;
        }
        else
        {
            float distance = targetPos.y - _grabMouseWorldPos.y;
            float angle = distance * 360.0f / MaxDragRotateDistance.Value;
            _draggedObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, _grabRotation.z + angle));

        }

    }



    void DoubleTap(Vector3 mousePos)
    {
        Vector3 targetPos = GetWorldMousePosition(mousePos);


        Collider2D col;
        if(!(col = GetPlatformColliderOnPoint(targetPos)))
        {
            CreatePlatformAtPoint(targetPos);
        }
        else
        {
            //Debug.Log("Destroying gameobject");
            Destroy(col.gameObject);
            _draggedObject = null;
        }
    }

    void SingleTap(Vector3 mousePos)
    {
        Vector3 targetPos = GetWorldMousePosition(mousePos);
        //Debug.Log("Single Tap" + targetPos.x + " " + targetPos.y + " " + targetPos.z);


        Collider2D col;
        if(col = GetPlatformColliderOnPoint(targetPos))
        {
            //Debug.Log("Hitted platform single tap");
            _draggedObject = col.gameObject;
            _grabMouseWorldPos = targetPos;
            _grabRotation = _draggedObject.transform.rotation.eulerAngles;
        }

    }


    Collider2D GetPlatformColliderOnPoint(Vector3 targetPos)
    {
        Collider2D col = Physics2D.OverlapCircle(targetPos, _overlappingCircleSize);
        if (col != null && col.CompareTag("Platform"))
        {
            return col;
        }

        return null;
    }

    void CreatePlatformAtPoint(Vector3 targetPos)
    {
        GameObject p = Instantiate(Platform, targetPos, Quaternion.identity);
        _platforms.Add(p);
    }


    Vector3 GetWorldMousePosition(Vector3 mousePos)
    {
        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        float dist;
        if (plane.Raycast(ray, out dist))
        {
            Vector3 targetPos = ray.GetPoint(dist);
            //Debug.Log("Hitted" + targetPos.x + " " + targetPos.y + " " + targetPos.z);
            return targetPos;
        }

        return new Vector3();
    }

}
