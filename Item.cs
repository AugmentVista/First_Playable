﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_Playable
{
    internal class Item
    {
        Player player;
        Buffer buffer;

        int xPos;
        int yPos;
        public bool Collected = false;

        public enum ItemType
        {
            health,
            teleport,
            buff
        }
        public ItemType itemType;

        public Item(Player player, Buffer buffer)
        {
            this.player = player;
            this.buffer = player.buffer;
            DetermineType();
        }

        void DetermineType()
        {
            int randomInt = Settings.random.Next(6);
            switch (randomInt)
            {
                case 0:
                case 1:
                case 2:
                    itemType = ItemType.health;
                    break;
                case 3:
                case 4:
                    itemType = ItemType.buff;
                    break;
                case 5:
                    itemType = ItemType.teleport;
                    break;
            }
        }

        public int[] GetItemXY()
        {
            int[] pos = new int[2];
            pos[0] = xPos;
            pos[1] = yPos;
            return pos;
        }
        public void SetItemXY(int x, int y)
        {
            xPos = x;
            yPos = y;
        }
        public void DrawItem()
        {
            if (!Collected)
            {
                char charToDraw = ' ';

                switch(itemType)
                {
                    case ItemType.health:
                        charToDraw = Settings.HealthChar;
                        break;
                    case ItemType.teleport:
                        charToDraw = Settings.TeleportChar;
                        break;
                    case ItemType.buff:
                        charToDraw = Settings.BuffChar;
                        break;
                }

                buffer.secondBuffer[yPos, xPos] = charToDraw;
            }
        }
        public void SetPlayer(Player player)
        {
            this.player = player;
        }
        public void RemoveItem(Item item)
        {
            ItemManager.AllItemsList.Remove(this);
        }
        public void UseItem()
        {
            Console.WriteLine(itemType);
            GetItemXY();
            if (xPos == Player.playerRow && yPos == Player.playerCol) 
            {
                switch(itemType)
                {
                    case ItemType.teleport:
                        player.Teleport();
                        break;
                    case ItemType.health:
                        player.Heal(20);
                        break;
                    case ItemType.buff:
                        player.Buff();
                        break;
                }
                Collected = true;
                buffer.secondBuffer[yPos, xPos] = ' ';
                RemoveItem(this);
            }
        }
    }
}
