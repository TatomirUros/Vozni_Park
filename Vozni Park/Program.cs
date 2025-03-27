using Microsoft.Extensions.DependencyInjection;
using Vozni_Park.Context;
using Vozni_Park.Repository;
using Vozni_Park.Repository.Interfaces;
using Vozni_Park.Services;
using Vozni_Park.Services.Interfaces;
using Vozni_Park.View;

namespace Vozni_Park
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}