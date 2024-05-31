using System;
using System.Reflection;
using System.Windows;
using System.DirectoryServices.AccountManagement;



// TODO: Replace the following version attributes by creating AssemblyInfo.cs. You can do this in the properties of the Visual Studio project.
[assembly: AssemblyVersion("1.0.0.1")]
[assembly: AssemblyFileVersion("1.0.0.1")]
[assembly: AssemblyInformationalVersion("1.0")]

// TODO: Uncomment the following line if the script requires write access.
//[assembly: ESAPIScript(IsWriteable = false)]

namespace AccessCaseDatabase
{
    class Program
    {
        [STAThread]
        static void Main()
        {

            try
            {
                string domain = "YOUR_DOMAIN"; //Kolla att anv�ndaren finns i Varian grupperna
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, domain);
                UserPrincipal user = UserPrincipal.FindByIdentity(ctx, Environment.UserName);

                GroupPrincipal group_VarianAppUsers = GroupPrincipal.FindByIdentity(ctx, ".u.app.VarianApplicationUsers");
                GroupPrincipal group_VarianUsers = GroupPrincipal.FindByIdentity(ctx, ".u.app.VarianUsers");

                if (user != null && user.IsMemberOf(group_VarianAppUsers) && user.IsMemberOf(group_VarianUsers)) //Om anv�ndaren finns i Varian grupperna, godk�nn hans/hennes credentials med l�senord
                {
                    Check_Password.Check_Password Password_Popup = new Check_Password.Check_Password(); //Popup f�r att skriva in l�senordet
                    Password_Popup.ShowDialog();

                    if(Password_Popup.DialogResult == System.Windows.Forms.DialogResult.OK && Password_Popup.pass != null)
                    {
                        bool isUserValid = ctx.ValidateCredentials(Environment.UserName, Password_Popup.pass);
                        Password_Popup.Dispose();

                        if (isUserValid)
                        {
                            Form.MainView MainView = new Form.MainView();
                            MainView.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Fel l�senord", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Du �r inte registerad som Varian anv�ndare", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Fel\r\n" + e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
