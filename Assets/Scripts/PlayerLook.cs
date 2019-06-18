using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    public Transform target;
    public GameObject player;
    public float speedX = 360f;
    public float speedY = 240f;
    public float limitYup = 60f;
    public float limitYdown = -40f;
    public float minDistance = 1.5f;
    public float hideDistance = 2f;

    private float _maxDistance;
    private Vector3 _localPosition;
    private float _currentYRotation; //текущая позиция по Y

    public LayerMask obstacles; //маски что видим\не видим
    public LayerMask noPlayer; //сквозь игрока
    private LayerMask _camOrigin;
    private Vector3 _position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }


    void Start()
    {
        _localPosition = target.InverseTransformPoint(_position);
        _maxDistance = Vector3.Distance(_position, target.position);
        _camOrigin = cam.cullingMask;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _position = target.TransformPoint(_localPosition);
        CameraRotation();
        ObstaclesReact();
        PlayerReact();
        _localPosition = target.InverseTransformPoint(_position);
    }

    void CameraRotation() //поворот камеры
    {
        var mx = Input.GetAxis("Mouse X"); // получаем перемещение нашей мыши по Х
        var my = -Input.GetAxis("Mouse Y");

        if (my != 0)
        {
            var tmp = Mathf.Clamp(_currentYRotation + my * speedY * Time.deltaTime, limitYdown, limitYup);
            if (tmp != _currentYRotation)
            {
                var rot = tmp - _currentYRotation;
                transform.RotateAround(target.position, transform.right, rot);
                _currentYRotation = tmp;
            }
        }
        if (mx !=0)
        {
            transform.RotateAround(target.position, Vector3.up, mx * speedX * Time.deltaTime);
          
            player.transform.RotateAround(target.position, Vector3.up, mx * speedX * Time.deltaTime);
        }

        transform.LookAt(target);
    }

    void ObstaclesReact() //реакция на объекты
    {
        var distance = Vector3.Distance(_position, target.position);
        RaycastHit hit;
        if (Physics.Raycast(target.position,transform.position-target.position,out hit,_maxDistance,obstacles))
        {
            _position = hit.point;
        }
        else if (distance<_maxDistance && !Physics.Raycast(_position,-transform.forward,.1f,obstacles))
        {
            _position -= transform.forward * .05f;
        }

    }
    void PlayerReact() //скрыть игрока
    {
        var distance = Vector3.Distance(_position, target.position);
        if (distance < hideDistance)
        {
            cam.cullingMask = noPlayer;
        }
        else
        {
            cam.cullingMask = _camOrigin;
        }
    }
}
