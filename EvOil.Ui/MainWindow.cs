using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using EvOil.Domain.Models;
using EvOil.Business;
using EvOil.Persistence;

namespace EvOil.Ui;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly OrganizerService _organizerService;
    public MainWindow()
    {
        var db = EvOilDatabaseContextfactory.Create();
        _organizerService = new OrganizerService(db);
    }
    private void GetUser(object sender, RoutedEventArgs e)
    {
        var username = this.sendUsername.Text;
        try
        {
            var user = _organizerService.GetUser(username);
            this.sendUsername.Text = "";
            this.messageBox.Text = user.Username.ToString();
        }
        catch
        {
            this.sendUsername.Text = "";
            this.messageBox.Text = "Failed to get user";
            return;
        }
    }

    private void AddUser(object sender, RoutedEventArgs e)
    {
        var username = this.setUsername.Text;
        var password = this.setPassword.Text;

        if (this.setUsername.Text == string.Empty || this.setPassword.Text == string.Empty)
        {
            this.messageBox.Text = "Failed to create user! Enter username and password!";
            return;
        }

        try
        {
            _organizerService.AddUser(username, password);
        }
        catch
        {
            this.setUsername.Text = "";
            this.setPassword.Text = "";
            this.messageBox.Text = "Failed to create user! Enter username and password!";
            return;
        }

        this.setUsername.Text = "";
        this.setPassword.Text = "";
        this.messageBox.Text = "User created!";
    }

    private void AddOil(object sender, RoutedEventArgs e)
    {

        var codeName = this.setCodeName.Text;
        var fullName = this.setFullName.Text;

        if (this.setCodeName.Text == string.Empty || this.setFullName.Text == string.Empty)
        {
            this.messageBox.Text = "Failed to add oil! Enter code name and full name";
            return;
        }

        try
        {
            _organizerService.AddOil(codeName, fullName);
        }
        catch
        {
            this.setCodeName.Text = "";
            this.setFullName.Text = "";
            this.messageBox.Text = "Failed to add oil";
            return;
        }

        this.setCodeName.Text = "";
        this.setFullName.Text = "";
        this.messageBox.Text = "Oil added! Enter code name and full name";
    }
}
