using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BreatheLogic : MonoBehaviour
{
    [SerializeField] Transform _breathContainer;
    [SerializeField] Color _idleColor;
    [SerializeField] Color _breathInColor;
    [SerializeField] Color _breathOutColor;
    [SerializeField] Animator _breathAnim;

    private int _cycle = 0;
    private bool _newCycle = false;
    private int _clickCycle = 0;

    float _lastEarnedKarma;
    float _karmaEarnDelay = 3f;
    int _karmaEarnAmount = 1;

    float _lastEarnedChi;
    float _chiEarnDelay = 0.5f;
    int _chiEarnAmount = 1;

    double _karma = 0;
    double _chi = 0;

    bool _multiplyEarnings = false;

    float _karmaMultiplier = 0.2f;
    float _chiMultiplier = 0.2f;

    [SerializeField] TMP_Text _karmaText;
    [SerializeField] TMP_Text _chiText;

    [SerializeField] Camera _cam;

    float _camFOVTarget;
    float _camFOVNormal = 50f;
    float _camFOVFocus = 53f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = GetTime();
        UpdateUI(t);
        ManageInputs(t);
        PassiveEarnings();
        HandleCameraFocus();
    }

    private void HandleCameraFocus()
    {
        _camFOVTarget = _multiplyEarnings ? _camFOVFocus : _camFOVNormal;
        float diff = _camFOVTarget - _cam.fieldOfView;
        _cam.fieldOfView += diff * Time.deltaTime * 2;
    }

    private void PassiveEarnings ()
    {
        IdleData.CHI += IdleData.GetChiAmount() * (_multiplyEarnings ? IdleData.GetChiMultiplier() : 1) * Time.deltaTime * IdleData.GetChiSpeed();

        Debug.Log(IdleData.CHI);

        // Karma : convertit automatiquement une petite partie du Chi en Karma
        double karmaGain = IdleData.GetKarmaAmount() * (_multiplyEarnings ? IdleData.GetKarmaMultiplier() : 1) * Time.deltaTime * 0.1;
        IdleData.KARMA += karmaGain;
        IdleData.CHI -= karmaGain; // optionnel : si tu veux que �a co�te du chi

        /*
        float chiDelay = _chiEarnDelay * (_multiplyEarnings ? _chiMultiplier : 1f);
        float karmaDelay = _karmaEarnDelay * (_multiplyEarnings ? _karmaMultiplier : 1f);
        if (Time.time > _lastEarnedChi + chiDelay)
        {
            _lastEarnedChi = Time.time;
            _chi += _chiEarnAmount;
            Debug.Log(chiDelay);
        }
        if (Time.time > _lastEarnedKarma + karmaDelay)
        {
            _lastEarnedKarma = Time.time;
            _karma += _karmaEarnAmount;
        }
        */
        UpdateTexts();
    }

    void UpdateTexts ()
    {
        _karmaText.color = _multiplyEarnings ? _breathInColor : Color.white;
        _chiText.color = _multiplyEarnings ? _breathInColor : Color.white;
        _karmaText.text = UnitsFormatter.Format(IdleData.KARMA);
        _chiText.text = UnitsFormatter.Format(IdleData.CHI);
    }

    void UpdateUI (float t)
    {
        for(int i = 0; i < _breathContainer.childCount; i++)
        {
            Image c = _breathContainer.GetChild(i).gameObject.GetComponent<Image>();
            if (t < 0.5f)
            {
                float r = ((float)i / (float)_breathContainer.childCount) * 0.4f;
                c.color = t > r ? _breathInColor : _idleColor;
            } else
            {
                float r = ((float)(_breathContainer.childCount - 1f - (float)i) / (float)_breathContainer.childCount) * 0.4f;
                c.color = t >= 0.5f + r ? _idleColor : _breathOutColor;
            }
        }
    }

    void ManageInputs (float t)
    {
        _multiplyEarnings = false; 
        if (t < 0.5f)
        {
            if (_newCycle)
            {
                _cycle += 1;
                _newCycle = false;
            }
            if (Input.GetMouseButton(0) == false)
            {
                _clickCycle = _cycle;
            }
            if (_clickCycle == _cycle)
            {
                if (Input.GetMouseButton(0) == true && Input.mousePosition.x < Screen.width / 2)
                {
                    _multiplyEarnings = true;
                }
            }
        } else
        {
            if (t > 0.9f) {
                _newCycle = true;
                if (Input.GetMouseButton(0) == false)
                {
                    _clickCycle = _cycle + 1;
                }
            } 
        }
    }

    private void MultiplyEarnings()
    {

    }

    private float GetTime ()
    {
        AnimatorStateInfo stateInfo = _breathAnim.GetCurrentAnimatorStateInfo(0);
        float normalizedTime = stateInfo.normalizedTime;
        return normalizedTime % 1;
    }
}
