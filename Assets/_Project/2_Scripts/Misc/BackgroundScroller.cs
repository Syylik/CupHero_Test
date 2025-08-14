using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed;

    [SerializeField] private float _resetPositionX = -20f;
    [SerializeField] private float _startPositionX;

    public bool isScrolling { get; set; } = false;

    private void Update()
    {
        if (isScrolling)
        {
            transform.Translate(Vector2.left * (_scrollSpeed * Time.deltaTime));
            if (transform.position.x <= _resetPositionX)
            {
                transform.position = new Vector2(_startPositionX, transform.position.y);
            }
        }
    }

    public void SetScrolling(bool state) => isScrolling = state;
}
