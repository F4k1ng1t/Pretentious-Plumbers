using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plumber : MonoBehaviour
{
    [SerializeField] GameObject pipeBase;
    [SerializeField] GameObject pipeTop;
    [SerializeField] float _launchForce;

    bool _fired = false;

    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        _rigidbody2D.isKinematic = true;
        _spriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_fired)
        {
            _rigidbody2D.position = pipeTop.transform.position;
        }
        if (Input.GetMouseButtonDown(1) && !_fired)
        {
            Launch();
        }
    }
    void Launch()
    {
        var audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        _spriteRenderer.enabled = true;
        Vector2 direction = pipeTop.transform.position - pipeBase.transform.position;
        direction.Normalize();

        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * _launchForce);
        _fired = true;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _rigidbody2D.position = pipeTop.transform.position;
        _spriteRenderer.enabled = false;
        _fired = false;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }
}
