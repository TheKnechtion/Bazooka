using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class EnemyDatabase
{
    
    private List<string> statTxtData = null;

    Importer importer = new Importer();

    List<string> statsHolder = new List<string>();

    string tempLine;

    int increment = 0;

    EnemyInfo tempEnemyInfo;


    public EnemyDatabase()
    {
        enemyDatabase = new List<EnemyInfo>();

        ImportData();


        /*
        knight.name = tempEnemyInfo.name;
        knight.HP = tempEnemyInfo.HP;
        knight.MP = tempEnemyInfo.MP;
        knight.AP = tempEnemyInfo.AP;
        knight.DEF = tempEnemyInfo.DEF;
        knight.weaponNameFromString = tempEnemyInfo.name;
         */

    }

    public List<EnemyInfo> enemyDatabase { get; set; }

    void ImportData()
    {
        statTxtData = importer.Import("Stats.txt");

        //the current line in the imported file
        tempLine = statTxtData[0];


        tempEnemyInfo = new EnemyInfo();


        for (int i = 0; i < tempLine.Length; i++)
        {
            if (tempLine[i] == ' ')
            {
                increment++;
            }

            //get name
            tempEnemyInfo.name = (increment == 0) ? tempEnemyInfo.name + tempLine[i] : tempEnemyInfo.name;

            //get HP
            tempEnemyInfo.HP = (increment == 1) ? int.Parse(tempEnemyInfo.HP.ToString() + tempLine[i]) : tempEnemyInfo.HP;

            //get MP
            tempEnemyInfo.MP = (increment == 2) ? int.Parse(tempEnemyInfo.MP.ToString() + tempLine[i]) : tempEnemyInfo.MP;

            //get AP
            tempEnemyInfo.AP = (increment == 3) ? int.Parse(tempEnemyInfo.MP.ToString() + tempLine[i]) : tempEnemyInfo.AP;

            //get DEF
            tempEnemyInfo.DEF = (increment == 4) ? int.Parse(tempEnemyInfo.DEF.ToString() + tempLine[i]) : tempEnemyInfo.DEF;

        }


        enemyDatabase.Add(tempEnemyInfo);


        tempEnemyInfo = null;
    }


}
