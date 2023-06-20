using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callMintContructor : MonoBehaviour
{
    // Start is called before the first frame update
    public void SendMintConstructor()
    {
        print("hi");
        /*
         * This one calls mint for ice cream cone (THIS ONE WORKS)
         */
        SendMint sendmint = new SendMint("0xE6E7bbc417040e1cD7d8fadcB3Cc5Ba2D9A459F3", "data:application/json;base64,ewoJIm5hbWUiOiAiQ29uc3RydWN0b3IgdGVzdCIsCgkiZGVzY3JpcHRpb24iOiAiTkZULCBiZWluZyBtaW50ZWQgYnkgY2FsbGluZyBtaW50IGZyb20gb3RoZXIgZmlsZSIsCgkiaW1hZ2UiOiAiaHR0cHM6Ly9pcGZzLmlvL2lwZnMvUW1Xc2F0UzZleTlrQjYxQmFZa1lKVWRMTGE5OFFOVmJ5b0pTZG5SbVJ6NVZ4cD9maWxlbmFtZT1taWxrc2hha2UucG5nIgp9");
        sendmint.OnSendContract();
        


        /* Here is a test for minting first person test
         */
        /*
        SendMint sendmint = new SendMint("0xE6E7bbc417040e1cD7d8fadcB3Cc5Ba2D9A459F3", "data:application/json;base64,ewogICAgIm5hbWUiOiAiY2Fwc3VsZSBwZXJzb24gdGVzdCIsCiAgICAiZGVzY3JpcHRpb24iOiAiQSB0ZXN0IGZvciBmaXR0aW5nIHBlcnNvbiBpbnRvIGNhcHN1bGUiLAogICAgImltYWdlIjogImh0dHBzOi8vaXBmcy5pby9pcGZzL1FtZUFVMzZuTVR4UVhzMWRWWG9naVgydmlLOWc1S20zRVkxdlR1MTlFWXc2OVM/ZmlsZW5hbWU9Y2Fwc3VsZV90ZXN0LnBuZyIKfQ==");
        sendmint.OnSendContract();
        */
        
        
        /*Sending mint on actual polygon */
        /*
        SendMintPolygonMain sendmint = new SendMintPolygonMain("0x436d4f0Fc6d3f8e01470609e74a0C1E6BE9dCfDD", "data:application/json;base64,ewogICAgIm5hbWUiOiAiTW91bnRhaW5fUGVhayIsCiAgICAiZGVzY3JpcHRpb24iOiAiRmlyc3QgTkZUIGZyb20gZ2FtZSBnb2luZyBvbiBhY3R1YWwgUG9seWdvbiBOZXR3b3JrIiwKICAgICJpbWFnZSI6ICJodHRwczovL2lwZnMuaW8vaXBmcy9RbWVOVzFUQWdFREtEOXpMV0JUUUZCdDRNR1dTQ1VNWmdhSjhaV2NWOXg4aUdyP2ZpbGVuYW1lPW1vdW50YWluLXBlYWsuanBlZyIKfQ==");
        sendmint.OnSendContract();
        */


    }

}
