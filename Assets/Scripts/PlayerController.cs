using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private float _minSpeed = 2f;
    [SerializeField] private Animator _animator;
    private int _state;

    [SerializeField] private Rigidbody Rb;
    void Update()
    {
        if(!IsOwner) return;
        GetInput();
    }
    public void GetInput()
    {
        if (Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            _state = 1;
            if (Input.GetKey(KeyCode.LeftShift)){ 

            }
        }
        else
        {
            _state = 0;
        }
        if (Input.GetKey(KeyCode.A)){
            transform.Translate(Vector3.left * _minSpeed * Time.deltaTime);
            _state = 5;
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(Vector3.right * _minSpeed * Time.deltaTime);
            _state = 6;
        }
        if (Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back * _minSpeed * Time.deltaTime);
            _state = 3;
        }
        _animator.SetInteger("State", _state);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall"){
            _speed = 0;
        }
        else{
            _speed = 3;
        }
    }
}
