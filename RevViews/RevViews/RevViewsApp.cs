using System;
using System.IO;


namespace RevViews
{
    internal class RevViewsApp
    {
        public static void Main(string[] args)
        {
            LittleWorker.ToJSON();
            Views.MainMenuView();
        }
    }
}