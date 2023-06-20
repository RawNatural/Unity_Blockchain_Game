using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mintSktNFT : MonoBehaviour
{
    // Start is called before the first frame update
    public void mint()
    {
        SendMint sendmint = new SendMint("0xE6E7bbc417040e1cD7d8fadcB3Cc5Ba2D9A459F3", "Qmb1dKFo1YmUdhNAzZkGntJfW1w61BUPhRoL3P92P5tDqt");
        sendmint.OnSendContract();
    }

}
