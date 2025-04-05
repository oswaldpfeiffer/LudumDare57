using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
    }

    private void PassiveEarnings ()
    {
        if (Time.time > _lastEarnedChi + (_chiEarnDelay * (_multiplyEarnings ? _chiMultiplier : 1f)))
        {
            _lastEarnedChi = Time.time;
            _chi += _chiEarnAmount * (_multiplyEarnings ? _chiMultiplier : 1f);
        }
        if (Time.time > _lastEarnedKarma + (_karmaEarnDelay * (_multiplyEarnings ? _karmaMultiplier : 1f)))
        {
            _lastEarnedKarma = Time.time;
            _karma += _karmaEarnAmount;
        }
        UpdateTexts();
    }

    void UpdateTexts ()
    {
        _karmaText.color = _multiplyEarnings ? _breathInColor : Color.white;
        _chiText.color = _multiplyEarnings ? _breathInColor : Color.white;
        _karmaText.text = UnitsFormatter.Format(_karma);
        _chiText.text = UnitsFormatter.Format(_chi);
    }

    void UpdateUI (float t)
    {
        for(int i = 0; i < _breathContainer.childCount; i++)
        {
            SpriteRenderer c = _breathContainer.GetChild(i).gameObject.GetComponent<SpriteRenderer>();
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
                if (Input.GetMouseButton(0) == true)
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
