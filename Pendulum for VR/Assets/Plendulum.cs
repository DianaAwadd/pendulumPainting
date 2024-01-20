using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plendulum : MonoBehaviour
{
    Quaternion _start,_end;
    [SerializeField,Range(0.0f,360f)]
     private float _angle=90.0f;
     [SerializeField,Range(0.0f,5.0f)]
     private float _speed=2.0f;
    [SerializeField,Range(0.0f,10.0f)]
     private float _startTime=0.0f;
    // Start is called before the first frame update
    
    private void Start()
    {
       _start=PlendulumRotation(_angle);
       _end=PlendulumRotation(-_angle);
    }

    // Update is called once per frame
    private void Update() 
    {
    _startTime +=Time.deltaTime;
    transform.rotation=Quaternion.Lerp(_start,_end,(Mathf.Sin(_startTime*_speed+Mathf.PI/2)+1.0f)/2.0f);    
    }

    void ResetTimer()
    {
        _startTime=0.0f;
    }
    Quaternion PlendulumRotation(float angle){
    var PlendulumRotation=transform.rotation;
    var angleZ=PlendulumRotation.eulerAngles.z+angle;
    PlendulumRotation.eulerAngles =new Vector3(PlendulumRotation.eulerAngles.x,PlendulumRotation.eulerAngles.y,angleZ);
    return PlendulumRotation;
    }
}
