using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightControler : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private Light _light2;
    [SerializeField] private Transform _firePoint;

    [SerializeField] private float _baseIntensity = 4.0f;
    [SerializeField] private float _shootingIntensity = 10.0f;

    [SerializeField] [Range(10.0f, 50.0f)] private float _angle = 20.0f;

    [SerializeField] private float _focusedLightIntensity = 100.0f;
    [SerializeField] private float _focusedLightRange = 50.0f;
    [SerializeField] private float _focusedLightSightView = 3.0f;

    private RaycastHit hit;
    private bool _mode = true;
    private bool _flash = false;

    private float _range;
    private float _spotAngle;
    private Color _originalColor;

    private bool _shot;
    public float damage = 25f;
    public float range = 100f;

    void Start()
    {
        _spotAngle = _light.spotAngle;
        _originalColor = _light.color;
        _range = _light.range;
    }

    void Update()
    {


        if (Input.GetMouseButton(0))
        {
            Shot();
        }
        else if (Input.GetMouseButton(2))
        {
            if (!_flash)
            {
                _light.range += _focusedLightRange;
                _light.intensity = _focusedLightIntensity;
                _light.spotAngle /= _focusedLightSightView;
                _flash = true;
            }
        }
        else
        {
            if (_mode)
            {
                _light.spotAngle = _spotAngle;
                _light.intensity = _baseIntensity;
                if (_flash)
                {
                   _flash = false;
                    _light.range = _range;
                }
                
            }
            else
            {
                _light2.intensity = 0;
            }
        }

        ChangeColor();

        

    }

    IEnumerator TargetShot(GameObject target)
    {
        target.SetActive(false);

        yield return new WaitForSeconds(3);

        target.SetActive(true);
        _shot = false;
    }

    void ChangeColor(){
        if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    if (_mode)
                        _light.color = _originalColor;
                    else
                        _light2.color = _originalColor;
                }

                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    if (_mode)
                        _light.color = Color.red;
                    else
                        _light2.color = Color.red;
                }

                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    if (_mode)
                        _light.color = Color.green;
                    else
                        _light2.color = Color.green;
                }

                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    if (_mode)
                        _light.color = Color.blue;
                    else
                        _light2.color = Color.blue;
                }

                if (Input.GetKeyDown(KeyCode.R))
                {
                    _mode = !_mode;
                }

    }

    void Shot(){
        var ray = new Ray(_firePoint.position, _firePoint.forward);
        if (_mode)
        {
            _light.spotAngle = _angle;
            _light.intensity = _shootingIntensity;
        }
        else
        {
            _light2.spotAngle = _angle;
            _light2.intensity = _shootingIntensity;
        }
        
        if (Physics.Raycast(ray, out hit, range))
        {
            if(hit.transform.gameObject.tag == "Enemy"){
                MeshRenderer rend = hit.transform.GetComponentInChildren<MeshRenderer>();
                if(AreEqualColors(_light.color, rend.material.color)){
                    EnemyController enemy = hit.transform.GetComponent<EnemyController>();
                    if(enemy != null){
                        enemy.TakeDamage(damage);
                    }

                }

            }
        }

    }
    

    public void SetLightColor(Color wheelButtonColor)
    {
            _light.color = wheelButtonColor;
            _light2.color = wheelButtonColor;
    }

    bool AreEqualColors(Color lightColor, Color enemyColor){
        if(lightColor.r == enemyColor.r && lightColor.g == enemyColor.g && lightColor.b == enemyColor.b){
            return true;
        }
        return false;
    }

}
