using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _gm;
    public static GameManager GM
    {
        get
        {
            if (_gm == null)
                Debug.LogError("Game Manager is down");
            return _gm;
        }
    }

    [SerializeField] private LayerMask _groundLayer;
    
    private void Start()
    {
        _gm = this;
    }

    public static bool InCamera(GameObject theObject)
    {   // shamelessly copied from unity answers
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        return GeometryUtility.TestPlanesAABB(planes, theObject.GetComponent<Collider2D>().bounds);
    }

    public bool IsBoxGrounded(BoxCollider2D collider, float castDist = 0.1f)
    {
        return Physics2D.BoxCast(
            collider.bounds.center, collider.size, 0f, 
            Vector2.down, castDist, _groundLayer
        ).collider != null;
    }
}
