using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleObject {

    private int numberOfDamagedEquip;

    private int poleMaterial;        //0 = wood, 1 = concrete
    private int poleDamage;
    private string insulatorType;    //V, M, T, SC, DC   
    private int insulatorMaterial;   //0 for ..., 1 for polymer
    private bool insulatorA;
    private bool insulatorB;
    private bool insulatorC;
    private int insulatorDamage;

    private int deadendInsulator;
    private int capacitorBank;
    private int transformer;
    private int fuseSwitch;
    private int lightningArrester;
    private int recloser;
    private int afs;
    private int automaticLineSwitch;
    private int pothead;
    private int disconnectSwitch;
    private int palm;
    private int oak;
    private int downguy;
    private int fci;
    private bool splice;
    private bool balloon;
    private bool nest;
    private bool kite;

    private bool deadendInsulatorSpawn;
    private bool capacitorBankSpawn;
    private bool transformerSpawn;
    private bool fuseSwitchSpawn;
    private bool lightningArresterSpawn;
    private bool recloserSpawn;
    private bool afsSpawn;
    private bool automaticLineSwitchSpawn;
    private bool potheadSpawn;
    private bool disconnectSwitchSpawn;
    private bool palmSpawn;
    private bool oakSpawn;
    private bool downguySpawn;
    private bool fciSpawn;
    private bool spliceSpawn;
    private bool balloonSpawn;
    private bool nestSpawn;
    private bool kiteSpawn;

    private int equipmentType;
    private int transformerCount;

    public ArrayList listOfDamagedEquip = new ArrayList();

    public PoleObject() {

        numberOfDamagedEquip = 0;

        poleMaterial = 0;
        insulatorType = "null";
        insulatorMaterial = 0;
        insulatorA = false;
        insulatorB = false;
        insulatorC = false;
        insulatorDamage = 0;

        deadendInsulator = 0;

        capacitorBank = 0;
        transformer = 0;
        fuseSwitch = 0;
        lightningArrester = 0;
        recloser = 0;
        afs = 0;
        automaticLineSwitch = 0;
        pothead = 0;
        disconnectSwitch = 0;
        palm = 0;
        oak = 0;
        downguy = 0;
        fci = 0;

        splice = false;
        balloon = false;
        nest = false;
        kite = false;

        equipmentType = 0;
        transformerCount = 0;

        listOfDamagedEquip = null;

    }
    public void setNumberOfDamagedEquip(int i)
    {
        this.numberOfDamagedEquip = i;
    }
    public int getNumberOfDamagedEquip()
    {
        return this.numberOfDamagedEquip;
    }

    public void setPoleMaterial(int i) {
        this.poleMaterial = i;
    }
    public int getPoleMaterial() {
        return this.poleMaterial;
    }

    public void setInsulatorType(string i) {
        this.insulatorType = i;
    }
    public string getInsulatorType() {
        return this.insulatorType;
    }
    
    public void setInsulatorDamage(int i)
    {
        this.insulatorDamage = i;
    }
    public int getInsulatorDamage()
    {
        return this.insulatorDamage;
    }

    public void setInsulatorA(bool i)
    {
        this.insulatorA = true;
    }

    public bool getInsulatorA(bool i)
    {
        return this.insulatorA;
    }

    public void setInsulatorB(bool i)
    {
        this.insulatorB = true;
    }

    public bool getInsulatorB(bool i)
    {
        return this.insulatorB;
    }

    public void setInsulatorC(bool i)
    {
        this.insulatorC = true;
    }

    public bool getInsulatorC(bool i)
    {
        return this.insulatorC;
    }

    public void setEquipmentType(int i) {
        this.equipmentType = i;
        if (i == 2) {
            setTransformerCount(Random.Range(1, 4));
        }
    }
    public int getEquipmentType() {
        return this.equipmentType;
    }

    public void setInsulatorMaterial (int i)
    {
        this.insulatorMaterial = i;
    }
    public int getInsulatorMaterial()
    {
        return this.insulatorMaterial;
    }

    public void setCapacitorBank(int i)
    {
        this.capacitorBank = i;
    }
    public int getCapacitorBank()
    {
        return this.capacitorBank;
    }
    public void setFuseSwitch(int i){
        this.fuseSwitch = i;
    }
    public int getFuseSwitch()
    {
        return this.fuseSwitch;
    }
    public void setTransformerCount(int i) {
        this.transformerCount = i;
    }
    public int getTransformerCount() {
        return this.transformerCount;
    }

    public void setTransformer(int i)
    {
        this.transformer = i;
    }
    public int getTransformer()
    {
        return this.transformer;
    }

    public void setRecloser(int i)
    {
        this.recloser = i;
    }
    public int getRecloser()
    {
        return this.recloser;
    }

    public void setAfs(int i)
    {
        this.afs = i;
    }
    public int getAfs()
    {
        return this.afs;
    }

    public void setPothead(int i)
    {
        this.pothead = i;
    }
    public int getPothead()
    {
        return this.pothead;
    }

    public void setDisconnectSwitch(int i)
    {
        this.disconnectSwitch = i;
    }
    public int getDisconnectSwitch()
    {
        return this.disconnectSwitch;
    }

    public void setAutomaticLineSwitch(int i)
    {
        this.automaticLineSwitch = i;
    }
    public int getAutomaticLineSwitch()
    {
        return this.automaticLineSwitch;
    }
    public void setLightningArrestor(int i)
    {
        this.lightningArrester = i;
    }
    public int getLightningArrestor()
    {
        return this.lightningArrester;
    }


    public void setFci(int i)
    {
        this.fci = i;
    }

    public int getFci(int i)
    {
        return this.fci;
    }


    public void setPalm(int i) {
        this.palm = i;
    }

    public int getPalm(int i) {
        return this.palm;
    }

    public void setOak(int i)
    {
        this.palm = i;
    }

    public int getOak(int i)
    {
        return this.palm;
    }

    public void setBallon(bool i)
    {
        this.balloon =true;
    }

    public bool getBalloon(bool i)
    {
        return this.balloon;
    }

    public void setSplice(bool i)
    {
        this.balloon = true;
    }

    public bool getSplice(bool i)
    {
        return this.splice;
    }

    public void setNest(bool i)
    {
        this.nest = true;
    }

    public bool getNest(bool i)
    {
        return this.nest;
    }

    public void setKite(bool i)
    {
        this.kite = true;
    }

    public bool getkite(bool i)
    {
        return this.kite;
    }

    public void setDamageToItems() {
        //NO DAMAGE
        if (getNumberOfDamagedEquip() == 0) {
            int tempRand = Random.Range(0, 2);
            if (tempRand == 0)
                setPalm(0);
            else if (tempRand == 1)
                setOak(0);
            else if (tempRand == 2)
                setFci(0);
            else if (tempRand == 3)
                return;
        }
        //getNumberOfDamagedEquip != 0
        else
        { 
            assignRandomEquip();
        }
        //Debug.Log("inner loop bug");
    }

    public void assignRandomEquip() {

        if (getEquipmentType() == 0) {
            return;
        }
        //Capacitor bank
        if (getEquipmentType() == 1) {
            randomCapacitor();
        }
        //Transformer
        else if (getEquipmentType() == 2) {
            randomTransformer();
        }
        //Recloser
        else if (getEquipmentType() == 3) { 
            randomRecloser();
        }
        //AFS
        else if (getEquipmentType() == 4) { 
            randomAfs();
        }
        //Pothead + dcswitch
        else if (getEquipmentType() == 5) { 
            randomPotheadDcswitch();
        }
        //Automatic line Switch
        else if (getEquipmentType() == 6) { 
            randomAutomaticLineSwitch();
        }
        //Lightning Arrestor
        else if (getEquipmentType() == 7) { 
            randomLightningArrestor();
        }
        else
            Debug.Log("Bug happened");
    }

    //Insulator
    public void randomAssignInsulator(int x) {
        if (x == 1) {
            int temp = Random.Range(1, 4);
            if (temp == 1)
                setInsulatorA(true);
            else if (temp == 2)
                setInsulatorB(true);
            else if (temp == 3)
                setInsulatorC(true);
        }
        else if (x == 2) {
            int temp = Random.Range(1, 4);
            if (temp == 1)
            {
                setInsulatorA(true);
                setInsulatorB(true);
            }
            else if (temp == 2)
            {
                setInsulatorB(true);
                setInsulatorC(true);
            }
            else if (temp == 3)
            {
                setInsulatorA(true);
                setInsulatorC(true);
            }
        }
        else if (x == 3) {
            setInsulatorA(true);
            setInsulatorB(true);
            setInsulatorC(true);
        }

    }


    public void randomCapacitor() {
        int n = 0;
        List<string> tempArray = new List<string>();

        //CapacitorBank
        while (n < getNumberOfDamagedEquip() ) {

            start:
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Capictorbank"))
            {
                setCapacitorBank(tempSev);
                tempArray.Add("Capictorbank");
                n++;
            }
            else if (tempEquipType == 1 && !tempArray.Contains("Fuseswitch"))
            {
                setFuseSwitch(tempSev);
                tempArray.Add("Fuseswitch");
                n++;
            }
            else if (tempEquipType == 2 )
            {
                int tempEquip = Random.Range(2, 10);
                int tempInt = Random.Range(1, 4);
                if (tempEquip == 2 && !tempArray.Contains("Insulator"))
                {
                    setInsulatorDamage(tempInt);
                    tempArray.Add("Insulator");
                    int tempIns = Random.Range(1, 4);
                    int tempMat = Random.Range(0, 2);
                    setInsulatorMaterial(tempMat);
                    randomAssignInsulator(tempIns);
                    n++;
                }
                else if (tempEquip == 3 && !tempArray.Contains("Fci"))
                {
                    setFci(tempInt);
                    tempArray.Add("Fci");
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm")) 
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    n++;
                }
            }
            else
                goto start;
        }
        Debug.Log("DMG ARRAY"+ tempArray);
    }

    public void randomTransformer()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        //CapacitorBank
        while (n < getNumberOfDamagedEquip())
        {
            start:
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Transformer"))
            {
                setTransformer(tempSev);
                tempArray.Add("Transformer");
                n++;
            }
            else if (tempEquipType == 1 && !tempArray.Contains("Fuseswitch"))
            {
                setFuseSwitch(tempSev);
                tempArray.Add("Fuseswitch");
                n++;
            }
            else if (tempEquipType == 2)
            {
                int tempEquip = Random.Range(2, 10);
                int tempInt = Random.Range(1, 4);
                if (tempEquip == 2 && !tempArray.Contains("Insulator"))
                {
                    setInsulatorDamage(tempInt);
                    tempArray.Add("Insulator");
                    int tempIns = Random.Range(1, 4);
                    int tempMat = Random.Range(0, 2);
                    setInsulatorMaterial(tempMat);
                    randomAssignInsulator(tempIns);
                    n++;
                }
                else if (tempEquip == 3 && !tempArray.Contains("Fci"))
                {
                    setFci(tempInt);
                    tempArray.Add("Fci");
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    n++;
                }
            }
            else
                goto start;
        }
        Debug.Log("DMG ARRAY" + tempArray);
    }

    //Recloser
    public void randomRecloser()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        //CapacitorBank
        while (n < getNumberOfDamagedEquip())
        {
            start:
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Recloser"))
            {
                setRecloser(tempSev);
                tempArray.Add("Recloser");
                n++;
            }
            else if (tempEquipType == 1)
            {
                int tempEquip = Random.Range(2, 10);
                int tempInt = Random.Range(1, 4);
                if (tempEquip == 2 && !tempArray.Contains("Insulator"))
                {
                    setInsulatorDamage(tempInt);
                    tempArray.Add("Insulator");
                    int tempIns = Random.Range(1, 4);
                    int tempMat = Random.Range(0, 2);
                    setInsulatorMaterial(tempMat);
                    randomAssignInsulator(tempIns);
                    n++;
                }
                else if (tempEquip == 3 && !tempArray.Contains("Fci"))
                {
                    setFci(tempInt);
                    tempArray.Add("Fci");
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    n++;
                }
            }
            else
                goto start;
        }
        Debug.Log("DMG ARRAY" + tempArray);
    }

    //Afs
    public void randomAfs()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        while (n < getNumberOfDamagedEquip())
        {
            start:
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Afs"))
            {
                setAfs(tempSev);
                tempArray.Add("Afs");
                n++;
            }
            else if (tempEquipType == 1)
            {
                int tempEquip = Random.Range(2, 10);
                int tempInt = Random.Range(1, 4);
                if (tempEquip == 2 && !tempArray.Contains("Insulator"))
                {
                    setInsulatorDamage(tempInt);
                    tempArray.Add("Insulator");
                    int tempIns = Random.Range(1, 4);
                    int tempMat = Random.Range(0, 2);
                    setInsulatorMaterial(tempMat);
                    randomAssignInsulator(tempIns);
                    n++;
                }
                else if (tempEquip == 3 && !tempArray.Contains("Fci"))
                {
                    setFci(tempInt);
                    tempArray.Add("Fci");
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    n++;
                }
            }
            else
                goto start;
        }
        Debug.Log("DMG ARRAY" + tempArray);
    }

    //randomPotheadDcswitch();
    public void randomPotheadDcswitch()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        while (n < getNumberOfDamagedEquip())
        {
            start:
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Pothead"))
            {
                setPothead(tempSev);
                tempArray.Add("Pothead");
                n++;
            }
            else if(tempEquipType == 1 && !tempArray.Contains("Disconnectswitch"))
            {
                setDisconnectSwitch(tempSev);
                tempArray.Add("Disconnectswitch");
                n++;
            }
            else if (tempEquipType == 2)
            {
                int tempEquip = Random.Range(2, 10);
                int tempInt = Random.Range(1, 4);
                if (tempEquip == 2 && !tempArray.Contains("Insulator"))
                {
                    setInsulatorDamage(tempInt);
                    tempArray.Add("Insulator");
                    int tempIns = Random.Range(1, 4);
                    int tempMat = Random.Range(0, 2);
                    setInsulatorMaterial(tempMat);
                    randomAssignInsulator(tempIns);
                    n++;
                }
                else if (tempEquip == 3 && !tempArray.Contains("Fci"))
                {
                    setFci(tempInt);
                    tempArray.Add("Fci");
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    n++;
                }
            }
            else
                goto start;
        }
        Debug.Log("DMG ARRAY" + tempArray);
    }
    //randomAutomaticLineSwitch
    public void randomAutomaticLineSwitch()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        while (n < getNumberOfDamagedEquip())
        {
            start:
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Automaticlineswitch"))
            {
                setAutomaticLineSwitch(tempSev);
                tempArray.Add("Automaticlineswitch");
                n++;
            }
            else if (tempEquipType == 1)
            {
                int tempEquip = Random.Range(2, 10);
                int tempInt = Random.Range(1, 4);
                if (tempEquip == 2 && !tempArray.Contains("Insulator"))
                {
                    setInsulatorDamage(tempInt);
                    tempArray.Add("Insulator");
                    int tempIns = Random.Range(1, 4);
                    int tempMat = Random.Range(0, 2);
                    setInsulatorMaterial(tempMat);
                    randomAssignInsulator(tempIns);
                    n++;
                }
                else if (tempEquip == 3 && !tempArray.Contains("Fci"))
                {
                    setFci(tempInt);
                    tempArray.Add("Fci");
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    n++;
                }
            }
            else
                goto start;
        }
        Debug.Log("DMG ARRAY" + tempArray);
    }

    //LightningArrestor()
    public void randomLightningArrestor()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        while (n < getNumberOfDamagedEquip())
        {
            start:
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Lightningarrestor"))
            {
                setAutomaticLineSwitch(tempSev);
                tempArray.Add("Lightningarrestor");
                n++;
            }
            else if (tempEquipType == 1)
            {
                int tempEquip = Random.Range(2, 10);
                int tempInt = Random.Range(1, 4);
                if (tempEquip == 2 && !tempArray.Contains("Insulator"))
                {
                    setInsulatorDamage(tempInt);
                    tempArray.Add("Insulator");
                    int tempIns = Random.Range(1, 4);
                    int tempMat = Random.Range(0, 2);
                    setInsulatorMaterial(tempMat);
                    randomAssignInsulator(tempIns);
                    n++;
                }
                else if (tempEquip == 3 && !tempArray.Contains("Fci"))
                {
                    setFci(tempInt);
                    tempArray.Add("Fci");
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    n++;
                }
            }
            else
                goto start;
        }
        Debug.Log("DMG ARRAY" + tempArray);
    }

    public void writeList(ArrayList list) {
        foreach (int i in list) {
            Debug.Log(i);
        }

    }

}
