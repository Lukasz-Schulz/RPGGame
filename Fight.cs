using System;
using System.Threading;
using System.Windows;

namespace Gra
{
    public class Fight  //handles the fight processes
    {
        FightScreen _FightScreen;
        AttackChooser AttackChooser = new AttackChooser();

        public Fight(FightScreen fightScreen)
        {
            _FightScreen = fightScreen;
        }

        public void Turn(Character attacker, Character attacked) //method used to proceed a random attack
        {
            _FightScreen.IsEnabled = false;//blocks ability to click buttons more times while attack is being processed
            Attack attack = AttackChooser.ChooseAttack(attacker);//draws an attack
            attack.Proceed(attacked);
            _FightScreen.lblBattle.Text += attack.Message;//attack's message is being put on archive box on the fightscreen
            _FightScreen.UpdateScreen();
            _FightScreen.IsEnabled = true;//unlock the screen
            WinCheck(attacker, attacked);
        }

        public void Turn(Character attacker, Character attacked, int attackNumber) //metoda wywoływana, aby wywołać kontratak 
                                                                                    //z wybranym atakiem
        {
            _FightScreen.IsEnabled = false;//blocks ability to click buttons more times while attack is being processed
            Attack attack = AttackChooser.ChooseAttack(attacker, attackNumber);//chooses attack by its number
            attack.Proceed(attacked);
            _FightScreen.lblBattle.Text += attack.Message;//attack's message is being put on archive box on the fightscreen
            _FightScreen.UpdateScreen(); 
            _FightScreen.IsEnabled = true;//unlock the screen
            WinCheck(attacker, attacked);
        }

        private bool CheckIfCharacterIsAlive(Character attacked) //determines if character has any hp left
        {
            if (attacked.Health <= 0)
                return false;
            else return true;
        }

        private void WinCheck(Character attacker, Character attacked) //checks if any of fighters is dead yet
        {
            if (CheckIfCharacterIsAlive(attacked) == false)//if the attacked character is dead it checks if it was a hero character
            {
                if (attacker == _FightScreen.Hero)
                {                                       
                    _FightScreen.Hero.GainExp(attacked);
                    MessageBox.Show("You win!");
                }
                else   
                {
                    MessageBox.Show("You lose!");
                }
                _FightScreen.MainWindow.IsEnabled = true;
                _FightScreen.Close();
            }
        }
    }
}
