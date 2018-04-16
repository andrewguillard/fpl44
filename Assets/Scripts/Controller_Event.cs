namespace VRTK.Examples
{
    using UnityEngine;

    public class Controller_Event : MonoBehaviour
    {
        public GameObject ToolBoxMenu;
        public GameObject Binocular;

        private void Start()
        {
            if (GetComponent<VRTK_ControllerEvents>() == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
                return;
            }

            GetComponent<VRTK_ControllerEvents>().ButtonTwoPressed += new ControllerInteractionEventHandler(DoButtonTopPressed);
            GetComponent<VRTK_ControllerEvents>().ButtonTwoReleased += new ControllerInteractionEventHandler(DoButtonTopReleased);
            GetComponent<VRTK_ControllerEvents>().GripPressed += new ControllerInteractionEventHandler(DoGripPressed);

        }


        private void DoButtonTopPressed(object sender, ControllerInteractionEventArgs e)
        {
            ToolBoxMenu.SetActive(!ToolBoxMenu.activeSelf);
        }

        private void DoGripPressed(object sender, ControllerInteractionEventArgs e)
        {
            Binocular.SetActive(!Binocular.activeSelf);
        }

        private void DoButtonTopReleased(object sender, ControllerInteractionEventArgs e)
        {

        }
    }
}
