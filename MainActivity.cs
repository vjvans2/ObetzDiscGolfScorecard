﻿using Android.App;
using Android.Widget;
using Android.OS;
//
using System;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Graphics;

namespace ObetzDiscGolfScorecard
{
    [Activity(Label = "ObetzDiscGolfScorecard", MainLauncher = true, ScreenOrientation = ScreenOrientation.Landscape)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);
            base.OnCreate(savedInstanceState);            
            SetContentView(Resource.Layout.Main);            

            CalcDistanceFrontNine();
            CalcDistanceBackNine();           

            Button btnRecalculate = FindViewById<Button>(Resource.Id.btnRecalculate);
            btnRecalculate.Click += BtnRecalculate_Click;
        }

        private void BtnRecalculate_Click(object sender, EventArgs e)
        {
            CalcFrontNineScore();
            CalcBackNineScore();
            CalcFinalScore();
        }

        protected void CalcDistanceFrontNine()
        {
            var distanceHole1 = FindViewById<TextView>(Resource.Id.txtDistanceHole1);
            var distanceHole2 = FindViewById<TextView>(Resource.Id.txtDistanceHole2);
            var distanceHole3 = FindViewById<TextView>(Resource.Id.txtDistanceHole3);
            var distanceHole4 = FindViewById<TextView>(Resource.Id.txtDistanceHole4);
            var distanceHole5 = FindViewById<TextView>(Resource.Id.txtDistanceHole5);
            var distanceHole6 = FindViewById<TextView>(Resource.Id.txtDistanceHole6);
            var distanceHole7 = FindViewById<TextView>(Resource.Id.txtDistanceHole7);
            var distanceHole8 = FindViewById<TextView>(Resource.Id.txtDistanceHole8);
            var distanceHole9 = FindViewById<TextView>(Resource.Id.txtDistanceHole9);
            var distanceFrontNine = FindViewById<TextView>(Resource.Id.txtDistanceFrontNine);
            var sumf =
                Convert.ToInt32(distanceHole1.Text) +
                Convert.ToInt32(distanceHole2.Text) +
                Convert.ToInt32(distanceHole3.Text) +
                Convert.ToInt32(distanceHole4.Text) +
                Convert.ToInt32(distanceHole5.Text) +
                Convert.ToInt32(distanceHole6.Text) +
                Convert.ToInt32(distanceHole7.Text) +
                Convert.ToInt32(distanceHole8.Text) +
                Convert.ToInt32(distanceHole9.Text);

            distanceFrontNine.Text = sumf.ToString();
        }
        protected void CalcDistanceBackNine()
        {
            var distanceHole10 = FindViewById<TextView>(Resource.Id.txtDistanceHole10);
            var distanceHole11 = FindViewById<TextView>(Resource.Id.txtDistanceHole11);
            var distanceHole12 = FindViewById<TextView>(Resource.Id.txtDistanceHole12);
            var distanceHole13 = FindViewById<TextView>(Resource.Id.txtDistanceHole13);
            var distanceHole14 = FindViewById<TextView>(Resource.Id.txtDistanceHole14);
            var distanceHole15 = FindViewById<TextView>(Resource.Id.txtDistanceHole15);
            var distanceHole16 = FindViewById<TextView>(Resource.Id.txtDistanceHole16);
            var distanceHole17 = FindViewById<TextView>(Resource.Id.txtDistanceHole17);
            var distanceHole18 = FindViewById<TextView>(Resource.Id.txtDistanceHole18);
            var distanceBackNine = FindViewById<TextView>(Resource.Id.txtDistanceBackNine);
            var sumb =
                Convert.ToInt32(distanceHole10.Text) +
                Convert.ToInt32(distanceHole11.Text) +
                Convert.ToInt32(distanceHole12.Text) +
                Convert.ToInt32(distanceHole13.Text) +
                Convert.ToInt32(distanceHole14.Text) +
                Convert.ToInt32(distanceHole15.Text) +
                Convert.ToInt32(distanceHole16.Text) +
                Convert.ToInt32(distanceHole17.Text) +
                Convert.ToInt32(distanceHole18.Text);

            distanceBackNine.Text = sumb.ToString();
        }

        private static void ParChecker(EditText yourScore, int holeScore, int holePar)
        {
            if (holeScore > holePar)
            {
                yourScore.SetTextColor(Color.ParseColor("#ff0000"));
            }
            if (holeScore < holePar)
            {
                yourScore.SetTextColor(Color.ParseColor("#00ff00"));
            }
            if (holeScore == holePar)
            {
                yourScore.SetTextColor(Color.ParseColor("#33b5e5"));
            }
            if (holeScore == 0)
            {
                yourScore.SetTextColor(Color.ParseColor("#33b5e5"));
            }
        }

        protected void CalcFrontNineScore()
        {
            var score1 = FindViewById<EditText>(Resource.Id.txtScoreHole1);
            var score2 = FindViewById<EditText>(Resource.Id.txtScoreHole2);
            var score3 = FindViewById<EditText>(Resource.Id.txtScoreHole3);
            var score4 = FindViewById<EditText>(Resource.Id.txtScoreHole4);
            var score5 = FindViewById<EditText>(Resource.Id.txtScoreHole5);
            var score6 = FindViewById<EditText>(Resource.Id.txtScoreHole6);
            var score7 = FindViewById<EditText>(Resource.Id.txtScoreHole7);
            var score8 = FindViewById<EditText>(Resource.Id.txtScoreHole8);
            var score9 = FindViewById<EditText>(Resource.Id.txtScoreHole9);

            int score1x = Convert.ToInt32(score1.Text);
            int score2x = Convert.ToInt32(score2.Text);
            int score3x = Convert.ToInt32(score3.Text);
            int score4x = Convert.ToInt32(score4.Text);
            int score5x = Convert.ToInt32(score5.Text);
            int score6x = Convert.ToInt32(score6.Text);
            int score7x = Convert.ToInt32(score7.Text);
            int score8x = Convert.ToInt32(score8.Text);
            int score9x = Convert.ToInt32(score9.Text);

            var par1 = FindViewById<TextView>(Resource.Id.txtParLabelHole1);
            var par2 = FindViewById<TextView>(Resource.Id.txtParLabelHole2);
            var par3 = FindViewById<TextView>(Resource.Id.txtParLabelHole3);
            var par4 = FindViewById<TextView>(Resource.Id.txtParLabelHole4);
            var par5 = FindViewById<TextView>(Resource.Id.txtParLabelHole5);
            var par6 = FindViewById<TextView>(Resource.Id.txtParLabelHole6);
            var par7 = FindViewById<TextView>(Resource.Id.txtParLabelHole7);
            var par8 = FindViewById<TextView>(Resource.Id.txtParLabelHole8);
            var par9 = FindViewById<TextView>(Resource.Id.txtParLabelHole9);

            int par1x = Convert.ToInt32(par1.Text);
            int par2x = Convert.ToInt32(par2.Text);
            int par3x = Convert.ToInt32(par3.Text);
            int par4x = Convert.ToInt32(par4.Text);
            int par5x = Convert.ToInt32(par5.Text);
            int par6x = Convert.ToInt32(par6.Text);
            int par7x = Convert.ToInt32(par7.Text);
            int par8x = Convert.ToInt32(par8.Text);
            int par9x = Convert.ToInt32(par9.Text);


            ParChecker(score1, score1x, par1x);
            ParChecker(score2, score2x, par2x);
            ParChecker(score3, score3x, par3x);
            ParChecker(score4, score4x, par4x);
            ParChecker(score5, score5x, par5x);
            ParChecker(score6, score6x, par6x);
            ParChecker(score7, score7x, par7x);
            ParChecker(score8, score8x, par8x);
            ParChecker(score9, score9x, par9x);

            /////////////////////////////////////

            var scoreFrontNine = FindViewById<TextView>(Resource.Id.txtScoreFrontNine);
            int sumf = score1x + score2x + score3x + score4x +
                score5x + score6x + score7x + score8x + score9x;   

            if (sumf > 33)
            {
                scoreFrontNine.SetTextColor(Color.ParseColor("#ff0000"));
            }
            if (sumf < 33)
            {
                scoreFrontNine.SetTextColor(Color.ParseColor("#00ff00"));
            }
            if (sumf == 33)
            {
                scoreFrontNine.SetTextColor(Color.ParseColor("#33b5e5"));
            }
            scoreFrontNine.Text = sumf.ToString();

            /////////////////////////////////////

            var frontSTPTextbox = FindViewById<TextView>(Resource.Id.txtFrontSTP);
            int frontSTPDiff = sumf - 33;  //checking against par
            if (frontSTPDiff > 0)
            {
                frontSTPTextbox.SetTextColor(Color.ParseColor("#ff0000"));
                frontSTPTextbox.Text = "+" + frontSTPDiff;
            }
            if (frontSTPDiff < 0)
            {
                frontSTPTextbox.SetTextColor(Color.ParseColor("#00ff00"));
                frontSTPTextbox.Text = "-" + frontSTPDiff;
            }
            if (frontSTPDiff == 0)
            {
                frontSTPTextbox.SetTextColor(Color.ParseColor("#33b5e5"));
                frontSTPTextbox.Text = "E";
            }
        }

        protected void CalcBackNineScore()
        {
            var score10 = FindViewById<EditText>(Resource.Id.txtScoreHole10);
            var score11 = FindViewById<EditText>(Resource.Id.txtScoreHole11);
            var score12 = FindViewById<EditText>(Resource.Id.txtScoreHole12);
            var score13 = FindViewById<EditText>(Resource.Id.txtScoreHole13);
            var score14 = FindViewById<EditText>(Resource.Id.txtScoreHole14);
            var score15 = FindViewById<EditText>(Resource.Id.txtScoreHole15);
            var score16 = FindViewById<EditText>(Resource.Id.txtScoreHole16);
            var score17 = FindViewById<EditText>(Resource.Id.txtScoreHole17);
            var score18 = FindViewById<EditText>(Resource.Id.txtScoreHole18);

            int score10x = Convert.ToInt32(score10.Text);
            int score11x = Convert.ToInt32(score11.Text);
            int score12x = Convert.ToInt32(score12.Text);
            int score13x = Convert.ToInt32(score13.Text);
            int score14x = Convert.ToInt32(score14.Text);
            int score15x = Convert.ToInt32(score15.Text);
            int score16x = Convert.ToInt32(score16.Text);
            int score17x = Convert.ToInt32(score17.Text);
            int score18x = Convert.ToInt32(score18.Text);

            var par10 = FindViewById<TextView>(Resource.Id.txtParLabelHole10);
            var par11 = FindViewById<TextView>(Resource.Id.txtParLabelHole11);
            var par12 = FindViewById<TextView>(Resource.Id.txtParLabelHole12);
            var par13 = FindViewById<TextView>(Resource.Id.txtParLabelHole13);
            var par14 = FindViewById<TextView>(Resource.Id.txtParLabelHole14);
            var par15 = FindViewById<TextView>(Resource.Id.txtParLabelHole15);
            var par16 = FindViewById<TextView>(Resource.Id.txtParLabelHole16);
            var par17 = FindViewById<TextView>(Resource.Id.txtParLabelHole17);
            var par18 = FindViewById<TextView>(Resource.Id.txtParLabelHole18);

            int par10x = Convert.ToInt32(par10.Text);
            int par11x = Convert.ToInt32(par11.Text);
            int par12x = Convert.ToInt32(par12.Text);
            int par13x = Convert.ToInt32(par13.Text);
            int par14x = Convert.ToInt32(par14.Text);
            int par15x = Convert.ToInt32(par15.Text);
            int par16x = Convert.ToInt32(par16.Text);
            int par17x = Convert.ToInt32(par17.Text);
            int par18x = Convert.ToInt32(par18.Text);


            ParChecker(score10, score10x, par10x);
            ParChecker(score11, score11x, par11x);
            ParChecker(score12, score12x, par12x);
            ParChecker(score13, score13x, par13x);
            ParChecker(score14, score14x, par14x);
            ParChecker(score15, score15x, par15x);
            ParChecker(score16, score16x, par16x);
            ParChecker(score17, score17x, par17x);
            ParChecker(score18, score18x, par18x);

            /////////////////////////////////////

            var scoreBackNine = FindViewById<TextView>(Resource.Id.txtScoreBackNine);
            int sumb = score10x + score11x + score12x + score13x +
                score14x + score15x + score16x + score17x + score18x;

            if (sumb > 39)
            {
                scoreBackNine.SetTextColor(Color.ParseColor("#ff0000"));
            }
            if (sumb < 39)
            {
                scoreBackNine.SetTextColor(Color.ParseColor("#00ff00"));
            }
            if (sumb == 39)
            {
                scoreBackNine.SetTextColor(Color.ParseColor("#33b5e5"));
            }
            scoreBackNine.Text = sumb.ToString();

            /////////////////////////////////////

            var backSTPTextbox = FindViewById<TextView>(Resource.Id.txtBackSTP);
            int backSTPDiff = sumb - 39;  //checking against par
            if (backSTPDiff > 0)
            {
                backSTPTextbox.SetTextColor(Color.ParseColor("#ff0000"));
                backSTPTextbox.Text = "+" + backSTPDiff;
            }
            if (backSTPDiff < 0)
            {
                backSTPTextbox.SetTextColor(Color.ParseColor("#00ff00"));
                backSTPTextbox.Text = "-" + backSTPDiff;
            }
            if (backSTPDiff == 0)
            {
                backSTPTextbox.SetTextColor(Color.ParseColor("#33b5e5"));
                backSTPTextbox.Text = "E";
            }
        } 

        protected void CalcFinalScore()
        {
            var scoreFrontNineTxt = FindViewById<TextView>(Resource.Id.txtScoreFrontNine);
            int frontNineScore = Convert.ToInt32(scoreFrontNineTxt.Text);
            var scoreBackNineTxt = FindViewById<TextView>(Resource.Id.txtScoreBackNine);
            int backNineScore = Convert.ToInt32(scoreBackNineTxt.Text);

            var scoreFinalScoreTxt = FindViewById<TextView>(Resource.Id.txtFinalScore);

            int finalScore = frontNineScore + backNineScore;
            scoreFinalScoreTxt.Text = finalScore.ToString();

            /// stp ///

            var finalSTPTextbox = FindViewById<TextView>(Resource.Id.txtFinalSTP);
            int finalSTPDiff = finalScore - 72;
            if (finalSTPDiff > 0)
            {
                finalSTPTextbox.SetTextColor(Color.ParseColor("#ff0000"));
                finalSTPTextbox.Text = "+" + finalSTPDiff;
            }
            if (finalSTPDiff < 0)
            {
                finalSTPTextbox.SetTextColor(Color.ParseColor("#00ff00"));
                finalSTPTextbox.Text = "-" + finalSTPDiff;
            }
            if (finalSTPDiff == 0)
            {
                finalSTPTextbox.SetTextColor(Color.ParseColor("#33b5e5"));
                finalSTPTextbox.Text = "E";
            }




        }

    } 

}
