using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLR : MonoBehaviour
{
    private Quaternion _baseTransform;
    private Quaternion _currentTransform;
    private Animator _unitAnimator;
    public string leftTrigger;
    public string rightTrigger;


    void Awake()
    {
        _baseTransform = gameObject.transform.rotation;
        _unitAnimator = gameObject.GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        _currentTransform = gameObject.transform.rotation;
        Turn();
        _baseTransform = _currentTransform;
    }

    private void Turn()
    {
        
        
        if (Mathf.Round( _baseTransform.eulerAngles.y) > Mathf.Round(_currentTransform.eulerAngles.y))
        {
            _unitAnimator.SetBool(rightTrigger, false);
            _unitAnimator.SetBool(leftTrigger, true);
         //   print("Лево "+ _baseTransform.eulerAngles.y + "   " + _currentTransform.eulerAngles.y);
        }
        else if(Mathf.Round(_baseTransform.eulerAngles.y) < Mathf.Round(_currentTransform.eulerAngles.y))
        {
            _unitAnimator.SetBool(leftTrigger, false);
            _unitAnimator.SetBool(rightTrigger, true);
          //  print("Право " + _baseTransform.eulerAngles.y + "   " + _currentTransform.eulerAngles.y);
        }
        else
        {
            _unitAnimator.SetBool(leftTrigger, false);
            _unitAnimator.SetBool(rightTrigger, false);

        }
    }
}
