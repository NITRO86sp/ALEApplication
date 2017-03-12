using System;
using System.Windows.Forms;
using alwfx.UI.Infrastructure;

namespace alwfx.UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Override application module with Ninject for dependency injection
            CompositionRoot.Wire(new ApplicationModule());

            //Next line disabled so progress bars are customized.
            //Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Run form and inject arguments from bindings defined in application module
            Application.Run(CompositionRoot.Resolve<Form1>());
        }
    }
}
