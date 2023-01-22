using System;


namespace UI_Layer
{
    internal interface IMenu
    {
        /// <summary>
        /// Will display the menu and user choices in the terminal
        /// </summary>
        void Display();
        /// <summary>
        /// Will record the user's choice 
        /// </summary>
        /// <returns></returns>
        string UserOption();
    }
}
