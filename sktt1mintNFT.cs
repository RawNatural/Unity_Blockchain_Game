using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sktt1mintNFT : MonoBehaviour
{
    // Start is called before the first frame update
    public void SendNFT()
    {                                   //Post contract address here.                   //post metadata JSON here.
        SendMint sendmint = new SendMint("0xE6E7bbc417040e1cD7d8fadcB3Cc5Ba2D9A459F3", "data:application/json;base64,ewoJIm5hbWUiOiAiQ29uc3RydWN0b3IgdGVzdCIsCgkiZGVzY3JpcHRpb24iOiAiTkZULCBiZWluZyBtaW50ZWQgYnkgY2FsbGluZyBtaW50IGZyb20gb3RoZXIgZmlsZSIsCgkiaW1hZ2UiOiAiaHR0cHM6Ly9pcGZzLmlvL2lwZnMvUW1Xc2F0UzZleTlrQjYxQmFZa1lKVWRMTGE5OFFOVmJ5b0pTZG5SbVJ6NVZ4cD9maWxlbmFtZT1taWxrc2hha2UucG5nIgp9");
        sendmint.OnSendContract();
    }

}
