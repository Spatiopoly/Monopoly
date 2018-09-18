﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Monopoly.Models;

namespace Monopoly.Views
{
    public partial class frmGame : Form
    {
        Game game;

        public frmGame(Game game)
        {
            InitializeComponent();
            this.game = game;
            gameView.Game = game;
        }
    }
}
