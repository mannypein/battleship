﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using BattleShip.Model;
using System.Windows.Forms;

namespace BattleShip.Controller
{
    [Serializable]
    class ComputerController : Player
    {
        public ComputerController(List<GameMode> gameModes) : base(gameModes)
        {
            isPlayer = false;
            Random();
        }

        public bool Shoot(Point position, DataGridView grid)
        {
            grid.Enabled = true;
            if(positions.Contains(position))
            {
                positions.Remove(position);
                foreach (Ship ship in ships)
                {
                    if (ship.ExistPosition(position))
                    {
                        ship.ShootPosition(position);
                        if (ship.Destroyed())
                        {
                            selected = ship;
                            RemoveDeadShip();
                            selected = null;
                            Game.score += 500;
                        }
                        else
                        {
                            RemoveDeadPoints(position);
                        }                       
                        System.Media.SoundPlayer sound2 = new System.Media.SoundPlayer(Properties.Resources.explosion);
                        if (!Game.MuteClicked)
                        {
                            sound2.Play();
                        }
                        else
                        {
                            sound2.Stop();
                        }
                        
                        Game.score += 100;
                        
                        grid.Rows[position.X].Cells[position.Y].Style.BackColor = Color.Red;
                        ShowShips(grid);
                        grid.Enabled = false;
                        return false;
                    }
                }
                DataGridViewImageCell imgCell = new DataGridViewImageCell();
                imgCell.Value = Properties.Resources.dotImage;

                // if FOFB do this instead of line above
                //string file = string.Format("_{0}", GetShipCount(position));
                //imgCell.Value = Properties.Resources.ResourceManager.GetObject(file);

                missedPositions.Add(position);
                grid.Rows[position.X].Cells[position.Y] = imgCell;

                grid.Enabled = false;
                System.Media.SoundPlayer sound = new System.Media.SoundPlayer(Properties.Resources.miss);
                if (!Game.MuteClicked)
                {
                    sound.Play();
                }else
                {
                    sound.Stop();
                }
                return true;
            }
            return false;
        }

        public int GetShipCount(Point position)
        {
            int count = 0;
            foreach(Ship ship in ships)
            {
                if(ship.Cells[0].Positon.X == position.X || ship.Cells[0].Positon.Y == position.Y)
                    count++;
            }

            return count;
        }


        public void ShowShips(DataGridView grid)
        {
            //ships.ForEach(ship => ship.enemyShipsDraw(grid));
            ships.ForEach(ship => ship.enemyShipsDrawFOFB(grid, ships));
        }

        public void ShowEndShips(DataGridView grid)
        {
            ships.ForEach(ship => ship.ShowShip(grid));
        }

    }
}