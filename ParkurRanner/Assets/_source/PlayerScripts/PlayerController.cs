using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    public Spawner spawner;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _howMuschToMove;
    [SerializeField] private float _leftLineZ;
    [SerializeField] private float _middleLineZ;
    [SerializeField] private float _rightLineZ;
    [SerializeField] private float _slideTime;
    [SerializeField] private float _slidePosition;
    [SerializeField] private float _standPosition;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _pointsPerFiveSeconds;
    [SerializeField] private GameObject _restartPanel;
    private float _pointsToPlus;
    private float _sphereActing;
    private float _shiledActing;
    public float _watchActingTime;
    private float _points = 0;
    private int _whichLine = 1;
    public float Speed;
    public float JumpForce; 
    private CapsuleCollider _collider;
    
    private bool _isGrounded = false;
    private float _timeInSlide;
    private bool _hadSlided = false;
    private bool _watchCollected;
    private bool _sphereCollected;
    private bool _shiledcollected = false;
    private float _time = 0;
    private Vector3 _leftLine;
    private Vector3 _middleLine;
    private Vector3 _rightLine;



    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<CapsuleCollider>();
        _timeInSlide = _slideTime;
        _pointsToPlus = _pointsPerFiveSeconds;
    }
    private void Update()
    {
        
        _text.text = "points " + _points;
        MooveToTheRight();
        MooveToTheLeft();
        Slide();
        _time += Time.deltaTime;
        
        if (Mathf.RoundToInt(_time) % 5 == 0)
        {
            
            _points += _pointsToPlus;
            
        } else if (Time.deltaTime % 5 == 0 && _sphereCollected == true)
        {
            _points += _pointsToPlus;
        }
        if (_sphereActing <= 0)
        {
            _sphereCollected = false;
        }
        if (_shiledActing <= 0)
        {
            _shiledcollected = false;
        }
        _timeInSlide -= Time.deltaTime;
    }
    void FixedUpdate()
    {
        JumpLogic();
        MoveLogic();
    }
    public void SpawnLoc()
    {
        Debug.Log("asdas");
        spawner.Spawn();
    }
    private void Slide()
    {
        if (Input.GetKeyDown(KeyCode.S) && _timeInSlide <= 0)
        {
            Vector3 _slideSize = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y / 2f, gameObject.transform.localScale.z);
            gameObject.transform.localScale = _slideSize;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, _slidePosition, gameObject.transform.position.z);
            _timeInSlide = _slideTime;
            _hadSlided = true;
        }
        if (_hadSlided == true && _timeInSlide <= 0)
        {
            Vector3 _nonSlideSIze = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y * 2f, gameObject.transform.localScale.z);
            gameObject.transform.localScale = _nonSlideSIze;
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, _standPosition, gameObject.transform.position.z);
            _hadSlided = false;
        }
    }
    private void MooveToTheRight()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
           
            
            if (_whichLine == 1)
            {
                Vector3 lineChange = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, _rightLineZ);
                gameObject.transform.position = lineChange;
                _whichLine = 2;

            } else if(_whichLine == 0)
            {
                Vector3 lineChange = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, _middleLineZ);
                gameObject.transform.position = lineChange;
                _whichLine = 1;
            }
        }
        
    }
    private void MooveToTheLeft()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            
           
            if (_whichLine == 1)
            {
                Vector3 lineChange = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, _leftLineZ);
                gameObject.transform.position = lineChange;
                _whichLine = 0;

            }
            else if (_whichLine == 2)
            {
                Vector3 lineChange = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, _middleLineZ);
                gameObject.transform.position = lineChange;
                _whichLine = 1;
            }
        }
        
    }

    private void MoveLogic()
    {

        
        _rb.velocity = new Vector3(-Speed, _rb.velocity.y, _rb.velocity.z);
        
    }

    private void JumpLogic()
    {
        if (_isGrounded && Input.GetAxis("Jump") != 0 )
        {
            
            
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            _isGrounded = false;
        }
    }
    public void GotWatch(float _speedSlowDawn, float _timeOfSlawDawn)
    {

    }
    public void GotShiled(float _actingTime)
    {
        _shiledActing = _actingTime;
        _shiledcollected = true;
    }
    public void GotSphere(float pointsIncrease, float timeTOincrease)
    {
        _sphereActing = timeTOincrease;
        _pointsToPlus = pointsIncrease;
        _sphereCollected = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6 && _shiledcollected == false)
        {
            _restartPanel.SetActive(true);
           
        } else if (collision.gameObject.layer == 6 && _shiledcollected)
        {
            Destroy(collision.gameObject);
            _shiledcollected = false;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            _isGrounded = true;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 0)
        {
            _isGrounded = false;
        }
    }

}
