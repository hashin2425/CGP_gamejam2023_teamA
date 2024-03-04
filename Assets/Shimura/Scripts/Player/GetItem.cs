using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameData.ConstSettings;

public class GetItem : MonoBehaviour
{
    [SerializeField] GManager gManager;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    //何かがGetItemAreaのCollider内に入ったら発動
    void OnTriggerEnter(Collider other)
    {
        //その何かのtagがitemのとき
        if(other.gameObject.CompareTag("item"))
        {
            //ここに獲得したときの処理
            Items item = Items.Mouse;
            //オブジェクトの名前と名前空間のItemsと比較
            switch (other.gameObject.name)
            {
                case "Nezumi":
                    item = Items.Mouse;break;
                case "Sakana":
                    item = Items.Swordfish;break;
                case "Runba":
                    item = Items.Roomba;break;
                case "Matatabi":
                    item = Items.Matatabi;break;
                case "Kandume":
                    item = Items.CannedFood;break;
                case "Kingyobati":
                    item = item = Items.GoldfishBowl;break;
                case "Dorayaki":
                    item = Items.Dorayaki;break;
                case "Kyuuri":
                    item = Items.Cucumber;break;
                case "Geta":
                    item = Items.Geta;break;
                case "Nekozyarasi":
                    item = Items.BristleGrass;break;
                case "Koban":
                    item = Items.Koban;break;
                case "Shinzyu":
                    item = Items.Pearl;break;
                case "Makimono":
                    item = Items.Scroll;break;
                case "Katsuobushi":
                    item = Items.BonitoFlakes;break;
                case "Suzu":
                    item = Items.Bell;break;
            }
            gManager.CollectItem(item);
            Destroy(other.gameObject);
        }
    }

    

}
