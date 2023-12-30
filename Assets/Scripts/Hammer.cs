using UnityEngine;

public class Hammer : MonoBehaviour
{
    [SerializeField] private float cursorOffsetX;
    [SerializeField] private float cursorOffsetY;

    private Vector3 cursorPosition;

    public float GetCursorPositionX => cursorPosition.x;

    public float GetCursorPositionY => cursorPosition.y;


    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(cursorPosition.x + cursorOffsetX, cursorPosition.y + cursorOffsetY, 0);
    }
}