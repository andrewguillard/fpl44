namespace VRTK.Examples
{
    using UnityEngine;

    public class Controller_Event : MonoBehaviour
    {
        public GameObject ToolBoxMenu;
        private void Start()
        {
            if (GetComponent<VRTK_ControllerEvents>() == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
                return;
            }
            GetComponent<VRTK_ControllerEvents>().ButtonTwoPressed += new ControllerInteractionEventHandler(DoButtonTopPressed);
            GetComponent<VRTK_ControllerEvents>().ButtonTwoReleased += new ControllerInteractionEventHandler(DoButtonTopReleased);


        }


        private void DoButtonTopPressed(object sender, ControllerInteractionEventArgs e)
        {
            //GameObject ToolBox = GameObject.Find("MenuCanvas");
            print("\n\nToolbox is showed = " + ToolBoxMenu.activeSelf);
            ToolBoxMenu.SetActive(!ToolBoxMenu.activeSelf);
            print("Toolbox now is " + ToolBoxMenu.activeSelf);
        }

        private void DoButtonTopReleased(object sender, ControllerInteractionEventArgs e)
        {
            print("click top button");
        }
    }
}
