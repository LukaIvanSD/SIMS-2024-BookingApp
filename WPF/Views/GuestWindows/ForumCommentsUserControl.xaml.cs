﻿using BookingApp.Domain.Models;
using BookingApp.WPF.ViewModels;
using BookingApp.WPF.ViewModels.GuestViewModels;
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

namespace BookingApp.WPF.Views.GuestWindows
{
    /// <summary>
    /// Interaction logic for ForumCommentsUserControl.xaml
    /// </summary>
    public partial class ForumCommentsUserControl : UserControl
    {
    
        public ForumCommentsUserControl(User user, ForumViewModel selectedForum)
        {
            InitializeComponent();
            DataContext = new ForumReadMoreCommentsViewModel(user, selectedForum);
        }
    }
}
