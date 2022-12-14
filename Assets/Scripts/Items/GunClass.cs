using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "new Gun Class", menuName = "Item/Gun")]
public class GunClass : ItemClass
{
    [Header("Gun")]
    public GunType guntype;
    public float damage;
    public bool fullAuto;

    [SerializeField] private Transform hitEffectPrefab;

    public enum GunType
    {
        onehanded,
        twohanded,
    }

    public override void Use(PlayerController player)
    {
        Vector3 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;
        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f))
        {
            hitTransform = raycastHit.transform;
        }
        if (hitTransform != null)
        {
            Instantiate(hitEffectPrefab, raycastHit.point, Quaternion.identity); // Spawn hit effect

            if (hitTransform.GetComponent<Enemy>() != null)
            {
                raycastHit.transform.gameObject.GetComponent<Enemy>().health -= damage;
            }
        }
    }

    public override GunClass getGun() { return this; }
}
