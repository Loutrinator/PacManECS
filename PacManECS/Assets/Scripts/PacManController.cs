using UnityEngine;

public class PacManController : MonoBehaviour {
    public int speed;
    private Vector3 _direction = Vector3.zero;
    void Update() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            _direction = Vector3.forward;
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            _direction = Vector3.back;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            _direction = Vector3.left;
        } else if (Input.GetKey(KeyCode.RightArrow)) {
            _direction = Vector3.right;
        }

        if (_direction != Vector3.zero && !Physics.BoxCast(transform.position, Vector3.one/2, _direction, Quaternion.identity, 0.1f, 1 << 8)) {
            Vector3 position = transform.position;
            transform.LookAt(position + _direction);
            transform.position = Vector3.MoveTowards(position, position+_direction, Time.deltaTime*speed);
        }
    }
}
