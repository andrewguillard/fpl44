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
    //test if this was pushed

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

    public static List<string> listOfDamagedEquip;

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

        deadendInsulatorSpawn = false;
        capacitorBankSpawn = false;
        transformerSpawn = false;
        fuseSwitchSpawn = false;
        lightningArresterSpawn = false;
        recloserSpawn = false;
        afsSpawn = false;
        automaticLineSwitchSpawn = false;
        potheadSpawn = false;
        disconnectSwitchSpawn = false;
        palmSpawn = false;
        oakSpawn = false;
        downguySpawn = false;
        fciSpawn = false;
        spliceSpawn = false;
        balloonSpawn = false;
        nestSpawn = false;
        kiteSpawn = false;

        equipmentType = 0;
        transformerCount = 0;

        listOfDamagedEquip = new List<string>(); 
    }

    public void setDeadendInsulatorSpawn(bool i)
    {
        this.deadendInsulatorSpawn = i;
    }
    public bool getDeadendInsulatorSpawn()
    {
        return this.deadendInsulatorSpawn;
    }

    public void setCapacitorBankSpawn(bool i)
    {
        this.capacitorBankSpawn = i;
    }
    public bool getCapacitorBankSpawn()
    {
        return this.capacitorBankSpawn;
    }

    public void setTransformerSpawn(bool i)
    {
        this.transformerSpawn = i;
    }
    public bool getsetTransformerSpawn()
    {
        return this.transformerSpawn;
    }

    public void setFuseSwitchSpawn(bool i)
    {
        this.fuseSwitchSpawn = i;
    }
    public bool getFuseSwitchSpawn()
    {
        return this.fuseSwitchSpawn;
    }

    public void setLightningArresterSpawn(bool i)
    {
        this.lightningArresterSpawn = i;
    }
    public bool getLightningArresterSpawn()
    {
        return this.lightningArresterSpawn;
    }

    public void setRecloserSpawn(bool i)
    {
        this.recloserSpawn = i;
    }
    public bool getRecloserSpawn()
    {
        return this.recloserSpawn;
    }

    public void setAfsSpawn(bool i)
    {
        this.afsSpawn = i;
    }
    public bool getAfsSpawn()
    {
        return this.afsSpawn;
    }

    public void setAutomaticLineSwitchSpawn(bool i)
    {
        this.automaticLineSwitchSpawn = i;
    }
    public bool getAutomaticLineSwitchSpawn()
    {
        return this.automaticLineSwitchSpawn;
    }

    public void setPotheadSpawn(bool i)
    {
        this.potheadSpawn = i;
    }
    public bool getPotheadSpawn()
    {
        return this.potheadSpawn;
    }

    public void setDisconnectSwitchSpawn(bool i)
    {
        this.disconnectSwitchSpawn = i;
    }
    public bool getDisconnectSwitchSpawn()
    {
        return this.disconnectSwitchSpawn;
    }

    public void setPalmSpawn(bool i)
    {
        this.palmSpawn = i;
    }
    public bool getPalmSpawn()
    {
        return this.palmSpawn;
    }

    public void setOakSpawn(bool i)
    {
        this.oakSpawn = i;
    }
    public bool getOakSpawn()
    {
        return this.oakSpawn;
    }

    public void setDownguySpawn(bool i)
    {
        this.downguySpawn = i;
    }
    public bool getDownguySpawn()
    {
        return this.downguySpawn;
    }
    public void setFciSpawn(bool i)
    {
        this.fciSpawn = i;
    }
    public bool getFciSpawn()
    {
        return this.fciSpawn;
    }
    public void setSpliceSpawn(bool i)
    {
        this.spliceSpawn = i;
    }
    public bool getSpliceSpawn()
    {
        return this.spliceSpawn;
    }
    public void setBalloonSpawn(bool i)
    {
        this.balloonSpawn = i;
    }
    public bool getBalloonSpawn()
    {
        return this.balloonSpawn;
    }

    public void setNestSpawn(bool i)
    {
        this.nestSpawn = i;
    }
    public bool getNestSpawn()
    {
        return this.nestSpawn;
    }

    public void setKiteSpawn(bool i)
    {
        this.kiteSpawn = i;
    }
    public bool getKiteSpawn()
    {
        return this.kiteSpawn;
    }

    public void setNumberOfDamagedEquip(int i)
    {
        if(getEquipmentType() == 0)
            this.numberOfDamagedEquip = 0;
        else
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

    public void setPoleDamage(int i)
    {
        this.poleDamage = i;
    }
    public int getPoleDamage()
    {
        return this.poleDamage;
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

    public bool getInsulatorA()
    {
        return this.insulatorA;
    }

    public void setInsulatorB(bool i)
    {
        this.insulatorB = true;
    }

    public bool getInsulatorB()
    {
        return this.insulatorB;
    }

    public void setInsulatorC(bool i)
    {
        this.insulatorC = true;
    }

    public bool getInsulatorC()
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

    public int getFci()
    {
        return this.fci;
    }


    public void setPalm(int i) {
        this.palm = i;
    }

    public int getPalm() {
        return this.palm;
    }

    public void setOak(int i)
    {
        this.palm = i;
    }

    public int getOak()
    {
        return this.palm;
    }

    public void setBallon(bool i)
    {
        this.balloon =true;
    }

    public bool getBalloon()
    {
        return this.balloon;
    }

    public void setSplice(bool i)
    {
        this.balloon = true;
    }

    public bool getSplice()
    {
        return this.splice;
    }

    public void setNest(bool i)
    {
        this.nest = true;
    }

    public bool getNest()
    {
        return this.nest;
    }

    public void setKite(bool i)
    {
        this.kite = true;
    }

    public bool getkite()
    {
        return this.kite;
    }

    public void addToDamageList(string p) {
        listOfDamagedEquip.Add(p);
    }

    public List<string> getDamagedList() {
        return listOfDamagedEquip;
    }

    public string[] getDamagedArray()
    {
        return listOfDamagedEquip.ToArray();
    }

    public void printDamagedList() {
        foreach (string i in listOfDamagedEquip)
        {
            Debug.Log(i);
        }
    }

    public void setDamageToItems() {
        //NO DAMAGE
        if (getNumberOfDamagedEquip() == 0) {
            addToDamageList("There is no damage");
            int tempRand = Random.Range(0, 5);
            if (tempRand == 0) { 
                setPalm(0);
                setPalmSpawn(true);
            }
            else if (tempRand == 1) {
                setOak(0);
                setOakSpawn(true);
            }
            else if (tempRand == 2) { 
                setFci(0);
                setFciSpawn(true);
            }
            else if (tempRand == 3)
                return;
        }
        else
        { 
            assignRandomEquip();
        }
    }

    public void assignRandomEquip() {
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
        else { 
            Debug.Log("Bug happened");
            addToDamageList("This is a bug");
        }
    }

    //Insulator
    public void randomAssignInsulator(int x) {
        if (x == 1) {
            int temp = Random.Range(1, 4);
            if (temp == 1) { 
            setInsulatorA(true);
            addToDamageList("InsulatorA"+" sevlevel "+getInsulatorDamage());
            }
        else if (temp == 2) { 
            setInsulatorB(true);
            addToDamageList("InsulatorB" + " sevlevel " + getInsulatorDamage());
            }
            else if (temp == 3) { 
            setInsulatorC(true);
            addToDamageList("InsulatorC" + " sevlevel " + getInsulatorDamage());
            }
        }
        else if (x == 2) {
            int temp = Random.Range(1, 4);
            if (temp == 1)
            {
                setInsulatorA(true);
                setInsulatorB(true);
                addToDamageList("InsulatorA" + " sevlevel " + getInsulatorDamage());
                addToDamageList("InsulatorB" + " sevlevel " + getInsulatorDamage());
            }
            else if (temp == 2)
            {
                setInsulatorB(true);
                setInsulatorC(true);
                addToDamageList("InsulatorB" + " sevlevel " + getInsulatorDamage());
                addToDamageList("InsulatorC" + " sevlevel " + getInsulatorDamage());
            }
            else if (temp == 3)
            {
                setInsulatorA(true);
                setInsulatorC(true);
                addToDamageList("InsulatorA" + " sevlevel " + getInsulatorDamage());
                addToDamageList("InsulatorC" + " sevlevel " + getInsulatorDamage());
            }
        }
        else if (x == 3) {
            setInsulatorA(true);
            setInsulatorB(true);
            setInsulatorC(true);
            addToDamageList("InsulatorA" + " sevlevel " + getInsulatorDamage());
            addToDamageList("InsulatorB" + " sevlevel " + getInsulatorDamage());
            addToDamageList("InsulatorC" + " sevlevel " + getInsulatorDamage());
        }
    }


    public void randomCapacitor() {
        int n = 0;
        List<string> tempArray = new List<string>();

        //CapacitorBank
        while (n < getNumberOfDamagedEquip() ) {

            //start:
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Capictorbank"))
            {
                setCapacitorBank(tempSev);
                tempArray.Add("Capictorbank");
                addToDamageList("Capictorbank");
                addToDamageList(tempSev.ToString());
                n++;
            }
            else if (tempEquipType == 1 && !tempArray.Contains("Fuseswitch"))
            {
                setFuseSwitch(tempSev);
                tempArray.Add("Fuseswitch");
                addToDamageList("Fuseswitch");
                addToDamageList(tempSev.ToString());
                n++;
            }
            else if (tempEquipType == 2 )
            {
                int tempEquip = Random.Range(2, 11);
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
                    addToDamageList("Fci");
                    addToDamageList("true");
                    setFciSpawn(true);
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    addToDamageList("Splice");
                    addToDamageList("true");
                    setSpliceSpawn(true);
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    addToDamageList("Balloon");
                    addToDamageList("true");
                    setBalloonSpawn(true);
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    addToDamageList("Palm");
                    addToDamageList("true");
                    setPalmSpawn(true);
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    addToDamageList("Nest");
                    addToDamageList("true");
                    setNestSpawn(true);
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    addToDamageList("Oak");
                    addToDamageList("true");
                    setOakSpawn(true);
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    addToDamageList("Kite");
                    addToDamageList("true");
                    setKiteSpawn(true);
                    n++;
                }
                else if (tempEquip == 10 && !tempArray.Contains("Pole"))
                {
                    setPoleDamage(tempInt);
                    tempArray.Add("Pole");
                    addToDamageList("Pole");
                    addToDamageList(tempSev.ToString());
                    n++;
                }
            }
        }
    }

    public void randomTransformer()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        //CapacitorBank
        while (n < getNumberOfDamagedEquip())
        {
            //start:
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Transformer"))
            {
                setTransformer(tempSev);
                tempArray.Add("Transformer");
                addToDamageList("Transformer");
                addToDamageList(tempSev.ToString());
                n++;
            }
            else if (tempEquipType == 1 && !tempArray.Contains("Fuseswitch"))
            {
                setFuseSwitch(tempSev);
                tempArray.Add("Fuseswitch");
                addToDamageList("Fuseswitch");
                addToDamageList(tempSev.ToString());
                n++;
            }
            else if (tempEquipType == 2)
            {
                int tempEquip = Random.Range(2, 11);
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
                    addToDamageList("Fci");
                    addToDamageList("true");
                    setFciSpawn(true);
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    addToDamageList("Splice");
                    addToDamageList("true");
                    setSpliceSpawn(true);
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    addToDamageList("Balloon");
                    addToDamageList("true");
                    setBalloonSpawn(true);
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    addToDamageList("Palm");
                    addToDamageList("true");
                    setPalmSpawn(true);
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    addToDamageList("Nest");
                    addToDamageList("true");
                    setNestSpawn(true);
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    addToDamageList("Oak");
                    addToDamageList("true");
                    setOakSpawn(true);
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    addToDamageList("Kite");
                    addToDamageList("true");
                    setKiteSpawn(true);
                    n++;
                }
                else if (tempEquip == 10 && !tempArray.Contains("Pole"))
                {
                    setPoleDamage(tempInt);
                    tempArray.Add("Pole");
                    addToDamageList("Pole");
                    addToDamageList(tempSev.ToString());
                    n++;
                }
            }
        }
    }

    //Recloser
    public void randomRecloser()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        //CapacitorBank
        while (n < getNumberOfDamagedEquip())
        {
            //start:
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Recloser"))
            {
                setRecloser(tempSev);
                tempArray.Add("Recloser");
                addToDamageList("Recloser");
                addToDamageList(tempSev.ToString());
                n++;
            }
            else if (tempEquipType == 1)
            {
                int tempEquip = Random.Range(2, 11);
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
                    addToDamageList("Fci");
                    addToDamageList("true");
                    setFciSpawn(true);
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    addToDamageList("Splice");
                    addToDamageList("true");
                    setSpliceSpawn(true);
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    addToDamageList("Balloon");
                    addToDamageList("true");
                    setBalloonSpawn(true);
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    addToDamageList("Palm");
                    addToDamageList("true");
                    setPalmSpawn(true);
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    addToDamageList("Nest");
                    addToDamageList("true");
                    setNestSpawn(true);
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    addToDamageList("Oak");
                    addToDamageList("true");
                    setOakSpawn(true);
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    addToDamageList("Kite");
                    addToDamageList("true");
                    setKiteSpawn(true);
                    n++;
                }
                else if (tempEquip == 10 && !tempArray.Contains("Pole"))
                {
                    setPoleDamage(tempInt);
                    tempArray.Add("Pole");
                    addToDamageList("Pole");
                    addToDamageList(tempSev.ToString());
                    n++;
                }
            }
        }
    }

    //Afs
    public void randomAfs()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        while (n < getNumberOfDamagedEquip())
        {
            //start:
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Afs"))
            {
                setAfs(tempSev);
                tempArray.Add("Afs");
                addToDamageList("Afs");
                addToDamageList(tempSev.ToString());
                n++;
            }
            else if (tempEquipType == 1)
            {
                int tempEquip = Random.Range(2, 11);
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
                    addToDamageList("Fci");
                    setFciSpawn(true);
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    addToDamageList("Splice");
                    setSpliceSpawn(true);
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    addToDamageList("Balloon");
                    setBalloonSpawn(true);
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    addToDamageList("Palm");
                    setPalmSpawn(true);
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    addToDamageList("Nest");
                    setNestSpawn(true);
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    addToDamageList("Oak");
                    setOakSpawn(true);
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    addToDamageList("Kite");
                    setKiteSpawn(true);
                    n++;
                }
                else if (tempEquip == 10 && !tempArray.Contains("Pole"))
                {
                    setPoleDamage(tempInt);
                    tempArray.Add("Pole");
                    addToDamageList("Pole");
                    addToDamageList(tempSev.ToString());
                    n++;
                }
            }
        }
    }

    //randomPotheadDcswitch();
    public void randomPotheadDcswitch()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        while (n < getNumberOfDamagedEquip())
        {
            //start:
            int tempEquipType = Random.Range(0, 3);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Pothead"))
            {
                setPothead(tempSev);
                tempArray.Add("Pothead");
                addToDamageList("Pothead");
                addToDamageList(tempSev.ToString());
                n++;
            }
            else if(tempEquipType == 1 && !tempArray.Contains("Disconnectswitch"))
            {
                setDisconnectSwitch(tempSev);
                tempArray.Add("Disconnectswitch");
                addToDamageList("Disconnectswitch");
                addToDamageList(tempSev.ToString());
                n++;
            }
            else if (tempEquipType == 2)
            {
                int tempEquip = Random.Range(2, 11);
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
                    addToDamageList("Fci");
                    setFciSpawn(true);
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    addToDamageList("Splice");
                    setSpliceSpawn(true);
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    addToDamageList("Balloon");
                    setBalloonSpawn(true);
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    addToDamageList("Palm");
                    setPalmSpawn(true);
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    addToDamageList("Nest");
                    setNestSpawn(true);
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    addToDamageList("Oak");
                    setOakSpawn(true);
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    addToDamageList("Kite");
                    setKiteSpawn(true);
                    n++;
                }
                else if (tempEquip == 10 && !tempArray.Contains("Pole"))
                {
                    setPoleDamage(tempInt);
                    tempArray.Add("Pole");
                    addToDamageList("Pole");
                    addToDamageList(tempSev.ToString());
                    n++;
                }
            }
        }
    }
    //randomAutomaticLineSwitch
    public void randomAutomaticLineSwitch()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        while (n < getNumberOfDamagedEquip())
        {
            //start:
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Automaticlineswitch"))
            {
                setAutomaticLineSwitch(tempSev);
                tempArray.Add("Automaticlineswitch");
                addToDamageList("Automaticlineswitch");
                addToDamageList(tempSev.ToString());
                n++;
            }
            else if (tempEquipType == 1)
            {
                int tempEquip = Random.Range(2, 11);
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
                    addToDamageList("Fci");
                    setFciSpawn(true);
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    addToDamageList("Splice");
                    setSpliceSpawn(true);
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    addToDamageList("Balloon");
                    setBalloonSpawn(true);
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    addToDamageList("Palm");
                    setPalmSpawn(true);
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    addToDamageList("Nest");
                    setNestSpawn(true);
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    addToDamageList("Oak");
                    setOakSpawn(true);
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    addToDamageList("Kite");
                    setKiteSpawn(true);
                    n++;
                }
                else if (tempEquip == 10 && !tempArray.Contains("Pole"))
                {
                    setPoleDamage(tempInt);
                    tempArray.Add("Pole");
                    addToDamageList("Pole");
                    addToDamageList(tempSev.ToString());
                    n++;
                }
            }
        }
    }

    //LightningArrestor()
    public void randomLightningArrestor()
    {
        int n = 0;
        List<string> tempArray = new List<string>();

        while (n < getNumberOfDamagedEquip())
        {
            //start:
            int tempEquipType = Random.Range(0, 2);
            int tempSev = Random.Range(1, 4);
            if (tempEquipType == 0 && !tempArray.Contains("Lightningarrestor"))
            {
                setAutomaticLineSwitch(tempSev);
                tempArray.Add("Lightningarrestor");
                addToDamageList(tempSev.ToString());
                n++;
            }
            else if (tempEquipType == 1)
            {
                int tempEquip = Random.Range(2, 11);
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
                    addToDamageList("Fci");
                    setFciSpawn(true);
                    n++;
                }
                else if (tempEquip == 4 && !tempArray.Contains("Splice"))
                {
                    setSplice(true);
                    tempArray.Add("Splice");
                    addToDamageList("Splice");
                    setSpliceSpawn(true);
                    n++;
                }
                else if (tempEquip == 5 && !tempArray.Contains("Balloon"))
                {
                    setBallon(true);
                    tempArray.Add("Balloon");
                    addToDamageList("Balloon");
                    setBalloonSpawn(true);
                    n++;
                }
                else if (tempEquip == 6 && !tempArray.Contains("Palm"))
                {
                    setPalm(tempInt);
                    tempArray.Add("Palm");
                    addToDamageList("Palm");
                    setPalmSpawn(true);
                    n++;
                }
                else if (tempEquip == 7 && !tempArray.Contains("Nest"))
                {
                    setNest(true);
                    tempArray.Add("Nest");
                    addToDamageList("Nest");
                    setNestSpawn(true);
                    n++;
                }
                else if (tempEquip == 8 && !tempArray.Contains("Oak"))
                {
                    setOak(tempInt);
                    tempArray.Add("Oak");
                    addToDamageList("Oak");
                    setOakSpawn(true);
                    n++;
                }
                else if (tempEquip == 9 && !tempArray.Contains("Kite"))
                {
                    setKite(true);
                    tempArray.Add("Kite");
                    addToDamageList("Kite");
                    setKiteSpawn(true);
                    n++;
                }
                else if (tempEquip == 10 && !tempArray.Contains("Pole"))
                {
                    setPoleDamage(tempInt);
                    tempArray.Add("Pole");
                    addToDamageList("Pole");
                    addToDamageList(tempSev.ToString());
                    n++;
                }
            }
        }
    }

    public void writeList(ArrayList list) {
        foreach (int i in list) {
            Debug.Log(i);
        }
    }
}
