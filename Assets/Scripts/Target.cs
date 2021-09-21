using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Target : MonoBehaviour
{
    private const float TIME_TO_DESTROY = 10F;

    [SerializeField]
    private int maxHP = 1;

    #region ScoreManager
    [SerializeField]
    private int scoreAdd;
    #endregion

    private int currentHP;

    //[SerializeField]
    //private int scoreAdd = 10;

    private void Start()
    {
        currentHP = maxHP;
        Destroy(gameObject, TIME_TO_DESTROY);
    }

    private void OnCollisionEnter(Collision collision)
    {
        int collidedObjectLayer = collision.gameObject.layer;

        if (collidedObjectLayer.Equals(Utils.BulletLayer))
        {
            Destroy(collision.gameObject);

            currentHP -= 1;

            if (currentHP <= 0)
            {
                if(Player.OnPlayerScoreChanged != null) Player.OnPlayerScoreChanged(scoreAdd);

                Destroy(gameObject);
            }
        }
        else if (collidedObjectLayer.Equals(Utils.PlayerLayer) ||
            collidedObjectLayer.Equals(Utils.KillVolumeLayer))
        {
            if (Player.OnPlayerHit != null) Player.OnPlayerHit(1);
            Destroy(gameObject);
        }
    }
}