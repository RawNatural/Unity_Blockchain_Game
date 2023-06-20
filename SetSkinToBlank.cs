using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


//Used by metadata class for storing attributes
public class Attributes
{
    //The type or name of a given trait
    public string trait_type;
    //The value associated with the trait_type
    public string value;
}

//Used for storing NFT metadata from standard NFT json files
public class Metadata
{
    //List storing attributes of the NFT
    public List<Attributes> attributes { get; set; }
    //Description of the NFT
    public string description { get; set; }
    //An external_url related to the NFT (often a website)
    public string external_url { get; set; }
    //image stores the NFTs URI for image NFTs
    public string image { get; set; }
    //Name of the NFT
    public string name { get; set; }
}

//Interacting with blockchain
public class SetSkinToBlank : MonoBehaviour
{
    //The chain to interact with, using Polygon here
    public string chain = "polygon";
    //The network to interact with (mainnet, testnet)
    public string network = "testnet";
    //Contract to interact with, contract below is "Project: Pigeon Smart Contract"
    public string contract = "0x99ada1af5bc9bce1b2b2b80c8d0e3abf9cc18057";
    //Token ID to pull from contract
    public string tokenId = "4";
    //Used for storing metadata
    Metadata metadata;

    private void Start()
    {
        print("BCInteract started");
        //Starts async function to get the NFT image
        GetNFTImage();
    }

    async private void GetNFTImage()
    {
        //Interacts with the Blockchain to find the URI related to that specific token
        string URI = await ERC721.URI(chain, network, contract, tokenId);

        //Perform webrequest to get JSON file from URI
        using (UnityWebRequest webRequest = UnityWebRequest.Get(URI))
        {
            //Sends webrequest
            await webRequest.SendWebRequest();
            //Gets text from webrequest
            string metadataString = webRequest.downloadHandler.text;
            print("metadataString " + metadataString);
            //Converts the metadata string to the Metadata object
            metadata = JsonConvert.DeserializeObject<Metadata>(metadataString);
            print("metadata: " + metadata);
        }

        //Performs another web request to collect the image related to the NFT
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(metadata.image))
        {
            //Sends webrequest
            await webRequest.SendWebRequest();
            //Gets the image from the web request and stores it as a texture
            Texture texture = DownloadHandlerTexture.GetContent(webRequest);
            //Sets the objects main render material to the texture
            GetComponent<MeshRenderer>().material.mainTexture = texture;
        }

    }
}
