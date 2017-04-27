﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.Model;
using BattleShip;
using System.Drawing;
using System.Windows.Forms;

namespace BattleShip.Controller
{
    class PlayerController
    {
        public static List<Ship> ships;
        public Ship selected;
       
        public PlayerController()
        {
            ships = new List<Ship>();
            ships.Add(new Ship(1, Color.Blue, new Point { X = 0, Y = 2 }, Ship.View.HORIZONTAL));
            ships.Add(new Ship(1, Color.Blue, new Point { X = 0, Y = 6 }, Ship.View.VERTICAL));
            ships.Add(new Ship(1, Color.Blue, new Point { X = 11, Y = 2 }, Ship.View.HORIZONTAL));
            ships.Add(new Ship(2, Color.Blue, new Point { X = 2, Y = 1 }, Ship.View.VERTICAL));
            ships.Add(new Ship(2, Color.Blue, new Point { X = 4, Y = 8 }, Ship.View.HORIZONTAL));
            ships.Add(new Ship(3, Color.Blue, new Point { X = 5, Y = 7 }, Ship.View.VERTICAL));
            ships.Add(new Ship(3, Color.Blue, new Point { X = 8, Y = 1 }, Ship.View.HORIZONTAL));
            ships.Add(new Ship(4, Color.Blue, new Point { X = 8, Y = 9 }, Ship.View.VERTICAL));
            ships.Add(new Ship(5, Color.Blue, new Point { X = 6, Y = 5 }, Ship.View.VERTICAL));
            selected = null;
        }          

        public void SetGridView(DataGridView grid)
        {
            grid.Rows.Clear();
            grid.RowCount = 12;
            grid.ColumnCount = 12;;
            for (int i = 0; i < 12; i++)
            {
                grid.Rows[i].Height = 30;
                grid.Columns[i].Width = 30;
            }
            grid.ClearSelection();
        }

        public void ShowShips(DataGridView grid)
        {
            ships.ForEach(ship => ship.ShowShip(grid));
        }

        public bool SearchShip()
        {
            return ships.FindAll(ship => ship.ExistShip(selected)).Count > 1;
        }

        public void Select(Point Position)
        {
            selected = ships.FirstOrDefault(ship => ship.ExistPosition(Position));
        }

        public void UnSelect()
        {
            selected = null;
        }

        public void DisableCells(DataGridView grid)
        {
            grid.Enabled = false;
            ships.ForEach(ship => ship.Color = Color.Gray);
            /*grid.DefaultCellStyle.BackColor = Color.LightGray;
            grid.DefaultCellStyle.ForeColor = Color.DarkGray;*/
        }

        public void EnableCells(DataGridView grid)
        {
            grid.Enabled = true;            
            ships.ForEach(ship => ship.Color = Color.Blue);
        }

        public void Shoot(DataGridView grid)
        {
            Random random = new Random();
            int row = random.Next(0, 12);
            int column = random.Next(0, 12);
            Point position = new Point { X = row, Y = column };
            foreach (Ship ship in ships)
            {
                if (ship.ExistPosition(position))
                {
                    ship.ShootPosition(position);
                    if(ship.Destroyed())
                    {
                        MessageBox.Show("Destroyed");
                    }
                }
                else
                {
                    grid.Rows[row].Cells[column].Style.BackColor = Color.LightBlue;
                }
            }
        }
    }
}
