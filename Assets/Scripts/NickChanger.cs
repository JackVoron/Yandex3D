using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NickChanger : MonoBehaviour
{
    [SerializeField] private TMP_Text _nick;
    [SerializeField] private TMP_InputField _input;

    public void ChangeNickname()
    {
        _nick.text = _input.text;
    }
}
