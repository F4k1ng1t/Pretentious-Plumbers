using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] float _launchForce = 500f;
    [SerializeField] float _maxDragDistance = 5;
    [SerializeField] GameObject Cart;
    
    Vector2 _startPosition;

    Rigidbody2D _rigidbody2D;

    SpriteRenderer _spriteRenderer;

    

    public bool IsDragging { get; private set; }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
        //Pipe.transform.localRotation = Quaternion.Euler(0, 0, 90);
    }
    
    void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 cartPosition = new Vector2(Cart.transform.position.x, Cart.transform.position.y);
        float distanceA = Vector2.Distance(cartPosition, mousePosition);
        float distanceB = Vector2.Distance(this.transform.position, new Vector2(mousePosition.x,cartPosition.y));
        float angle = Mathf.Asin(distanceB / distanceA);
        if (!float.IsNaN(angle))    
        {   
            angle *= Mathf.Rad2Deg;
            if (mousePosition.x - cartPosition.x < 0)
            {
                this.transform.rotation = Quaternion.Euler(0,0,0);
            }
            else if(mousePosition.y - cartPosition.y < 0)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, 0, -angle);
            }
        }
    }
}
