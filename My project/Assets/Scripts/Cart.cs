using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{
    [SerializeField] float offset;
    
    Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;


    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Start()
    {
        _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
    }
    void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
    }
    void OnMouseDrag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < _startPosition.x + offset && mousePosition.x > _startPosition.x - offset)
        {
            this.transform.position = new Vector2(mousePosition.x,this.transform.position.y);
        }
        else if (mousePosition.x > _startPosition.x + offset)
        {
            this.transform.position = new Vector2(_startPosition.x + offset,this.transform.position.y);
        }
        else if (mousePosition.x < _startPosition.x - offset)
        {
            this.transform.position = new Vector2(_startPosition.x - offset, this.transform.position.y);
        }

    }
    void OnMouseUp()
    {
        _spriteRenderer.color = Color.white;
    }
}
